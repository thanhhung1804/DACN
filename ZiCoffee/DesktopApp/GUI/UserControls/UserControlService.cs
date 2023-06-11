using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DesktopApp.GUI.UserControls
{
    public partial class UserControlService : UserControl
    {
        #region Form Round Corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        public event EventHandler UserControlClick;

        public UserControlService()
        {
            InitializeComponent();
        }

        private void ucService_Load(object sender, EventArgs e)
        {
            WireUpChildControlClickEvents();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void ucService_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void WireUpChildControlClickEvents()
        {
            this.Click += ChildControl_Click;
            picService.Click += ChildControl_Click;
            lbServiceName.Click += ChildControl_Click;
            lbServicePrice.Click += ChildControl_Click;
        }

        private void ChildControl_Click(object sender, EventArgs e)
        {
            OnUserControlClick();
        }

        protected virtual void OnUserControlClick()
        {
            UserControlClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
