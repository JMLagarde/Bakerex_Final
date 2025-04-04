﻿using System;
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
        private readonly int adminId;

        public Technicians(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
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
                Tickets tickets = new Tickets(requestID, adminId);
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
                cmd.Parameters.AddWithValue("@AdminID", adminId);

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
            new Summary(adminId).Show();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainDashboard(adminId).Show();
        }
    }
}
