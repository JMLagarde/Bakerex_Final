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
    public partial class TrackTicket2ndForm : Form
    {
        private string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        private int requestID;

        public TrackTicket2ndForm(int requestID)
        {
            InitializeComponent();
            this.requestID = requestID;
        }

        private void TrackTicket2ndForm_Load(object sender, EventArgs e)
        {
            LoadTicketDetails();
        }
        private void LoadTicketDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT RequestID, Status, Subject, CustomerName, Email, PhoneNumber, 
                         CompanyName, IssueType, CreatedAt, Description, ProductDetails, 
                         PriorityLevel, Technician, Schedule, Response 
                  FROM CustomerRequests 
                  WHERE RequestID = @RequestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Ensure that requestID is passed as an integer
                    cmd.Parameters.AddWithValue("@RequestID", requestID); // requestID should be an int

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read()) // Check if a record was found
                        {
                            // Populate your form controls with the data
                            lblTicketId.Text = reader["RequestID"].ToString();
                            lblStatus.Text = reader["Status"].ToString();
                            lblSubject.Text = reader["Subject"].ToString();
                            lblCustomerName.Text = reader["CustomerName"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblPhoneNumber.Text = reader["PhoneNumber"].ToString();
                            lblCompanyName.Text = reader["CompanyName"].ToString();
                            lblIssueType.Text = reader["IssueType"].ToString();
                            lblCreatedAt.Text = reader["CreatedAt"].ToString();
                            lblDescription.Text = reader["Description"].ToString();
                            lblProductDetails.Text = reader["ProductDetails"].ToString();
                            lblPriorityLevel.Text = reader["PriorityLevel"].ToString();
                            lblTechnician.Text = reader["Technician"].ToString();
                            lblSchedule.Text = reader["Schedule"].ToString();
                            lblResponse.Text = reader["Response"].ToString();
                        }
                        else
                        {
                            MessageBox.Show($"No ticket found with the specified Request ID: {requestID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

