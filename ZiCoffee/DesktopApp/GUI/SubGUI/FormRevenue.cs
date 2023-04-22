using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formRevenue : Form
    {
        public formRevenue()
        {
            InitializeComponent();
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txbCashierName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbTableName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void formRevenue_Load(object sender, EventArgs e)
        {
            dtpTimeStart.Format = DateTimePickerFormat.Custom;
            dtpTimeEnd.Format = DateTimePickerFormat.Custom;
            dtpTimeStart.CustomFormat = "dd/MM/yyyy";
            dtpTimeEnd.CustomFormat = "dd/MM/yyyy";
            DateTime currentDateTime = DateTime.Now;
            DateTime datetimeStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 0, 0, 0);
            DateTime datetimeEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 59, 59);
            dtpTimeStart.Value = datetimeStart;
            dtpTimeEnd.Value = datetimeEnd;
        }
    }
}

