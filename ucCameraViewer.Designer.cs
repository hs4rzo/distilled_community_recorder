namespace distilled_community_recorder
{
    partial class ucCameraViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Black;
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(406, 24);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "...";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(406, 341);
            panel1.TabIndex = 1;
            // 
            // ucCameraViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(panel1);
            Controls.Add(lblMessage);
            Name = "ucCameraViewer";
            Size = new Size(406, 365);
            Load += ucCameraViewer_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private Panel panel1;
    }
}
