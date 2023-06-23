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
        private List<string> authorizedActions;

        public formRole(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedRole = null;
            this.authorizedActions = authorizedActions;
        }

        private void formRole_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            dgRole.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgRole.Width, dgRole.Height, 20, 20));
            LoadData();
        }

        private void formRole_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            dgRole.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgRole.Width, dgRole.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            dgRole.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgRole.Width, dgRole.Height, 20, 20));
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedRole = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            txbName.Text = string.Empty;
            rtxbDescription.Text = string.Empty;
            LoadActions();

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is Label && (control as Label).Name.EndsWith("Error"))
                {
                    (control as Label).Visible = false;
                }
            }
        }

        private void dgRole_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRole.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedRole = (RoleDTO)dgRole.SelectedRows[0].DataBoundItem;
            if (currentSelectedRole != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedRole.Name;
                rtxbDescription.Text = currentSelectedRole.Description;
                LoadActions();

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

            if (currentSelectedRole == null)
            {   
                CreateRole();
                LoadData(descSortByCreatedDate: true);
            }
            else
            {
                UpdateRole();
                LoadData();
            }
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
            else if (new RoleDAO().IsExistName(name: txbName.Text))
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Role is existed!!!";
                return false;
            }
            else
            {
                lbNameError.Visible = false;
                return true;
            }
        }

        private void CreateRole()
        {
            if (!authorizedActions.Contains(Constants.ADD_ROLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Create";
            Tuple<bool, Guid> roleCreationResult = new RoleDAO().Create(
                name: txbName.Text, description: rtxbDescription.Text
            );

            bool isSucceed = roleCreationResult.Item1;
            if (!isSucceed)
            {
                Notify(actionType, isSucceed);
                return;
            }

            Guid roleId = roleCreationResult.Item2;
            foreach (Control control in fpnlActions.Controls)
            {
                if (control is CheckBox && (control as CheckBox).Checked)
                {
                    object tag = (control as CheckBox).Tag;
                    ActionDTO checkedAction = (ActionDTO)tag;

                    bool roleActionCreationResult = new RoleActionDAO().Create(
                        roleId, actionId: checkedAction.ActionId
                    );

                    if (roleActionCreationResult == false)
                    {
                        Notify(actionType, isSucceed: false);
                        return;
                    }
                }
            }
            Notify(actionType, isSucceed: true);
        }

        private void UpdateRole()
        {
            if (!authorizedActions.Contains(Constants.EDIT_ROLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Update";
            bool roleUpdationResult = new RoleDAO().Update(
                roleId: currentSelectedRole.RoleId,
                name: txbName.Text,
                description: rtxbDescription.Text
            );

            if (!roleUpdationResult)
            {
                Notify(actionType, isSucceed: roleUpdationResult);
                return;
            }

            foreach (Control control in fpnlActions.Controls)
            {
                if (control is CheckBox && (control as CheckBox).Checked)
                {
                    object tag = (control as CheckBox).Tag;
                    ActionDTO action = (ActionDTO)tag;

                    List<RoleActionDTO> roleActions = new RoleActionDAO().GetRoleActionMapping(
                        roleId: currentSelectedRole.RoleId,
                        actionId: action.ActionId
                    );

                    if (roleActions.Count > 0)
                    {
                        continue;
                    }

                    bool roleActionCreationResult = new RoleActionDAO().Create(
                        roleId: currentSelectedRole.RoleId,
                        actionId: action.ActionId
                    );

                    if (roleActionCreationResult == false)
                    {
                        Notify(actionType, isSucceed: false);
                        return;
                    }
                }
                else if (control is CheckBox && !(control as CheckBox).Checked)
                {
                    object tag = (control as CheckBox).Tag;
                    ActionDTO action = (ActionDTO)tag;

                    List<RoleActionDTO> roleActions = new RoleActionDAO().GetRoleActionMapping(
                        roleId: currentSelectedRole.RoleId,
                        actionId: action.ActionId
                    );

                    if (roleActions.Count <= 0)
                    {
                        continue;
                    }

                    bool roleActionDeletionResult = new RoleActionDAO().Delete(
                        roleId: currentSelectedRole.RoleId,
                        actionId: action.ActionId
                    );

                    if (roleActionDeletionResult == false)
                    {
                        Notify(actionType, isSucceed: false);
                        return;
                    }
                }
            }
            Notify(actionType, isSucceed: true);
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
                return;
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.DELETE_ROLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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

            bool result = new RoleDAO().Delete(roleId: currentSelectedRole.RoleId);

            Notify(actionType: "Delete", isSucceed: result);

            LoadData();
            pnlDetail.Visible = false;
        }

        private void LoadData(bool descSortByCreatedDate = false)
        {
            List<RoleDTO> roles = new RoleDAO().GetAll(descSortByCreatedDate: descSortByCreatedDate);
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

        private void LoadActions()
        {
            List<Guid> enabledActionIds = new List<Guid>();
            if (currentSelectedRole != null)
            {
                List<RoleActionDTO>  roleActions = new RoleActionDAO().GetRoleActionMapping(roleId: currentSelectedRole.RoleId);
                foreach (RoleActionDTO roleAction in roleActions)
                {
                    enabledActionIds.Add(roleAction.ActionId);
                }
            }

            fpnlActions.Controls.Clear();
            List<ActionDTO> actions = new ActionDAO().GetAll();
            foreach (ActionDTO action in actions)
            {
                CheckBox ckb = new CheckBox();
                ckb.AutoSize = true;
                ckb.Text = action.Name;
                if (!string.IsNullOrEmpty(action.Description))
                {
                    ckb.Text += string.Format(" - {0}", action.Description);
                }
                if (enabledActionIds.Contains(action.ActionId))
                {
                    ckb.Checked = true;
                }
                ckb.Tag = action;
                fpnlActions.Controls.Add(ckb);
            }
        }

        private void picReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
