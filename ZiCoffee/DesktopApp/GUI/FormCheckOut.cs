using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI
{
    public partial class formCheckOut : Form
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

        private TableDTO currentSelectedTable;
        private UserDTO currentUser;
        private BillDTO currentBill;
        private List<BillDetailDTO> currentBillDetails;

        public formCheckOut(TableDTO table, UserDTO user)
        {
            InitializeComponent();
            currentSelectedTable = table;
            currentUser = user;
            currentBill = null;
        }

        private void formCheckOut_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));

            lbTableName.Text = currentSelectedTable.Name + " - " + currentSelectedTable.Status.ToString();

            LoadBill();
        }

        private void LoadBill()
        {
            currentBill = new BillDAO().GetUnpaidBillByTable(tableId: currentSelectedTable.TableId);
            if (currentBill == null)
            {
                Tuple<bool, Guid> creationResult = new BillDAO().Create(
                    tableId: currentSelectedTable.TableId,
                    userId: currentUser.UserId
                );
                currentBill = new BillDAO().GetUnpaidBillByTable(tableId: currentSelectedTable.TableId);
            }
            currentBillDetails = new BillDetailDAO().GetBillDetails(billId: currentBill.BillId);
            LoadBillDetail();
        }

        private void LoadBillDetail()
        {
            lsvBill.Items.Clear();
            float total = 0;
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                ListViewItem item = new ListViewItem(billDetail.ServiceName);
                item.SubItems.Add(billDetail.Quantity.ToString());
                item.SubItems.Add(billDetail.ServicePrice.ToString());
                item.SubItems.Add(billDetail.Amount.ToString());
                item.Tag = billDetail;
                lsvBill.Items.Add(item);
                total += billDetail.Amount;
            }
            txbTotal.Text = total.ToString();
        }

        private void formCheckOut_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBill();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to pay?", "Pay Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new BillDAO().ChangeStatus(billId: currentBill.BillId, status: BillStatus.Paid);
                new TableDAO().ChangeStatus(tableId: currentSelectedTable.TableId, status: TableStatus.Ready);
                PrintBill();
                Close();
            }
        }

        private void PrintBill()
        { 
            var result = MessageBox.Show("Do you want to print?", "Print Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.DefaultPageSettings.Margins = new Margins(50,320,50,50);
                printDocument.PrinterSettings.PrintFileName = currentBill.BillId.ToString();
                printDocument.Print();
                return;
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 20, FontStyle.Bold);
            System.Drawing.Font totalFont = new System.Drawing.Font("Courier New", 16, FontStyle.Bold);
            System.Drawing.Font headerFont = new System.Drawing.Font("Courier New", 12, FontStyle.Bold);
            System.Drawing.Font contentFont = new System.Drawing.Font("Courier New", 12);
            int lineSpacing = 20;

            // Print store name
            string storeName = "ZiCoffee";
            SizeF storeNameSize = graphics.MeasureString(storeName, titleFont);
            PointF storeNamePosition = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - storeNameSize.Width) / 2, 
                e.MarginBounds.Top
            );
            graphics.DrawString(storeName, titleFont, Brushes.Black, storeNamePosition);

            // Print cashier name
            string cashierName = "Cashier: " + currentUser.Name;
            SizeF cashierNameSize = graphics.MeasureString(cashierName, contentFont);
            PointF cashierNamePosition = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - cashierNameSize.Width) / 2, 
                e.MarginBounds.Top + lineSpacing * 2
            );
            graphics.DrawString(cashierName, contentFont, Brushes.Black, cashierNamePosition);

            // Print current date
            string createDate = "Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            SizeF createDateSize = graphics.MeasureString(createDate, contentFont);
            PointF createDatePosition = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - createDateSize.Width) / 2, 
                e.MarginBounds.Top + lineSpacing * 3
            );
            graphics.DrawString(createDate, contentFont, Brushes.Black, createDatePosition);

            // Print table name
            string tableName = "Table: " + currentSelectedTable.Name;
            SizeF tableNameSize = graphics.MeasureString(tableName, contentFont);
            PointF tableNamePosition = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - tableNameSize.Width) / 2, 
                e.MarginBounds.Top + lineSpacing * 4
            );
            graphics.DrawString(tableName, contentFont, Brushes.Black, tableNamePosition);

            // Print bill details table headers
            graphics.DrawString("Service", headerFont, Brushes.Black, new PointF(e.MarginBounds.Left, e.MarginBounds.Top + lineSpacing * 6));
            graphics.DrawString("Price", headerFont, Brushes.Black, new PointF(e.MarginBounds.Left + 200, e.MarginBounds.Top + lineSpacing * 6));
            graphics.DrawString("Qty", headerFont, Brushes.Black, new PointF(e.MarginBounds.Left + 300, e.MarginBounds.Top + lineSpacing * 6));
            graphics.DrawString("Amount", headerFont, Brushes.Black, new PointF(e.MarginBounds.Left + 400, e.MarginBounds.Top + lineSpacing * 6));

            int lineY = e.MarginBounds.Top + lineSpacing * 7;
            graphics.DrawLine(Pens.Black, e.MarginBounds.Left, lineY, e.MarginBounds.Right, lineY);

            // Print bill details
            float tableY = e.MarginBounds.Top + lineSpacing * 8;
            float totalAmount = 0;
            foreach (BillDetailDTO billDetail in currentBillDetails)
            {
                float amount = billDetail.Quantity * billDetail.ServicePrice;
                totalAmount += amount;

                graphics.DrawString(billDetail.ServiceName, contentFont, Brushes.Black, new PointF(e.MarginBounds.Left, tableY));
                graphics.DrawString(billDetail.ServicePrice.ToString("n0"), contentFont, Brushes.Black, new PointF(e.MarginBounds.Left + 200, tableY));
                graphics.DrawString(billDetail.Quantity.ToString(), contentFont, Brushes.Black, new PointF(e.MarginBounds.Left + 300, tableY));
                graphics.DrawString(amount.ToString("n0"), contentFont, Brushes.Black, new PointF(e.MarginBounds.Left + 400, tableY));

                tableY += lineSpacing;
            }

            // Print total amount
            string total = "Total: " + totalAmount.ToString("n0");
            SizeF totalSize = graphics.MeasureString(total, contentFont);
            PointF totalPosition = new PointF(
                e.MarginBounds.Right - totalSize.Width - 50, 
                tableY + lineSpacing
            );
            graphics.DrawString(total, totalFont, Brushes.Black, totalPosition);

            // Print thanks message
            string thanks = "Thank you for your visit!";
            SizeF thanksSize = graphics.MeasureString(thanks, contentFont);
            PointF thanksPosition = new PointF(e.MarginBounds.Left + (
                e.MarginBounds.Width - thanksSize.Width) / 2, 
                tableY + lineSpacing * 3
            );
            graphics.DrawString(thanks, contentFont, Brushes.Black, thanksPosition);

            // Print store address
            string addressLine1 = "441/42 Dien Bien Phu";
            SizeF addressLine1Size = graphics.MeasureString(addressLine1, contentFont);
            PointF addressLine1Position = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - addressLine1Size.Width) / 2, 
                tableY + lineSpacing * 4
            );
            graphics.DrawString(addressLine1, contentFont, Brushes.Black, addressLine1Position);

            string addressLine2 = "ward 25, Binh Thanh district, HCM city";
            SizeF addressLine2Size = graphics.MeasureString(addressLine2, contentFont);
            PointF addressLine2Position = new PointF(
                e.MarginBounds.Left + (e.MarginBounds.Width - addressLine2Size.Width) / 2, 
                tableY + lineSpacing * 5
            );
            graphics.DrawString(addressLine2, contentFont, Brushes.Black, addressLine2Position);

            // Add logo at the bottom center
            int logoX = e.MarginBounds.Left + (e.MarginBounds.Width - 100) / 2;
            float logoY = tableY + lineSpacing * 7;
            graphics.DrawImage(Properties.Resources.Logo, logoX, int.Parse(logoY.ToString()), 100, 100);

            // Indicate that there are no more pages to print
            e.HasMorePages = false;
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
