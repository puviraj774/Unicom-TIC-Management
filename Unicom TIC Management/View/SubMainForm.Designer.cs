namespace Unicom_TIC_Management.View
{
    partial class SubMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubMainForm));
            this.pnldown = new System.Windows.Forms.Panel();
            this.btnmarksmanagement = new System.Windows.Forms.Button();
            this.btnexammanagement = new System.Windows.Forms.Button();
            this.btnviewmarks = new System.Windows.Forms.Button();
            this.btnviewclass = new System.Windows.Forms.Button();
            this.btnviewexam = new System.Windows.Forms.Button();
            this.pnlup = new System.Windows.Forms.Panel();
            this.labelhead = new System.Windows.Forms.Label();
            this.pnlcenter = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.pnldown.SuspendLayout();
            this.pnlup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnldown
            // 
            this.pnldown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnldown.Controls.Add(this.logoutbtn);
            this.pnldown.Controls.Add(this.pictureBox1);
            this.pnldown.Controls.Add(this.btnmarksmanagement);
            this.pnldown.Controls.Add(this.btnexammanagement);
            this.pnldown.Controls.Add(this.btnviewmarks);
            this.pnldown.Controls.Add(this.btnviewclass);
            this.pnldown.Controls.Add(this.btnviewexam);
            this.pnldown.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnldown.Location = new System.Drawing.Point(0, 0);
            this.pnldown.Name = "pnldown";
            this.pnldown.Size = new System.Drawing.Size(217, 769);
            this.pnldown.TabIndex = 0;
            // 
            // btnmarksmanagement
            // 
            this.btnmarksmanagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmarksmanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmarksmanagement.Location = new System.Drawing.Point(12, 454);
            this.btnmarksmanagement.Name = "btnmarksmanagement";
            this.btnmarksmanagement.Size = new System.Drawing.Size(192, 60);
            this.btnmarksmanagement.TabIndex = 4;
            this.btnmarksmanagement.Text = "Marks Management\r\n";
            this.btnmarksmanagement.UseVisualStyleBackColor = false;
            this.btnmarksmanagement.Click += new System.EventHandler(this.btnmarksmanagement_Click);
            // 
            // btnexammanagement
            // 
            this.btnexammanagement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnexammanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexammanagement.Location = new System.Drawing.Point(12, 375);
            this.btnexammanagement.Name = "btnexammanagement";
            this.btnexammanagement.Size = new System.Drawing.Size(192, 60);
            this.btnexammanagement.TabIndex = 3;
            this.btnexammanagement.Text = "Exam Management\r\n";
            this.btnexammanagement.UseVisualStyleBackColor = false;
            this.btnexammanagement.Click += new System.EventHandler(this.btnexammanagement_Click);
            // 
            // btnviewmarks
            // 
            this.btnviewmarks.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnviewmarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewmarks.Location = new System.Drawing.Point(12, 300);
            this.btnviewmarks.Name = "btnviewmarks";
            this.btnviewmarks.Size = new System.Drawing.Size(192, 60);
            this.btnviewmarks.TabIndex = 2;
            this.btnviewmarks.Text = "View Marks\r\n";
            this.btnviewmarks.UseVisualStyleBackColor = false;
            this.btnviewmarks.Click += new System.EventHandler(this.btnviewmarks_Click);
            // 
            // btnviewclass
            // 
            this.btnviewclass.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnviewclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewclass.Location = new System.Drawing.Point(12, 225);
            this.btnviewclass.Name = "btnviewclass";
            this.btnviewclass.Size = new System.Drawing.Size(192, 60);
            this.btnviewclass.TabIndex = 1;
            this.btnviewclass.Text = "View Class Timetable";
            this.btnviewclass.UseVisualStyleBackColor = false;
            this.btnviewclass.Click += new System.EventHandler(this.btnviewclass_Click);
            // 
            // btnviewexam
            // 
            this.btnviewexam.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnviewexam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewexam.Location = new System.Drawing.Point(12, 140);
            this.btnviewexam.Name = "btnviewexam";
            this.btnviewexam.Size = new System.Drawing.Size(192, 60);
            this.btnviewexam.TabIndex = 0;
            this.btnviewexam.Text = "View Exam Timetable";
            this.btnviewexam.UseVisualStyleBackColor = false;
            this.btnviewexam.Click += new System.EventHandler(this.btnviewexam_Click);
            // 
            // pnlup
            // 
            this.pnlup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlup.Controls.Add(this.labelhead);
            this.pnlup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlup.Location = new System.Drawing.Point(217, 0);
            this.pnlup.Name = "pnlup";
            this.pnlup.Size = new System.Drawing.Size(803, 100);
            this.pnlup.TabIndex = 1;
            // 
            // labelhead
            // 
            this.labelhead.AutoSize = true;
            this.labelhead.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelhead.Location = new System.Drawing.Point(322, 36);
            this.labelhead.Name = "labelhead";
            this.labelhead.Size = new System.Drawing.Size(92, 31);
            this.labelhead.TabIndex = 0;
            this.labelhead.Text = "label1";
            // 
            // pnlcenter
            // 
            this.pnlcenter.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlcenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlcenter.Location = new System.Drawing.Point(217, 100);
            this.pnlcenter.Name = "pnlcenter";
            this.pnlcenter.Size = new System.Drawing.Size(803, 669);
            this.pnlcenter.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(48, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 100);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.Red;
            this.logoutbtn.Location = new System.Drawing.Point(129, 724);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(75, 33);
            this.logoutbtn.TabIndex = 14;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // SubMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 769);
            this.Controls.Add(this.pnlcenter);
            this.Controls.Add(this.pnlup);
            this.Controls.Add(this.pnldown);
            this.Name = "SubMainForm";
            this.Text = "SubMainForm";
            this.Load += new System.EventHandler(this.SubMainForm_Load);
            this.pnldown.ResumeLayout(false);
            this.pnlup.ResumeLayout(false);
            this.pnlup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnldown;
        private System.Windows.Forms.Panel pnlup;
        private System.Windows.Forms.Label labelhead;
        private System.Windows.Forms.Panel pnlcenter;
        private System.Windows.Forms.Button btnexammanagement;
        private System.Windows.Forms.Button btnviewmarks;
        private System.Windows.Forms.Button btnviewclass;
        private System.Windows.Forms.Button btnviewexam;
        private System.Windows.Forms.Button btnmarksmanagement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button logoutbtn;
    }
}