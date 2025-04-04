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

            SqlParameter[] parameters = {
                new SqlParameter("@RequestID", requestID)
            };

            try
            {
                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTicketId.Text = row["RequestID"].ToString();
                    lblStatus.Text = row["Status"]?.ToString();
                    lblSubject.Text = row["Subject"]?.ToString();
                    lblCustomerName.Text = row["CustomerName"]?.ToString();
                    lblEmail.Text = row["Email"]?.ToString();
                    lblPhoneNumber.Text = row["PhoneNumber"]?.ToString();
                    lblCompanyName.Text = row["CompanyName"]?.ToString();
                    lblIssueType.Text = row["IssueType"]?.ToString();
                    lblCreatedAt.Text = row["CreatedAt"]?.ToString();
                    lblDescription.Text = row["Description"]?.ToString();
                    lblProductDetails.Text = row["ProductDetails"]?.ToString();
                    lblPriorityLevel.Text = row["PriorityLevel"]?.ToString();
                    lblTechnician.Text = row["Technician"]?.ToString();
                    lblSchedule.Text = row["Schedule"]?.ToString();
                    lblResponse.Text = row["Response"]?.ToString();
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
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSubmitTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SubmitRequest().Show();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainUser().Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }
    }
}

