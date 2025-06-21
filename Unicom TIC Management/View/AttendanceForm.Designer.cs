namespace Unicom_TIC_Management.View
{
    partial class AttendanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceForm));
            this.btnsubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cobstudent = new System.Windows.Forms.ComboBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cobstatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.btnchange = new System.Windows.Forms.Button();
            this.dgvattendance = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvattendance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnsubmit.Location = new System.Drawing.Point(375, 268);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 32);
            this.btnsubmit.TabIndex = 0;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cobstudent
            // 
            this.cobstudent.FormattingEnabled = true;
            this.cobstudent.Location = new System.Drawing.Point(207, 121);
            this.cobstudent.Name = "cobstudent";
            this.cobstudent.Size = new System.Drawing.Size(243, 24);
            this.cobstudent.TabIndex = 2;
            this.cobstudent.SelectedIndexChanged += new System.EventHandler(this.cobstudent_SelectedIndexChanged);
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(207, 174);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(114, 22);
            this.dtpdate.TabIndex = 3;
            this.dtpdate.ValueChanged += new System.EventHandler(this.dtpdate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cobstatus
            // 
            this.cobstatus.FormattingEnabled = true;
            this.cobstatus.Location = new System.Drawing.Point(207, 219);
            this.cobstatus.Name = "cobstatus";
            this.cobstatus.Size = new System.Drawing.Size(243, 24);
            this.cobstatus.TabIndex = 6;
            this.cobstatus.SelectedIndexChanged += new System.EventHandler(this.cobstatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "Attendance Management";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(29, 36);
            this.backpicbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backpicbox.Name = "backpicbox";
            this.backpicbox.Size = new System.Drawing.Size(35, 31);
            this.backpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backpicbox.TabIndex = 44;
            this.backpicbox.TabStop = false;
            this.backpicbox.Click += new System.EventHandler(this.backpicbox_Click);
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnchange.Location = new System.Drawing.Point(207, 268);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(75, 32);
            this.btnchange.TabIndex = 45;
            this.btnchange.Text = "Change";
            this.btnchange.UseVisualStyleBackColor = false;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // dgvattendance
            // 
            this.dgvattendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvattendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvattendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvattendance.Location = new System.Drawing.Point(29, 377);
            this.dgvattendance.Name = "dgvattendance";
            this.dgvattendance.RowHeadersWidth = 51;
            this.dgvattendance.RowTemplate.Height = 24;
            this.dgvattendance.Size = new System.Drawing.Size(459, 228);
            this.dgvattendance.TabIndex = 46;
            this.dgvattendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvattendance_CellContentClick);
            this.dgvattendance.SelectionChanged += new System.EventHandler(this.dgvattendance_SelectionChanged);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 617);
            this.Controls.Add(this.dgvattendance);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cobstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.cobstudent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsubmit);
            this.Name = "AttendanceForm";
            this.Text = "Attendance Form";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvattendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobstudent;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.DataGridView dgvattendance;
    }
}