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
            this.lbProgramName = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picMaximize = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lbPendingTable = new System.Windows.Forms.Label();
            this.lbReadyTable = new System.Windows.Forms.Label();
            this.lbUsingTable = new System.Windows.Forms.Label();
            this.TotalTable = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.pnlAccountSideBar = new System.Windows.Forms.Panel();
            this.txbRole = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.txbCitizenId = new System.Windows.Forms.TextBox();
            this.txbBirthday = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbFullName = new System.Windows.Forms.TextBox();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlMarginLeft = new System.Windows.Forms.Panel();
            this.pnlSwitch = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picShowAccount = new System.Windows.Forms.PictureBox();
            this.picHideAccount = new System.Windows.Forms.PictureBox();
            this.pnlBusinessSideBar = new System.Windows.Forms.Panel();
            this.btnLockTable = new System.Windows.Forms.Button();
            this.btnMoveTable = new System.Windows.Forms.Button();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.txbSelectingTable = new System.Windows.Forms.TextBox();
            this.fpnlArea = new System.Windows.Forms.FlowLayoutPanel();
            this.fpnlTable = new System.Windows.Forms.FlowLayoutPanel();
            this.btnManage = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlAccountSideBar.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlSwitch.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHideAccount)).BeginInit();
            this.pnlBusinessSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
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
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
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
            // pnlAccountSideBar
            // 
            this.pnlAccountSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlAccountSideBar.Controls.Add(this.btnManage);
            this.pnlAccountSideBar.Controls.Add(this.txbRole);
            this.pnlAccountSideBar.Controls.Add(this.btnLogOut);
            this.pnlAccountSideBar.Controls.Add(this.btnChangePassword);
            this.pnlAccountSideBar.Controls.Add(this.txbAddress);
            this.pnlAccountSideBar.Controls.Add(this.txbPhone);
            this.pnlAccountSideBar.Controls.Add(this.txbCitizenId);
            this.pnlAccountSideBar.Controls.Add(this.txbBirthday);
            this.pnlAccountSideBar.Controls.Add(this.panel1);
            this.pnlAccountSideBar.Controls.Add(this.txbFullName);
            this.pnlAccountSideBar.Controls.Add(this.pnlAvatar);
            this.pnlAccountSideBar.Controls.Add(this.pnlSwitch);
            this.pnlAccountSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccountSideBar.Location = new System.Drawing.Point(0, 50);
            this.pnlAccountSideBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccountSideBar.Name = "pnlAccountSideBar";
            this.pnlAccountSideBar.Size = new System.Drawing.Size(300, 720);
            this.pnlAccountSideBar.TabIndex = 0;
            // 
            // txbRole
            // 
            this.txbRole.Cursor = System.Windows.Forms.Cursors.No;
            this.txbRole.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRole.Location = new System.Drawing.Point(60, 325);
            this.txbRole.MaxLength = 20;
            this.txbRole.Name = "txbRole";
            this.txbRole.ReadOnly = true;
            this.txbRole.Size = new System.Drawing.Size(240, 30);
            this.txbRole.TabIndex = 0;
            this.txbRole.TabStop = false;
            this.txbRole.Text = "Admin";
            this.txbRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLogOut.FlatAppearance.BorderSize = 3;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(60, 617);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(240, 50);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChangePassword.FlatAppearance.BorderSize = 3;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(60, 505);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(240, 50);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txbAddress
            // 
            this.txbAddress.Cursor = System.Windows.Forms.Cursors.No;
            this.txbAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddress.Location = new System.Drawing.Point(60, 469);
            this.txbAddress.MaxLength = 20;
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.ReadOnly = true;
            this.txbAddress.Size = new System.Drawing.Size(240, 30);
            this.txbAddress.TabIndex = 0;
            this.txbAddress.TabStop = false;
            this.txbAddress.Text = "441/42D Điện Biên Phủ, P24, Q.Bình Thạnh";
            this.txbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbPhone
            // 
            this.txbPhone.Cursor = System.Windows.Forms.Cursors.No;
            this.txbPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPhone.Location = new System.Drawing.Point(60, 433);
            this.txbPhone.MaxLength = 20;
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.ReadOnly = true;
            this.txbPhone.Size = new System.Drawing.Size(240, 30);
            this.txbPhone.TabIndex = 0;
            this.txbPhone.TabStop = false;
            this.txbPhone.Text = "0797972243";
            this.txbPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbCitizenId
            // 
            this.txbCitizenId.Cursor = System.Windows.Forms.Cursors.No;
            this.txbCitizenId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCitizenId.Location = new System.Drawing.Point(60, 397);
            this.txbCitizenId.MaxLength = 20;
            this.txbCitizenId.Name = "txbCitizenId";
            this.txbCitizenId.ReadOnly = true;
            this.txbCitizenId.Size = new System.Drawing.Size(240, 30);
            this.txbCitizenId.TabIndex = 0;
            this.txbCitizenId.TabStop = false;
            this.txbCitizenId.Text = "273640209";
            this.txbCitizenId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbBirthday
            // 
            this.txbBirthday.Cursor = System.Windows.Forms.Cursors.No;
            this.txbBirthday.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBirthday.Location = new System.Drawing.Point(60, 361);
            this.txbBirthday.MaxLength = 20;
            this.txbBirthday.Name = "txbBirthday";
            this.txbBirthday.ReadOnly = true;
            this.txbBirthday.Size = new System.Drawing.Size(240, 30);
            this.txbBirthday.TabIndex = 0;
            this.txbBirthday.TabStop = false;
            this.txbBirthday.Text = "18/04/1998";
            this.txbBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 274);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 446);
            this.panel1.TabIndex = 0;
            // 
            // txbFullName
            // 
            this.txbFullName.Cursor = System.Windows.Forms.Cursors.No;
            this.txbFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.Location = new System.Drawing.Point(60, 289);
            this.txbFullName.MaxLength = 20;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.ReadOnly = true;
            this.txbFullName.Size = new System.Drawing.Size(240, 30);
            this.txbFullName.TabIndex = 0;
            this.txbFullName.TabStop = false;
            this.txbFullName.Text = "Lý Thanh Hùng";
            this.txbFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Controls.Add(this.picAvatar);
            this.pnlAvatar.Controls.Add(this.pnlMarginLeft);
            this.pnlAvatar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAvatar.Location = new System.Drawing.Point(0, 50);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(300, 224);
            this.pnlAvatar.TabIndex = 0;
            // 
            // picAvatar
            // 
            this.picAvatar.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAvatar.Image = global::DesktopApp.Properties.Resources.Avatar;
            this.picAvatar.Location = new System.Drawing.Point(60, 0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(240, 208);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 3;
            this.picAvatar.TabStop = false;
            // 
            // pnlMarginLeft
            // 
            this.pnlMarginLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarginLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMarginLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMarginLeft.Name = "pnlMarginLeft";
            this.pnlMarginLeft.Size = new System.Drawing.Size(60, 224);
            this.pnlMarginLeft.TabIndex = 0;
            // 
            // pnlSwitch
            // 
            this.pnlSwitch.Controls.Add(this.panel2);
            this.pnlSwitch.Controls.Add(this.picHideAccount);
            this.pnlSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSwitch.Location = new System.Drawing.Point(0, 0);
            this.pnlSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSwitch.Name = "pnlSwitch";
            this.pnlSwitch.Size = new System.Drawing.Size(300, 50);
            this.pnlSwitch.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.picShowAccount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 50);
            this.panel2.TabIndex = 0;
            // 
            // picShowAccount
            // 
            this.picShowAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowAccount.Image = global::DesktopApp.Properties.Resources.right_arrow;
            this.picShowAccount.Location = new System.Drawing.Point(12, 7);
            this.picShowAccount.Name = "picShowAccount";
            this.picShowAccount.Size = new System.Drawing.Size(35, 35);
            this.picShowAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowAccount.TabIndex = 0;
            this.picShowAccount.TabStop = false;
            this.picShowAccount.Visible = false;
            this.picShowAccount.Click += new System.EventHandler(this.picShowAccount_Click);
            // 
            // picHideAccount
            // 
            this.picHideAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHideAccount.Image = global::DesktopApp.Properties.Resources.left_arrow;
            this.picHideAccount.Location = new System.Drawing.Point(250, 7);
            this.picHideAccount.Name = "picHideAccount";
            this.picHideAccount.Size = new System.Drawing.Size(35, 35);
            this.picHideAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHideAccount.TabIndex = 8;
            this.picHideAccount.TabStop = false;
            this.picHideAccount.Click += new System.EventHandler(this.picHideAccount_Click);
            // 
            // pnlBusinessSideBar
            // 
            this.pnlBusinessSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlBusinessSideBar.Controls.Add(this.btnLockTable);
            this.pnlBusinessSideBar.Controls.Add(this.btnMoveTable);
            this.pnlBusinessSideBar.Controls.Add(this.btnMergeTable);
            this.pnlBusinessSideBar.Controls.Add(this.btnOrder);
            this.pnlBusinessSideBar.Controls.Add(this.btnPay);
            this.pnlBusinessSideBar.Controls.Add(this.txbSelectingTable);
            this.pnlBusinessSideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBusinessSideBar.Location = new System.Drawing.Point(900, 50);
            this.pnlBusinessSideBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBusinessSideBar.Name = "pnlBusinessSideBar";
            this.pnlBusinessSideBar.Size = new System.Drawing.Size(300, 720);
            this.pnlBusinessSideBar.TabIndex = 1;
            // 
            // btnLockTable
            // 
            this.btnLockTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockTable.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLockTable.FlatAppearance.BorderSize = 3;
            this.btnLockTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockTable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockTable.Location = new System.Drawing.Point(0, 50);
            this.btnLockTable.Name = "btnLockTable";
            this.btnLockTable.Size = new System.Drawing.Size(300, 50);
            this.btnLockTable.TabIndex = 0;
            this.btnLockTable.Text = "Lock";
            this.btnLockTable.UseVisualStyleBackColor = true;
            // 
            // btnMoveTable
            // 
            this.btnMoveTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveTable.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnMoveTable.FlatAppearance.BorderSize = 3;
            this.btnMoveTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveTable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveTable.Location = new System.Drawing.Point(0, 106);
            this.btnMoveTable.Name = "btnMoveTable";
            this.btnMoveTable.Size = new System.Drawing.Size(300, 50);
            this.btnMoveTable.TabIndex = 0;
            this.btnMoveTable.Text = "Move";
            this.btnMoveTable.UseVisualStyleBackColor = true;
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMergeTable.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnMergeTable.FlatAppearance.BorderSize = 3;
            this.btnMergeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeTable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeTable.Location = new System.Drawing.Point(0, 162);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(300, 50);
            this.btnMergeTable.TabIndex = 0;
            this.btnMergeTable.Text = "Merge";
            this.btnMergeTable.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOrder.FlatAppearance.BorderSize = 3;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(0, 218);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(300, 50);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnPay
            // 
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPay.FlatAppearance.BorderSize = 3;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(0, 274);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(300, 50);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txbSelectingTable
            // 
            this.txbSelectingTable.Cursor = System.Windows.Forms.Cursors.No;
            this.txbSelectingTable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSelectingTable.Location = new System.Drawing.Point(0, 12);
            this.txbSelectingTable.MaxLength = 20;
            this.txbSelectingTable.Name = "txbSelectingTable";
            this.txbSelectingTable.ReadOnly = true;
            this.txbSelectingTable.Size = new System.Drawing.Size(300, 30);
            this.txbSelectingTable.TabIndex = 0;
            this.txbSelectingTable.TabStop = false;
            this.txbSelectingTable.Text = "No Selected Table";
            this.txbSelectingTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fpnlArea
            // 
            this.fpnlArea.BackColor = System.Drawing.Color.Transparent;
            this.fpnlArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnlArea.Location = new System.Drawing.Point(300, 50);
            this.fpnlArea.Name = "fpnlArea";
            this.fpnlArea.Size = new System.Drawing.Size(600, 200);
            this.fpnlArea.TabIndex = 0;
            // 
            // fpnlTable
            // 
            this.fpnlTable.BackColor = System.Drawing.Color.Transparent;
            this.fpnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlTable.Location = new System.Drawing.Point(300, 250);
            this.fpnlTable.Name = "fpnlTable";
            this.fpnlTable.Size = new System.Drawing.Size(600, 520);
            this.fpnlTable.TabIndex = 0;
            // 
            // btnManage
            // 
            this.btnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManage.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnManage.FlatAppearance.BorderSize = 3;
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.Location = new System.Drawing.Point(60, 561);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(240, 50);
            this.btnManage.TabIndex = 0;
            this.btnManage.Text = "Manage";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // formBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.fpnlTable);
            this.Controls.Add(this.fpnlArea);
            this.Controls.Add(this.pnlBusinessSideBar);
            this.Controls.Add(this.pnlAccountSideBar);
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
            this.Load += new System.EventHandler(this.formBusiness_Load);
            this.SizeChanged += new System.EventHandler(this.formBusiness_SizeChanged);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlAccountSideBar.ResumeLayout(false);
            this.pnlAccountSideBar.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlSwitch.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShowAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHideAccount)).EndInit();
            this.pnlBusinessSideBar.ResumeLayout(false);
            this.pnlBusinessSideBar.PerformLayout();
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
        private System.Windows.Forms.Panel pnlAccountSideBar;
        private System.Windows.Forms.Panel pnlSwitch;
        private System.Windows.Forms.PictureBox picShowAccount;
        private System.Windows.Forms.PictureBox picHideAccount;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlMarginLeft;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.TextBox txbCitizenId;
        private System.Windows.Forms.TextBox txbBirthday;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbFullName;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txbRole;
        private System.Windows.Forms.Panel pnlBusinessSideBar;
        private System.Windows.Forms.Button btnLockTable;
        private System.Windows.Forms.Button btnMoveTable;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txbSelectingTable;
        private System.Windows.Forms.FlowLayoutPanel fpnlArea;
        private System.Windows.Forms.FlowLayoutPanel fpnlTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnManage;
    }
}