namespace DesktopApp.GUI.SubGUI
{
    partial class formUser
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
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.btnDone = new System.Windows.Forms.Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lbRoleError = new System.Windows.Forms.Label();
            this.lbEmailError = new System.Windows.Forms.Label();
            this.lbPhoneError = new System.Windows.Forms.Label();
            this.lbCitizenIdError = new System.Windows.Forms.Label();
            this.lbAddressError = new System.Windows.Forms.Label();
            this.lbBirthdayError = new System.Windows.Forms.Label();
            this.lbGenderError = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.lbUsernameError = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lbRole = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txbCitizenId = new System.Windows.Forms.TextBox();
            this.lbCitizenId = new System.Windows.Forms.Label();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.cbGenderSelector = new System.Windows.Forms.ComboBox();
            this.lbGender = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.cbGenderFilter = new System.Windows.Forms.ComboBox();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.lbGenderFilter = new System.Windows.Forms.Label();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.AutoScroll = true;
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDetail.Controls.Add(this.btnDone);
            this.pnlDetail.Controls.Add(this.picAvatar);
            this.pnlDetail.Controls.Add(this.lbRoleError);
            this.pnlDetail.Controls.Add(this.lbEmailError);
            this.pnlDetail.Controls.Add(this.lbPhoneError);
            this.pnlDetail.Controls.Add(this.lbCitizenIdError);
            this.pnlDetail.Controls.Add(this.lbAddressError);
            this.pnlDetail.Controls.Add(this.lbBirthdayError);
            this.pnlDetail.Controls.Add(this.lbGenderError);
            this.pnlDetail.Controls.Add(this.lbNameError);
            this.pnlDetail.Controls.Add(this.lbUsernameError);
            this.pnlDetail.Controls.Add(this.cbRole);
            this.pnlDetail.Controls.Add(this.lbRole);
            this.pnlDetail.Controls.Add(this.txbEmail);
            this.pnlDetail.Controls.Add(this.lbEmail);
            this.pnlDetail.Controls.Add(this.txbPhone);
            this.pnlDetail.Controls.Add(this.lbPhone);
            this.pnlDetail.Controls.Add(this.txbCitizenId);
            this.pnlDetail.Controls.Add(this.lbCitizenId);
            this.pnlDetail.Controls.Add(this.txbAddress);
            this.pnlDetail.Controls.Add(this.lbAddress);
            this.pnlDetail.Controls.Add(this.dtpBirthday);
            this.pnlDetail.Controls.Add(this.lbBirthday);
            this.pnlDetail.Controls.Add(this.cbGenderSelector);
            this.pnlDetail.Controls.Add(this.lbGender);
            this.pnlDetail.Controls.Add(this.txbName);
            this.pnlDetail.Controls.Add(this.lbName);
            this.pnlDetail.Controls.Add(this.txbUsername);
            this.pnlDetail.Controls.Add(this.lbUsername);
            this.pnlDetail.Controls.Add(this.picClose);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(700, 0);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(400, 866);
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
            this.btnDone.Location = new System.Drawing.Point(14, 777);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(374, 50);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Image = global::DesktopApp.Properties.Resources.Avatar;
            this.picAvatar.Location = new System.Drawing.Point(237, 621);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 10;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // lbRoleError
            // 
            this.lbRoleError.AutoSize = true;
            this.lbRoleError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoleError.ForeColor = System.Drawing.Color.Red;
            this.lbRoleError.Location = new System.Drawing.Point(10, 752);
            this.lbRoleError.Name = "lbRoleError";
            this.lbRoleError.Size = new System.Drawing.Size(117, 19);
            this.lbRoleError.TabIndex = 0;
            this.lbRoleError.Text = "Error message";
            this.lbRoleError.Visible = false;
            // 
            // lbEmailError
            // 
            this.lbEmailError.AutoSize = true;
            this.lbEmailError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmailError.ForeColor = System.Drawing.Color.Red;
            this.lbEmailError.Location = new System.Drawing.Point(10, 671);
            this.lbEmailError.Name = "lbEmailError";
            this.lbEmailError.Size = new System.Drawing.Size(117, 19);
            this.lbEmailError.TabIndex = 0;
            this.lbEmailError.Text = "Error message";
            this.lbEmailError.Visible = false;
            // 
            // lbPhoneError
            // 
            this.lbPhoneError.AutoSize = true;
            this.lbPhoneError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneError.ForeColor = System.Drawing.Color.Red;
            this.lbPhoneError.Location = new System.Drawing.Point(10, 591);
            this.lbPhoneError.Name = "lbPhoneError";
            this.lbPhoneError.Size = new System.Drawing.Size(117, 19);
            this.lbPhoneError.TabIndex = 0;
            this.lbPhoneError.Text = "Error message";
            this.lbPhoneError.Visible = false;
            // 
            // lbCitizenIdError
            // 
            this.lbCitizenIdError.AutoSize = true;
            this.lbCitizenIdError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCitizenIdError.ForeColor = System.Drawing.Color.Red;
            this.lbCitizenIdError.Location = new System.Drawing.Point(10, 511);
            this.lbCitizenIdError.Name = "lbCitizenIdError";
            this.lbCitizenIdError.Size = new System.Drawing.Size(117, 19);
            this.lbCitizenIdError.TabIndex = 0;
            this.lbCitizenIdError.Text = "Error message";
            this.lbCitizenIdError.Visible = false;
            // 
            // lbAddressError
            // 
            this.lbAddressError.AutoSize = true;
            this.lbAddressError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddressError.ForeColor = System.Drawing.Color.Red;
            this.lbAddressError.Location = new System.Drawing.Point(10, 431);
            this.lbAddressError.Name = "lbAddressError";
            this.lbAddressError.Size = new System.Drawing.Size(117, 19);
            this.lbAddressError.TabIndex = 0;
            this.lbAddressError.Text = "Error message";
            this.lbAddressError.Visible = false;
            // 
            // lbBirthdayError
            // 
            this.lbBirthdayError.AutoSize = true;
            this.lbBirthdayError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBirthdayError.ForeColor = System.Drawing.Color.Red;
            this.lbBirthdayError.Location = new System.Drawing.Point(10, 351);
            this.lbBirthdayError.Name = "lbBirthdayError";
            this.lbBirthdayError.Size = new System.Drawing.Size(117, 19);
            this.lbBirthdayError.TabIndex = 0;
            this.lbBirthdayError.Text = "Error message";
            this.lbBirthdayError.Visible = false;
            // 
            // lbGenderError
            // 
            this.lbGenderError.AutoSize = true;
            this.lbGenderError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGenderError.ForeColor = System.Drawing.Color.Red;
            this.lbGenderError.Location = new System.Drawing.Point(10, 273);
            this.lbGenderError.Name = "lbGenderError";
            this.lbGenderError.Size = new System.Drawing.Size(117, 19);
            this.lbGenderError.TabIndex = 0;
            this.lbGenderError.Text = "Error message";
            this.lbGenderError.Visible = false;
            // 
            // lbNameError
            // 
            this.lbNameError.AutoSize = true;
            this.lbNameError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.Red;
            this.lbNameError.Location = new System.Drawing.Point(9, 192);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(117, 19);
            this.lbNameError.TabIndex = 0;
            this.lbNameError.Text = "Error message";
            this.lbNameError.Visible = false;
            // 
            // lbUsernameError
            // 
            this.lbUsernameError.AutoSize = true;
            this.lbUsernameError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lbUsernameError.Location = new System.Drawing.Point(9, 112);
            this.lbUsernameError.Name = "lbUsernameError";
            this.lbUsernameError.Size = new System.Drawing.Size(117, 19);
            this.lbUsernameError.TabIndex = 0;
            this.lbUsernameError.Text = "Error message";
            this.lbUsernameError.Visible = false;
            // 
            // cbRole
            // 
            this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(13, 717);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(217, 31);
            this.cbRole.TabIndex = 9;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.Location = new System.Drawing.Point(10, 690);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(50, 23);
            this.lbRole.TabIndex = 0;
            this.lbRole.Text = "Role";
            // 
            // txbEmail
            // 
            this.txbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEmail.Location = new System.Drawing.Point(13, 637);
            this.txbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(217, 30);
            this.txbEmail.TabIndex = 8;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(10, 610);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(58, 23);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            // 
            // txbPhone
            // 
            this.txbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPhone.Location = new System.Drawing.Point(13, 557);
            this.txbPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(374, 30);
            this.txbPhone.TabIndex = 7;
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(9, 530);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(65, 23);
            this.lbPhone.TabIndex = 0;
            this.lbPhone.Text = "Phone";
            // 
            // txbCitizenId
            // 
            this.txbCitizenId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCitizenId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCitizenId.Location = new System.Drawing.Point(13, 477);
            this.txbCitizenId.Margin = new System.Windows.Forms.Padding(4);
            this.txbCitizenId.Name = "txbCitizenId";
            this.txbCitizenId.Size = new System.Drawing.Size(374, 30);
            this.txbCitizenId.TabIndex = 6;
            // 
            // lbCitizenId
            // 
            this.lbCitizenId.AutoSize = true;
            this.lbCitizenId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCitizenId.Location = new System.Drawing.Point(10, 450);
            this.lbCitizenId.Name = "lbCitizenId";
            this.lbCitizenId.Size = new System.Drawing.Size(94, 23);
            this.lbCitizenId.TabIndex = 0;
            this.lbCitizenId.Text = "Citizen ID";
            // 
            // txbAddress
            // 
            this.txbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddress.Location = new System.Drawing.Point(13, 397);
            this.txbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(374, 30);
            this.txbAddress.TabIndex = 5;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(10, 370);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(83, 23);
            this.lbAddress.TabIndex = 0;
            this.lbAddress.Text = "Address";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Location = new System.Drawing.Point(13, 318);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(374, 30);
            this.dtpBirthday.TabIndex = 4;
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBirthday.Location = new System.Drawing.Point(10, 292);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(82, 23);
            this.lbBirthday.TabIndex = 0;
            this.lbBirthday.Text = "Birthday";
            // 
            // cbGenderSelector
            // 
            this.cbGenderSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGenderSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenderSelector.FormattingEnabled = true;
            this.cbGenderSelector.Location = new System.Drawing.Point(13, 238);
            this.cbGenderSelector.Margin = new System.Windows.Forms.Padding(4);
            this.cbGenderSelector.Name = "cbGenderSelector";
            this.cbGenderSelector.Size = new System.Drawing.Size(374, 31);
            this.cbGenderSelector.TabIndex = 3;
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGender.Location = new System.Drawing.Point(10, 211);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(76, 23);
            this.lbGender.TabIndex = 0;
            this.lbGender.Text = "Gender";
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(13, 158);
            this.txbName.Margin = new System.Windows.Forms.Padding(4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(374, 30);
            this.txbName.TabIndex = 2;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(9, 131);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // txbUsername
            // 
            this.txbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(13, 78);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(374, 30);
            this.txbUsername.TabIndex = 1;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(9, 51);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(99, 23);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "Username";
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::DesktopApp.Properties.Resources.Quit;
            this.picClose.Location = new System.Drawing.Point(358, 13);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lbGenderFilter);
            this.pnlHeader.Controls.Add(this.picDelete);
            this.pnlHeader.Controls.Add(this.picNew);
            this.pnlHeader.Controls.Add(this.picSearch);
            this.pnlHeader.Controls.Add(this.cbGenderFilter);
            this.pnlHeader.Controls.Add(this.txbSearch);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 119);
            this.pnlHeader.TabIndex = 0;
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::DesktopApp.Properties.Resources.Remove;
            this.picDelete.Location = new System.Drawing.Point(664, 12);
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
            this.picNew.Location = new System.Drawing.Point(628, 12);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(30, 30);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 3;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // picSearch
            // 
            this.picSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::DesktopApp.Properties.Resources.Search;
            this.picSearch.Location = new System.Drawing.Point(476, 12);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(30, 30);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 2;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // cbGenderFilter
            // 
            this.cbGenderFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGenderFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenderFilter.FormattingEnabled = true;
            this.cbGenderFilter.Location = new System.Drawing.Point(13, 77);
            this.cbGenderFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbGenderFilter.Name = "cbGenderFilter";
            this.cbGenderFilter.Size = new System.Drawing.Size(250, 31);
            this.cbGenderFilter.TabIndex = 0;
            this.cbGenderFilter.SelectedValueChanged += new System.EventHandler(this.cbGenderFilter_SelectedValueChanged);
            // 
            // txbSearch
            // 
            this.txbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(13, 13);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(493, 30);
            this.txbSearch.TabIndex = 0;
            this.txbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearch_KeyPress);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.dgUser);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 119);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(700, 747);
            this.pnlBody.TabIndex = 0;
            // 
            // dgUser
            // 
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.Location = new System.Drawing.Point(0, 0);
            this.dgUser.Name = "dgUser";
            this.dgUser.RowHeadersWidth = 51;
            this.dgUser.RowTemplate.Height = 24;
            this.dgUser.Size = new System.Drawing.Size(700, 747);
            this.dgUser.TabIndex = 0;
            // 
            // lbGenderFilter
            // 
            this.lbGenderFilter.AutoSize = true;
            this.lbGenderFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGenderFilter.Location = new System.Drawing.Point(9, 51);
            this.lbGenderFilter.Name = "lbGenderFilter";
            this.lbGenderFilter.Size = new System.Drawing.Size(76, 23);
            this.lbGenderFilter.TabIndex = 0;
            this.lbGenderFilter.Text = "Gender";
            // 
            // formUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1100, 866);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlDetail);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formUser";
            this.Text = "FormUser";
            this.Load += new System.EventHandler(this.formUser_Load);
            this.SizeChanged += new System.EventHandler(this.formUser_SizeChanged);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.ComboBox cbGenderFilter;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.ComboBox cbGenderSelector;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txbCitizenId;
        private System.Windows.Forms.Label lbCitizenId;
        private System.Windows.Forms.Label lbRoleError;
        private System.Windows.Forms.Label lbEmailError;
        private System.Windows.Forms.Label lbPhoneError;
        private System.Windows.Forms.Label lbCitizenIdError;
        private System.Windows.Forms.Label lbAddressError;
        private System.Windows.Forms.Label lbBirthdayError;
        private System.Windows.Forms.Label lbGenderError;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.Label lbUsernameError;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lbGenderFilter;
    }
}