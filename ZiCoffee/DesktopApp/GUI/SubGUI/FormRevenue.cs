using DesktopApp.DAO;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
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
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets.Add();

            SetReportInfo(
                worksheet: excelWorksheet,
                rowIndex: 1,
                value: "REVENUE REPORT",
                color: Color.Black,
                isBold: true,
                size: 16,
                align: Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            );
            SetReportInfo(
                worksheet: excelWorksheet,
                rowIndex: 2,
                value: string.Format("From: {0}", dtpTimeStart.Value.ToString()),
                color: Color.DarkBlue,
                isBold: true
            );
            SetReportInfo(
                worksheet: excelWorksheet,
                rowIndex: 3,
                value: string.Format("To: {0}", dtpTimeEnd.Value.ToString()),
                color: Color.DarkBlue,
                isBold: true
            );
            SetColumnHeaders(worksheet: excelWorksheet);
            PopulateData(worksheet: excelWorksheet);
            CalculateTotal(worksheet: excelWorksheet);
            SaveFile(app: excelApp, workbook: excelWorkbook, worksheet: excelWorksheet);
        }

        private void SetReportInfo(
            Microsoft.Office.Interop.Excel.Worksheet worksheet,
            int rowIndex,
            string value,
            Color color,
            bool isBold = false,
            int size = 12,
            Microsoft.Office.Interop.Excel.XlHAlign align = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
        {
            worksheet.Cells[rowIndex, 1] = string.Format(value);

            Microsoft.Office.Interop.Excel.Range range = worksheet.Range[
                worksheet.Cells[rowIndex, 1],
                worksheet.Cells[rowIndex, dgRevenue.Columns.Count]
            ];
            range.Merge();

            range.Font.Bold = isBold;
            range.Font.Size = size;
            range.Font.Color = color;
            range.HorizontalAlignment = align;
        }

        private void SetColumnHeaders(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            for (int j = 0; j < dgRevenue.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range headerColumn = worksheet.Columns[j + 1];
                headerColumn.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range headerCell = worksheet.Cells[4, j + 1];
                headerCell.Value = dgRevenue.Columns[j].HeaderText;
                headerCell.Font.Bold = true;
                headerCell.Interior.Color = Color.Gray;
                headerColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
        }

        private void PopulateData(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            for (int i = 0; i < dgRevenue.Rows.Count; i++)
            {
                for (int j = 0; j < dgRevenue.Columns.Count; j++)
                {
                    if (dgRevenue.Columns[j].Name == "colCreatedDate")
                    {
                        DateTime value = DateTime.Parse(dgRevenue.Rows[i].Cells[j].Value.ToString());
                        worksheet.Cells[i + 5, j + 1].NumberFormat = "dd/MM/yyyy HH:mm:ss";
                        worksheet.Cells[i + 5, j + 1].Value = value;
                        continue;
                    }
                    worksheet.Cells[i + 5, j + 1] = dgRevenue.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void CalculateTotal(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            int lastRowIndex = dgRevenue.Rows.Count + 4;
            for (int j = 0; j < dgRevenue.Columns.Count; j++)
            {
                if (dgRevenue.Columns[j].ValueType == typeof(decimal))
                {
                    decimal cellValue = Convert.ToDecimal(dgRevenue.Rows[lastRowIndex].Cells[j].Value);
                }
            }
            Microsoft.Office.Interop.Excel.Range totalTitle = worksheet.Cells[lastRowIndex + 1, 1];
            totalTitle.Value = "Total";
            totalTitle.Font.Bold = true;
            totalTitle.Font.Color = Color.Red;

            Microsoft.Office.Interop.Excel.Range totalValue = worksheet.Cells[lastRowIndex + 1, 2];
            totalValue.Value = txbTotalRevenue.Text;
            totalValue.Font.Bold = true;
            totalValue.Font.Color = Color.Red;
        }

        private void SaveFile(
            Microsoft.Office.Interop.Excel.Application app,
            Microsoft.Office.Interop.Excel.Workbook workbook,
            Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "ExportedData.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                worksheet.SaveAs(filePath);
                workbook.Close();
                app.Quit();
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
            createdDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
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

