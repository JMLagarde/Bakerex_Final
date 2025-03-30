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
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.CodeParser;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraCharts.Native;


namespace Bakerex_Practice
{
    public partial class Summary : Form
    {
        private int adminId;
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        public Summary(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            LoadPriorityChart();
            LoadIssueChart();
            LoadTickets();
        }

        private void LoadTickets()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                (SELECT COUNT(*) FROM CustomerRequests) AS TotalTickets,
                SUM(CASE WHEN StatusID = 1 THEN 1 ELSE 0 END) AS PendingCount,
                SUM(CASE WHEN StatusID = 2 THEN 1 ELSE 0 END) AS ScheduledCount,
                SUM(CASE WHEN StatusID = 3 THEN 1 ELSE 0 END) AS InProgressCount,
                SUM(CASE WHEN StatusID = 4 THEN 1 ELSE 0 END) AS ResolvedCount,
                SUM(CASE WHEN StatusID IS NULL OR StatusID = 0 THEN 1 ELSE 0 END) AS UnassignedCount
            FROM CustomerRequests;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblTotalTickets.Text = reader["TotalTickets"].ToString();
                            lblPending.Text = reader["PendingCount"].ToString();
                            lblScheduled.Text = reader["ScheduledCount"].ToString();
                            lblInProgress.Text = reader["InProgressCount"].ToString();
                            lblResolved.Text = reader["ResolvedCount"].ToString();
                            lblUnassigned.Text = reader["UnassignedCount"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading summary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lblStatusBoard_Click(object sender, EventArgs e)
        {
            MainDashboard mainDashboard = new MainDashboard(adminId);
            mainDashboard.Show();
            this.Hide();
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

        private void lblTechnicians_Click(object sender, EventArgs e)
        {
            Technicians techniciansForm = new Technicians(adminId);
            techniciansForm.Show();
            this.Hide();
        }

        private void lblLogut_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void LoadPriorityChart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT pl.PriorityLevelName, COUNT(*) AS TicketCount 
                FROM CustomerRequests cr
                JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
                GROUP BY pl.PriorityLevelName", conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    PriorityChart.Series.Clear();
                    Series series = new Series("Priority Levels") { ChartType = SeriesChartType.Column };

                    while (reader.Read())
                        series.Points.AddXY(reader["PriorityLevelName"].ToString(), Convert.ToInt32(reader["TicketCount"]));

                    PriorityChart.Series.Add(series);

                    double maxY = series.Points.Max(p => p.YValues[0]);
                    PriorityChart.ChartAreas[0].AxisY.Maximum = maxY + 5;
                    PriorityChart.ChartAreas[0].AxisY.Minimum = 0;
                    PriorityChart.ChartAreas[0].AxisY.Interval = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading chart: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadIssueChart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT it.IssueTypeName, COUNT(*) AS TicketCount 
                FROM CustomerRequests cr
                JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
                GROUP BY it.IssueTypeName", conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    chart1.Series.Clear();
                    Series series = new Series("Issue Types")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true
                    };

                    while (reader.Read())
                    {
                        series.Points.AddXY(reader["IssueTypeName"].ToString(), Convert.ToInt32(reader["TicketCount"]));
                    }

                    chart1.Series.Add(series);

                    if (series.Points.Count > 0)
                    {
                        double maxY = series.Points.Max(p => p.YValues[0]);
                        chart1.ChartAreas[0].AxisY.Maximum = maxY + 5;
                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        chart1.ChartAreas[0].AxisY.Interval = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading issue type chart: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
