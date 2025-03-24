namespace Bakerex_Practice
{
    partial class Summary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblLogut = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCalendar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSummary = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTechnicians = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTickets = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatusBoard = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Bakerex_Practice.Properties.Resources.Bakerex_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(542, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbxExit
            // 
            this.cbxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxExit.BackColor = System.Drawing.Color.Transparent;
            this.cbxExit.BorderRadius = 1;
            this.cbxExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.cbxExit.IconColor = System.Drawing.Color.White;
            this.cbxExit.Location = new System.Drawing.Point(12, 12);
            this.cbxExit.Name = "cbxExit";
            this.cbxExit.Size = new System.Drawing.Size(19, 19);
            this.cbxExit.TabIndex = 39;
            // 
            // lblLogut
            // 
            this.lblLogut.BackColor = System.Drawing.Color.Transparent;
            this.lblLogut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblLogut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogut.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblLogut.Location = new System.Drawing.Point(16, 378);
            this.lblLogut.Name = "lblLogut";
            this.lblLogut.Size = new System.Drawing.Size(59, 22);
            this.lblLogut.TabIndex = 38;
            this.lblLogut.Text = "Logout";
            this.lblLogut.Click += new System.EventHandler(this.lblLogut_Click);
            // 
            // lblCalendar
            // 
            this.lblCalendar.BackColor = System.Drawing.Color.Transparent;
            this.lblCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendar.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCalendar.Location = new System.Drawing.Point(16, 330);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(75, 22);
            this.lblCalendar.TabIndex = 37;
            this.lblCalendar.Text = "Calendar";
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Location = new System.Drawing.Point(16, 283);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(77, 22);
            this.lblSummary.TabIndex = 36;
            this.lblSummary.Text = "Summary";
            // 
            // lblTechnicians
            // 
            this.lblTechnicians.BackColor = System.Drawing.Color.Transparent;
            this.lblTechnicians.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblTechnicians.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechnicians.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTechnicians.Location = new System.Drawing.Point(16, 238);
            this.lblTechnicians.Name = "lblTechnicians";
            this.lblTechnicians.Size = new System.Drawing.Size(98, 22);
            this.lblTechnicians.TabIndex = 35;
            this.lblTechnicians.Text = "Technicians";
            this.lblTechnicians.Click += new System.EventHandler(this.lblTechnicians_Click);
            // 
            // lblTickets
            // 
            this.lblTickets.BackColor = System.Drawing.Color.Transparent;
            this.lblTickets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTickets.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTickets.Location = new System.Drawing.Point(16, 189);
            this.lblTickets.Name = "lblTickets";
            this.lblTickets.Size = new System.Drawing.Size(60, 22);
            this.lblTickets.TabIndex = 34;
            this.lblTickets.Text = "Tickets";
            this.lblTickets.Click += new System.EventHandler(this.lblTickets_Click);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(31, 114);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel4.TabIndex = 33;
            this.guna2HtmlLabel4.Text = null;
            // 
            // lblStatusBoard
            // 
            this.lblStatusBoard.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblStatusBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBoard.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblStatusBoard.Location = new System.Drawing.Point(16, 144);
            this.lblStatusBoard.Name = "lblStatusBoard";
            this.lblStatusBoard.Size = new System.Drawing.Size(109, 22);
            this.lblStatusBoard.TabIndex = 32;
            this.lblStatusBoard.Text = "Status Board";
            this.lblStatusBoard.Click += new System.EventHandler(this.lblStatusBoard_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.lblSummaryTitle);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(165, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(666, 519);
            this.guna2Panel1.TabIndex = 31;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Poppins Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblSummaryTitle.Location = new System.Drawing.Point(18, 12);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(115, 34);
            this.lblSummaryTitle.TabIndex = 18;
            this.lblSummaryTitle.Text = "Summary";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(843, 551);
            this.Controls.Add(this.cbxExit);
            this.Controls.Add(this.lblLogut);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblTechnicians);
            this.Controls.Add(this.lblTickets);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.lblStatusBoard);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox cbxExit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogut;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCalendar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSummary;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTechnicians;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTickets;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatusBoard;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblSummaryTitle;
    }
}