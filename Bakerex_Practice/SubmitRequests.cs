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
        }

        private void SubmitRequest_Load(object sender, EventArgs e)
        {

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

            // Phone Number Validation (Must start with 09 and be 11 digits long)
            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^09\d{9}$"))
            {
                MessageBox.Show("Enter a valid Phone Number (11 digits, starting with 09).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CustomerRequests 
                        (CustomerName, Email, PhoneNumber, CompanyName, IssueType, Subject, Description, ProductDetails, PriorityLevel) 
                        VALUES 
                        (@CustomerName, @Email, @PhoneNumber, @CompanyName, @IssueType, @Subject, @Description, @ProductDetails, @PriorityLevel)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text);
                    cmd.Parameters.AddWithValue("@IssueType", cbxIssueType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", txtProduct.Text);
                    cmd.Parameters.AddWithValue("@PriorityLevel", cbxPrioritylevel.SelectedItem.ToString());

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
    }
}
