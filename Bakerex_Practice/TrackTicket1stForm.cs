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
        }

        private void TrackTicket1stForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string email = lblEmail.Text.Trim();
            string phoneNumber = lblPhoneNumber.Text.Trim();

            string query = @"
                SELECT 
                    cr.RequestID, 
                    st.StatusName AS Status, 
                    cr.Subject, 
                    cr.CustomerName, 
                    cr.Email, 
                    cr.PhoneNumber, 
                    cr.CompanyName, 
                    it.IssueTypeName AS IssueType, 
                    cr.CreatedAt, 
                    cr.Description, 
                    cr.ProductDetails, 
                    pl.PriorityLevelName AS PriorityLevel, 
                    cr.Technician, 
                    cr.Schedule, 
                    cr.Response 
                FROM CustomerRequests cr
                LEFT JOIN IssueType it ON cr.IssueTypeID = it.IssueTypeID
                LEFT JOIN PriorityLevel pl ON cr.PriorityLevelID = pl.PriorityLevelID
                LEFT JOIN Status st ON cr.StatusID = st.StatusID
                WHERE cr.Email = @Email AND cr.PhoneNumber = @PhoneNumber;";

            SqlParameter[] parameters = {
                new SqlParameter("@Email", email),
                new SqlParameter("@PhoneNumber", phoneNumber)
            };

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataGridStatusBoard.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving ticket data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
