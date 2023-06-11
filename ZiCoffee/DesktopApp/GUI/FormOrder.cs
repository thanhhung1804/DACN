using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using DesktopApp.GUI.UserControls;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class formOrder : Form
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

        private TableDTO currentSelectedTable;
        private UserDTO currentUser;
        private CategoryDTO currentSelectedCategory;
        private ServiceDTO currentSelectedService;
        private BillDTO currentBill;
        private List<BillDetailDTO> currentBillDetails;
        private List<BillDetailDTO> currentBillDetailsBackup;

        public formOrder(TableDTO table, UserDTO user)
        {
            InitializeComponent();
            currentSelectedTable = table;
            currentUser = user;
            currentSelectedCategory = null;
            currentSelectedService = null;
            currentBill = null;
            currentBillDetails = null; 
        }

        private void formOrder_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
            lsvBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lsvBill.Width, lsvBill.Height, 20, 20));

            lbTableName.Text = currentSelectedTable.Name + " - " + currentSelectedTable.Status.ToString();

            LoadCategory();
            LoadService();
            LoadBill();
        }

        private void LoadBill()
        {
            currentBill = new BillDAO().GetUnpaidBillByTable(tableId: currentSelectedTable.TableId);
            if (currentBill == null)
            {
                Tuple<bool, Guid> creationResult = new BillDAO().Create(
                    tableId: currentSelectedTable.TableId, 
                    userId: currentUser.UserId
                );
                currentBill = new BillDAO().GetUnpaidBillByTable(tableId: currentSelectedTable.TableId);
            }
            currentBillDetails = new BillDetailDAO().GetBillDetails(billId: currentBill.BillId);
            currentBillDetailsBackup = new BillDetailDAO().GetBillDetails(billId: currentBill.BillId);
            LoadBillDetail();
        }

        private void LoadBillDetail()
        {
            lsvBill.Items.Clear();
            float total = 0;
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                ListViewItem item = new ListViewItem(billDetail.ServiceName);
                item.SubItems.Add(billDetail.Quantity.ToString());
                item.SubItems.Add(billDetail.ServicePrice.ToString());
                item.SubItems.Add(billDetail.Amount.ToString());
                item.Tag = billDetail;
                lsvBill.Items.Add(item);
                total += billDetail.Amount;
            }
            txbTotal.Text = total.ToString();
        }

        private void LoadCategory()
        {
            List<CategoryDTO> categories = new CategoryDAO().GetAll();
            CategoryDTO allCategory = new CategoryDTO(name: "All");
            categories.Add(allCategory);

            fpnlCategory.Controls.Clear();
            foreach (CategoryDTO category in categories)
            {
                Button btnCategory = new Button();
                btnCategory.Text = category.Name;
                btnCategory.Size = new Size(100, 50);
                btnCategory.FlatStyle = FlatStyle.Flat;
                btnCategory.FlatAppearance.BorderSize = 0;
                btnCategory.Font = new Font("Arial", 12, FontStyle.Bold);
                btnCategory.Cursor = Cursors.Hand;
                btnCategory.Tag = category;
                btnCategory.Click += btnCategory_Click;
                fpnlCategory.Controls.Add(btnCategory);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            currentSelectedCategory = (sender as Button).Tag as CategoryDTO;
            LoadService();
        }

        private void LoadService()
        {
            Guid categoryId = Guid.Empty;
            if (currentSelectedCategory != null)
            {
                categoryId = currentSelectedCategory.CategoryId;
            }
            List<ServiceDTO> services = new ServiceDAO().GetAll(categoryId);

            fpnlService.Controls.Clear();
            foreach (ServiceDTO service in services)
            {
                UserControlService btnService = new UserControlService();
                if (service.Image == null || service.Image.Length == 0)
                {
                    btnService.picService.Image = Properties.Resources.Drink;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(service.Image);
                    Image image = Image.FromStream(ms);
                    btnService.picService.Image = image;
                }
                btnService.lbServiceName.Text = service.Name;
                btnService.lbServicePrice.Text = service.Price.ToString("n0");
                btnService.Size = new Size(150, 210);
                btnService.Font = new Font("Arial", 12, FontStyle.Bold);
                btnService.Cursor = Cursors.Hand;
                if (service.Status == ServiceStatus.Available)
                {
                    btnService.BackColor = Color.FromArgb(140, 209, 255);
                    btnService.ForeColor = Color.Black;
                }
                else if (service.Status == ServiceStatus.Unavailable)
                {
                    btnService.BackColor = Color.Gray;
                    btnService.ForeColor = Color.Black;
                }
                btnService.Tag = service;
                btnService.UserControlClick += btnService_UserControlClick;
                btnService.KeyDown += btnService_KeyDown;
                fpnlService.Controls.Add(btnService);
            }
        }

        private void btnService_UserControlClick(object sender, EventArgs e)
        {
            currentSelectedService = (sender as UserControlService).Tag as ServiceDTO;
            if (currentSelectedService.Status == ServiceStatus.Unavailable)
            {
                MessageBox.Show(
                    text: string.Format("{0} is unavailable", currentSelectedService.Name),
                    caption: "Information",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
                return;
            }
        }

        private void btnService_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Add:
                    PushOrder();
                    break;
                case Keys.Subtract:
                    PopOrder();
                    break;
                default: break;
            }
        }

        private void PushOrder()
        {
            if (currentSelectedService == null)
            {
                MessageBox.Show("Please select a service before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsExistedBillDetail())
            {
                AddRecord();
            }
            else
            {
                IncreaseQuantity();
            }
            LoadBillDetail();
        }

        private bool IsExistedBillDetail()
        {
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                if (billDetail.ServiceId == currentSelectedService.ServiceId)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddRecord()
        {
            BillDetailDTO billDetail = new BillDetailDTO(
                billId: currentBill.BillId,
                serviceId: currentSelectedService.ServiceId,
                quantity: 1,
                amount: currentSelectedService.Price,
                serviceName: currentSelectedService.Name,
                servicePrice: currentSelectedService.Price
            );
            currentBillDetails.Add(billDetail);
        }

        private void IncreaseQuantity()
        {
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                if (billDetail.ServiceId == currentSelectedService.ServiceId)
                {
                    billDetail.Quantity += 1;
                    billDetail.Amount = currentSelectedService.Price * billDetail.Quantity;
                    break;
                }
            }
        }

        private void PopOrder()
        {
            if (currentSelectedService == null)
            {
                MessageBox.Show("Please select a service before", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsExistedBillDetail())
            {
                return;
            }
            else
            {
                DecreaseQuantity();
            }
            LoadBillDetail();
        }

        private void DecreaseQuantity()
        {
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                if (billDetail.ServiceId == currentSelectedService.ServiceId)
                {
                    billDetail.Quantity -= 1;
                    billDetail.Amount = currentSelectedService.Price * billDetail.Quantity;
                    if (billDetail.Amount == 0)
                    {
                        currentBillDetails.Remove(billDetail);
                    }
                    break;
                }
            }
        }

        private void formOrder_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
                pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
                lsvBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lsvBill.Width, lsvBill.Height, 20, 20));
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
                lsvBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lsvBill.Width, lsvBill.Height, 20, 20));
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (currentBill != null && currentBillDetailsBackup.Count <= 0)
            {
                new BillDAO().Delete(billId: currentBill.BillId);
            }
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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lsvBill.Items.Count <= 0)
            {
                MessageBox.Show("Please select at least a service", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BillDetailDAO billDetailDAO = new BillDetailDAO();
            billDetailDAO.DeleteBillDetails(billId: currentBill.BillId);
            float total = 0;
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                billDetailDAO.CreateBillDetails(billDetail: billDetail);
                total += billDetail.Amount;
            }

            new BillDAO().UpdateTotal(billId: currentBill.BillId, total: total);
            
            if (currentSelectedTable.Status == TableStatus.Ready)
            {
                new TableDAO().ChangeStatus(tableId: currentSelectedTable.TableId, status: TableStatus.Using);
            }

            MessageBox.Show("Order successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
