namespace Bakerex_Practice
{
    partial class MainDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.DataGridStatusBoard = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlPendingTickets = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtFrequentPriority = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPendingTickets = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlFrequentIssue = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtFrequentIssue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblResolved = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlOpenTickets = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtTotalTickets = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblOpenTickets = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbxIdentifier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatusBoardText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatusBoard = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTickets = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSummary = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTechnicians = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLogut = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCalendar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbxExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStatusBoard)).BeginInit();
            this.pnlPendingTickets.SuspendLayout();
            this.pnlFrequentIssue.SuspendLayout();
            this.pnlOpenTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.DataGridStatusBoard);
            this.guna2Panel1.Controls.Add(this.pnlPendingTickets);
            this.guna2Panel1.Controls.Add(this.pnlFrequentIssue);
            this.guna2Panel1.Controls.Add(this.pnlOpenTickets);
            this.guna2Panel1.Controls.Add(this.cbxIdentifier);
            this.guna2Panel1.Controls.Add(this.lblStatusBoardText);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(165, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(666, 519);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // DataGridStatusBoard
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridStatusBoard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridStatusBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.DataGridStatusBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridStatusBoard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridStatusBoard.ColumnHeadersHeight = 4;
            this.DataGridStatusBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridStatusBoard.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridStatusBoard.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridStatusBoard.Location = new System.Drawing.Point(25, 177);
            this.DataGridStatusBoard.Name = "DataGridStatusBoard";
            this.DataGridStatusBoard.RowHeadersVisible = false;
            this.DataGridStatusBoard.RowHeadersWidth = 51;
            this.DataGridStatusBoard.Size = new System.Drawing.Size(613, 315);
            this.DataGridStatusBoard.TabIndex = 7;
            this.DataGridStatusBoard.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridStatusBoard.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridStatusBoard.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridStatusBoard.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridStatusBoard.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridStatusBoard.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridStatusBoard.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridStatusBoard.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridStatusBoard.ThemeStyle.ReadOnly = false;
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridStatusBoard.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridStatusBoard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridStatusBoard_CellContentClick);
            // 
            // pnlPendingTickets
            // 
            this.pnlPendingTickets.BackColor = System.Drawing.Color.Transparent;
            this.pnlPendingTickets.BorderRadius = 10;
            this.pnlPendingTickets.Controls.Add(this.txtFrequentPriority);
            this.pnlPendingTickets.Controls.Add(this.lblPendingTickets);
            this.pnlPendingTickets.FillColor = System.Drawing.Color.Gainsboro;
            this.pnlPendingTickets.FillColor2 = System.Drawing.Color.DarkGray;
            this.pnlPendingTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.pnlPendingTickets.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlPendingTickets.Location = new System.Drawing.Point(246, 86);
            this.pnlPendingTickets.Name = "pnlPendingTickets";
            this.pnlPendingTickets.Size = new System.Drawing.Size(168, 76);
            this.pnlPendingTickets.TabIndex = 6;
            // 
            // txtFrequentPriority
            // 
            this.txtFrequentPriority.AutoSize = false;
            this.txtFrequentPriority.BackColor = System.Drawing.Color.Transparent;
            this.txtFrequentPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrequentPriority.ForeColor = System.Drawing.Color.Black;
            this.txtFrequentPriority.Location = new System.Drawing.Point(3, 16);
            this.txtFrequentPriority.Name = "txtFrequentPriority";
            this.txtFrequentPriority.Size = new System.Drawing.Size(162, 34);
            this.txtFrequentPriority.TabIndex = 8;
            this.txtFrequentPriority.Text = "0";
            this.txtFrequentPriority.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPendingTickets
            // 
            this.lblPendingTickets.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingTickets.ForeColor = System.Drawing.Color.Black;
            this.lblPendingTickets.Location = new System.Drawing.Point(3, 55);
            this.lblPendingTickets.Name = "lblPendingTickets";
            this.lblPendingTickets.Size = new System.Drawing.Size(162, 15);
            this.lblPendingTickets.TabIndex = 7;
            this.lblPendingTickets.Text = "Most Frequent Priority Level";
            // 
            // pnlFrequentIssue
            // 
            this.pnlFrequentIssue.BackColor = System.Drawing.Color.Transparent;
            this.pnlFrequentIssue.BorderRadius = 10;
            this.pnlFrequentIssue.Controls.Add(this.txtFrequentIssue);
            this.pnlFrequentIssue.Controls.Add(this.lblResolved);
            this.pnlFrequentIssue.FillColor = System.Drawing.Color.Gainsboro;
            this.pnlFrequentIssue.FillColor2 = System.Drawing.Color.DarkGray;
            this.pnlFrequentIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFrequentIssue.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlFrequentIssue.Location = new System.Drawing.Point(470, 86);
            this.pnlFrequentIssue.Name = "pnlFrequentIssue";
            this.pnlFrequentIssue.Size = new System.Drawing.Size(168, 76);
            this.pnlFrequentIssue.TabIndex = 5;
            // 
            // txtFrequentIssue
            // 
            this.txtFrequentIssue.AutoSize = false;
            this.txtFrequentIssue.BackColor = System.Drawing.Color.Transparent;
            this.txtFrequentIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrequentIssue.ForeColor = System.Drawing.Color.Black;
            this.txtFrequentIssue.Location = new System.Drawing.Point(13, 16);
            this.txtFrequentIssue.Name = "txtFrequentIssue";
            this.txtFrequentIssue.Size = new System.Drawing.Size(150, 34);
            this.txtFrequentIssue.TabIndex = 9;
            this.txtFrequentIssue.Text = "0";
            this.txtFrequentIssue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResolved
            // 
            this.lblResolved.BackColor = System.Drawing.Color.Transparent;
            this.lblResolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolved.ForeColor = System.Drawing.Color.Black;
            this.lblResolved.Location = new System.Drawing.Point(13, 55);
            this.lblResolved.Name = "lblResolved";
            this.lblResolved.Size = new System.Drawing.Size(150, 15);
            this.lblResolved.TabIndex = 8;
            this.lblResolved.Text = "Most Frequent Issue Type";
            // 
            // pnlOpenTickets
            // 
            this.pnlOpenTickets.BackColor = System.Drawing.Color.Transparent;
            this.pnlOpenTickets.BorderRadius = 10;
            this.pnlOpenTickets.Controls.Add(this.txtTotalTickets);
            this.pnlOpenTickets.Controls.Add(this.lblOpenTickets);
            this.pnlOpenTickets.FillColor = System.Drawing.Color.Gainsboro;
            this.pnlOpenTickets.FillColor2 = System.Drawing.Color.DarkGray;
            this.pnlOpenTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.pnlOpenTickets.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlOpenTickets.Location = new System.Drawing.Point(25, 86);
            this.pnlOpenTickets.Name = "pnlOpenTickets";
            this.pnlOpenTickets.Size = new System.Drawing.Size(168, 76);
            this.pnlOpenTickets.TabIndex = 4;
            // 
            // txtTotalTickets
            // 
            this.txtTotalTickets.AutoSize = false;
            this.txtTotalTickets.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTickets.ForeColor = System.Drawing.Color.Black;
            this.txtTotalTickets.Location = new System.Drawing.Point(80, 25);
            this.txtTotalTickets.Name = "txtTotalTickets";
            this.txtTotalTickets.Size = new System.Drawing.Size(10, 15);
            this.txtTotalTickets.TabIndex = 10;
            this.txtTotalTickets.Text = "0";
            this.txtTotalTickets.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpenTickets
            // 
            this.lblOpenTickets.BackColor = System.Drawing.Color.Transparent;
            this.lblOpenTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenTickets.ForeColor = System.Drawing.Color.Black;
            this.lblOpenTickets.Location = new System.Drawing.Point(43, 55);
            this.lblOpenTickets.Name = "lblOpenTickets";
            this.lblOpenTickets.Size = new System.Drawing.Size(78, 15);
            this.lblOpenTickets.TabIndex = 9;
            this.lblOpenTickets.Text = "Total Tickets";
            // 
            // cbxIdentifier
            // 
            this.cbxIdentifier.BackColor = System.Drawing.Color.White;
            this.cbxIdentifier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIdentifier.FillColor = System.Drawing.SystemColors.Window;
            this.cbxIdentifier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxIdentifier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxIdentifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cbxIdentifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxIdentifier.ItemHeight = 30;
            this.cbxIdentifier.Items.AddRange(new object[] {
            "This Day",
            "This Week",
            "This Month"});
            this.cbxIdentifier.Location = new System.Drawing.Point(25, 44);
            this.cbxIdentifier.Name = "cbxIdentifier";
            this.cbxIdentifier.Size = new System.Drawing.Size(137, 36);
            this.cbxIdentifier.StartIndex = 0;
            this.cbxIdentifier.TabIndex = 8;
            this.cbxIdentifier.SelectedIndexChanged += new System.EventHandler(this.cbxIdentifier_SelectedIndexChanged);
            // 
            // lblStatusBoardText
            // 
            this.lblStatusBoardText.AutoSize = true;
            this.lblStatusBoardText.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusBoardText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBoardText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblStatusBoardText.Location = new System.Drawing.Point(19, 13);
            this.lblStatusBoardText.Name = "lblStatusBoardText";
            this.lblStatusBoardText.Size = new System.Drawing.Size(127, 24);
            this.lblStatusBoardText.TabIndex = 1;
            this.lblStatusBoardText.Text = "Status Board";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Bakerex_Practice.Properties.Resources.Bakerex_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(542, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(31, 114);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel4.TabIndex = 5;
            this.guna2HtmlLabel4.Text = null;
            // 
            // lblStatusBoard
            // 
            this.lblStatusBoard.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblStatusBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBoard.ForeColor = System.Drawing.Color.White;
            this.lblStatusBoard.Location = new System.Drawing.Point(16, 144);
            this.lblStatusBoard.Name = "lblStatusBoard";
            this.lblStatusBoard.Size = new System.Drawing.Size(109, 22);
            this.lblStatusBoard.TabIndex = 4;
            this.lblStatusBoard.Text = "Status Board";
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
            this.lblTickets.TabIndex = 7;
            this.lblTickets.Text = "Tickets";
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSummary.Location = new System.Drawing.Point(16, 283);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(77, 22);
            this.lblSummary.TabIndex = 9;
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
            this.lblTechnicians.TabIndex = 8;
            this.lblTechnicians.Text = "Technicians";
            this.lblTechnicians.Click += new System.EventHandler(this.lblTechnicians_Click);
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
            this.lblLogut.TabIndex = 11;
            this.lblLogut.Text = "Logout";
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
            this.lblCalendar.TabIndex = 10;
            this.lblCalendar.Text = "Calendar";
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
            this.cbxExit.TabIndex = 12;
            this.cbxExit.Click += new System.EventHandler(this.cbxExit_Click);
            // 
            // MainDashboard
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
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridStatusBoard)).EndInit();
            this.pnlPendingTickets.ResumeLayout(false);
            this.pnlPendingTickets.PerformLayout();
            this.pnlFrequentIssue.ResumeLayout(false);
            this.pnlFrequentIssue.PerformLayout();
            this.pnlOpenTickets.ResumeLayout(false);
            this.pnlOpenTickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogut;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCalendar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSummary;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTechnicians;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTickets;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatusBoard;
        private System.Windows.Forms.Label lblStatusBoardText;
        private Guna.UI2.WinForms.Guna2ComboBox cbxIdentifier;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlOpenTickets;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlFrequentIssue;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlPendingTickets;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPendingTickets;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblResolved;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOpenTickets;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridStatusBoard;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtFrequentPriority;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtFrequentIssue;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtTotalTickets;
        private Guna.UI2.WinForms.Guna2ControlBox cbxExit;
    }
}