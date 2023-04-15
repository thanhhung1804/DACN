namespace DesktopApp.GUI
{
    partial class formChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChangePassword));
            this.txbOldPassword = new System.Windows.Forms.TextBox();
            this.picEyeOld = new System.Windows.Forms.PictureBox();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.picEyeNew = new System.Windows.Forms.PictureBox();
            this.txbReenterPassword = new System.Windows.Forms.TextBox();
            this.picEyeReenter = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lbOldPassword = new System.Windows.Forms.Label();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.lbReEnter = new System.Windows.Forms.Label();
            this.lbCommentNewPassword = new System.Windows.Forms.Label();
            this.lbCommentReenterPassword = new System.Windows.Forms.Label();
            this.lbCommentOldPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeReenter)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txbOldPassword
            // 
            this.txbOldPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOldPassword.Location = new System.Drawing.Point(57, 89);
            this.txbOldPassword.MaxLength = 20;
            this.txbOldPassword.Name = "txbOldPassword";
            this.txbOldPassword.Size = new System.Drawing.Size(350, 30);
            this.txbOldPassword.TabIndex = 1;
            this.txbOldPassword.Text = "Password";
            this.txbOldPassword.UseSystemPasswordChar = true;
            // 
            // picEyeOld
            // 
            this.picEyeOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEyeOld.Image = global::DesktopApp.Properties.Resources.show;
            this.picEyeOld.Location = new System.Drawing.Point(413, 89);
            this.picEyeOld.Name = "picEyeOld";
            this.picEyeOld.Size = new System.Drawing.Size(30, 30);
            this.picEyeOld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEyeOld.TabIndex = 6;
            this.picEyeOld.TabStop = false;
            this.picEyeOld.Click += new System.EventHandler(this.picEyeOld_Click);
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPassword.Location = new System.Drawing.Point(57, 174);
            this.txbNewPassword.MaxLength = 20;
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.Size = new System.Drawing.Size(350, 30);
            this.txbNewPassword.TabIndex = 2;
            this.txbNewPassword.Text = "Password";
            this.txbNewPassword.UseSystemPasswordChar = true;
            // 
            // picEyeNew
            // 
            this.picEyeNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEyeNew.Image = global::DesktopApp.Properties.Resources.show;
            this.picEyeNew.Location = new System.Drawing.Point(413, 174);
            this.picEyeNew.Name = "picEyeNew";
            this.picEyeNew.Size = new System.Drawing.Size(30, 30);
            this.picEyeNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEyeNew.TabIndex = 9;
            this.picEyeNew.TabStop = false;
            this.picEyeNew.Click += new System.EventHandler(this.picEyeNew_Click);
            // 
            // txbReenterPassword
            // 
            this.txbReenterPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbReenterPassword.Location = new System.Drawing.Point(57, 262);
            this.txbReenterPassword.MaxLength = 20;
            this.txbReenterPassword.Name = "txbReenterPassword";
            this.txbReenterPassword.Size = new System.Drawing.Size(350, 30);
            this.txbReenterPassword.TabIndex = 3;
            this.txbReenterPassword.Text = "Password";
            this.txbReenterPassword.UseSystemPasswordChar = true;
            // 
            // picEyeReenter
            // 
            this.picEyeReenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEyeReenter.Image = global::DesktopApp.Properties.Resources.show;
            this.picEyeReenter.Location = new System.Drawing.Point(413, 262);
            this.picEyeReenter.Name = "picEyeReenter";
            this.picEyeReenter.Size = new System.Drawing.Size(30, 30);
            this.picEyeReenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEyeReenter.TabIndex = 12;
            this.picEyeReenter.TabStop = false;
            this.picEyeReenter.Click += new System.EventHandler(this.picEyeReenter_Click);
            // 
            // btnChange
            // 
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChange.FlatAppearance.BorderSize = 3;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(57, 328);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(180, 50);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(263, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 50);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.picMinimize);
            this.pnlHeader.Controls.Add(this.picClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // picMinimize
            // 
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.Image = global::DesktopApp.Properties.Resources.minimize;
            this.picMinimize.Location = new System.Drawing.Point(420, 12);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(30, 30);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 1;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.close;
            this.picClose.Location = new System.Drawing.Point(458, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(50, 360);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(450, 50);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(50, 360);
            this.pnlRight.TabIndex = 0;
            // 
            // lbOldPassword
            // 
            this.lbOldPassword.AutoSize = true;
            this.lbOldPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldPassword.Location = new System.Drawing.Point(57, 63);
            this.lbOldPassword.Name = "lbOldPassword";
            this.lbOldPassword.Size = new System.Drawing.Size(135, 23);
            this.lbOldPassword.TabIndex = 0;
            this.lbOldPassword.Text = "Old Password";
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewPassword.Location = new System.Drawing.Point(57, 148);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(143, 23);
            this.lbNewPassword.TabIndex = 0;
            this.lbNewPassword.Text = "New Password";
            // 
            // lbReEnter
            // 
            this.lbReEnter.AutoSize = true;
            this.lbReEnter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReEnter.Location = new System.Drawing.Point(57, 236);
            this.lbReEnter.Name = "lbReEnter";
            this.lbReEnter.Size = new System.Drawing.Size(181, 23);
            this.lbReEnter.TabIndex = 0;
            this.lbReEnter.Text = "Re-enter Password";
            // 
            // lbCommentNewPassword
            // 
            this.lbCommentNewPassword.AutoSize = true;
            this.lbCommentNewPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCommentNewPassword.ForeColor = System.Drawing.Color.Red;
            this.lbCommentNewPassword.Location = new System.Drawing.Point(57, 207);
            this.lbCommentNewPassword.Name = "lbCommentNewPassword";
            this.lbCommentNewPassword.Size = new System.Drawing.Size(215, 19);
            this.lbCommentNewPassword.TabIndex = 0;
            this.lbCommentNewPassword.Text = "New password is not valid !!!";
            this.lbCommentNewPassword.Visible = false;
            // 
            // lbCommentReenterPassword
            // 
            this.lbCommentReenterPassword.AutoSize = true;
            this.lbCommentReenterPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCommentReenterPassword.ForeColor = System.Drawing.Color.Red;
            this.lbCommentReenterPassword.Location = new System.Drawing.Point(57, 295);
            this.lbCommentReenterPassword.Name = "lbCommentReenterPassword";
            this.lbCommentReenterPassword.Size = new System.Drawing.Size(247, 19);
            this.lbCommentReenterPassword.TabIndex = 0;
            this.lbCommentReenterPassword.Text = "Re-enter password is not valid !!!";
            this.lbCommentReenterPassword.Visible = false;
            // 
            // lbCommentOldPassword
            // 
            this.lbCommentOldPassword.AutoSize = true;
            this.lbCommentOldPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCommentOldPassword.ForeColor = System.Drawing.Color.Red;
            this.lbCommentOldPassword.Location = new System.Drawing.Point(57, 122);
            this.lbCommentOldPassword.Name = "lbCommentOldPassword";
            this.lbCommentOldPassword.Size = new System.Drawing.Size(208, 19);
            this.lbCommentOldPassword.TabIndex = 0;
            this.lbCommentOldPassword.Text = "Old password is not valid !!!";
            this.lbCommentOldPassword.Visible = false;
            // 
            // formChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(500, 410);
            this.Controls.Add(this.lbCommentOldPassword);
            this.Controls.Add(this.lbCommentReenterPassword);
            this.Controls.Add(this.lbCommentNewPassword);
            this.Controls.Add(this.lbReEnter);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.lbOldPassword);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txbReenterPassword);
            this.Controls.Add(this.picEyeReenter);
            this.Controls.Add(this.txbNewPassword);
            this.Controls.Add(this.picEyeNew);
            this.Controls.Add(this.txbOldPassword);
            this.Controls.Add(this.picEyeOld);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChangePasswork";
            ((System.ComponentModel.ISupportInitialize)(this.picEyeOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeReenter)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbOldPassword;
        private System.Windows.Forms.PictureBox picEyeOld;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.PictureBox picEyeNew;
        private System.Windows.Forms.TextBox txbReenterPassword;
        private System.Windows.Forms.PictureBox picEyeReenter;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lbOldPassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.Label lbReEnter;
        private System.Windows.Forms.Label lbCommentNewPassword;
        private System.Windows.Forms.Label lbCommentReenterPassword;
        private System.Windows.Forms.Label lbCommentOldPassword;
    }
}