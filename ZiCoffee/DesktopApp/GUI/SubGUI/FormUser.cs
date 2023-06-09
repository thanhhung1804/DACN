﻿using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private UserDTO currentSelectedUser;
        private List<string> authorizedActions;

        public formUser(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedUser = null;
            this.authorizedActions = authorizedActions;
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

            LoadData();
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

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedUser = null;
            pnlDetail.Visible = true;
            btnDone.Text = "Add";
            txbUsername.ReadOnly = false;

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            picAvatar.Image = Properties.Resources.Avatar;

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is Label && (control as Label).Name.EndsWith("Error"))
                { 
                    (control as Label).Visible = false;
                }
            }
        }

        private void dgUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUser.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedUser = (UserDTO)dgUser.SelectedRows[0].DataBoundItem;
            if (currentSelectedUser != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";
                txbUsername.ReadOnly = true;

                txbUsername.Text = currentSelectedUser.Username;
                txbName.Text = currentSelectedUser.Name;
                txbAddress.Text = currentSelectedUser.Address;
                txbCitizenId.Text = currentSelectedUser.CitizenId;
                txbPhone.Text = currentSelectedUser.Phone;
                txbEmail.Text = currentSelectedUser.Email;
                dtpBirthday.Value = currentSelectedUser.Birthday;
                cbGenderSelector.SelectedIndex = cbGenderSelector.FindString(currentSelectedUser.Gender.ToString());
                cbRole.SelectedIndex = cbRole.FindStringExact(currentSelectedUser.RoleName);
                if (currentSelectedUser.Avatar == null || currentSelectedUser.Avatar.Length == 0)
                {
                    picAvatar.Image = Properties.Resources.Avatar;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(currentSelectedUser.Avatar);
                    Image image = Image.FromStream(ms);
                    picAvatar.Image = image;
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
            Regex specialChars = new Regex(@"[!@#$%^&*()_+\-=[\]{}\\|;':"",./<>?]");
            Regex unicodeChars = new Regex(@"^(?!^[\p{IsBasicLatin}]+$)\p{L}+$");

            if (!ValidateName(specialChars) ||
                !ValidateBirthday() ||
                !ValidateCitizenId() ||
                !ValidateAddress() ||
                !ValidatePhone() ||
                !ValidateEmail())
            {
                return;
            }

            if (currentSelectedUser == null)
            {
                if (!ValidateUsername(specialChars, unicodeChars))
                {
                    return;
                }
                CreateUser();
                LoadData(descSortByCreatedDate: true);
            }
            else
            {
                UpdateUser();
                LoadData();
            }
            pnlDetail.Visible = false;
        }

        private bool ValidateEmail()
        {
            if (txbEmail.Text.Length > 40 || txbPhone.Text.Length <=0)
            {
                lbEmailError.Visible = true;
                lbEmailError.Text = "Email has to contain character between 1 and 40!!!";
                return false;
            }
            else if (txbEmail.Text.Contains(" "))
            {
                lbEmailError.Visible = true;
                lbEmailError.Text = "Email isn't allowed to have whitespace";
                return false;
            }
            else
            { 
                lbEmailError.Visible = false;
            }

            try
            {
                MailAddress email = new MailAddress(txbEmail.Text);
                lbEmailError.Visible = false;
                return true;
            }
            catch (FormatException)
            {
                lbEmailError.Visible = true;
                lbEmailError.Text = "Email is not valid format!!!";
                return false;
            }
        }

        private bool ValidatePhone()
        {
            if (txbPhone.Text.Length < 10 || txbPhone.Text.Length > 11)
            {
                lbPhoneError.Visible = true;
                lbPhoneError.Text = "Phone has to contain least 10 characters to 11 character!!!";
                return false;
            }
            else if (!Regex.IsMatch(txbPhone.Text, @"^[0-9]+$"))
            {
                lbPhoneError.Visible = true;
                lbPhoneError.Text = "Phone must contain only numeric characters!";
                return false;
            }
            else
            {
                lbPhoneError.Visible = false;
                return true;
            }
        }

        private bool ValidateAddress()
        {
            if (txbAddress.Text.Length > 100 || txbAddress.Text.Length <= 0)
            {
                lbAddressError.Visible = true;
                lbAddressError.Text = "Adress has to contain character between 1 and 100!!!";
                return false;
            }
            else
            {
                lbAddressError.Visible = false;
                return true;
            }
        }

        private bool ValidateCitizenId()
        {
            if (txbCitizenId.Text.Length != 12)
            {
                lbCitizenIdError.Visible = true;
                lbCitizenIdError.Text = "CitizenId has to contain 12 characters!!!";
                return false;
            }
            else if (!Regex.IsMatch(txbCitizenId.Text, @"^[0-9]+$"))
            {
                lbCitizenIdError.Visible = true;
                lbCitizenIdError.Text = "CitizenId must contain only numeric characters!";
                return false;
            }
            else
            {
                lbCitizenIdError.Visible = false;
                return true;
            }
        }

        private bool ValidateBirthday()
        {
            if (dtpBirthday.Value.Year < DateTime.Now.Year - 100 || dtpBirthday.Value.Year > DateTime.Now.Year - 15)
            {
                lbBirthdayError.Visible = true;
                lbBirthdayError.Text = "Birthday only has between 1923 and 2008";
                return false;
            }
            else
            {
                lbBirthdayError.Visible = false;
                return true;
            }
        }

        private bool ValidateName(Regex specialChars)
        {
            if (txbName.Text.Length > 40 || txbName.Text.Length <= 0)
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Name has to contain character between 1 and 40!!!";
                return false;
            }
            else if (specialChars.IsMatch(txbName.Text))
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Name isn't allowed to have special character";
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

        private bool ValidateUsername(Regex specialChars, Regex unicodeChars)
        {
            if (txbUsername.Text.Length > 20 || txbUsername.Text.Length <= 0)
            {
                lbUsernameError.Visible = true;
                lbUsernameError.Text = "Username only allow to have character from 1 to 20!!!";
                return false;
            }
            else if (txbUsername.Text.Contains(" "))
            {
                lbUsernameError.Visible = true;
                lbUsernameError.Text = "Username isn't allowed to have whitespace";
                return false;
            }
            else if (specialChars.IsMatch(txbUsername.Text))
            {
                lbUsernameError.Visible = true;
                lbUsernameError.Text = "Username isn't allowed to have special character";
                return false;
            }
            else if (unicodeChars.IsMatch(txbUsername.Text))
            {
                lbUsernameError.Visible = true;
                lbUsernameError.Text = "Username can't contain unicode chars";
                return false;
            }
            else if (new UserDAO().IsExistUsername(username: txbUsername.Text))
            { 
                lbUsernameError.Visible = true;
                lbUsernameError.Text = "Username is existed";
                return false;
            }
            else
            {
                lbUsernameError.Visible = false;
                return true;
            }
        }

        private void CreateUser()
        {
            if (!authorizedActions.Contains(Constants.ADD_USER))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            byte[] avatar = null;
            if (picAvatar.Tag != null)
            {
                avatar = File.ReadAllBytes(path: picAvatar.Tag.ToString());
            }

            string actionType = "Create";
            bool result = new UserDAO().Create(
                username: txbUsername.Text,
                name: txbName.Text,
                address: txbAddress.Text,
                citizenId: txbCitizenId.Text,
                phone: txbPhone.Text,
                birthday: dtpBirthday.Value,
                roleId: (cbRole.SelectedItem as RoleDTO).RoleId,
                email: txbEmail.Text,
                gender: (Gender)cbGenderSelector.SelectedIndex,
                avatar: avatar
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void UpdateUser()
        {
            if (!authorizedActions.Contains(Constants.EDIT_USER))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            byte[] avatar = currentSelectedUser.Avatar;
            if (picAvatar.Tag != null)
            {
                avatar = File.ReadAllBytes(path: picAvatar.Tag.ToString());
            }

            string actionType = "Update";
            bool result = new UserDAO().Update(
                userId: currentSelectedUser.UserId,
                name: txbName.Text,
                address: txbAddress.Text,
                citizenId: txbCitizenId.Text,
                phone: txbPhone.Text,
                birthday: dtpBirthday.Value,
                roleId: (cbRole.SelectedItem as RoleDTO).RoleId,
                email: txbEmail.Text,
                gender: (Gender)cbGenderSelector.SelectedIndex,
                avatar: avatar
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
            if (!authorizedActions.Contains(Constants.DELETE_USER))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (currentSelectedUser == null)
            {
                MessageBox.Show(
                    text: "Please choose an user", 
                    caption: "Notification", 
                    buttons: MessageBoxButtons.OK, 
                    icon: MessageBoxIcon.None
                );
                return;
            }

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

            bool result = new UserDAO().Delete(userId: currentSelectedUser.UserId);

            Notify(actionType: "Delete", result);
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

        private void cbGenderFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                picAvatar.Image = Image.FromFile(selectedImagePath);
                picAvatar.Tag = selectedImagePath;
            }
        }

        private void LoadData(bool descSortByCreatedDate = false)
        {
            List<UserDTO> users = new UserDAO().GetAll(
                keyword: txbSearch.Text, 
                gender: (Gender)cbGenderFilter.SelectedIndex,
                descSortByCreatedDate: descSortByCreatedDate
            );
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

        private void picReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
