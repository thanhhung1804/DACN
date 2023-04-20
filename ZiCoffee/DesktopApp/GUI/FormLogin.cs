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
    public partial class formLogin : Form
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

        public formLogin()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
        
        private void ExitApplication()
        {
            var result = MessageBox.Show("Are you sure for that action?", "Question", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void picEye_Click(object sender, EventArgs e)
        {
            txbPassword.UseSystemPasswordChar = !txbPassword.UseSystemPasswordChar;
            if (txbPassword.UseSystemPasswordChar)
            {
                picEye.Image = Properties.Resources.show;
            }
            else
            {
                picEye.Image = Properties.Resources.hide;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            var result = ValidateUsername(username);
            var valid = result.Item1;
            var message = result.Item2;
            if (!valid)
            { 
                lbErrorUsername.Text = message;
                lbErrorUsername.Visible = true;
                return;
            }
            else
            {
                lbErrorUsername.Visible = false;
            }

            string password = txbPassword.Text;
            result = ValidatePassword(password);
            valid = result.Item1;
            message = result.Item2;
            if (!valid)
            {
                lbErrorPassword.Text = message;
                lbErrorPassword.Visible = true;
                return;
            }
            else
            {
                lbErrorPassword.Visible = false;
            }

            //Check database: to verify username and password
            formBusiness formBusiness = new formBusiness();
            Hide();
            formBusiness.ShowDialog();
            Show();
        }

        private Tuple<bool,string> ValidateUsername(string username)
        {
            Regex specialChars = new Regex(@"[!@#$%^&*()_+\-=[\]{}\\|;':"",./<>?]");
            if (username.Length == 0)
            {
                return Tuple.Create(false, "Username isn't allowed to be empty");
            }
            if (username.Contains(" "))
            {
                return Tuple.Create(false, "Username isn't allowed to have whitespace");
            }
            if (specialChars.IsMatch(username))
            {
                return Tuple.Create(false, "Username isn't allowed to have special character");
            }
            return Tuple.Create(true, "");
        }

        private Tuple<bool,string> ValidatePassword(string password)
        {
            if (password.Length == 0)
            {
                return Tuple.Create(false, "Password isn't allowed to be empty");
            }
            if (password.Contains(" "))
            {
                return Tuple.Create(false, "Password isn't allowed to have whitespace");
            }
            return Tuple.Create(true, "");
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
