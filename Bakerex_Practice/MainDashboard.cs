using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraCharts.Native;

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
            cbxIdentifier.SelectedIndex = 0; 
            LoadDashboardSummary();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
             if (cbxIdentifier.SelectedItem == null)
                cbxIdentifier.SelectedIndex = 0;
        }

        private void LoadDashboardSummary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DateTime dateFilter = GetDateFilterValue();

                    string ticketQuery = @"
                SELECT 
                    cr.RequestID,
                    cr.CustomerName,
                    cr.Email,
                    cr.PhoneNumber,
                    cr.CompanyName,
                    cr.Subject,
                    cr.Description,
                    cr.ProductDetails,
                    cr.CreatedAt,
                    cr.Technician,
                    cr.Response,
                    cr.Schedule,
                    it.IssueTypeName,
                    pl.PriorityLevelName,
                    st.StatusName
                FROM CustomerRequests cr
                LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
                LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
                LEFT JOIN Status st ON cr.StatusID = st.StatusID
                WHERE cr.CreatedAt >= @DateFilter";

                    using (SqlCommand cmd = new SqlCommand(ticketQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DateFilter", dateFilter);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            DataGridStatusBoard.DataSource = dt;
                        }
                    }

                    string summaryQuery = @"
                SELECT 
                    (SELECT COUNT(*) FROM CustomerRequests WHERE CreatedAt >= @DateFilter) AS TotalTickets,
                    (SELECT TOP 1 it.IssueTypeName 
                     FROM CustomerRequests cr 
                     LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
                     WHERE cr.CreatedAt >= @DateFilter
                     GROUP BY it.IssueTypeName 
                     ORDER BY COUNT(*) DESC) AS MostFrequentIssueType,
                    (SELECT TOP 1 pl.PriorityLevelName 
                     FROM CustomerRequests cr 
                     LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
                     WHERE cr.CreatedAt >= @DateFilter
                     GROUP BY pl.PriorityLevelName 
                     ORDER BY COUNT(*) DESC) AS MostFrequentPriorityLevel";

                    using (SqlCommand cmdSummary = new SqlCommand(summaryQuery, conn))
                    {
                        cmdSummary.Parameters.AddWithValue("@DateFilter", dateFilter);
                        using (SqlDataReader reader = cmdSummary.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTotalTickets.Text = (reader["TotalTickets"] != DBNull.Value ? reader["TotalTickets"].ToString() : "0");
                                txtFrequentIssue.Text = (reader["MostFrequentIssueType"] != DBNull.Value ? reader["MostFrequentIssueType"].ToString() : "N/A");
                                txtFrequentPriority.Text = (reader["MostFrequentPriorityLevel"] != DBNull.Value ? reader["MostFrequentPriorityLevel"].ToString() : "N/A");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private DateTime GetDateFilterValue()
        {
            switch (cbxIdentifier.SelectedItem.ToString())
            {
                case "This Day":
                    return DateTime.Today;
                case "This Week":
                    return DateTime.Today.AddDays(-7); 
                case "This Month":
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); 
                default:
                    return DateTime.MinValue; 
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
