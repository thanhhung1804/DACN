using DesktopApp.Common;
using DesktopApp.DAO;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DesktopApp.GUI.SubGUI
{
    public partial class formTable : Form
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

        private TableDTO currentSelectedTable;
        private List<string> authorizedActions;

        public formTable(List<string> authorizedActions)
        {
            InitializeComponent();
            currentSelectedTable = null;
            this.authorizedActions = authorizedActions;
        }

        private void formTable_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));

            string[] tableStatusFilter = Enum.GetNames(typeof(TableStatus));
            cbStatusFilter.Items.AddRange(tableStatusFilter);
            cbStatusFilter.SelectedIndex = (int)TableStatus.All;

            string[] tableStatusSelector = Enum.GetNames(typeof(TableStatus)).Except(new[] { TableStatus.All.ToString() }).ToArray();
            cbStatusSelector.Items.AddRange(tableStatusSelector);
            cbStatusSelector.SelectedIndex = (int)TableStatus.Ready;

            List<AreaDTO> selectorAreas = new AreaDAO().GetAll();
            cbAreaSelector.DataSource = selectorAreas;
            cbAreaSelector.DisplayMember = "Name";

            List<AreaDTO> filterAreas = new AreaDAO().GetAll();
            AreaDTO filterAllArea = new AreaDTO(name: "All");
            filterAreas.Add(filterAllArea);
            cbAreaFilter.DataSource = filterAreas;
            cbAreaFilter.DisplayMember = "Name";
            cbAreaFilter.SelectedItem = filterAllArea;

            LoadData();
        }

        private void formTable_SizeChanged(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void pnlBody_SizeChanged(object sender, EventArgs e)
        {
            pnlBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBody.Width, pnlBody.Height, 20, 20));
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            currentSelectedTable = null;

            pnlDetail.Visible = true;
            btnDone.Text = "Add";

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
            rtxbDescription.Text = string.Empty;

            foreach (Control control in pnlDetail.Controls)
            {
                if (control is Label && (control as Label).Name.EndsWith("Error"))
                {
                    (control as Label).Visible = false;
                }
            }
        }

        private void dgTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTable.SelectedRows.Count <= 0)
            {
                return;
            }

            currentSelectedTable = (TableDTO)dgTable.SelectedRows[0].DataBoundItem;
            if (currentSelectedTable != null)
            {
                pnlDetail.Visible = true;
                btnDone.Text = "Update";

                txbName.Text = currentSelectedTable.Name;
                rtxbDescription.Text = currentSelectedTable.Description;
                cbStatusSelector.SelectedIndex = cbStatusSelector.FindString(currentSelectedTable.Status.ToString());
                cbAreaSelector.SelectedIndex = cbAreaSelector.FindString(currentSelectedTable.AreaName);

                foreach (Control control in pnlDetail.Controls)
                {
                    if (control is Label && (control as Label).Name.EndsWith("Error"))
                    {
                        (control as Label).Visible = false;
                    }
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable == null)
            {
                if(ValidateName() && ValidateDescription())
                {
                    CreateTable();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (ValidateName() && ValidateDescription())
                {
                    UpdateTable();
                }
                else
                {
                    return;
                }
                
            }
            LoadData();
            pnlDetail.Visible = false;
        }

        private bool ValidateDescription()
        {
            if (rtxbDescription.Text.Length >100)
            {
                lbDescriptionError.Visible = true;
                lbDescriptionError.Text = "Description has to contain maximum 100 characters!!!";
                return false;
            }
            else
            {
                lbDescriptionError.Visible = false;
                return true;
            }
        }

        private bool ValidateName()
        {
            if (txbName.Text.Length > 40 || txbName.Text.Length <= 0)
            {
                lbNameError.Visible = true;
                lbNameError.Text = "Name has to contain character between 1 and 40!!!";
                return false;
            }
            else
            {
                lbNameError.Visible = false;
                return true;
            }
        }

        private void CreateTable()
        {
            if (!authorizedActions.Contains(Constants.ADD_TABLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Create";
            bool result = new TableDAO().Create(
                name: txbName.Text,
                areaId: (cbAreaSelector.SelectedItem as AreaDTO).AreaId,
                status: (TableStatus)cbStatusSelector.SelectedIndex,
                description: rtxbDescription.Text
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void UpdateTable()
        {
            if (!authorizedActions.Contains(Constants.EDIT_TABLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string actionType = "Update";
            bool result = new TableDAO().Update(
                tableId: currentSelectedTable.TableId,
                name: txbName.Text,
                areaId: (cbAreaSelector.SelectedItem as AreaDTO).AreaId,
                status: (TableStatus)cbStatusSelector.SelectedIndex,
                description: rtxbDescription.Text
            );

            if (!result)
            {
                Notify(actionType, isSucceed: result);
                return;
            }
            Notify(actionType, isSucceed: result);
        }

        private void Notify(string actionType, bool isSucceed = true)
        {
            if (isSucceed)
            {
                MessageBox.Show(
                    text: string.Format("{0} successful", actionType),
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    text: string.Format("{0} fail", actionType),
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );
            }
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (!authorizedActions.Contains(Constants.DELETE_TABLE))
            {
                MessageBox.Show("Permission denied", "Unauthorization", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (currentSelectedTable == null)
            {
                MessageBox.Show(
                    text: "Please choose an table",
                    caption: "Notification",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.None
                );
                return;
            }

            var choosen = MessageBox.Show(
                text: "Are you sure that you want to delete this table",
                caption: "Confirmation",
                buttons: MessageBoxButtons.OKCancel,
                icon: MessageBoxIcon.Question
            );
            if (choosen == DialogResult.Cancel)
            {
                return;
            }

            bool result = new TableDAO().Delete(tableId: currentSelectedTable.TableId);

            Notify(actionType: "Delete", isSucceed: result);

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

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbAreaFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Guid areaId = Guid.Empty;
            if (cbAreaFilter.SelectedItem != null)
            {
                areaId = (cbAreaFilter.SelectedItem as AreaDTO).AreaId;
            }

            TableStatus status = TableStatus.All;
            if (cbStatusFilter.SelectedItem != null)
            {
                status = (TableStatus)cbStatusFilter.SelectedIndex;
            }

            List<TableDTO> tables = new TableDAO().GetAll(
                areaId: areaId,
                keyword: txbSearch.Text,
                status: status
            );
            dgTable.DataSource = tables;

            dgTable.AutoGenerateColumns = false;
            dgTable.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "colName";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgTable.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "colDescription";
            descriptionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descriptionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgTable.Columns.Add(descriptionColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "colStatus";
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            statusColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgTable.Columns.Add(statusColumn);

            DataGridViewTextBoxColumn areaNameColumn = new DataGridViewTextBoxColumn();
            areaNameColumn.DataPropertyName = "AreaName";
            areaNameColumn.HeaderText = "Area";
            areaNameColumn.Name = "colAreaName";
            areaNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            areaNameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgTable.Columns.Add(areaNameColumn);
        }
    }
}
