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
        private readonly string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        private int adminId;

        public MainDashboard(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            LoadDashboardSummary();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            cbxIdentifier.SelectedItem = "This Day";
        }

        private void LoadDashboardSummary()
        {
            string dateFilter = GetDateFilter();

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
                try
                {
                    conn.Open();

                    
                    using (SqlCommand cmd = new SqlCommand(summaryQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTotalTickets.Text = reader["TotalTickets"].ToString();
                                txtFrequentPriority.Text = reader["MostFrequentPriority"] != DBNull.Value ? reader["MostFrequentPriority"].ToString() : "N/A";
                                txtFrequentIssue.Text = reader["MostFrequentIssue"] != DBNull.Value ? reader["MostFrequentIssue"].ToString() : "N/A";
                            }
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(dataQuery, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        DataGridStatusBoard.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetDateFilter()
        {
            switch (cbxIdentifier.SelectedItem.ToString())
            {
                case "This Day":
                    return "CAST(CreatedAt AS DATE) = CAST(GETDATE() AS DATE)";
                case "This Week":
                    return "DATEPART(WEEK, CreatedAt) = DATEPART(WEEK, GETDATE()) AND YEAR(CreatedAt) = YEAR(GETDATE())";
                case "This Month":
                    return "MONTH(CreatedAt) = MONTH(GETDATE()) AND YEAR(CreatedAt) = YEAR(GETDATE())";
                default:
                    return "";
            }
        }

        private void cbxIdentifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardSummary();
        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            Technicians techniciansForm = new Technicians(adminId);
            techniciansForm.Show();
            this.Hide();
        }

        private void DataGridStatusBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.Rows[e.RowIndex].Cells["RequestID"].Value);
                Tickets detailsForm = new Tickets(requestID, adminId);
                detailsForm.Show();
            }
        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            if (DataGridStatusBoard.SelectedRows.Count > 0)
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.SelectedRows[0].Cells["RequestID"].Value);
                Tickets ticketsForm = new Tickets(requestID, adminId);
                ticketsForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a ticket to access details.", "No Ticket Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {
            Summary summaryForm = new Summary(adminId);
            summaryForm.Show();
            this.Hide();
        }
    }
}
