using DesktopApp.Common;
using DesktopApp.GUI.SubGUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class formManage : Form
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

        private List<string> authorizedActions;

        public formManage(List<string> authorizedActions)
        {
            InitializeComponent();
            this.authorizedActions = authorizedActions;
        }

        private void formManage_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            if (authorizedActions.Contains(Constants.VIEW_REVENUE))
            {
                btnRevenue_Click(sender: btnRevenue, e: new EventArgs());
            }
        }

        private void formManage_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
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

        private void picToggle_Click(object sender, EventArgs e)
        {
            if (pnlNavBar.Width > 0) 
            {
                pnlNavBar.Size = new Size(0, pnlNavBar.Height);
            }
            else
            {
                pnlNavBar.Size = new Size(200, pnlNavBar.Height);
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_REVENUE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formRevenue subform = new formRevenue();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_USER))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formUser subform = new formUser(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_ROLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formRole subform = new formRole(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_AREA))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formArea subform = new formArea(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_TABLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formTable subform = new formTable(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_CATEGORY))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formCategory subform = new formCategory(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.VIEW_SERVICE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ChangeBackcolorNavbarButtons(sender);
            formService subform = new formService(authorizedActions);
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void ChangeBackcolorNavbarButtons(object sender)
        {
            foreach (Control control in pnlNavBar.Controls)
            {
                if (control is Button)
                {
                    (control as Button).BackColor = Color.FromArgb(38, 38, 38);
                }
            }
            (sender as Button).BackColor = Color.DeepSkyBlue;
        }
    }
}
