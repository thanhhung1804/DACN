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
    public partial class formRevenue : Form
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

        public formRevenue()
        {
            InitializeComponent();
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {
            //Load data
        }

        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            //Load data
        }

        private void txbCashierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                //Load data
                MessageBox.Show("dsgfd");
            }
        }

        private void txbTableName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                //Load data
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //export to excel
        }

        private void formRevenue_Load(object sender, EventArgs e)
        {
            dtpTimeStart.Format = dtpTimeEnd.Format = DateTimePickerFormat.Custom;
            dtpTimeStart.CustomFormat = dtpTimeEnd.CustomFormat = "dd/MM/yyyy";
            DateTime currentDateTime = DateTime.Now;
            dtpTimeStart.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 0, 0, 0);
            dtpTimeEnd.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 59, 59);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void formRevenue_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}

