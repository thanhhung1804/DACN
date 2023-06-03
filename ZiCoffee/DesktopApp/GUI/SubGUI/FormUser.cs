using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                cbRole.SelectedIndex = cbRole.FindString(currentSelectedUser.RoleName);
                if (currentSelectedUser.Avatar == null)
                {
                    picAvatar.Image = Properties.Resources.Avatar;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(currentSelectedUser.Avatar);
                    Image image = Image.FromStream(ms);
                    picAvatar.Image = image;
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //valid datafield
            if (currentSelectedUser == null)
            {
                CreateUser();
            }
            else
            {
                UpdateUser();
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private void CreateUser()
        {
            if (!authorizedActions.Contains(Constants.ADD_USER))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
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
                avatar: File.ReadAllBytes(path: picAvatar.Tag.ToString())
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
                avatar: File.ReadAllBytes(path: picAvatar.Tag.ToString())
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

        private void LoadData()
        {
            List<UserDTO> users = new UserDAO().GetAll(
                keyword: txbSearch.Text, 
                gender: (Gender)cbGenderFilter.SelectedIndex
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
    }
}
