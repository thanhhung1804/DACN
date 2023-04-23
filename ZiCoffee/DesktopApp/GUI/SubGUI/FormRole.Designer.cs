namespace DesktopApp.GUI.SubGUI
{
    partial class formRole
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgRole = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.btnDone = new System.Windows.Forms.Button();
            this.rtxbDescription = new System.Windows.Forms.RichTextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBody.Controls.Add(this.dgRole);
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(400, 556);
            this.pnlBody.TabIndex = 0;
            // 
            // dgRole
            // 
            this.dgRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRole.Location = new System.Drawing.Point(0, 59);
            this.dgRole.Name = "dgRole";
            this.dgRole.RowHeadersWidth = 51;
            this.dgRole.RowTemplate.Height = 24;
            this.dgRole.Size = new System.Drawing.Size(400, 497);
            this.dgRole.TabIndex = 0;
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
            this.pnlHeader.Size = new System.Drawing.Size(400, 59);
            this.pnlHeader.TabIndex = 0;
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::DesktopApp.Properties.Resources.Remove;
            this.picDelete.Location = new System.Drawing.Point(364, 12);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(30, 30);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 4;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // picNew
            // 
            this.picNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::DesktopApp.Properties.Resources.Plus;
            this.picNew.Location = new System.Drawing.Point(328, 12);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(30, 30);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 3;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.AutoScroll = true;
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlActions.Location = new System.Drawing.Point(855, 0);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(300, 556);
            this.pnlActions.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.AutoScroll = true;
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDetail.Controls.Add(this.btnDone);
            this.pnlDetail.Controls.Add(this.rtxbDescription);
            this.pnlDetail.Controls.Add(this.lbDescription);
            this.pnlDetail.Controls.Add(this.lbNameError);
            this.pnlDetail.Controls.Add(this.txbName);
            this.pnlDetail.Controls.Add(this.lbName);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(400, 0);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(455, 556);
            this.pnlDetail.TabIndex = 0;
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
            this.btnDone.Location = new System.Drawing.Point(13, 283);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(434, 50);
            this.btnDone.TabIndex = 17;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // rtxbDescription
            // 
            this.rtxbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxbDescription.Location = new System.Drawing.Point(13, 119);
            this.rtxbDescription.Name = "rtxbDescription";
            this.rtxbDescription.Size = new System.Drawing.Size(434, 158);
            this.rtxbDescription.TabIndex = 16;
            this.rtxbDescription.Text = "";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(9, 93);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(108, 23);
            this.lbDescription.TabIndex = 12;
            this.lbDescription.Text = "Description";
            // 
            // lbNameError
            // 
            this.lbNameError.AutoSize = true;
            this.lbNameError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.Red;
            this.lbNameError.Location = new System.Drawing.Point(9, 74);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(117, 19);
            this.lbNameError.TabIndex = 13;
            this.lbNameError.Text = "Error message";
            this.lbNameError.Visible = false;
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(13, 40);
            this.txbName.Margin = new System.Windows.Forms.Padding(4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(434, 30);
            this.txbName.TabIndex = 15;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(9, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "Name";
            // 
            // formRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1155, 556);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formRole";
            this.Text = "FormRole";
            this.Load += new System.EventHandler(this.formRole_Load);
            this.SizeChanged += new System.EventHandler(this.formRole_SizeChanged);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.DataGridView dgRole;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.RichTextBox rtxbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lbName;
    }
}