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
using DevExpress.CodeParser;

namespace Bakerex_Practice
{
    public partial class SubmitRequest : Form
    {
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        public SubmitRequest()
        {
            InitializeComponent();
            ClearFields();
            LoadIssueTypes();
            LoadPriorityLevels();
        }
        private void Summary_Load(object sender, EventArgs e)
        {
            LoadIssueTypes();
            LoadPriorityLevels();
        }

        private void LoadIssueTypes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT IssueTypeID, IssueTypeName FROM IssueType";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable issueTypeTable = new DataTable();
                adapter.Fill(issueTypeTable);

                cbxIssueType.DataSource = issueTypeTable;
                cbxIssueType.DisplayMember = "IssueTypeName"; // Shows name in dropdown
                cbxIssueType.ValueMember = "IssueTypeID"; // Uses ID internally
                cbxIssueType.SelectedIndex = -1; // No default selection
            }
        }

        private void LoadPriorityLevels()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PriorityLevelID, PriorityLevelName FROM PriorityLevel";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable priorityTable = new DataTable();
                adapter.Fill(priorityTable);

                cbxPrioritylevel.DataSource = priorityTable;
                cbxPrioritylevel.DisplayMember = "PriorityLevelName"; // Shows name in dropdown
                cbxPrioritylevel.ValueMember = "PriorityLevelID"; // Uses ID internally
                cbxPrioritylevel.SelectedIndex = -1;
            }
        }


        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                cbxIssueType.SelectedIndex == -1 ||
                cbxPrioritylevel.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^09\d{9}$"))
            {
                MessageBox.Show("Enter a valid Phone Number (11 digits, starting with 09).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int issueTypeID = Convert.ToInt32(cbxIssueType.SelectedValue);
            int priorityLevelID = Convert.ToInt32(cbxPrioritylevel.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CustomerRequests 
                        (CustomerName, Email, PhoneNumber, CompanyName, IssueTypeID, Subject, Description, ProductDetails, PriorityLevelID) 
                        VALUES 
                        (@CustomerName, @Email, @PhoneNumber, @CompanyName, @IssueTypeID, @Subject, @Description, @ProductDetails, @PriorityLevelID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text);
                    cmd.Parameters.AddWithValue("@IssueTypeID", issueTypeID);
                    cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", txtProduct.Text);
                    cmd.Parameters.AddWithValue("@PriorityLevelID", priorityLevelID);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            MainUser mainUserForm = new MainUser();
                            mainUserForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Submission failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ClearFields()
        {
            txtCustomerName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtCompany.Clear();
            cbxIssueType.SelectedIndex = -1;
            txtSubject.Clear();
            txtDescription.Clear();
            txtProduct.Clear();
            cbxPrioritylevel.SelectedIndex = -1;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            MainUser mainUserForm = new MainUser();
            mainUserForm.Show();
            this.Hide();
        }

        private void lblTrackTicket_Click(object sender, EventArgs e)
        {
            TrackTicket1stForm trackTicket1stForm = new TrackTicket1stForm();
            trackTicket1stForm.Show();
            this.Hide();
        }


    }
}
