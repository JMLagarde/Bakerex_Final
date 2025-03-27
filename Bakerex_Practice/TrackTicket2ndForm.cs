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
            LoadTicketDetails();
        }

        private void TrackTicket2ndForm_Load(object sender, EventArgs e)
        {
        }
        private void LoadTicketDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT cr.RequestID, 
                   st.StatusName AS Status, 
                   cr.Subject, 
                   cr.CustomerName, 
                   cr.Email, 
                   cr.PhoneNumber, 
                   cr.CompanyName, 
                   it.IssueTypeName AS IssueType, 
                   cr.CreatedAt, 
                   cr.Description, 
                   cr.ProductDetails, 
                   pl.PriorityLevelName AS PriorityLevel, 
                   cr.Technician, 
                   cr.Schedule, 
                   cr.Response 
            FROM CustomerRequests cr
            LEFT JOIN Status st ON cr.StatusID = st.StatusID
            LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
            LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
            WHERE cr.RequestID = @RequestID";

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
                            lblStatus.Text = reader["Status"]?.ToString();
                            lblSubject.Text = reader["Subject"]?.ToString();
                            lblCustomerName.Text = reader["CustomerName"]?.ToString();
                            lblEmail.Text = reader["Email"]?.ToString();
                            lblPhoneNumber.Text = reader["PhoneNumber"]?.ToString();
                            lblCompanyName.Text = reader["CompanyName"]?.ToString();
                            lblIssueType.Text = reader["IssueType"]?.ToString();
                            lblCreatedAt.Text = reader["CreatedAt"]?.ToString();
                            lblDescription.Text = reader["Description"]?.ToString();
                            lblProductDetails.Text = reader["ProductDetails"]?.ToString();
                            lblPriorityLevel.Text = reader["PriorityLevel"]?.ToString();
                            lblTechnician.Text = reader["Technician"]?.ToString()   ;
                            lblSchedule.Text = reader["Schedule"]?.ToString();
                            lblResponse.Text = reader["Response"]?.ToString();
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

        private void lblSubmitTicket_Click(object sender, EventArgs e)
        {
            SubmitRequest submitRequest = new SubmitRequest();
            submitRequest.Show();
            this.Hide();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            MainUser mainUserForm = new MainUser();
            mainUserForm.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }
    }
}

