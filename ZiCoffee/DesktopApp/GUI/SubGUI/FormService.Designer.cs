namespace DesktopApp.GUI.SubGUI
{
    partial class formService
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
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.lbCategoryError = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbStatusError = new System.Windows.Forms.Label();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.cbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.cbStatusSelector = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.lbName = new System.Windows.Forms.Label();
            this.lbStatusFilter = new System.Windows.Forms.Label();
            this.lbCategoryFilter = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lbPriceError = new System.Windows.Forms.Label();
            this.rtxbDescription = new System.Windows.Forms.RichTextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::DesktopApp.Properties.Resources.Remove;
            this.picDelete.Location = new System.Drawing.Point(606, 12);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(30, 30);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 4;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // lbCategoryError
            // 
            this.lbCategoryError.AutoSize = true;
            this.lbCategoryError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoryError.ForeColor = System.Drawing.Color.Red;
            this.lbCategoryError.Location = new System.Drawing.Point(10, 274);
            this.lbCategoryError.Name = "lbCategoryError";
            this.lbCategoryError.Size = new System.Drawing.Size(117, 19);
            this.lbCategoryError.TabIndex = 0;
            this.lbCategoryError.Text = "Error message";
            this.lbCategoryError.Visible = false;
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(14, 239);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(431, 31);
            this.cbCategory.TabIndex = 3;
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(10, 212);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(91, 23);
            this.lbCategory.TabIndex = 0;
            this.lbCategory.Text = "Category";
            // 
            // lbStatusError
            // 
            this.lbStatusError.AutoSize = true;
            this.lbStatusError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusError.ForeColor = System.Drawing.Color.Red;
            this.lbStatusError.Location = new System.Drawing.Point(10, 193);
            this.lbStatusError.Name = "lbStatusError";
            this.lbStatusError.Size = new System.Drawing.Size(117, 19);
            this.lbStatusError.TabIndex = 0;
            this.lbStatusError.Text = "Error message";
            this.lbStatusError.Visible = false;
            // 
            // picSearch
            // 
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::DesktopApp.Properties.Resources.Search;
            this.picSearch.Location = new System.Drawing.Point(300, 13);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(30, 30);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 2;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // cbCategoryFilter
            // 
            this.cbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryFilter.FormattingEnabled = true;
            this.cbCategoryFilter.Location = new System.Drawing.Point(13, 78);
            this.cbCategoryFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategoryFilter.Name = "cbCategoryFilter";
            this.cbCategoryFilter.Size = new System.Drawing.Size(317, 31);
            this.cbCategoryFilter.TabIndex = 0;
            this.cbCategoryFilter.SelectedValueChanged += new System.EventHandler(this.cbCategoryFilter_SelectedValueChanged);
            // 
            // txbSearch
            // 
            this.txbSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(13, 13);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(317, 30);
            this.txbSearch.TabIndex = 0;
            this.txbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearch_KeyPress);
            // 
            // cbStatusSelector
            // 
            this.cbStatusSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatusSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusSelector.FormattingEnabled = true;
            this.cbStatusSelector.Location = new System.Drawing.Point(14, 158);
            this.cbStatusSelector.Margin = new System.Windows.Forms.Padding(4);
            this.cbStatusSelector.Name = "cbStatusSelector";
            this.cbStatusSelector.Size = new System.Drawing.Size(431, 31);
            this.cbStatusSelector.TabIndex = 2;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(10, 131);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(66, 23);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Status";
            // 
            // lbNameError
            // 
            this.lbNameError.AutoSize = true;
            this.lbNameError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.Red;
            this.lbNameError.Location = new System.Drawing.Point(9, 112);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(117, 19);
            this.lbNameError.TabIndex = 0;
            this.lbNameError.Text = "Error message";
            this.lbNameError.Visible = false;
            // 
            // picNew
            // 
            this.picNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::DesktopApp.Properties.Resources.Plus;
            this.picNew.Location = new System.Drawing.Point(570, 12);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(30, 30);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 3;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(13, 78);
            this.txbName.Margin = new System.Windows.Forms.Padding(4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(432, 30);
            this.txbName.TabIndex = 1;
            // 
            // dgService
            // 
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgService.Location = new System.Drawing.Point(0, 0);
            this.dgService.Name = "dgService";
            this.dgService.RowHeadersWidth = 51;
            this.dgService.RowTemplate.Height = 24;
            this.dgService.Size = new System.Drawing.Size(642, 647);
            this.dgService.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(10, 51);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // lbStatusFilter
            // 
            this.lbStatusFilter.AutoSize = true;
            this.lbStatusFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusFilter.Location = new System.Drawing.Point(334, 51);
            this.lbStatusFilter.Name = "lbStatusFilter";
            this.lbStatusFilter.Size = new System.Drawing.Size(66, 23);
            this.lbStatusFilter.TabIndex = 0;
            this.lbStatusFilter.Text = "Status";
            // 
            // lbCategoryFilter
            // 
            this.lbCategoryFilter.AutoSize = true;
            this.lbCategoryFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoryFilter.Location = new System.Drawing.Point(12, 51);
            this.lbCategoryFilter.Name = "lbCategoryFilter";
            this.lbCategoryFilter.Size = new System.Drawing.Size(91, 23);
            this.lbCategoryFilter.TabIndex = 0;
            this.lbCategoryFilter.Text = "Category";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lbStatusFilter);
            this.pnlHeader.Controls.Add(this.lbCategoryFilter);
            this.pnlHeader.Controls.Add(this.cbStatusFilter);
            this.pnlHeader.Controls.Add(this.picDelete);
            this.pnlHeader.Controls.Add(this.picNew);
            this.pnlHeader.Controls.Add(this.picSearch);
            this.pnlHeader.Controls.Add(this.cbCategoryFilter);
            this.pnlHeader.Controls.Add(this.txbSearch);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(642, 131);
            this.pnlHeader.TabIndex = 0;
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Location = new System.Drawing.Point(338, 78);
            this.cbStatusFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(296, 31);
            this.cbStatusFilter.TabIndex = 0;
            this.cbStatusFilter.SelectedValueChanged += new System.EventHandler(this.cbStatusFilter_SelectedValueChanged);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.Quit;
            this.picClose.Location = new System.Drawing.Point(416, 13);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.dgService);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(642, 647);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.AutoScroll = true;
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDetail.Controls.Add(this.picImage);
            this.pnlDetail.Controls.Add(this.btnDone);
            this.pnlDetail.Controls.Add(this.rtxbDescription);
            this.pnlDetail.Controls.Add(this.lbDescription);
            this.pnlDetail.Controls.Add(this.lbPriceError);
            this.pnlDetail.Controls.Add(this.nudPrice);
            this.pnlDetail.Controls.Add(this.lbPrice);
            this.pnlDetail.Controls.Add(this.lbCategoryError);
            this.pnlDetail.Controls.Add(this.cbCategory);
            this.pnlDetail.Controls.Add(this.lbCategory);
            this.pnlDetail.Controls.Add(this.lbStatusError);
            this.pnlDetail.Controls.Add(this.cbStatusSelector);
            this.pnlDetail.Controls.Add(this.lbStatus);
            this.pnlDetail.Controls.Add(this.lbNameError);
            this.pnlDetail.Controls.Add(this.txbName);
            this.pnlDetail.Controls.Add(this.lbName);
            this.pnlDetail.Controls.Add(this.picClose);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(642, 0);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(458, 647);
            this.pnlDetail.TabIndex = 0;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(10, 293);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(55, 23);
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Text = "Price";
            // 
            // nudPrice
            // 
            this.nudPrice.Location = new System.Drawing.Point(14, 319);
            this.nudPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(431, 30);
            this.nudPrice.TabIndex = 4;
            // 
            // lbPriceError
            // 
            this.lbPriceError.AutoSize = true;
            this.lbPriceError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPriceError.ForeColor = System.Drawing.Color.Red;
            this.lbPriceError.Location = new System.Drawing.Point(10, 352);
            this.lbPriceError.Name = "lbPriceError";
            this.lbPriceError.Size = new System.Drawing.Size(117, 19);
            this.lbPriceError.TabIndex = 0;
            this.lbPriceError.Text = "Error message";
            this.lbPriceError.Visible = false;
            // 
            // rtxbDescription
            // 
            this.rtxbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxbDescription.Location = new System.Drawing.Point(13, 397);
            this.rtxbDescription.Name = "rtxbDescription";
            this.rtxbDescription.Size = new System.Drawing.Size(276, 150);
            this.rtxbDescription.TabIndex = 5;
            this.rtxbDescription.Text = "";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(10, 371);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(108, 23);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = "Description";
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
            this.btnDone.Location = new System.Drawing.Point(13, 553);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(432, 50);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.Image = global::DesktopApp.Properties.Resources.Avatar;
            this.picImage.Location = new System.Drawing.Point(295, 397);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(150, 150);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 11;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // formService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlDetail);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formService";
            this.Text = "FormService";
            this.Load += new System.EventHandler(this.formService_Load);
            this.SizeChanged += new System.EventHandler(this.formService_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.Label lbCategoryError;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbStatusError;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.ComboBox cbCategoryFilter;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.ComboBox cbStatusSelector;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbStatusFilter;
        private System.Windows.Forms.Label lbCategoryFilter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lbPriceError;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.RichTextBox rtxbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.PictureBox picImage;
    }
}