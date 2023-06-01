﻿using DesktopApp.GUI.SubGUI;
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

        public formManage()
        {
            InitializeComponent();
        }

        private void formManage_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btnRevenue_Click(sender: btnRevenue, e: new EventArgs());
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
            ChangeBackcolorNavbarButtons(sender);
            formUser subform = new formUser();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            ChangeBackcolorNavbarButtons(sender);
            formRole subform = new formRole();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            ChangeBackcolorNavbarButtons(sender);
            formArea subform = new formArea();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ChangeBackcolorNavbarButtons(sender);
            formTable subform = new formTable();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ChangeBackcolorNavbarButtons(sender);
            formCategory subform = new formCategory();
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.AutoScroll = true;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(subform);
            subform.Show();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ChangeBackcolorNavbarButtons(sender);
            formService subform = new formService();
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
