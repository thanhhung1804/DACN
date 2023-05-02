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

namespace DesktopApp.GUI.SubGUI
{
    public partial class formTable : Form
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

        public formTable()
        {
            InitializeComponent();
        }

        private void formTable_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //First load data
        }

        private void formTable_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                //reload data
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            //Reload data
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = true;
            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            rtxbDescription.Text = string.Empty;
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            //check selected item
            //delete record in database
            //Notify
            //reload data
            pnlDetail.Visible = false;
        }

        private void cbAreaFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            //reload data
        }

        private void cbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            //reload data
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //valid datafield
            //insert or update data
            //Notify
            //reload data
            pnlDetail.Visible = false;
        }
    }
}
