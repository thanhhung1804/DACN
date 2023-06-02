using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class formBusiness : Form
    {
        #region Form Move (Keep and move form on screen)
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Form Round Corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        private AreaDTO currentSelectedArea;
        private TableDTO currentSelectedTable;
        private UserDTO currentSelectedUser;

        private Button draggedButton;

        public formBusiness(UserDTO user)
        {
            InitializeComponent();
            currentSelectedArea = null;
            currentSelectedTable = null;
            currentSelectedUser = user;
        }

        private void formBusiness_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            LoadArea();
            LoadTable();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            picAvatar.Image = Properties.Resources.Avatar;
            txbFullName.Text = currentSelectedUser.Name;
            txbAddress.Text = currentSelectedUser.Address;
            txbBirthday.Text = currentSelectedUser.Birthday.Date.ToString("dd-MM-yyyy");
            txbCitizenId.Text = currentSelectedUser.CitizenId;
            txbPhone.Text = currentSelectedUser.Phone;
            txbRole.Text = currentSelectedUser.RoleName;
        }

        private void formBusiness_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
        }

        private void LoadArea()
        {
            List<AreaDTO> areas = new AreaDAO().GetAll();
            AreaDTO allArea = new AreaDTO(name: "All");
            areas.Add(allArea);

            fpnlArea.Controls.Clear();
            foreach (AreaDTO area in areas)
            {
                Button btnArea = new Button();
                btnArea.Text = area.Name;
                btnArea.Size = new Size(100, 50);
                btnArea.FlatStyle = FlatStyle.Flat;
                btnArea.FlatAppearance.BorderSize = 0;
                btnArea.Font = new Font("Arial", 12, FontStyle.Bold);
                btnArea.Cursor = Cursors.Hand;
                btnArea.Tag = area;
                btnArea.Click += btnArea_Click;
                fpnlArea.Controls.Add(btnArea);
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            currentSelectedArea = (sender as Button).Tag as AreaDTO;
            LoadTable();
        }

        private void LoadTable()
        {
            Guid areaId = Guid.Empty;
            if (currentSelectedArea != null)
            {
                areaId = currentSelectedArea.AreaId;
            }
            List<TableDTO> tables = new TableDAO().GetAll(areaId);

            fpnlTable.Controls.Clear();
            foreach (TableDTO table in tables)
            {
                Button btnTable = new Button();
                btnTable.Text = table.DisplayName;
                btnTable.Size = new Size(150, 150);
                btnTable.FlatStyle = FlatStyle.Flat;
                btnTable.FlatAppearance.BorderSize = 0;
                btnTable.Font = new Font("Arial", 12, FontStyle.Bold);
                btnTable.Cursor = Cursors.Hand;
                if (table.Status == TableStatus.Ready)
                {
                    btnTable.BackColor = Color.FromArgb(140, 209, 255);
                    btnTable.ForeColor = Color.Black;
                }
                else if (table.Status == TableStatus.Using)
                {
                    btnTable.BackColor = Color.DarkGreen;
                    btnTable.ForeColor = Color.White;
                }
                else if (table.Status == TableStatus.Pending)
                {
                    btnTable.BackColor = Color.Orange;
                    btnTable.ForeColor = Color.Black;
                }
                btnTable.Tag = table;
                btnTable.Click += btnTable_Click;

                btnTable.AllowDrop = true;
                btnTable.MouseDown += btnTable_MouseDown;
                btnTable.MouseMove += btnTable_MouseMove;
                btnTable.DragEnter += btnTable_DragEnter;
                btnTable.DragOver += btnTable_DragOver;
                btnTable.DragDrop += btnTable_DragDrop;
                fpnlTable.Controls.Add(btnTable);
            }
            LoadFooter();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            currentSelectedTable = (sender as Button).Tag as TableDTO;
            txbSelectingTable.Text = string.Format("Selecting {0}", currentSelectedTable.Name);
            if (currentSelectedTable.Status == TableStatus.Pending)
            {
                btnLockTable.Text = "Unlock";
            }
            else
            {
                btnLockTable.Text = "Lock";
            }
        }

        private void btnTable_MouseDown(object sender, MouseEventArgs e)
        {
            btnTable_Click(sender, new EventArgs());
            Button originButton = (Button)sender;
            TableDTO originTable = originButton.Tag as TableDTO;

            if (originTable.Status == TableStatus.Ready || originTable.Status == TableStatus.Pending)
            {
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }
                
            draggedButton = originButton;
            draggedButton.DoDragDrop(draggedButton, DragDropEffects.Move);
        }

        private void btnTable_MouseMove(object sender, MouseEventArgs e)
        {
            Button originButton = (Button)sender;
            TableDTO originTable = originButton.Tag as TableDTO;

            if (originTable.Status == TableStatus.Ready || originTable.Status == TableStatus.Pending)
            {
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            draggedButton = originButton;
            draggedButton.DoDragDrop(draggedButton, DragDropEffects.Move);
        }

        private void btnTable_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void btnTable_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnTable_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                Button originButton = (Button)e.Data.GetData(typeof(Button));
                TableDTO originTable = originButton.Tag as TableDTO;

                Button targetButton = (Button)sender;
                TableDTO targetTable = targetButton.Tag as TableDTO;

                if (originTable == targetTable)
                {
                    return;
                }

                switch (targetTable.Status)
                {
                    case TableStatus.Ready:
                        MoveTable(originTable, targetTable);
                        break;
                    case TableStatus.Using:
                        MergeTable(originTable, targetTable);
                        break;
                    default: break;
                }
            }
        }

        private void MoveTable(TableDTO originTable, TableDTO targetTable)
        {
            var result = MessageBox.Show(
                text: string.Format("Are you sure you want to move {0} to {1}?", originTable.Name, targetTable.Name), 
                caption: "Confirmation", 
                buttons: MessageBoxButtons.OKCancel, 
                icon: MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                return;
            }

            BillDTO originBill = new BillDAO().GetUnpaidBillByTable(tableId: originTable.TableId);
            new BillDAO().UpdateTableId(billId: originBill.BillId, tableId: targetTable.TableId);
            new TableDAO().ChangeStatus(tableId: originTable.TableId, status: TableStatus.Ready);
            new TableDAO().ChangeStatus(tableId: targetTable.TableId, status: TableStatus.Using);
            LoadTable();
        }

        private void MergeTable(TableDTO originTable, TableDTO targetTable)
        {
            var result = MessageBox.Show(
                text: string.Format("Are you sure you want to merge {0} into {1}?", originTable.Name, targetTable.Name),
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                return;
            }

            BillDTO originBill = new BillDAO().GetUnpaidBillByTable(tableId: originTable.TableId);
            BillDTO targetBill = new BillDAO().GetUnpaidBillByTable(tableId: targetTable.TableId);
            List<BillDetailDTO> originBillDetails = new BillDetailDAO().GetBillDetails(billId: originBill.BillId);
            List<BillDetailDTO> targetBillDetails = new BillDetailDAO().GetBillDetails(billId: targetBill.BillId);
            foreach (BillDetailDTO originItem in originBillDetails)
            {
                BillDetailDTO targetItem = targetBillDetails.Find(item => item.ServiceId == originItem.ServiceId);
                if (targetItem != null)
                {
                    targetItem.Quantity += originItem.Quantity;
                    targetItem.Amount += originItem.Amount;
                }
                else
                {
                    originItem.BillId = targetBill.BillId;
                    targetBillDetails.Add(originItem);
                }
            }
            new BillDetailDAO().DeleteBillDetails(billId: targetBill.BillId);
            float total = 0;
            foreach (BillDetailDTO targetItem in targetBillDetails)
            {
                new BillDetailDAO().CreateBillDetails(billDetail: targetItem);
                total += targetItem.Amount;
            }
            new BillDAO().UpdateTotal(billId: targetBill.BillId, total: total);
            new BillDAO().Delete(billId: originBill.BillId);
            new TableDAO().ChangeStatus(tableId: originTable.TableId, status: TableStatus.Ready);
            LoadTable();
        }

        private void LoadFooter()
        {
            List<TableDTO> tables = new TableDAO().GetAll(areaId: Guid.Empty);
            int pendingTable = 0;
            int usingTable = 0;
            int readyTable = 0;
            foreach (TableDTO table in tables)
            {
                if (table.Status == TableStatus.Pending)
                {
                    pendingTable++;
                }
                else if (table.Status == TableStatus.Using)
                {
                    usingTable++;
                }
                else
                {
                    readyTable++;
                }
            }
            lbTotalTable.Text = string.Format("Total table: {0}", tables.Count.ToString());
            lbPendingTable.Text = string.Format("Pending table: {0}", pendingTable.ToString());
            lbUsingTable.Text = string.Format("Using table: {0}", usingTable.ToString());
            lbReadyTable.Text = string.Format("Ready table: {0}", readyTable.ToString());
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            FormWindowState state = FormWindowState.Normal;
            if (WindowState == FormWindowState.Normal)
            {
                state = FormWindowState.Maximized;
            }
            WindowState = state;
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void picShowAccount_Click(object sender, EventArgs e)
        {
            pnlAccountSideBar.Size = new Size(300, pnlAccountSideBar.Size.Height);
            picShowAccount.Hide();
            picHideAccount.Show();
        }

        private void picHideAccount_Click(object sender, EventArgs e)
        {
            pnlAccountSideBar.Size = new Size(60, pnlAccountSideBar.Size.Height);
            picShowAccount.Show();
            picHideAccount.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            formChangePassword formChangePassword = new formChangePassword();
            formChangePassword.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable == null)
            {
                MessageBox.Show("Please select a table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentSelectedTable.Status == TableStatus.Pending)
            {
                MessageBox.Show("Please unlock table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formOrder formOrder = new formOrder(table: currentSelectedTable, user: currentSelectedUser);
            formOrder.ShowDialog();
            LoadTable();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable == null)
            {
                MessageBox.Show("Please select a table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentSelectedTable.Status == TableStatus.Pending)
            {
                MessageBox.Show("Please unlock table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentSelectedTable.Status == TableStatus.Ready)
            {
                MessageBox.Show("Can not pay for empty table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formCheckOut formCheckOut = new formCheckOut(currentSelectedTable, currentSelectedUser);
            formCheckOut.ShowDialog();
            LoadTable();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            formManage form = new formManage();
            Hide();
            form.ShowDialog();
            Show();
            LoadArea();
            LoadTable();
            LoadUserInfo();
        }

        private void btnLockTable_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable == null)
            {
                MessageBox.Show("Please select a table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentSelectedTable.Status == TableStatus.Using)
            {
                MessageBox.Show("Can not lock a using table", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TableStatus status = TableStatus.Pending;
            if (currentSelectedTable.Status == TableStatus.Pending)
            {
                status = TableStatus.Ready;
            }

            new TableDAO().ChangeStatus(
                tableId: currentSelectedTable.TableId,
                status: status
            );
            currentSelectedTable.Status = status;
            LoadTable();

            if (btnLockTable.Text == "Lock")
            {
                btnLockTable.Text = "UnLock";
            }
            else
            {
                btnLockTable.Text = "Lock";
            }
        }
    }
}
