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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class formChangePassword : Form
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

        private UserDTO currentUser;

        public formChangePassword(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picEyeOld_Click(object sender, EventArgs e)
        {
            txbOldPassword.UseSystemPasswordChar = !txbOldPassword.UseSystemPasswordChar;
            if (txbOldPassword.UseSystemPasswordChar)
            {
                picEyeOld.Image = Properties.Resources.show;
            }
            else
            {
                picEyeOld.Image = Properties.Resources.hide;
            }
        }

        private void picEyeNew_Click(object sender, EventArgs e)
        {
            txbNewPassword.UseSystemPasswordChar = !txbNewPassword.UseSystemPasswordChar;
            if (txbNewPassword.UseSystemPasswordChar)
            {
                picEyeNew.Image = Properties.Resources.show;
            }
            else
            {
                picEyeNew.Image = Properties.Resources.hide;
            }
        }

        private void picEyeReenter_Click(object sender, EventArgs e)
        {
            txbReenterPassword.UseSystemPasswordChar = !txbReenterPassword.UseSystemPasswordChar;
            if (txbReenterPassword.UseSystemPasswordChar)
            {
                picEyeReenter.Image = Properties.Resources.show;
            }
            else
            {
                picEyeReenter.Image = Properties.Resources.hide;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //check old password matching with database
            if (txbOldPassword.Text != currentUser.Password)
            {
                lbCommentOldPassword.Text = "The old password is not match";
                lbCommentOldPassword.Visible = true;
                return;
            }
            else
            {
                lbCommentOldPassword.Visible = false;
            }
            //check new password matching with old password
            if (txbNewPassword.Text == txbOldPassword.Text)
            {
                lbCommentNewPassword.Visible = true;
                return;
            }
            else
            {
                lbCommentNewPassword.Visible = false;
            }
            //check re-enter password matching with new password
            if (txbReenterPassword.Text != txbNewPassword.Text)
            {
                lbCommentReenterPassword.Visible = true;
                return;
            }
            else
            {
                lbCommentReenterPassword.Visible = false;
            }
            //check new password matching with password policy
            Tuple<bool, string> result = CheckPasswordPolicy(txbNewPassword.Text);
            bool valid = result.Item1;
            string message = result.Item2;
            if (!valid)
            {
                lbCommentNewPassword.Visible = true;
                lbCommentNewPassword.Text = message;
                return;
            }
            else
            {
                lbCommentNewPassword.Visible = false;
            }
            //Save new password into database
            bool isPasswordUpdated = new UserDAO().SetPassword(userId: currentUser.UserId, password: txbNewPassword.Text);
            
            if (!isPasswordUpdated)
            {
                MessageBox.Show("update fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("update successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private Tuple<bool, string> CheckPasswordPolicy(string newPassword)
        {
            if (newPassword.Length < 8 || newPassword.Length > 20)
            {
                return Tuple.Create(false, "Password length should be between 8 and 20 characters.");
            }

            if (newPassword.Contains(" "))
            {
                return Tuple.Create(false, "Password should not contain WhiteSpace character");
            }

            Regex lowerLatinChars = new Regex("[a-z]");
            Regex upperLatinChars = new Regex("[A-Z]");
            Regex digitChars = new Regex("[0-9]");
            Regex specialChars = new Regex(@"[!@#$%^&*()_+\-=[\]{}\\|;':"",./<>?]");

            if (!lowerLatinChars.IsMatch(newPassword))
            {
                return Tuple.Create(false, "Password should contain at least one lowercase letter");
            }
            if (!upperLatinChars.IsMatch(newPassword))
            {
                return Tuple.Create(false, "Password should contain at least one uppercase letter");
            }
            if (!digitChars.IsMatch(newPassword))
            {
                return Tuple.Create(false, "Password should contain at least one digit");
            }
            if (!specialChars.IsMatch(newPassword))
            {
                return Tuple.Create(false, "Password should contain at least one special character");
            }

            Regex leadingDigitChars = new Regex("^[0-9]");
            if (char.IsDigit(newPassword[0]))
            {
                return Tuple.Create(false, "Password should not start with a digit character.");
            }

            Regex leadingSpecialChars = new Regex(@"[!@#$%^&*()_+\-=[\]{}\\|;':"",./<>?]");
            if (leadingSpecialChars.IsMatch(newPassword[0].ToString()))
            {
                return Tuple.Create(false, "Password should not start with a special character.");
            }

            return Tuple.Create(true, "");
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void formChangePasswordLoad(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
