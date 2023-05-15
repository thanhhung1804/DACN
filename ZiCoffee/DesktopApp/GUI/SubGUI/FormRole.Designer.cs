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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.btnDone = new System.Windows.Forms.Button();
            this.fpnlActions = new System.Windows.Forms.FlowLayoutPanel();
            this.lbActions = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.rtxbDescription = new System.Windows.Forms.RichTextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgRole = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pnlDetail.SuspendLayout();
            this.fpnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.AutoScroll = true;
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDetail.Controls.Add(this.btnDone);
            this.pnlDetail.Controls.Add(this.fpnlActions);
            this.pnlDetail.Controls.Add(this.lbActions);
            this.pnlDetail.Controls.Add(this.picClose);
            this.pnlDetail.Controls.Add(this.rtxbDescription);
            this.pnlDetail.Controls.Add(this.lbDescription);
            this.pnlDetail.Controls.Add(this.lbNameError);
            this.pnlDetail.Controls.Add(this.txbName);
            this.pnlDetail.Controls.Add(this.lbName);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(755, 0);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(400, 556);
            this.pnlDetail.TabIndex = 0;
            this.pnlDetail.Visible = false;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDone.FlatAppearance.BorderSize = 3;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(13, 494);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(374, 50);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // fpnlActions
            // 
            this.fpnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlActions.AutoScroll = true;
            this.fpnlActions.Controls.Add(this.checkBox1);
            this.fpnlActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlActions.Location = new System.Drawing.Point(13, 306);
            this.fpnlActions.Name = "fpnlActions";
            this.fpnlActions.Size = new System.Drawing.Size(374, 182);
            this.fpnlActions.TabIndex = 0;
            // 
            // lbActions
            // 
            this.lbActions.AutoSize = true;
            this.lbActions.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActions.Location = new System.Drawing.Point(9, 280);
            this.lbActions.Name = "lbActions";
            this.lbActions.Size = new System.Drawing.Size(74, 23);
            this.lbActions.TabIndex = 0;
            this.lbActions.Text = "Actions";
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.Quit;
            this.picClose.Location = new System.Drawing.Point(357, 6);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // rtxbDescription
            // 
            this.rtxbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxbDescription.Location = new System.Drawing.Point(13, 119);
            this.rtxbDescription.Name = "rtxbDescription";
            this.rtxbDescription.Size = new System.Drawing.Size(374, 158);
            this.rtxbDescription.TabIndex = 2;
            this.rtxbDescription.Text = "";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(9, 93);
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
            this.lbNameError.Location = new System.Drawing.Point(9, 74);
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
            this.txbName.Location = new System.Drawing.Point(13, 40);
            this.txbName.Margin = new System.Windows.Forms.Padding(4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(374, 30);
            this.txbName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(9, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBody.Controls.Add(this.dgRole);
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(755, 556);
            this.pnlBody.TabIndex = 0;
            this.pnlBody.SizeChanged += new System.EventHandler(this.pnlBody_SizeChanged);
            // 
            // dgRole
            // 
            this.dgRole.AllowUserToAddRows = false;
            this.dgRole.AllowUserToDeleteRows = false;
            this.dgRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRole.BackgroundColor = System.Drawing.Color.White;
            this.dgRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRole.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgRole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRole.ColumnHeadersHeight = 29;
            this.dgRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRole.EnableHeadersVisualStyles = false;
            this.dgRole.GridColor = System.Drawing.Color.White;
            this.dgRole.Location = new System.Drawing.Point(0, 59);
            this.dgRole.MultiSelect = false;
            this.dgRole.Name = "dgRole";
            this.dgRole.ReadOnly = true;
            this.dgRole.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgRole.RowHeadersVisible = false;
            this.dgRole.RowHeadersWidth = 51;
            this.dgRole.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgRole.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgRole.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgRole.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgRole.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgRole.RowTemplate.DividerHeight = 2;
            this.dgRole.RowTemplate.Height = 40;
            this.dgRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRole.Size = new System.Drawing.Size(755, 497);
            this.dgRole.TabIndex = 0;
            this.dgRole.SelectionChanged += new System.EventHandler(this.dgRole_SelectionChanged);
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
            this.pnlHeader.Size = new System.Drawing.Size(755, 59);
            this.pnlHeader.TabIndex = 0;
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::DesktopApp.Properties.Resources.Remove;
            this.picDelete.Location = new System.Drawing.Point(719, 12);
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
            this.picNew.Location = new System.Drawing.Point(683, 12);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(30, 30);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 0;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 27);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // formRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1155, 556);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlDetail);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formRole";
            this.Text = "FormRole";
            this.Load += new System.EventHandler(this.formRole_Load);
            this.SizeChanged += new System.EventHandler(this.formRole_SizeChanged);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.fpnlActions.ResumeLayout(false);
            this.fpnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.RichTextBox rtxbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgRole;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.Label lbActions;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.FlowLayoutPanel fpnlActions;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}