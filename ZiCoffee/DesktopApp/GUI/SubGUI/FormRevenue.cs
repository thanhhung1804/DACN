using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.Database;
using DesktopApp.Model;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            LoadData(dtpTimeStart.Value, dtpTimeEnd.Value, txbTableName.Text, txbCashierName.Text);
        }

        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadData(dtpTimeStart.Value, dtpTimeEnd.Value, txbTableName.Text, txbCashierName.Text);
        }

        private void txbCashierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData(dtpTimeStart.Value, dtpTimeEnd.Value, txbTableName.Text, txbCashierName.Text);
            }
        }

        private void txbTableName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData(dtpTimeStart.Value, dtpTimeEnd.Value, txbTableName.Text, txbCashierName.Text);
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
            dgRevenue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgRevenue.Width, dgRevenue.Height, 20, 20));

            dgRevenue.ForeColor = Color.Black;
        }

        private void formRevenue_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            dgRevenue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgRevenue.Width, dgRevenue.Height, 20, 20));
        }

        private void LoadData(DateTime startTime, DateTime endTime, string tableName, string username)
        {
            BillDAO billDAO = new BillDAO();
            Tuple<List<BillDTO>, float> result = billDAO.GetRevenue(startTime, endTime, tableName, username);
            List<BillDTO> bills = result.Item1;
            float revenueTotal = result.Item2;
            dgRevenue.AutoGenerateColumns = false;
            dgRevenue.DataSource = bills;

            dgRevenue.Columns.Clear();

            DataGridViewTextBoxColumn createdDateColumn = new DataGridViewTextBoxColumn();
            createdDateColumn.DataPropertyName = "CreatedDate";
            createdDateColumn.HeaderText = "Created date";
            createdDateColumn.Name = "colCreatedDate";
            createdDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
            createdDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            createdDateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRevenue.Columns.Add(createdDateColumn);

            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.DataPropertyName = "Total";
            totalColumn.HeaderText = "Total";
            totalColumn.Name = "colTotal";
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            totalColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgRevenue.Columns.Add(totalColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "colStatus";
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgRevenue.Columns.Add(statusColumn);


            DataGridViewTextBoxColumn tableNameColumn = new DataGridViewTextBoxColumn();
            tableNameColumn.DataPropertyName = "TableName";
            tableNameColumn.HeaderText = "Table";
            tableNameColumn.Name = "colTableName";
            tableNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tableNameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRevenue.Columns.Add(tableNameColumn);

            DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn();
            usernameColumn.DataPropertyName = "Username";
            usernameColumn.HeaderText = "Cashier";
            usernameColumn.Name = "colUserName";
            usernameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            usernameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRevenue.Columns.Add(usernameColumn);

            txbTotalRevenue.Text = revenueTotal.ToString();
        }
    }
}

