namespace DesktopApp.GUI.UserControls
{
    partial class UserControlService
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picService = new System.Windows.Forms.PictureBox();
            this.lbServiceName = new System.Windows.Forms.Label();
            this.lbServicePrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picService)).BeginInit();
            this.SuspendLayout();
            // 
            // picService
            // 
            this.picService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picService.Image = global::DesktopApp.Properties.Resources.Drink;
            this.picService.Location = new System.Drawing.Point(3, 3);
            this.picService.Name = "picService";
            this.picService.Size = new System.Drawing.Size(244, 289);
            this.picService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picService.TabIndex = 0;
            this.picService.TabStop = false;
            // 
            // lbServiceName
            // 
            this.lbServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbServiceName.AutoSize = true;
            this.lbServiceName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServiceName.Location = new System.Drawing.Point(3, 295);
            this.lbServiceName.Name = "lbServiceName";
            this.lbServiceName.Size = new System.Drawing.Size(137, 24);
            this.lbServiceName.TabIndex = 0;
            this.lbServiceName.Text = "Service name";
            // 
            // lbServicePrice
            // 
            this.lbServicePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbServicePrice.AutoSize = true;
            this.lbServicePrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServicePrice.Location = new System.Drawing.Point(3, 319);
            this.lbServicePrice.Name = "lbServicePrice";
            this.lbServicePrice.Size = new System.Drawing.Size(71, 24);
            this.lbServicePrice.TabIndex = 0;
            this.lbServicePrice.Text = "15.000";
            // 
            // UserControlService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbServicePrice);
            this.Controls.Add(this.lbServiceName);
            this.Controls.Add(this.picService);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlService";
            this.Size = new System.Drawing.Size(250, 350);
            this.Load += new System.EventHandler(this.ucService_Load);
            this.SizeChanged += new System.EventHandler(this.ucService_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picService;
        public System.Windows.Forms.Label lbServiceName;
        public System.Windows.Forms.Label lbServicePrice;
    }
}
