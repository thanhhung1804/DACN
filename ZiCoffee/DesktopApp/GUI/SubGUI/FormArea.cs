using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formArea : Form
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

        private AreaDTO currentSelectedArea;
        private List<string> authorizedActions;

        public formArea(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedArea = null;
            this.authorizedActions = authorizedActions;
        }

        private void formArea_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            dgArea.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgArea.Width, dgArea.Height, 20, 20));
            LoadData();
        }

        private void formArea_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            dgArea.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgArea.Width, dgArea.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            dgArea.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgArea.Width, dgArea.Height, 20, 20));
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedArea = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            txbName.Text = string.Empty;
            rtxbDescription.Text = string.Empty;
        }

        private void dgArea_SelectionChanged(object sender, EventArgs e)
        {
            if (dgArea.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedArea = (AreaDTO)dgArea.SelectedRows[0].DataBoundItem;
            if (currentSelectedArea != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedArea.Name;
                rtxbDescription.Text = currentSelectedArea.Description;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //validate field
            if (currentSelectedArea == null)
            {
                CreateArea();
            }
            else
            {
                UpdateArea();
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private void CreateArea()
        {
            if (!authorizedActions.Contains(Constants.ADD_AREA))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Create";
            bool result = new AreaDAO().Create(
                name: txbName.Text, description: rtxbDescription.Text
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void UpdateArea()
        {
            if (!authorizedActions.Contains(Constants.EDIT_AREA))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Update";
            bool result = new AreaDAO().Update(
                areaId: currentSelectedArea.AreaId, name: txbName.Text, description: rtxbDescription.Text
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
            if (!authorizedActions.Contains(Constants.DELETE_AREA))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (currentSelectedArea == null)
            {
                MessageBox.Show(
                    text: "Please choose an area",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.None
                );
                return;
            }

            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this area",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }

            bool result = new AreaDAO().Delete(areaId: currentSelectedArea.AreaId);

            Notify(actionType: "Delete", isSucceed: result);

            LoadData();
            pnlDetail.Visible = false;
        }

        private void LoadData()
        {
            List<AreaDTO> areas = new AreaDAO().GetAll();
            dgArea.DataSource = areas;

            dgArea.AutoGenerateColumns = false;
            dgArea.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgArea.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "colDescription";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgArea.Columns.Add(descriptionColumn);
        }
    }
}
