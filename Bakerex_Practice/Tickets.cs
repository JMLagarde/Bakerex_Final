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
using DevExpress.DataAccess.Native.Web;

namespace Bakerex_Practice
{
    public partial class Tickets : Form
    {
        private int requestID;
        private int adminId;
        private string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";

        public Tickets(int requestID, int adminId)
        {
            InitializeComponent();
            this.requestID = requestID;
            this.adminId = adminId;
            LoadTicketDetails();
            LoadTechnicians();
            LoadStatuses();
        }

        private void LoadTicketDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT cr.RequestID, cr.CustomerName, cr.Email, cr.CompanyName, 
                   it.IssueTypeName, cr.Subject, cr.Description, cr.ProductDetails, 
                   pl.PriorityLevelName, cr.CreatedAt, s.StatusName, 
                   cr.Response, cr.Technician, cr.Schedule
            FROM CustomerRequests cr
            LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
            LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
            LEFT JOIN Status s ON cr.StatusID = s.StatusID
            WHERE cr.RequestID = @RequestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTicketId.Text = reader["RequestID"].ToString();
                                lblCustomerName.Text = reader["CustomerName"].ToString();
                                lblEmail.Text = reader["Email"].ToString();
                                lblCompanyName.Text = reader["CompanyName"].ToString();
                                lblIssueType.Text = reader["IssueTypeName"].ToString(); 
                                lblSubject.Text = reader["Subject"].ToString();
                                lblDescription.Text = reader["Description"].ToString();
                                lblProductDetails.Text = reader["ProductDetails"].ToString();
                                lblPriorityLevel.Text = reader["PriorityLevelName"].ToString(); 
                                lblCreatedAt.Text = Convert.ToDateTime(reader["CreatedAt"]).ToString("yyyy-MM-dd HH:mm");
                                cbxStatus.SelectedValue = reader["StatusName"].ToString();


                                txtResponse.Text = reader["Response"] != DBNull.Value ? reader["Response"].ToString() : "";
                                cbxTechnician.SelectedItem = reader["Technician"] != DBNull.Value ? reader["Technician"].ToString() : null;
                                dtmSchedule.Value = reader["Schedule"] != DBNull.Value ? Convert.ToDateTime(reader["Schedule"]) : DateTime.Now;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void LoadTechnicians()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName FROM Admin WHERE RoleID = (SELECT RoleID FROM Role WHERE RoleName = 'Technician')";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbxTechnician.Items.Clear();
                            while (reader.Read())
                            {
                                cbxTechnician.Items.Add(reader["FullName"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadStatuses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StatusID, StatusName FROM Status";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbxStatus.Items.Clear();
                            var statusList = new List<KeyValuePair<int, string>>();

                            while (reader.Read())
                            {
                                statusList.Add(new KeyValuePair<int, string>(
                                    Convert.ToInt32(reader["StatusID"]),
                                    reader["StatusName"].ToString()
                                ));
                            }

                            cbxStatus.DataSource = new BindingSource(statusList, null);
                            cbxStatus.DisplayMember = "Value"; 
                            cbxStatus.ValueMember = "Key";  
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        UPDATE CustomerRequests 
        SET StatusID = @StatusID, Response = @Response, Technician = @Technician, Schedule = @Schedule
        WHERE RequestID = @RequestID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    cmd.Parameters.AddWithValue("@StatusID", statusID);
                    cmd.Parameters.AddWithValue("@Response", string.IsNullOrEmpty(response) ? (object)DBNull.Value : response);
                    cmd.Parameters.AddWithValue("@Technician", string.IsNullOrEmpty(technician) ? (object)DBNull.Value : technician);
                    cmd.Parameters.AddWithValue("@Schedule", dtmSchedule.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        UpdateStatus(requestID, newStatus, technician, response);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating request: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void UpdateStatus(int requestID, string newStatus, string technician, string response)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        INSERT INTO RequestStatusHistory (RequestID, Status, Technician, UpdatedBy, UpdatedAt, Response)
        VALUES (@RequestID, @NewStatus, @Technician, @UpdatedBy, GETDATE(), @Response);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                    cmd.Parameters.AddWithValue("@Technician", string.IsNullOrEmpty(technician) ? (object)DBNull.Value : technician);
                    cmd.Parameters.AddWithValue("@UpdatedBy", adminId); 
                    cmd.Parameters.AddWithValue("@Response", string.IsNullOrEmpty(response) ? (object)DBNull.Value : response);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating status history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            MainDashboard mainDashboard = new MainDashboard(adminId);
            mainDashboard.Show();
            this.Hide();
        }

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            Technicians technicians = new Technicians(adminId);
            technicians.Show();
            this.Hide();
        }

        private void lblLogut_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }


        private void lblSummary_Click(object sender, EventArgs e)
        {
            Summary summaryForm = new Summary(adminId);
            summaryForm.Show();
            this.Hide();
        }

    }
}

