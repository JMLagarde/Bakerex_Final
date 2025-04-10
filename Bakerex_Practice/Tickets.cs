using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakerex_Practice
{
    public partial class Tickets : Form
    {
        private int requestID;
        private int adminId;

        public Tickets(int requestID, int adminId)
        {
            InitializeComponent();
            this.requestID = requestID;
            this.adminId = adminId;
            LoadTechnicians();
            LoadStatuses();
            LoadTicketDetails();
        }

        private void LoadTicketDetails()
        {
            string query = @"
            SELECT cr.RequestID, cr.CustomerName, cr.Email, cr.PhoneNumber, cr.CompanyName, 
                   it.IssueTypeName, cr.Subject, cr.Description, cr.ProductDetails, 
                   pl.PriorityLevelName, cr.CreatedAt, s.StatusID, s.StatusName, 
                   cr.Response, cr.Technician, cr.Schedule
            FROM CustomerRequests cr
            LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
            LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
            LEFT JOIN Status s ON cr.StatusID = s.StatusID
            WHERE cr.RequestID = @RequestID";

            SqlParameter[] parameters = { new SqlParameter("@RequestID", requestID) };
            DataTable ticketDetails = DBHelper.ExecuteQuery(query, parameters);

            if (ticketDetails.Rows.Count > 0)
            {
                DataRow row = ticketDetails.Rows[0];

                lblTicketId.Text = row["RequestID"].ToString();
                lblCustomerName.Text = row["CustomerName"].ToString();
                lblEmail.Text = row["Email"].ToString();
                lblPhoneNumber.Text = row["PhoneNumber"].ToString();
                lblCompanyName.Text = row["CompanyName"].ToString();
                lblIssueType.Text = row["IssueTypeName"].ToString();
                lblSubject.Text = row["Subject"].ToString();
                lblDescription.Text = row["Description"].ToString();
                lblProductDetails.Text = row["ProductDetails"].ToString();
                lblPriorityLevel.Text = row["PriorityLevelName"].ToString();
                lblCreatedAt.Text = Convert.ToDateTime(row["CreatedAt"]).ToString("yyyy-MM-dd HH:mm");

                if (row["StatusID"] != DBNull.Value)
                {
                    int statusId = Convert.ToInt32(row["StatusID"]);
                    cbxStatus.SelectedValue = statusId;
                }

                txtResponse.Text = row["Response"] != DBNull.Value ? row["Response"].ToString() : "";
                if (row["Technician"] != DBNull.Value)
                {
                    string savedTechnician = row["Technician"].ToString();
                    for (int i = 0; i < cbxTechnician.Items.Count; i++)
                    {
                        if (cbxTechnician.Items[i].ToString().Equals(savedTechnician, StringComparison.OrdinalIgnoreCase))
                        {
                            cbxTechnician.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cbxTechnician.SelectedIndex = -1;
                }
                if (row["Schedule"] != DBNull.Value)
                {
                    dtmSchedule.Value = Convert.ToDateTime(row["Schedule"]);
                }
                else
                {
                    dtmSchedule.Value = DateTime.Now;
                }
            }
        }


        private void LoadStatuses()
        {
            string query = "SELECT StatusID, StatusName FROM Status";
            DataTable statusData = DBHelper.ExecuteQuery(query);

            cbxStatus.Items.Clear();
            var statusList = new List<KeyValuePair<int, string>>();

            foreach (DataRow row in statusData.Rows)
            {
                statusList.Add(new KeyValuePair<int, string>(Convert.ToInt32(row["StatusID"]), row["StatusName"].ToString()));
            }

            cbxStatus.DataSource = new BindingSource(statusList, null);
            cbxStatus.DisplayMember = "Value";
            cbxStatus.ValueMember = "Key";
        }

        private void LoadTechnicians()
        {
            string query = "SELECT FullName FROM Admin WHERE RoleID = (SELECT RoleID FROM Role WHERE RoleName = 'Technician')";
            DataTable technicianData = DBHelper.ExecuteQuery(query);

            cbxTechnician.Items.Clear();
            foreach (DataRow row in technicianData.Rows)
            {
                cbxTechnician.Items.Add(row["FullName"].ToString());
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedValue == null)
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int statusID = Convert.ToInt32(cbxStatus.SelectedValue);
            string newStatus = cbxStatus.Text;
            string technician = cbxTechnician.SelectedItem != null ? cbxTechnician.SelectedItem.ToString() : null;
            string response = txtResponse.Text;

            string query = @"
                UPDATE CustomerRequests 
                SET StatusID = @StatusID, Response = @Response, Technician = @Technician, Schedule = @Schedule
                WHERE RequestID = @RequestID;";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", requestID),
                new SqlParameter("@StatusID", statusID),
                new SqlParameter("@Response", string.IsNullOrEmpty(response) ? (object)DBNull.Value : response),
                new SqlParameter("@Technician", string.IsNullOrEmpty(technician) ? (object)DBNull.Value : technician),
                new SqlParameter("@Schedule", dtmSchedule.Value)
            };

            try
            {
                DBHelper.ExecuteNonQuery(query, parameters);
                UpdateStatus(requestID, newStatus, technician, response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating request: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStatus(int requestID, string newStatus, string technician, string response)
        {
            string query = @"
                INSERT INTO RequestStatusHistory (RequestID, Status, Technician, UpdatedBy, UpdatedAt, Response)
                VALUES (@RequestID, @NewStatus, @Technician, @UpdatedBy, GETDATE(), @Response);";

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", requestID),
                new SqlParameter("@NewStatus", newStatus),
                new SqlParameter("@Technician", string.IsNullOrEmpty(technician) ? (object)DBNull.Value : technician),
                new SqlParameter("@UpdatedBy", adminId),
                new SqlParameter("@Response", string.IsNullOrEmpty(response) ? (object)DBNull.Value : response)
            };

            try
            {
                DBHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Ticket status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainDashboard(adminId).Show();
        }

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Technicians(adminId).Show();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Summary(adminId).Show();
        }
    }
}

