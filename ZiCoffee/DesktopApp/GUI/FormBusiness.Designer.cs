namespace DesktopApp.GUI
{
    partial class formBusiness
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBusiness));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picMaximize = new System.Windows.Forms.PictureBox();
            this.lbProgramName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.TotalTable = new System.Windows.Forms.Label();
            this.lbUsingTable = new System.Windows.Forms.Label();
            this.lbReadyTable = new System.Windows.Forms.Label();
            this.lbPendingTable = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lbProgramName);
            this.pnlHeader.Controls.Add(this.picClose);
            this.pnlHeader.Controls.Add(this.picMinimize);
            this.pnlHeader.Controls.Add(this.picMaximize);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 50);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.close;
            this.picClose.Location = new System.Drawing.Point(1158, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.Image = global::DesktopApp.Properties.Resources.minimize;
            this.picMinimize.Location = new System.Drawing.Point(1084, 12);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(30, 30);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 1;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picMaximize
            // 
            this.picMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMaximize.Image = global::DesktopApp.Properties.Resources.Maximize;
            this.picMaximize.Location = new System.Drawing.Point(1122, 12);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(30, 30);
            this.picMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMaximize.TabIndex = 0;
            this.picMaximize.TabStop = false;
            this.picMaximize.Click += new System.EventHandler(this.picMaximize_Click);
            // 
            // lbProgramName
            // 
            this.lbProgramName.AutoSize = true;
            this.lbProgramName.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgramName.Location = new System.Drawing.Point(12, 9);
            this.lbProgramName.Name = "lbProgramName";
            this.lbProgramName.Size = new System.Drawing.Size(105, 27);
            this.lbProgramName.TabIndex = 0;
            this.lbProgramName.Text = "ZiCoffee";
            this.lbProgramName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lbPendingTable);
            this.pnlFooter.Controls.Add(this.lbReadyTable);
            this.pnlFooter.Controls.Add(this.lbUsingTable);
            this.pnlFooter.Controls.Add(this.TotalTable);
            this.pnlFooter.Controls.Add(this.lbCopyright);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 770);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1200, 30);
            this.pnlFooter.TabIndex = 0;
            // 
            // lbCopyright
            // 
            this.lbCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(1070, -2);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(118, 20);
            this.lbCopyright.TabIndex = 0;
            this.lbCopyright.Text = "ZiCoffee©Copyright";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalTable
            // 
            this.TotalTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalTable.AutoSize = true;
            this.TotalTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTable.Location = new System.Drawing.Point(12, 1);
            this.TotalTable.Name = "TotalTable";
            this.TotalTable.Size = new System.Drawing.Size(108, 17);
            this.TotalTable.TabIndex = 0;
            this.TotalTable.Text = "Total Table: 100";
            this.TotalTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUsingTable
            // 
            this.lbUsingTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUsingTable.AutoSize = true;
            this.lbUsingTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsingTable.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbUsingTable.Location = new System.Drawing.Point(126, 1);
            this.lbUsingTable.Name = "lbUsingTable";
            this.lbUsingTable.Size = new System.Drawing.Size(115, 17);
            this.lbUsingTable.TabIndex = 0;
            this.lbUsingTable.Text = "Using Table: 100";
            this.lbUsingTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbReadyTable
            // 
            this.lbReadyTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbReadyTable.AutoSize = true;
            this.lbReadyTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReadyTable.ForeColor = System.Drawing.Color.LightGreen;
            this.lbReadyTable.Location = new System.Drawing.Point(247, 1);
            this.lbReadyTable.Name = "lbReadyTable";
            this.lbReadyTable.Size = new System.Drawing.Size(120, 17);
            this.lbReadyTable.TabIndex = 0;
            this.lbReadyTable.Text = "Ready Table: 100";
            this.lbReadyTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPendingTable
            // 
            this.lbPendingTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPendingTable.AutoSize = true;
            this.lbPendingTable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPendingTable.ForeColor = System.Drawing.Color.Yellow;
            this.lbPendingTable.Location = new System.Drawing.Point(373, 1);
            this.lbPendingTable.Name = "lbPendingTable";
            this.lbPendingTable.Size = new System.Drawing.Size(131, 17);
            this.lbPendingTable.TabIndex = 0;
            this.lbPendingTable.Text = "Pending Table: 100";
            this.lbPendingTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formBusiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBusiness";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picMaximize;
        private System.Windows.Forms.Label lbProgramName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbPendingTable;
        private System.Windows.Forms.Label lbReadyTable;
        private System.Windows.Forms.Label lbUsingTable;
        private System.Windows.Forms.Label TotalTable;
    }
}