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
            formBusiness formBusiness = new formBusiness();
            Hide();
            formBusiness.ShowDialog();
            Show();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
