namespace DesktopApp.GUI.SubGUI
{
    partial class formRevenue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.pnlFillter = new System.Windows.Forms.Panel();
            this.lbTableName = new System.Windows.Forms.Label();
            this.lbCashierName = new System.Windows.Forms.Label();
            this.txbTableName = new System.Windows.Forms.TextBox();
            this.txbCashierName = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.lbTotalRevenue = new System.Windows.Forms.Label();
            this.txbTotalRevenue = new System.Windows.Forms.TextBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgRevenue = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlFillter.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.dtpTimeEnd);
            this.pnlHeader.Controls.Add(this.dtpTimeStart);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTimeEnd.Location = new System.Drawing.Point(488, 12);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(300, 22);
            this.dtpTimeEnd.TabIndex = 0;
            this.dtpTimeEnd.ValueChanged += new System.EventHandler(this.dtpTimeEnd_ValueChanged);
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Location = new System.Drawing.Point(12, 12);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.Size = new System.Drawing.Size(300, 22);
            this.dtpTimeStart.TabIndex = 0;
            this.dtpTimeStart.ValueChanged += new System.EventHandler(this.dtpTimeStart_ValueChanged);
            // 
            // pnlFillter
            // 
            this.pnlFillter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlFillter.Controls.Add(this.lbTableName);
            this.pnlFillter.Controls.Add(this.lbCashierName);
            this.pnlFillter.Controls.Add(this.txbTableName);
            this.pnlFillter.Controls.Add(this.txbCashierName);
            this.pnlFillter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFillter.Location = new System.Drawing.Point(0, 50);
            this.pnlFillter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFillter.Name = "pnlFillter";
            this.pnlFillter.Size = new System.Drawing.Size(800, 76);
            this.pnlFillter.TabIndex = 0;
            // 
            // lbTableName
            // 
            this.lbTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTableName.AutoSize = true;
            this.lbTableName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableName.Location = new System.Drawing.Point(484, 7);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(114, 23);
            this.lbTableName.TabIndex = 0;
            this.lbTableName.Text = "Table Name";
            // 
            // lbCashierName
            // 
            this.lbCashierName.AutoSize = true;
            this.lbCashierName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCashierName.Location = new System.Drawing.Point(8, 7);
            this.lbCashierName.Name = "lbCashierName";
            this.lbCashierName.Size = new System.Drawing.Size(134, 23);
            this.lbCashierName.TabIndex = 0;
            this.lbCashierName.Text = "Cashier Name";
            // 
            // txbTableName
            // 
            this.txbTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTableName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTableName.Location = new System.Drawing.Point(488, 36);
            this.txbTableName.MaxLength = 20;
            this.txbTableName.Name = "txbTableName";
            this.txbTableName.Size = new System.Drawing.Size(300, 30);
            this.txbTableName.TabIndex = 0;
            this.txbTableName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTableName_KeyPress);
            // 
            // txbCashierName
            // 
            this.txbCashierName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCashierName.Location = new System.Drawing.Point(12, 36);
            this.txbCashierName.MaxLength = 20;
            this.txbCashierName.Name = "txbCashierName";
            this.txbCashierName.Size = new System.Drawing.Size(300, 30);
            this.txbCashierName.TabIndex = 0;
            this.txbCashierName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCashierName_KeyPress);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlFooter.Controls.Add(this.btnExport);
            this.pnlFooter.Controls.Add(this.lbTotalRevenue);
            this.pnlFooter.Controls.Add(this.txbTotalRevenue);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 375);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 75);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExport.FlatAppearance.BorderSize = 3;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(488, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(300, 50);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbTotalRevenue
            // 
            this.lbTotalRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTotalRevenue.AutoSize = true;
            this.lbTotalRevenue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRevenue.Location = new System.Drawing.Point(8, 26);
            this.lbTotalRevenue.Name = "lbTotalRevenue";
            this.lbTotalRevenue.Size = new System.Drawing.Size(134, 23);
            this.lbTotalRevenue.TabIndex = 0;
            this.lbTotalRevenue.Text = "Total Revenue";
            // 
            // txbTotalRevenue
            // 
            this.txbTotalRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTotalRevenue.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotalRevenue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalRevenue.ForeColor = System.Drawing.Color.Red;
            this.txbTotalRevenue.Location = new System.Drawing.Point(148, 23);
            this.txbTotalRevenue.MaxLength = 20;
            this.txbTotalRevenue.Name = "txbTotalRevenue";
            this.txbTotalRevenue.ReadOnly = true;
            this.txbTotalRevenue.Size = new System.Drawing.Size(164, 30);
            this.txbTotalRevenue.TabIndex = 0;
            this.txbTotalRevenue.Text = "0";
            this.txbTotalRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.dgRevenue);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 126);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 249);
            this.pnlBody.TabIndex = 1;
            // 
            // dgRevenue
            // 
            this.dgRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRevenue.Location = new System.Drawing.Point(0, 0);
            this.dgRevenue.Name = "dgRevenue";
            this.dgRevenue.RowHeadersWidth = 51;
            this.dgRevenue.RowTemplate.Height = 24;
            this.dgRevenue.Size = new System.Drawing.Size(800, 249);
            this.dgRevenue.TabIndex = 0;
            // 
            // formRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFillter);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formRevenue";
            this.Text = "FormRevenue";
            this.Load += new System.EventHandler(this.formRevenue_Load);
            this.SizeChanged += new System.EventHandler(this.formRevenue_SizeChanged);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFillter.ResumeLayout(false);
            this.pnlFillter.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.Panel pnlFillter;
        private System.Windows.Forms.TextBox txbTableName;
        private System.Windows.Forms.TextBox txbCashierName;
        private System.Windows.Forms.Label lbTableName;
        private System.Windows.Forms.Label lbCashierName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TextBox txbTotalRevenue;
        private System.Windows.Forms.Label lbTotalRevenue;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgRevenue;
    }
}