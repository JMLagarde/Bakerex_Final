using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bakerex_Practice
{
    public partial class AdminRegister : Form
    {
        public AdminRegister()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            string query = "SELECT RoleID, RoleName FROM Role";

            try
            {
                SqlParameter[] parameters = { };
                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                cbxRole.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    cbxRole.Items.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(row["RoleID"]),
                        row["RoleName"].ToString()
                    ));
                }

                cbxRole.DisplayMember = "Value";
                cbxRole.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSignin_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs()) return;

            string query = "INSERT INTO Admin (FullName, Email, Password, PhoneNumber, RoleID) VALUES (@FullName, @Email, @Password, @PhoneNumber, @RoleID)";

            try
            {
                KeyValuePair<int, string> selectedRole = (KeyValuePair<int, string>)cbxRole.SelectedItem;

                SqlParameter[] parameters = {
            new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = txtFullName.Text.Trim() },
            new SqlParameter("@Email", SqlDbType.NVarChar) { Value = txtEmail.Text.Trim() },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = txtPassword.Text.Trim() },
            new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = txtPhoneNumber.Text.Trim() },
            new SqlParameter("@RoleID", SqlDbType.Int) { Value = selectedRole.Key }
        };

                int result = DBHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Admin registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                cbxRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(txtPhoneNumber.Text, @"^09\d{9}$"))
            {
                MessageBox.Show("Phone number must be 11 digits and start with '09'!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtPassword.Text = "";
            cbxRole.SelectedIndex = -1; ;
        }

        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainDashboard().Show();
        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            int requestID = 0;
            if (requestID <= 0)
            {
                MessageBox.Show("Please select a client to access tickets.", "No Ticket Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Tickets tickets = new Tickets(requestID, DBHelper.CurrentUser.AdminID);
                tickets.Show();
                this.Hide();
            }
        }
        private void lblSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Summary().Show();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
