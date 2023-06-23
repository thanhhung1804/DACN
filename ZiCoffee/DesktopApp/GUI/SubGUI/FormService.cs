using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formService : Form
    {
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

        private ServiceDTO currentSelectedService;
        private List<string> authorizedActions;

        public formService(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedService = null;
            this.authorizedActions = authorizedActions;
        }

        private void formService_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));

            string[] serviceStatusFilter = Enum.GetNames(typeof(ServiceStatus));
            cbStatusFilter.Items.AddRange(serviceStatusFilter);
            cbStatusFilter.SelectedIndex = (int)ServiceStatus.All;

            string[] serviceStatusSelector = Enum.GetNames(typeof(ServiceStatus)).Except(new[] { ServiceStatus.All.ToString() }).ToArray();
            cbStatusSelector.Items.AddRange(serviceStatusSelector);
            cbStatusSelector.SelectedIndex = (int)ServiceStatus.Unavailable;

            List<CategoryDTO> selectorCategories = new CategoryDAO().GetAll();
            cbCategorySelector.DataSource = selectorCategories;
            cbCategorySelector.DisplayMember = "Name";

            List<CategoryDTO> filterCategories = new CategoryDAO().GetAll();
            CategoryDTO filterAllCategory = new CategoryDTO(name: "All");
            filterCategories.Add(filterAllCategory);
            cbCategoryFilter.DataSource = filterCategories;
            cbCategoryFilter.DisplayMember = "Name";
            cbCategoryFilter.SelectedItem = filterAllCategory;

            LoadData();
        }

        private void formService_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedService = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            picImage.Image = Properties.Resources.User;
            rtxbDescription.Text = string.Empty;
            nudPrice.Value = 0;

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is Label && (control as Label).Name.EndsWith("Error"))
                {
                    (control as Label).Visible = false;
                }
            }
        }

        private void dgService_SelectionChanged(object sender, EventArgs e)
        {
            if (dgService.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedService = (ServiceDTO)dgService.SelectedRows[0].DataBoundItem;
            if (currentSelectedService != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedService.Name;
                rtxbDescription.Text = currentSelectedService.Description;
                cbStatusSelector.SelectedIndex = cbStatusSelector.FindString(currentSelectedService.Status.ToString());
                cbCategorySelector.SelectedIndex = cbCategorySelector.FindString(currentSelectedService.CategoryName);
                nudPrice.Value = (decimal)currentSelectedService.Price;
                picImage.Image = Properties.Resources.Drink;

                if (currentSelectedService.Image == null || currentSelectedService.Image.Length == 0)
                {
                    picImage.Image = Properties.Resources.Drink;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(currentSelectedService.Image);
                    Image image = Image.FromStream(ms);
                    picImage.Image = image;
                }

                foreach (Control control in pnlDetail.Controls)
                {
                    if (control is Label && (control as Label).Name.EndsWith("Error"))
                    {
                        (control as Label).Visible = false;
                    }
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {   
            if (!ValidateName() || !ValidateDescription())
            {
                return;
            }

            if (currentSelectedService == null)
            {
               CreateService();
            }
            else
            {
                UpdateService();
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private bool ValidateDescription()
        {
            if (rtxbDescription.Text.Length > 100)
            {
                lbDescriptionError.Visible = true;
                lbDescriptionError.Text = "Description has to contain maximum 100 characters!!!";
                return false;
            }
            else
            {
                lbDescriptionError.Visible = false;
                return true;
            }
        }

        private bool ValidateName()
        {
            if (txbName.Text.Length > 20 || txbName.Text.Length <= 0)
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Name has to contain character between 1 and 20!!!";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Name can not contain only whitespace!!!";
                return false;
            }
            else
            {
                lbNameError.Visible = false;
                return true;
            }
        }

        private void CreateService()
        {
            if (!authorizedActions.Contains(Constants.ADD_SERVICE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            byte[] image = null;
            if (picImage.Tag != null)
            {
                image = File.ReadAllBytes(path: picImage.Tag.ToString());
            }

            string actionType = "Create";
            bool result = new ServiceDAO().Create(
                name: txbName.Text,
                categoryId: (cbCategorySelector.SelectedItem as CategoryDTO).CategoryId,
                status: (ServiceStatus)cbStatusSelector.SelectedIndex,
                description: rtxbDescription.Text,
                price: (float)nudPrice.Value,
                image: image
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void UpdateService()
        {
            if (!authorizedActions.Contains(Constants.EDIT_SERVICE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            byte[] image = currentSelectedService.Image;
            if (picImage.Tag != null)
            {
                image = File.ReadAllBytes(path: picImage.Tag.ToString());
            }

            string actionType = "Update";
            bool result = new ServiceDAO().Update(
                serviceId: currentSelectedService.ServiceId,
                name: txbName.Text,
                categoryId: (cbCategorySelector.SelectedItem as CategoryDTO).CategoryId,
                status: (ServiceStatus)cbStatusSelector.SelectedIndex,
                description: rtxbDescription.Text,
                price: (float)nudPrice.Value,
                image: image
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void Notify(string actionType, bool isSucceed = true)
        {
            if (isSucceed)
            {
                MessageBox.Show(
                    text: string.Format("{0} successful", actionType),
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    text: string.Format("{0} fail", actionType),
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.DELETE_SERVICE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (currentSelectedService == null)
            {
                MessageBox.Show(
                    text: "Please choose an service",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.None
                );
                return;
            }

            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this service",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }

            bool result = new ServiceDAO().Delete(serviceId: currentSelectedService.ServiceId);

            Notify(actionType: "Delete", isSucceed: result);

            LoadData();
            pnlDetail.Visible = false;
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData();
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbCategoryFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                picImage.Image = Image.FromFile(selectedImagePath);
                picImage.Tag = selectedImagePath;
            }
        }

        private void LoadData()
        {
            Guid categoryId = Guid.Empty;
            if (cbCategoryFilter.SelectedItem != null)
            {
                categoryId = (cbCategoryFilter.SelectedItem as CategoryDTO).CategoryId;
            }

            ServiceStatus status = ServiceStatus.All;
            if (cbStatusFilter.SelectedItem != null)
            {
                status = (ServiceStatus)cbStatusFilter.SelectedIndex;
            }

            List<ServiceDTO> services = new ServiceDAO().GetAll(
                categoryId: categoryId,
                keyword: txbSearch.Text,
                status: status
            );
            dgService.DataSource = services;

            dgService.AutoGenerateColumns = false;
            dgService.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgService.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "colDescription";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgService.Columns.Add(descriptionColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.Name = "colPrice";
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            priceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgService.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "colStatus";
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgService.Columns.Add(statusColumn);

            DataGridViewTextBoxColumn categoryNameColumn = new DataGridViewTextBoxColumn();
            categoryNameColumn.DataPropertyName = "CategoryName";
            categoryNameColumn.HeaderText = "Category";
            categoryNameColumn.Name = "colCategoryName";
            categoryNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            categoryNameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgService.Columns.Add(categoryNameColumn);
        }
    }
}
