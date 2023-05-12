using DesktopApp.DAO;
using DesktopApp.DTO;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formRole : Form
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
        
        public formRole()
        {
            InitializeComponent();
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = true;
            txbName.Text = string.Empty;
            rtxbDescription.Text = string.Empty;
            //reload action
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            //check selected item
            //delete record in database
            //Notify result
            LoadData();
            pnlDetail.Visible = false;
        }

        private void formRole_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadData();
        }

        private void formRole_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //validate fields
            //update database
            //Notify result
            LoadData();
            pnlDetail.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void LoadData()
        {
            RoleDAO roleDAO = new RoleDAO();
            List<RoleDTO> roles = roleDAO.GetAll();
            dgRole.DataSource = roles;
        }
    }
}
