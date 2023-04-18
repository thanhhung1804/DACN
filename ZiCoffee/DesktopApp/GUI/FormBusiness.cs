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
    public partial class formBusiness : Form
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

        public formBusiness()
        {
            InitializeComponent();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            FormWindowState state = FormWindowState.Normal;
            if (WindowState == FormWindowState.Normal)
            {
                state = FormWindowState.Maximized;
            }
            WindowState = state;
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void picShowAccount_Click(object sender, EventArgs e)
        {
            pnlAccountSideBar.Size = new Size(300, pnlAccountSideBar.Size.Height);
            picShowAccount.Hide();
            picHideAccount.Show();
        }

        private void picHideAccount_Click(object sender, EventArgs e)
        {
            pnlAccountSideBar.Size = new Size(60, pnlAccountSideBar.Size.Height);
            picShowAccount.Show();
            picHideAccount.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            formChangePassword formChangePassword = new formChangePassword();
            formChangePassword.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            formOrder formOrder = new formOrder();
            formOrder.Show();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            formCheckOut formCheckOut = new formCheckOut();
            formCheckOut.Show();
        }

        private void formBusiness_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
