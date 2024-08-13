namespace distilled_community_recorder
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            btnlive = new ToolStripButton();
            btnPlayback = new ToolStripButton();
            btnReccord = new ToolStripButton();
            btnConfig = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pn_1 = new Panel();
            pn_2 = new Panel();
            pn_3 = new Panel();
            pn_4 = new Panel();
            pn_5 = new Panel();
            pn_6 = new Panel();
            groupBox1 = new GroupBox();
            label1 = new Label();
            infoserver = new Label();
            infointerval = new Label();
            infolocal = new Label();
            infosite = new Label();
            infoprefix = new Label();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pn_6.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 855);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1235, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 20);
            lblStatus.Text = "Status: ...";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnlive, btnPlayback, btnReccord, btnConfig, toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1235, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnlive
            // 
            btnlive.Image = Properties.Resources.control_play;
            btnlive.ImageTransparentColor = Color.Magenta;
            btnlive.Name = "btnlive";
            btnlive.Size = new Size(142, 36);
            btnlive.Text = "Start Live View";
            btnlive.Click += toolStripButton1_Click;
            // 
            // btnPlayback
            // 
            btnPlayback.Image = Properties.Resources.control_play;
            btnPlayback.ImageTransparentColor = Color.Magenta;
            btnPlayback.Name = "btnPlayback";
            btnPlayback.Size = new Size(107, 36);
            btnPlayback.Text = "Start Rec.";
            btnPlayback.Click += btnPlayback_Click;
            // 
            // btnReccord
            // 
            btnReccord.Image = Properties.Resources.shape_square;
            btnReccord.ImageTransparentColor = Color.Magenta;
            btnReccord.Name = "btnReccord";
            btnReccord.Size = new Size(107, 36);
            btnReccord.Text = "Stop Rec.";
            btnReccord.Visible = false;
            // 
            // btnConfig
            // 
            btnConfig.Image = Properties.Resources.cog;
            btnConfig.ImageTransparentColor = Color.Magenta;
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(89, 36);
            btnConfig.Text = "Config";
            btnConfig.Click += btnConfig_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.folder;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(157, 36);
            toolStripButton1.Text = "Open Local Parth";
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = Properties.Resources.dest;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(150, 36);
            toolStripButton2.Text = "Open dest Parth";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 39);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1235, 816);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlDarkDark;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(pn_1, 0, 0);
            tableLayoutPanel1.Controls.Add(pn_2, 1, 0);
            tableLayoutPanel1.Controls.Add(pn_3, 2, 0);
            tableLayoutPanel1.Controls.Add(pn_4, 0, 1);
            tableLayoutPanel1.Controls.Add(pn_5, 1, 1);
            tableLayoutPanel1.Controls.Add(pn_6, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1235, 816);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pn_1
            // 
            pn_1.Location = new Point(5, 7);
            pn_1.Margin = new Padding(3, 4, 3, 4);
            pn_1.Name = "pn_1";
            pn_1.Size = new Size(229, 167);
            pn_1.TabIndex = 0;
            // 
            // pn_2
            // 
            pn_2.Location = new Point(415, 7);
            pn_2.Margin = new Padding(3, 4, 3, 4);
            pn_2.Name = "pn_2";
            pn_2.Size = new Size(229, 133);
            pn_2.TabIndex = 1;
            // 
            // pn_3
            // 
            pn_3.Location = new Point(825, 7);
            pn_3.Margin = new Padding(3, 4, 3, 4);
            pn_3.Name = "pn_3";
            pn_3.Size = new Size(229, 133);
            pn_3.TabIndex = 2;
            // 
            // pn_4
            // 
            pn_4.Location = new Point(5, 412);
            pn_4.Margin = new Padding(3, 4, 3, 4);
            pn_4.Name = "pn_4";
            pn_4.Size = new Size(229, 133);
            pn_4.TabIndex = 3;
            // 
            // pn_5
            // 
            pn_5.Location = new Point(415, 412);
            pn_5.Margin = new Padding(3, 4, 3, 4);
            pn_5.Name = "pn_5";
            pn_5.Size = new Size(229, 133);
            pn_5.TabIndex = 4;
            // 
            // pn_6
            // 
            pn_6.Controls.Add(groupBox1);
            pn_6.Dock = DockStyle.Fill;
            pn_6.Location = new Point(825, 412);
            pn_6.Margin = new Padding(3, 4, 3, 4);
            pn_6.Name = "pn_6";
            pn_6.Size = new Size(405, 397);
            pn_6.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(infoserver);
            groupBox1.Controls.Add(infointerval);
            groupBox1.Controls.Add(infolocal);
            groupBox1.Controls.Add(infosite);
            groupBox1.Controls.Add(infoprefix);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(405, 397);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 98);
            label1.Name = "label1";
            label1.Size = new Size(46, 19);
            label1.TabIndex = 41;
            label1.Text = "Time:";
            // 
            // infoserver
            // 
            infoserver.AutoSize = true;
            infoserver.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            infoserver.ForeColor = Color.White;
            infoserver.Location = new Point(16, 189);
            infoserver.Name = "infoserver";
            infoserver.Size = new Size(88, 19);
            infoserver.TabIndex = 40;
            infoserver.Text = "Server Path";
            // 
            // infointerval
            // 
            infointerval.AutoSize = true;
            infointerval.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            infointerval.ForeColor = Color.White;
            infointerval.Location = new Point(57, 98);
            infointerval.Name = "infointerval";
            infointerval.Size = new Size(93, 19);
            infointerval.TabIndex = 38;
            infointerval.Text = "Rec. Interval";
            // 
            // infolocal
            // 
            infolocal.AutoSize = true;
            infolocal.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            infolocal.ForeColor = Color.White;
            infolocal.Location = new Point(14, 136);
            infolocal.Name = "infolocal";
            infolocal.Size = new Size(71, 19);
            infolocal.TabIndex = 39;
            infolocal.Text = "Rec. Path";
            // 
            // infosite
            // 
            infosite.AutoSize = true;
            infosite.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            infosite.ForeColor = Color.White;
            infosite.Location = new Point(12, 32);
            infosite.Name = "infosite";
            infosite.Size = new Size(87, 19);
            infosite.TabIndex = 35;
            infosite.Text = "WORK SITE:";
            // 
            // infoprefix
            // 
            infoprefix.AutoSize = true;
            infoprefix.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            infoprefix.ForeColor = Color.White;
            infoprefix.Location = new Point(12, 65);
            infoprefix.Name = "infoprefix";
            infoprefix.Size = new Size(94, 19);
            infoprefix.TabIndex = 34;
            infoprefix.Text = "CAM PREFIX:";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 881);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RECORDER";
            FormClosing += FrmMain_FormClosing;
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pn_6.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripButton btnConfig;
        private Panel panel1;
        private ToolStripButton btnReccord;
        private TableLayoutPanel tableLayoutPanel1;
        private ucCameraViewer ucCameraViewer1;
        private ucCameraViewer ucCameraViewer2;
        private Panel pn_1;
        private Panel pn_2;
        private Panel pn_3;
        private Panel pn_4;
        private Panel pn_5;
        private Panel pn_6;
        public ToolStripButton btnlive;
        public ToolStrip toolStrip1;
        public ToolStripButton btnPlayback;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private GroupBox groupBox1;
        private Label infosite;
        private Label infoprefix;
        private Label infoserver;
        private Label infointerval;
        private Label infolocal;
        private Label label1;
    }
}