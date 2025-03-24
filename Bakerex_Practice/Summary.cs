using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.CodeParser;


namespace Bakerex_Practice
{
    public partial class Summary : Form
    {
        private int adminId;
        public Summary(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
