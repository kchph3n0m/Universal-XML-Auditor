namespace Universal_XML_Auditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            status_strip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            btnExport = new Button();
            btnRun = new Button();
            lblXml = new Label();
            lblXsd = new Label();
            lstErrors = new ListBox();
            txtXmlPath = new TextBox();
            txtXsdPath = new TextBox();
            btnBrowseXml = new Button();
            btnBrowseXsd = new Button();
            groupBox1.SuspendLayout();
            status_strip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(status_strip1);
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnRun);
            groupBox1.Controls.Add(lblXml);
            groupBox1.Controls.Add(lblXsd);
            groupBox1.Location = new Point(19, 355);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(769, 110);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // status_strip1
            // 
            status_strip1.Items.AddRange(new ToolStripItem[] { lblStatus, toolStripProgressBar1 });
            status_strip1.Location = new Point(3, 83);
            status_strip1.Name = "status_strip1";
            status_strip1.Size = new Size(763, 24);
            status_strip1.TabIndex = 11;
            status_strip1.Text = "Ready";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(436, 19);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Padding = new Padding(10, 0, 0, 0);
            toolStripProgressBar1.Size = new Size(310, 18);
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExport.Location = new Point(623, 48);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(84, 25);
            btnExport.TabIndex = 10;
            btnExport.Text = "Save Report";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRun.Location = new Point(623, 19);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(84, 24);
            btnRun.TabIndex = 7;
            btnRun.Text = "Run Audit";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnValidate_Click;
            // 
            // lblXml
            // 
            lblXml.AutoSize = true;
            lblXml.Location = new Point(6, 22);
            lblXml.Name = "lblXml";
            lblXml.Size = new Size(61, 15);
            lblXml.TabIndex = 4;
            lblXml.Text = "XML Path:";
            // 
            // lblXsd
            // 
            lblXsd.AutoSize = true;
            lblXsd.Location = new Point(6, 51);
            lblXsd.Name = "lblXsd";
            lblXsd.Size = new Size(58, 15);
            lblXsd.TabIndex = 5;
            lblXsd.Text = "XSD Path:";
            // 
            // lstErrors
            // 
            lstErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstErrors.FormattingEnabled = true;
            lstErrors.Location = new Point(19, 12);
            lstErrors.Name = "lstErrors";
            lstErrors.Size = new Size(769, 349);
            lstErrors.TabIndex = 8;
            // 
            // txtXmlPath
            // 
            txtXmlPath.Location = new Point(87, 374);
            txtXmlPath.Name = "txtXmlPath";
            txtXmlPath.Size = new Size(416, 23);
            txtXmlPath.TabIndex = 2;
            // 
            // txtXsdPath
            // 
            txtXsdPath.Location = new Point(87, 403);
            txtXsdPath.Name = "txtXsdPath";
            txtXsdPath.Size = new Size(416, 23);
            txtXsdPath.TabIndex = 3;
            // 
            // btnBrowseXml
            // 
            btnBrowseXml.Location = new Point(509, 374);
            btnBrowseXml.Name = "btnBrowseXml";
            btnBrowseXml.Size = new Size(75, 23);
            btnBrowseXml.TabIndex = 0;
            btnBrowseXml.Text = "Browse...";
            btnBrowseXml.UseVisualStyleBackColor = true;
            btnBrowseXml.Click += btnBrowseXml_Click;
            // 
            // btnBrowseXsd
            // 
            btnBrowseXsd.Location = new Point(509, 403);
            btnBrowseXsd.Name = "btnBrowseXsd";
            btnBrowseXsd.Size = new Size(75, 23);
            btnBrowseXsd.TabIndex = 6;
            btnBrowseXsd.Text = "Browse...";
            btnBrowseXsd.UseVisualStyleBackColor = true;
            btnBrowseXsd.Click += btnBrowseXsd_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 475);
            Controls.Add(lstErrors);
            Controls.Add(btnBrowseXsd);
            Controls.Add(btnBrowseXml);
            Controls.Add(txtXsdPath);
            Controls.Add(txtXmlPath);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Universal XML Auditor v1.1.0";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            status_strip1.ResumeLayout(false);
            status_strip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtXmlPath;
        private TextBox txtXsdPath;
        private Label lblXml;
        private Label lblXsd;
        private Button btnBrowseXml;
        private Button btnBrowseXsd;
        private ListBox lstErrors;
        private Button btnRun;
        private Button btnExport;
        private StatusStrip status_strip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
