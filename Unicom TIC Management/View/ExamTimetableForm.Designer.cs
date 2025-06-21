namespace Unicom_TIC_Management.View
{
    partial class ExamTimetableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamTimetableForm));
            this.dtptime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpexam = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvexam = new System.Windows.Forms.DataGridView();
            this.cobsubject = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnaddexam = new System.Windows.Forms.Button();
            this.cobexam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvexam)).BeginInit();
            this.SuspendLayout();
            // 
            // dtptime
            // 
            this.dtptime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtptime.Location = new System.Drawing.Point(211, 262);
            this.dtptime.Name = "dtptime";
            this.dtptime.Size = new System.Drawing.Size(124, 22);
            this.dtptime.TabIndex = 35;
            this.dtptime.Value = new System.DateTime(2025, 6, 19, 0, 3, 54, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Time";
            // 
            // dtpexam
            // 
            this.dtpexam.Location = new System.Drawing.Point(211, 215);
            this.dtpexam.Name = "dtpexam";
            this.dtpexam.Size = new System.Drawing.Size(251, 22);
            this.dtpexam.TabIndex = 33;
            this.dtpexam.Value = new System.DateTime(2025, 6, 19, 0, 3, 54, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Date";
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(419, 315);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 31;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(309, 315);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 30;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Subject Name";
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(28, 27);
            this.backpicbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backpicbox.Name = "backpicbox";
            this.backpicbox.Size = new System.Drawing.Size(35, 31);
            this.backpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backpicbox.TabIndex = 28;
            this.backpicbox.TabStop = false;
            this.backpicbox.Click += new System.EventHandler(this.backpicbox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "Exam Management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Exam Name";
            // 
            // dgvexam
            // 
            this.dgvexam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvexam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvexam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvexam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvexam.Location = new System.Drawing.Point(69, 362);
            this.dgvexam.Name = "dgvexam";
            this.dgvexam.RowHeadersWidth = 51;
            this.dgvexam.RowTemplate.Height = 24;
            this.dgvexam.Size = new System.Drawing.Size(425, 228);
            this.dgvexam.TabIndex = 24;
            this.dgvexam.SelectionChanged += new System.EventHandler(this.dgvexam_SelectionChanged);
            // 
            // cobsubject
            // 
            this.cobsubject.FormattingEnabled = true;
            this.cobsubject.Location = new System.Drawing.Point(211, 174);
            this.cobsubject.Name = "cobsubject";
            this.cobsubject.Size = new System.Drawing.Size(287, 24);
            this.cobsubject.TabIndex = 23;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(207, 315);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 22;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnaddexam
            // 
            this.btnaddexam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnaddexam.Location = new System.Drawing.Point(344, 135);
            this.btnaddexam.Name = "btnaddexam";
            this.btnaddexam.Size = new System.Drawing.Size(154, 33);
            this.btnaddexam.TabIndex = 36;
            this.btnaddexam.Text = "Add Exams";
            this.btnaddexam.UseVisualStyleBackColor = false;
            this.btnaddexam.Click += new System.EventHandler(this.btnaddexam_Click);
            // 
            // cobexam
            // 
            this.cobexam.FormattingEnabled = true;
            this.cobexam.Location = new System.Drawing.Point(207, 98);
            this.cobexam.Name = "cobexam";
            this.cobexam.Size = new System.Drawing.Size(287, 24);
            this.cobexam.TabIndex = 37;
            // 
            // ExamTimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 703);
            this.Controls.Add(this.cobexam);
            this.Controls.Add(this.btnaddexam);
            this.Controls.Add(this.dtptime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpexam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvexam);
            this.Controls.Add(this.cobsubject);
            this.Controls.Add(this.btndelete);
            this.Name = "ExamTimetableForm";
            this.Text = "ExamForm";
            this.Load += new System.EventHandler(this.ExamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvexam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtptime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpexam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvexam;
        private System.Windows.Forms.ComboBox cobsubject;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnaddexam;
        private System.Windows.Forms.ComboBox cobexam;
    }
}