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
    public partial class formRole : Form
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
        
        private RoleDTO currentSelectedRole;

        public formRole()
        {
            InitializeComponent();
            currentSelectedRole = null;
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedRole = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            txbName.Text = string.Empty;
            rtxbDescription.Text = string.Empty;

            //reload action
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            //check selected item
            if (currentSelectedRole == null)
            {
                MessageBox.Show(
                    text: "Please choose an role",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.None
                );
                return;
            }
            //confirmation
            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this role",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }
            //delete record in database
            bool result = new RoleDAO().Delete(roleId: currentSelectedRole.RoleId);
            //notification
            if (result == true)
            {
                MessageBox.Show(
                    text: "Delete successful",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    text: "Delete fail",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
                return;
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private void formRole_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));

            LoadData();
        }

        private void formRole_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //validate fields
            //insert or update data
            bool result = false;
            string actionType = null;
            RoleDAO roleDAO = new RoleDAO();
            if (currentSelectedRole == null)
            {
                result = roleDAO.Create(name: txbName.Text, description: rtxbDescription.Text);
                actionType = "Create";
            }
            else
            {
                result = roleDAO.Update(
                    roleId: currentSelectedRole.RoleId,
                    name: txbName.Text,
                    description: rtxbDescription.Text
                );
                actionType = "Update";
            }
            //notification
            if (result == true)
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
                return;
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void dgRole_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRole.SelectedRows.Count <= 0)
            {
                return;
            }

            //mark current selected item
            currentSelectedRole = (RoleDTO)dgRole.SelectedRows[0].DataBoundItem;
            if (currentSelectedRole != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedRole.Name;
                rtxbDescription.Text = currentSelectedRole.Description;
            }
        }

        private void LoadData()
        {
            List<RoleDTO> roles = new RoleDAO().GetAll();
            dgRole.DataSource = roles;

            dgRole.AutoGenerateColumns = false;
            dgRole.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRole.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "colDescription";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRole.Columns.Add(descriptionColumn);
        }
    }
}
