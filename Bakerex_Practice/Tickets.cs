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
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        public Tickets(int requestID, int adminId)
        {
            InitializeComponent();
            this.requestID = requestID;
            this.adminId = adminId;
            LoadTicketDetails();
            LoadTechnicians();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {

        }
        private void LoadTicketDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT RequestID, CustomerName, Email, CompanyName, IssueType, Subject, 
                                        Description, ProductDetails, PriorityLevel, CreatedAt, Status, Response, Technician
                                 FROM CustomerRequests WHERE RequestID = @RequestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblTicketId.Text = reader["RequestID"].ToString();
                            lblCustomerName.Text = reader["CustomerName"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblCompanyName.Text = reader["CompanyName"].ToString();
                            lblIssueType.Text = reader["IssueType"].ToString();
                            lblSubject.Text = reader["Subject"].ToString();
                            lblDescription.Text = reader["Description"].ToString();
                            lblProductDetails.Text = reader["ProductDetails"].ToString();
                            lblPriorityLevel.Text = reader["PriorityLevel"].ToString();
                            lblCreatedAt.Text = reader["CreatedAt"].ToString();
                            cbxStatus.SelectedItem = reader["Status"].ToString();
                            txtResponse.Text = reader["Response"].ToString();
                            cbxTechnician.SelectedItem = reader["Technician"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Hide();
            }

        }
        private void LoadTechnicians()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName FROM Registration WHERE Role = 'Technician'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cbxTechnician.Items.Add(reader["FullName"].ToString());
                        }
                        reader.Close();
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE CustomerRequests 
                         SET Status = @Status, Response = @Response, Technician = @Technician, Schedule = @Schedule
                         WHERE RequestID = @RequestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", cbxStatus.SelectedItem?.ToString() ?? "Pending");
                    cmd.Parameters.AddWithValue("@Response", txtResponse.Text);

                    if (cbxTechnician.SelectedItem != null)
                        cmd.Parameters.AddWithValue("@Technician", cbxTechnician.SelectedItem.ToString());
                    else
                        cmd.Parameters.AddWithValue("@Technician", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Schedule", dtmSchedule.Value); 

                    cmd.Parameters.AddWithValue("@RequestID", requestID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Hide(); ;
        }

        private void lblLogut_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            Tickets tickets = new Tickets(requestID, adminId);
            tickets.Show();
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
