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
    public partial class Technicians : Form
    {
        public Technicians()
        {
            InitializeComponent();
            LoadAdminProfile();
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

        private void LoadAdminProfile()
        {
            string query = @"
                SELECT r.FullName, r.Email, r.PhoneNumber, rl.RoleName, r.Password 
                FROM Admin r
                JOIN Role rl ON r.RoleID = rl.RoleID
                WHERE r.AdminID = @AdminID";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AdminID", DBHelper.CurrentUser.AdminID);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblFullName.Text = reader["FullName"].ToString();
                            lblEmail.Text = reader["Email"].ToString();
                            lblPhoneNumber.Text = reader["PhoneNumber"].ToString();
                            lblRole.Text = reader["RoleName"].ToString();
                            lblPassword.Text = reader["Password"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No admin profile found for the given AdminID.", "Profile Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading profile: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainDashboard().Show();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminRegister().Show();
        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string newPassword = txtChangeNewPassword.Text.Trim();
            string confirmPassword = txtChangeConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill out both password fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Password", newPassword),
                new SqlParameter("@UserID", DBHelper.CurrentUser.UserID)
            };

            try
            {
                int rowsAffected = DBHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtChangeNewPassword.Clear();
                    txtChangeConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
