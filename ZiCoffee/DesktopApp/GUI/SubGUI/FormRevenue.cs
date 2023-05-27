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
using Microsoft;

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

        private void formRevenue_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));

            dtpTimeStart.Format = dtpTimeEnd.Format = DateTimePickerFormat.Custom;
            dtpTimeStart.CustomFormat = dtpTimeEnd.CustomFormat = "dd/MM/yyyy";

            DateTime currentDateTime = DateTime.Now;
            dtpTimeStart.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 0, 0, 0);
            dtpTimeEnd.Value = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 59, 59);
        }

        private void formRevenue_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {
            CheckDateTimePickerValid();
            LoadData();
        }

        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            CheckDateTimePickerValid();
            LoadData();
        }

        private void CheckDateTimePickerValid()
        {
            DateTime startDate = dtpTimeStart.Value;
            DateTime endDate = dtpTimeEnd.Value;
            int compareResult = DateTime.Compare(startDate, endDate);
            if (compareResult > 0)
            {
                MessageBox.Show(
                    text: "Start date can not greater than end date", 
                    caption: "Notification", 
                    buttons: MessageBoxButtons.OK, 
                    icon: MessageBoxIcon.Information
                );
            }
        }

        private void txbCashierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData();
            }
        }

        private void txbTableName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgRevenue.Rows.Count <= 0)
            {
                MessageBox.Show(
                    text: "No data to export",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
                return;
            }
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            // Create a new Excel workbook and worksheet
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets.Add();
            
            // Set the [title, start time, end time] in the [first, second, third] row
            excelWorksheet.Cells[1, 1] = string.Format("REVENUE REPORT");
            excelWorksheet.Cells[2, 1] = string.Format("From: {0}", dtpTimeStart.Value.ToString());
            excelWorksheet.Cells[3, 1] = string.Format("To: {0}", dtpTimeEnd.Value.ToString());

            // Merge cells for the [title, start time, end time]
            Microsoft.Office.Interop.Excel.Range titleRange = excelWorksheet.Range[
                excelWorksheet.Cells[1, 1], 
                excelWorksheet.Cells[1, dgRevenue.Columns.Count]
            ];
            titleRange.Merge();

            Microsoft.Office.Interop.Excel.Range startTimeRange = excelWorksheet.Range[
                excelWorksheet.Cells[2, 1],
                excelWorksheet.Cells[2, dgRevenue.Columns.Count]
            ];
            startTimeRange.Merge();

            Microsoft.Office.Interop.Excel.Range endTimeRange = excelWorksheet.Range[
                excelWorksheet.Cells[3, 1],
                excelWorksheet.Cells[3, dgRevenue.Columns.Count]
            ];
            endTimeRange.Merge();

            // Apply formatting to the [title, start time, end time]
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 16;
            titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            startTimeRange.Font.Bold = true;
            startTimeRange.Font.Color = Color.DarkBlue;
            startTimeRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            endTimeRange.Font.Bold = true;
            endTimeRange.Font.Color = Color.DarkBlue;
            endTimeRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            // Set the column header in the fourth row
            for (int j = 0; j < dgRevenue.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range headerColumn = excelWorksheet.Columns[j + 1];
                headerColumn.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range headerCell = excelWorksheet.Cells[4, j + 1];
                headerCell.Value = dgRevenue.Columns[j].HeaderText;
                headerCell.Font.Bold = true;
                headerCell.Interior.Color = Color.Gray;
                headerColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            // Populate the worksheet with data from the DataGridView's DataSource
            for (int i = 0; i < dgRevenue.Rows.Count; i++)
            {
                for (int j = 0; j < dgRevenue.Columns.Count; j++)
                {
                    excelWorksheet.Cells[i + 5, j + 1] = dgRevenue.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Add a row at the end of the worksheet and calculate the total value
            int lastRowIndex = dgRevenue.Rows.Count + 4;
            for (int j = 0; j < dgRevenue.Columns.Count; j++)
            {
                if (dgRevenue.Columns[j].ValueType == typeof(decimal))
                {
                    decimal cellValue = Convert.ToDecimal(dgRevenue.Rows[lastRowIndex].Cells[j].Value);
                }
            }
            Microsoft.Office.Interop.Excel.Range totalTitle = excelWorksheet.Cells[lastRowIndex + 1, 1];
            totalTitle.Value = "Total";
            totalTitle.Font.Bold = true;
            totalTitle.Font.Color = Color.Red;

            Microsoft.Office.Interop.Excel.Range totalValue = excelWorksheet.Cells[lastRowIndex + 1, 2];
            totalValue.Value = txbTotalRevenue.Text;
            totalValue.Font.Bold = true;
            totalValue.Font.Color = Color.Red;

            // Prompt the user for a save location using a SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "ExportedData.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the workbook to the selected location
                string filePath = saveFileDialog.FileName;
                excelWorkbook.SaveAs(filePath);
                excelWorkbook.Close();
                excelApp.Quit();
                MessageBox.Show(
                    text: "Export successful!",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
            }
        }

        private void LoadData()
        {
            Tuple<List<BillDTO>, float> result = new BillDAO().GetRevenue(
                startTime: dtpTimeStart.Value,
                endTime: dtpTimeEnd.Value,
                tableName: txbTableName.Text,
                username: txbCashierName.Text
            );

            float revenueTotal = result.Item2;
            txbTotalRevenue.Text = revenueTotal.ToString();

            List<BillDTO> bills = result.Item1;
            dgRevenue.DataSource = bills;

            dgRevenue.AutoGenerateColumns = false;
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
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            totalColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRevenue.Columns.Add(totalColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "colStatus";
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
        }
    }
}

