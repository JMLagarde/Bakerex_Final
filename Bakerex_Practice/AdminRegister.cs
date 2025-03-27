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
    public partial class AdminRegister : Form
    {
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";

        public AdminRegister()
        {
            InitializeComponent();
        }
      
        private void AdminRegister_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }
        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT RoleID, RoleName FROM Role";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        cbxRole.Items.Clear();

                        while (reader.Read())
                        {
                            cbxRole.Items.Add(new KeyValuePair<int, string>(
                                Convert.ToInt32(reader["RoleID"]),
                                reader["RoleName"].ToString()
                            ));
                        }
                        reader.Close();

                        cbxRole.DisplayMember = "Value"; 
                        cbxRole.ValueMember = "Key";     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnSignin_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Admin (FullName, Email, Password, PhoneNumber, RoleID) VALUES (@FullName, @Email, @Password, @PhoneNumber, @RoleID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());

                        KeyValuePair<int, string> selectedRole = (KeyValuePair<int, string>)cbxRole.SelectedItem;
                        cmd.Parameters.AddWithValue("@RoleID", selectedRole.Key);

                        int result = cmd.ExecuteNonQuery();

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
               string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrWhiteSpace(txtPassword.Text) ||
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
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            cbxRole.SelectedIndex = -1;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            MainUser mainUser = new MainUser();
            mainUser.Show();
            this.Hide();
        }
    }
}
