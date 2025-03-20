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
    public partial class Technicians : Form
    {
        string connectionString = "Server=DESKTOP-D9KJ8S9\\SQLEXPRESS;Database=BakerexCustomerSupportSystem;Integrated Security=True;";
        public Technicians()
        {
            InitializeComponent();
            LoadRegistrationData();
        }

        private void Technicians_Load(object sender, EventArgs e)
        {

        }

        private void DataGridStatusBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadRegistrationData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT LoginID, FullName, Email, PhoneNumber, Role FROM Registration"; // Exclude Password for security

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DataGridStatusBoard.DataSource = dt; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
