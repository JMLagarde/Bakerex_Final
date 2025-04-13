using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bakerex_Practice
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
            cbxIdentifier.SelectedIndex = 0;
        }
        private void cbxIdentifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequestTable();
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
                case "All Records":
                    return new DateTime(2025, 1, 1);
                default:
                    return DateTime.MinValue;
            }
        }


        private void LoadRequestTable()
        {
            try
            {
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

                SqlParameter[] ticketParams = {
            new SqlParameter("@DateFilter", dateFilter)
        };

                DataTable dt = DBHelper.ExecuteQuery(ticketQuery, ticketParams);
                DataGridStatusBoard.DataSource = dt;

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

                SqlParameter[] summaryParams = {
            new SqlParameter("@DateFilter", dateFilter)
        };

                using (SqlDataReader reader = DBHelper.ExecuteReader(summaryQuery, summaryParams))
                {
                    if (reader.Read())
                    {
                        txtTotalTickets.Text = reader["TotalTickets"]?.ToString() ?? "0";
                        txtFrequentIssue.Text = reader["MostFrequentIssueType"]?.ToString() ?? "N/A";
                        txtFrequentPriority.Text = reader["MostFrequentPriorityLevel"]?.ToString() ?? "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridStatusBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.Rows[e.RowIndex].Cells["RequestID"].Value);
                Tickets detailsForm = new Tickets(requestID, DBHelper.CurrentUser.AdminID);
                detailsForm.Show();
            }
        }

        private void lblTickets_Click(object sender, EventArgs e)
        {
            if (DataGridStatusBoard.SelectedRows.Count > 0)
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.SelectedRows[0].Cells["RequestID"].Value);
                Tickets ticketsForm = new Tickets(requestID, DBHelper.CurrentUser.AdminID);
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
            this.Hide();
            new Summary().Show();
        }

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Technicians().Show();
        }

        private void lblLogut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }
    }
}
