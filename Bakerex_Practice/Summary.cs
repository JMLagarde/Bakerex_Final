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



namespace Bakerex_Practice
{
    public partial class Summary : Form
    {
        private int adminId;

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
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM CustomerRequests) AS TotalTickets,
                    SUM(CASE WHEN StatusID = 1 THEN 1 ELSE 0 END) AS PendingCount,
                    SUM(CASE WHEN StatusID = 2 THEN 1 ELSE 0 END) AS ScheduledCount,
                    SUM(CASE WHEN StatusID = 3 THEN 1 ELSE 0 END) AS InProgressCount,
                    SUM(CASE WHEN StatusID = 4 THEN 1 ELSE 0 END) AS ResolvedCount,
                    SUM(CASE WHEN StatusID IS NULL OR StatusID = 0 THEN 1 ELSE 0 END) AS UnassignedCount
                FROM CustomerRequests;";

            try
            {
                SqlParameter[] parameters = { };
                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalTickets.Text = row["TotalTickets"].ToString();
                    lblPending.Text = row["PendingCount"].ToString();
                    lblScheduled.Text = row["ScheduledCount"].ToString();
                    lblInProgress.Text = row["InProgressCount"].ToString();
                    lblResolved.Text = row["ResolvedCount"].ToString();
                    lblUnassigned.Text = row["UnassignedCount"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPriorityChart()
        {
            string query = @"
                SELECT pl.PriorityLevelName, COUNT(*) AS TicketCount 
                FROM CustomerRequests cr
                JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
                GROUP BY pl.PriorityLevelName";

            try
            {
                SqlParameter[] parameters = { };
                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                PriorityChart.Series.Clear();
                Series series = new Series("Priority Levels") { ChartType = SeriesChartType.Column };

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["PriorityLevelName"].ToString(), Convert.ToInt32(row["TicketCount"]));
                }

                PriorityChart.Series.Add(series);

                if (series.Points.Count > 0)
                {
                    double maxY = series.Points.Max(p => p.YValues[0]);
                    PriorityChart.ChartAreas[0].AxisY.Maximum = maxY + 5;
                    PriorityChart.ChartAreas[0].AxisY.Minimum = 0;
                    PriorityChart.ChartAreas[0].AxisY.Interval = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIssueChart()
        {
            string query = @"
                SELECT it.IssueTypeName, COUNT(*) AS TicketCount 
                FROM CustomerRequests cr
                JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
                GROUP BY it.IssueTypeName";

            try
            {
                SqlParameter[] parameters = { };
                DataTable dt = DBHelper.ExecuteQuery(query, parameters);

                chart1.Series.Clear();
                Series series = new Series("Issue Types")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["IssueTypeName"].ToString(), Convert.ToInt32(row["TicketCount"]));
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

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
