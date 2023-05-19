namespace DesktopApp.GUI.SubGUI
{
    partial class formArea
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.rtxbDescription = new System.Windows.Forms.RichTextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgArea = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArea)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDetail.Controls.Add(this.picClose);
            this.pnlDetail.Controls.Add(this.btnDone);
            this.pnlDetail.Controls.Add(this.rtxbDescription);
            this.pnlDetail.Controls.Add(this.lbDescription);
            this.pnlDetail.Controls.Add(this.lbNameError);
            this.pnlDetail.Controls.Add(this.txbName);
            this.pnlDetail.Controls.Add(this.lbName);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(700, 0);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(6);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(400, 647);
            this.pnlDetail.TabIndex = 0;
            this.pnlDetail.Visible = false;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.Quit;
            this.picClose.Location = new System.Drawing.Point(358, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDone.FlatAppearance.BorderSize = 3;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(16, 333);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(372, 50);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // rtxbDescription
            // 
            this.rtxbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxbDescription.Location = new System.Drawing.Point(16, 169);
            this.rtxbDescription.Name = "rtxbDescription";
            this.rtxbDescription.Size = new System.Drawing.Size(372, 158);
            this.rtxbDescription.TabIndex = 2;
            this.rtxbDescription.Text = "";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(12, 143);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(108, 23);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = "Description";
            // 
            // lbNameError
            // 
            this.lbNameError.AutoSize = true;
            this.lbNameError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.Red;
            this.lbNameError.Location = new System.Drawing.Point(12, 124);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(117, 19);
            this.lbNameError.TabIndex = 0;
            this.lbNameError.Text = "Error message";
            this.lbNameError.Visible = false;
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(16, 90);
            this.txbName.Margin = new System.Windows.Forms.Padding(4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(372, 30);
            this.txbName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(12, 63);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBody.Controls.Add(this.dgArea);
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(700, 647);
            this.pnlBody.TabIndex = 0;
            this.pnlBody.SizeChanged += new System.EventHandler(this.pnlBody_SizeChanged);
            // 
            // dgArea
            // 
            this.dgArea.AllowUserToAddRows = false;
            this.dgArea.AllowUserToDeleteRows = false;
            this.dgArea.AllowUserToOrderColumns = true;
            this.dgArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgArea.BackgroundColor = System.Drawing.Color.White;
            this.dgArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgArea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgArea.ColumnHeadersHeight = 29;
            this.dgArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArea.EnableHeadersVisualStyles = false;
            this.dgArea.GridColor = System.Drawing.Color.White;
            this.dgArea.Location = new System.Drawing.Point(0, 59);
            this.dgArea.MultiSelect = false;
            this.dgArea.Name = "dgArea";
            this.dgArea.ReadOnly = true;
            this.dgArea.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgArea.RowHeadersVisible = false;
            this.dgArea.RowHeadersWidth = 51;
            this.dgArea.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgArea.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgArea.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgArea.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgArea.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgArea.RowTemplate.DividerHeight = 2;
            this.dgArea.RowTemplate.Height = 40;
            this.dgArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgArea.Size = new System.Drawing.Size(700, 588);
            this.dgArea.TabIndex = 0;
            this.dgArea.SelectionChanged += new System.EventHandler(this.dgArea_SelectionChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.picDelete);
            this.pnlHeader.Controls.Add(this.picNew);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 59);
            this.pnlHeader.TabIndex = 0;
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::DesktopApp.Properties.Resources.Remove;
            this.picDelete.Location = new System.Drawing.Point(658, 12);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(30, 30);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 0;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // picNew
            // 
            this.picNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::DesktopApp.Properties.Resources.Plus;
            this.picNew.Location = new System.Drawing.Point(622, 12);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(30, 30);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 0;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // formArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlDetail);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formArea";
            this.Text = "FormArea";
            this.Load += new System.EventHandler(this.formArea_Load);
            this.SizeChanged += new System.EventHandler(this.formArea_SizeChanged);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArea)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.RichTextBox rtxbDescription;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgArea;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.PictureBox picClose;
    }
}