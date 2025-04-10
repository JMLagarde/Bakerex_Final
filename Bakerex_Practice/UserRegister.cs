using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakerex_Practice
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }
        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string query = "INSERT INTO Users (FullName, Email, Password, PhoneNumber, CompanyName) VALUES (@FullName, @Email, @Password, @PhoneNumber, @CompanyName)";

            try
            {
                SqlParameter[] parameters = {
            new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = txtFullName.Text.Trim() },
            new SqlParameter("@Email", SqlDbType.NVarChar) { Value = txtEmail.Text.Trim() },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = txtPassword.Text.Trim() },
            new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = txtPhoneNumber.Text.Trim() },
            new SqlParameter("@CompanyName", SqlDbType.NVarChar) { Value = txtCompany.Text.Trim() }
            };
                int result = DBHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCompany.Text))
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
            txtPhoneNumber.Text = "";
            txtCompany.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserLogin().Show();
        }
    }
}
