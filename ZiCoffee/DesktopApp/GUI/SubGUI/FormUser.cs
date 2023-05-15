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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formUser : Form
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

        private UserDTO userDTO;

        public formUser()
        {
            InitializeComponent();
            userDTO = null;
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            //unselect current item
            userDTO = null;
            //show panel to add
            pnlDetail.Visible = true;
            btnDone.Text = "Add";
            txbUsername.ReadOnly = true;
            //Clear fields
            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            picAvatar.Image = Properties.Resources.Avatar;
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            //check selected item
            if (userDTO == null)
            {
                MessageBox.Show(
                    text: "Please choose an user", 
                    caption: "Notification", 
                    buttons: MessageBoxButtons.OK, 
                    icon: MessageBoxIcon.None
                );
                return;
            }
            //confirmation
            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this user", 
                caption: "Confirmation", 
                buttons: MessageBoxButtons.OKCancel, 
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }
            //delete record in database
            bool result = new UserDAO().Delete(userId: userDTO.UserId);
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
            LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
            pnlDetail.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            //upload avatar
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //valid datafield
            //insert or update data
            bool result = false;
            string actionType = null;
            if (userDTO == null)
            {
                result = new UserDAO().Create(
                    username: txbUsername.Text,
                    name: txbName.Text,
                    gender: (Gender)cbGenderSelector.SelectedIndex,
                    birthday: dtpBirthday.Value,
                    address: txbAddress.Text,
                    citizenId: txbCitizenId.Text,
                    phone: txbPhone.Text,
                    email: txbEmail.Text,
                    roleId: (cbRole.SelectedItem as RoleDTO).RoleId
                );
                actionType = "Create";
            }
            else
            {
                //update
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
            LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
            pnlDetail.Visible = false;
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
            }
        }

        private void cbGenderFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));

            string[] genderNamesFilter = Enum.GetNames(typeof(Gender));
            cbGenderFilter.Items.AddRange(genderNamesFilter);
            cbGenderFilter.SelectedIndex = (int)Gender.All;

            string[] genderNamesSelector = Enum.GetNames(typeof(Gender)).Except(new[] { Gender.All.ToString() }).ToArray();
            cbGenderSelector.Items.AddRange(genderNamesSelector);
            cbGenderSelector.SelectedIndex = (int)Gender.Male;

            List<RoleDTO> roles = new RoleDAO().GetAll();
            cbRole.DataSource = roles;
            cbRole.DisplayMember = "Name";

            LoadData(keyword: txbSearch.Text, gender: (Gender)cbGenderFilter.SelectedIndex);
        }

        private void formUser_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void dgUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUser.SelectedRows.Count <= 0)
            {
                return;
            }

            //mark current selected item
            userDTO = (UserDTO)dgUser.SelectedRows[0].DataBoundItem;
            if (userDTO != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";
                txbUsername.ReadOnly = false;

                txbUsername.Text = userDTO.Username;
                txbName.Text = userDTO.Name;
                txbAddress.Text = userDTO.Address;
                txbCitizenId.Text = userDTO.CitizenId;
                txbPhone.Text = userDTO.Phone;
                txbEmail.Text = userDTO.Email;
                dtpBirthday.Value = userDTO.Birthday;
                cbGenderSelector.SelectedIndex = cbGenderSelector.FindString(userDTO.Gender.ToString());
                cbRole.SelectedIndex = cbRole.FindString(userDTO.RoleName);
                picAvatar.Image = Properties.Resources.Avatar;
            }
        }

        private void LoadData(string keyword, Gender gender)
        {
            List<UserDTO> users = new UserDAO().GetAll(keyword, gender);
            dgUser.DataSource = users;

            dgUser.AutoGenerateColumns = false;
            dgUser.Columns.Clear();

            DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn();
            usernameColumn.DataPropertyName = "Username";
            usernameColumn.HeaderText = "Username";
            usernameColumn.Name = "colUsername";
            usernameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            usernameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(usernameColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn();
            genderColumn.DataPropertyName = "Gender";
            genderColumn.HeaderText = "Gender";
            genderColumn.Name = "colGender";
            genderColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            genderColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(genderColumn);

            DataGridViewTextBoxColumn birthdayColumn = new DataGridViewTextBoxColumn();
            birthdayColumn.DataPropertyName = "Birthday";
            birthdayColumn.HeaderText = "Birthday";
            birthdayColumn.Name = "colBirthday";
            birthdayColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            birthdayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(birthdayColumn);

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "Phone";
            phoneColumn.HeaderText = "Phone";
            phoneColumn.Name = "colPhone";
            phoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            phoneColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(phoneColumn);

            DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn();
            emailColumn.DataPropertyName = "Email";
            emailColumn.HeaderText = "Email";
            emailColumn.Name = "colEmail";
            emailColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            emailColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(emailColumn);

            DataGridViewTextBoxColumn roleNameColumn = new DataGridViewTextBoxColumn();
            roleNameColumn.DataPropertyName = "RoleName";
            roleNameColumn.HeaderText = "Role";
            roleNameColumn.Name = "colRole";
            roleNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            roleNameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUser.Columns.Add(roleNameColumn);
        }
    }
}
