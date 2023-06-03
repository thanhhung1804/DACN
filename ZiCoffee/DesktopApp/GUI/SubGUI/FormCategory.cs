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

namespace DesktopApp.GUI.SubGUI
{
    public partial class formCategory : Form
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

        private CategoryDTO currentSelectedCategory;
        private List<string> authorizedActions;

        public formCategory(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedCategory = null;
            this.authorizedActions = authorizedActions;
        }

        private void formCategory_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
            LoadData();
        }

        private void formCategory_SizeChanged(object sender, EventArgs e)
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
            currentSelectedCategory = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            txbName.Text = string.Empty;
            rtxbDescription.Text = string.Empty;
        }

        private void dgCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCategory.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedCategory = (CategoryDTO)dgCategory.SelectedRows[0].DataBoundItem;
            if (currentSelectedCategory != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedCategory.Name;
                rtxbDescription.Text = currentSelectedCategory.Description;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //validate field
            if (currentSelectedCategory == null)
            {
                CreateCategory();
            }
            else
            {
                UpdateCategory();
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private void CreateCategory()
        {
            if (!authorizedActions.Contains(Constants.ADD_CATEGORY))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Create";
            bool result = new CategoryDAO().Create(
                name: txbName.Text, description: rtxbDescription.Text
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void UpdateCategory()
        {
            if (!authorizedActions.Contains(Constants.EDIT_CATEGORY))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Update";
            bool result = new CategoryDAO().Update(
                categoryId: currentSelectedCategory.CategoryId, 
                name: txbName.Text, 
                description: rtxbDescription.Text
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
            if (!authorizedActions.Contains(Constants.DELETE_CATEGORY))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (currentSelectedCategory == null)
            {
                MessageBox.Show(
                    text: "Please choose an category",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.None
                );
                return;
            }

            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this category",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }

            bool result = new CategoryDAO().Delete(categoryId: currentSelectedCategory.CategoryId);

            Notify(actionType: "Delete", isSucceed: result);

            LoadData();
            pnlDetail.Visible = false;
        }

        private void LoadData()
        {
            List<CategoryDTO> categories = new CategoryDAO().GetAll();
            dgCategory.DataSource = categories;

            dgCategory.AutoGenerateColumns = false;
            dgCategory.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgCategory.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "colDescription";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgCategory.Columns.Add(descriptionColumn);
        }
    }
}
