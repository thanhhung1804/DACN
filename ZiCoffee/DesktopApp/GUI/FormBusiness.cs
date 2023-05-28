using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
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

        public formBusiness()
        {
            InitializeComponent();
            currentSelectedArea = null; 
            currentSelectedTable = null;
        }

        private void formBusiness_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadArea();
            LoadTable();
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
                fpnlTable.Controls.Add(btnTable);
            }
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
            formOrder formOrder = new formOrder();
            formOrder.ShowDialog();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            formCheckOut formCheckOut = new formCheckOut();
            formCheckOut.ShowDialog();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            formManage form = new formManage();
            form.ShowDialog();
        }

        private void btnLockTable_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable == null)
            {
                MessageBox.Show("Please select a table before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}
