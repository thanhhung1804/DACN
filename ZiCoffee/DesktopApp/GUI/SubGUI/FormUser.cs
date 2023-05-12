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
    public partial class formUser : Form
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

        public formUser()
        {
            InitializeComponent();
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = true;
            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            picAvatar.Image = Properties.Resources.Avatar;
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            //check selected item
            //delete record in database
            //Notify
            LoadData();
            pnlDetail.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            //upload avatar
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //valid datafield
            //insert or update data
            //Notify
            LoadData();
            pnlDetail.Visible = false;
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int enterKeycode = 13;
            if (e.KeyChar == enterKeycode)
            {
                LoadData();
            }
        }

        private void cbGenderFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            LoadData();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void formUser_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void LoadData()
        {
            UserDAO userDAO = new UserDAO();
            List<UserDTO> users = userDAO.GetAll();
            dgUser.DataSource = users;
        }
    }
}
