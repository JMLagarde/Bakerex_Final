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
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        public TrackTicket1stForm()
        {
            InitializeComponent();
            LoadTickets();
            this.DataGridStatusBoard.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridStatusBoard_CellDoubleClick);
        }

        private void TrackTicket1stForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }
        private void LoadTickets()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string email = lblEmail.Text;
                string phoneNumber = lblPhoneNumber.Text;

                string query = @"SELECT RequestID, Status, Subject, CustomerName, Email, PhoneNumber, 
                                 CompanyName, IssueType, CreatedAt, Description, ProductDetails, 
                                 PriorityLevel, Technician, Schedule, Response 
                          FROM CustomerRequests 
                          WHERE Email = @Email AND PhoneNumber = @PhoneNumber";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        DataGridStatusBoard.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            SubmitRequest submitRequestForm = new SubmitRequest();
            submitRequestForm.Show();
            this.Hide();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            MainUser mainUserForm = new MainUser();
            mainUserForm.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLoginForm = new AdminLogin();
            adminLoginForm.Show();
            this.Hide();
        }
    }
}
