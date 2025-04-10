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
    public partial class TrackTicket1stForm : Form
    {
        public TrackTicket1stForm()
        {
            InitializeComponent();
            this.DataGridStatusBoard.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridStatusBoard_CellDoubleClick);
            LoadUserTickets();
        }
        private void LoadUserTickets()
        {
            int userID = DBHelper.CurrentUser.UserID;

            if (userID == 0)
            {
                MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"
                SELECT 
                    cr.RequestID, 
                    cr.CustomerName, 
                    cr.Subject, 
                    cr.ProductDetails, 
                    cr.CreatedAt, 
                    s.StatusName
                FROM 
                    CustomerRequests cr
                JOIN 
                    Status s ON cr.StatusID = s.StatusID
                WHERE 
                    cr.UserID = @UserID
                ORDER BY 
                    cr.CreatedAt DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };

            try
            {
                DataTable userTickets = DBHelper.ExecuteQuery(query, parameters);
                DataGridStatusBoard.DataSource = userTickets;

                DataGridStatusBoard.Columns["RequestID"].HeaderText = "Request ID";
                DataGridStatusBoard.Columns["CustomerName"].HeaderText = "Customer Name";
                DataGridStatusBoard.Columns["Subject"].HeaderText = "Subject";
                DataGridStatusBoard.Columns["StatusName"].HeaderText = "Status";
                DataGridStatusBoard.Columns["ProductDetails"].HeaderText = "Product Details";
                DataGridStatusBoard.Columns["CreatedAt"].HeaderText = "Date Created";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tickets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridStatusBoard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int requestID = Convert.ToInt32(DataGridStatusBoard.Rows[e.RowIndex].Cells["RequestID"].Value);
                TrackTicket2ndForm detailsForm = new TrackTicket2ndForm(requestID);
                detailsForm.Show();
            }
        }

        private void lblSubmitTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SubmitRequest().Show();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainUser().Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void cbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
