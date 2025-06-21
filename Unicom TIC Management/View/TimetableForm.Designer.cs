namespace Unicom_TIC_Management.View
{
    partial class TimetableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimetableForm));
            this.dtptime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpclass = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cobsubject = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.coblecturer = new System.Windows.Forms.ComboBox();
            this.cobroom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvtimetable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dtptime
            // 
            this.dtptime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtptime.Location = new System.Drawing.Point(214, 327);
            this.dtptime.Name = "dtptime";
            this.dtptime.Size = new System.Drawing.Size(124, 22);
            this.dtptime.TabIndex = 49;
            this.dtptime.Value = new System.DateTime(2025, 6, 19, 0, 3, 54, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Time";
            // 
            // dtpclass
            // 
            this.dtpclass.Location = new System.Drawing.Point(214, 280);
            this.dtpclass.Name = "dtpclass";
            this.dtpclass.Size = new System.Drawing.Size(251, 22);
            this.dtpclass.TabIndex = 47;
            this.dtpclass.Value = new System.DateTime(2025, 6, 19, 0, 3, 54, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Date";
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(422, 380);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 45;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(312, 380);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 44;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Subject Name";
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(31, 29);
            this.backpicbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backpicbox.Name = "backpicbox";
            this.backpicbox.Size = new System.Drawing.Size(35, 31);
            this.backpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backpicbox.TabIndex = 42;
            this.backpicbox.TabStop = false;
            this.backpicbox.Click += new System.EventHandler(this.backpicbox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 29);
            this.label2.TabIndex = 41;
            this.label2.Text = "Timetable Management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Lecturer Name";
            // 
            // cobsubject
            // 
            this.cobsubject.FormattingEnabled = true;
            this.cobsubject.Location = new System.Drawing.Point(214, 119);
            this.cobsubject.Name = "cobsubject";
            this.cobsubject.Size = new System.Drawing.Size(287, 24);
            this.cobsubject.TabIndex = 37;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(210, 380);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 36;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // coblecturer
            // 
            this.coblecturer.FormattingEnabled = true;
            this.coblecturer.Location = new System.Drawing.Point(214, 169);
            this.coblecturer.Name = "coblecturer";
            this.coblecturer.Size = new System.Drawing.Size(287, 24);
            this.coblecturer.TabIndex = 50;
            // 
            // cobroom
            // 
            this.cobroom.FormattingEnabled = true;
            this.cobroom.Location = new System.Drawing.Point(210, 218);
            this.cobroom.Name = "cobroom";
            this.cobroom.Size = new System.Drawing.Size(287, 24);
            this.cobroom.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Room Name";
            // 
            // dgvtimetable
            // 
            this.dgvtimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtimetable.Location = new System.Drawing.Point(72, 421);
            this.dgvtimetable.Name = "dgvtimetable";
            this.dgvtimetable.RowHeadersWidth = 51;
            this.dgvtimetable.RowTemplate.Height = 24;
            this.dgvtimetable.Size = new System.Drawing.Size(598, 202);
            this.dgvtimetable.TabIndex = 53;
            this.dgvtimetable.SelectionChanged += new System.EventHandler(this.dgvtimetable_SelectionChanged);
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 667);
            this.Controls.Add(this.dgvtimetable);
            this.Controls.Add(this.cobroom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.coblecturer);
            this.Controls.Add(this.dtptime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpclass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobsubject);
            this.Controls.Add(this.btndelete);
            this.Name = "TimetableForm";
            this.Text = "TimetableForm";
            this.Load += new System.EventHandler(this.TimetableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtptime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobsubject;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.ComboBox coblecturer;
        private System.Windows.Forms.ComboBox cobroom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvtimetable;
    }
}