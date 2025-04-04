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
    public partial class SubmitRequest : Form
    {
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
            string query = "SELECT IssueTypeID, IssueTypeName FROM IssueType";
            DataTable issueTypeTable = DBHelper.ExecuteQuery(query);
            cbxIssueType.DataSource = issueTypeTable;
            cbxIssueType.DisplayMember = "IssueTypeName";
            cbxIssueType.ValueMember = "IssueTypeID";
            cbxIssueType.SelectedIndex = -1;
        }

        private void LoadPriorityLevels()
        {
                string query = "SELECT PriorityLevelID, PriorityLevelName FROM PriorityLevel";
                DataTable priorityTable = DBHelper.ExecuteQuery(query);
                cbxPrioritylevel.DataSource = priorityTable;
                cbxPrioritylevel.DisplayMember = "PriorityLevelName";
                cbxPrioritylevel.ValueMember = "PriorityLevelID"; 
                cbxPrioritylevel.SelectedIndex = -1;
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

            string query = @"INSERT INTO CustomerRequests 
                             (CustomerName, Email, PhoneNumber, CompanyName, IssueTypeID, Subject, Description, ProductDetails, PriorityLevelID) 
                             VALUES 
                             (@CustomerName, @Email, @PhoneNumber, @CompanyName, @IssueTypeID, @Subject, @Description, @ProductDetails, @PriorityLevelID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerName", txtCustomerName.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@PhoneNumber", txtPhoneNumber.Text),
                new SqlParameter("@CompanyName", txtCompany.Text),
                new SqlParameter("@IssueTypeID", issueTypeID),
                new SqlParameter("@Subject", txtSubject.Text),
                new SqlParameter("@Description", txtDescription.Text),
                new SqlParameter("@ProductDetails", txtProduct.Text),
                new SqlParameter("@PriorityLevelID", priorityLevelID)
            };

            try
            {
                int rowsAffected = DBHelper.ExecuteNonQuery(query, parameters);

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
            this.Hide();
            MainUser mainUserForm = new MainUser();
        }

        private void lblTrackTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrackTicket1stForm trackTicketForm = new TrackTicket1stForm();
        }
    }
}
