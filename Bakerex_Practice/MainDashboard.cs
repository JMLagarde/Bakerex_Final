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
    public partial class MainDashboard : Form
    {
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        private int requestID;
        public MainDashboard()
        {
            InitializeComponent();
            LoadDashboardSummary();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            cbxIdentifier.SelectedItem = "This Day";
        }

        private void LoadDashboardSummary()
        {
            string dateFilter = "";

            if (cbxIdentifier.SelectedItem.ToString() == "This Day")
                dateFilter = "CAST(CreatedAt AS DATE) = CAST(GETDATE() AS DATE)";
            else if (cbxIdentifier.SelectedItem.ToString() == "This Week")
                dateFilter = "DATEPART(WEEK, CreatedAt) = DATEPART(WEEK, GETDATE()) AND YEAR(CreatedAt) = YEAR(GETDATE())";
            else if (cbxIdentifier.SelectedItem.ToString() == "This Month")
                dateFilter = "MONTH(CreatedAt) = MONTH(GETDATE()) AND YEAR(CreatedAt) = YEAR(GETDATE())";

            string summaryQuery = $@"
    SELECT 
        COUNT(*) AS TotalTickets,
        (SELECT TOP 1 PriorityLevel FROM CustomerRequests WHERE {dateFilter} GROUP BY PriorityLevel ORDER BY COUNT(*) DESC) AS MostFrequentPriority,
        (SELECT TOP 1 IssueType FROM CustomerRequests WHERE {dateFilter} GROUP BY IssueType ORDER BY COUNT(*) DESC) AS MostFrequentIssue
    FROM CustomerRequests
    WHERE {dateFilter}";

            string dataQuery = $"SELECT * FROM CustomerRequests WHERE {dateFilter}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(summaryQuery, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtTotalTickets.Text = reader["TotalTickets"].ToString();
                            txtFrequentPriority.Text = reader["MostFrequentPriority"] != DBNull.Value ? reader["MostFrequentPriority"].ToString() : "N/A";
                            txtFrequentIssue.Text = reader["MostFrequentIssue"] != DBNull.Value ? reader["MostFrequentIssue"].ToString() : "N/A";
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(dataQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataGridStatusBoard.DataSource = dt;
                }
            }
        }



        private void cbxIdentifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Selected: " + cbxIdentifier.SelectedItem.ToString()); 
            LoadDashboardSummary();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            Technicians techiniciansform = new Technicians();
            techiniciansform.Show();

            this.Hide();
        }

        private void DataGridStatusBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.Rows[e.RowIndex].Cells["RequestID"].Value);

                Tickets detailsForm = new Tickets(requestID);
                detailsForm.Show();
            }
        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            if (requestID <= 0)
            {
                MessageBox.Show("Please select a client to access tickets.", "No Ticket Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Tickets tickets = new Tickets(requestID);
                tickets.Show();
                this.Hide();
            }
        }
    }
}
