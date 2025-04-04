using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakerex_Practice
{
    public partial class MainUser : Form
    {
        public MainUser()
        {
            InitializeComponent();
        }

        private void MainUser_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainUser().Show();
        }


        private void btnSubmitTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SubmitRequest().Show();
        }

        private void lblSubmitTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SubmitRequest().Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void lblTrackTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TrackTicket1stForm().Show();
        }
    }
}
