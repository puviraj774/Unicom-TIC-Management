namespace Unicom_TIC_Management.View
{
    partial class LecturerSubjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturerSubjectForm));
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.coblecturer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvlecturersubject = new System.Windows.Forms.DataGridView();
            this.cobsubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlecturersubject)).BeginInit();
            this.SuspendLayout();
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(28, 25);
            this.backpicbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backpicbox.Name = "backpicbox";
            this.backpicbox.Size = new System.Drawing.Size(35, 31);
            this.backpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backpicbox.TabIndex = 31;
            this.backpicbox.TabStop = false;
            this.backpicbox.Click += new System.EventHandler(this.backpicbox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "Lecturer_ Subject Management";
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(402, 202);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(105, 23);
            this.btnedit.TabIndex = 29;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(251, 202);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(104, 23);
            this.btnadd.TabIndex = 28;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // coblecturer
            // 
            this.coblecturer.FormattingEnabled = true;
            this.coblecturer.Location = new System.Drawing.Point(221, 147);
            this.coblecturer.Name = "coblecturer";
            this.coblecturer.Size = new System.Drawing.Size(286, 24);
            this.coblecturer.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Lecturer";
            // 
            // dgvlecturersubject
            // 
            this.dgvlecturersubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlecturersubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlecturersubject.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvlecturersubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlecturersubject.Location = new System.Drawing.Point(93, 246);
            this.dgvlecturersubject.Name = "dgvlecturersubject";
            this.dgvlecturersubject.RowHeadersWidth = 51;
            this.dgvlecturersubject.Size = new System.Drawing.Size(414, 230);
            this.dgvlecturersubject.TabIndex = 25;
            this.dgvlecturersubject.SelectionChanged += new System.EventHandler(this.dgvlecturersubject_SelectionChanged);
            // 
            // cobsubject
            // 
            this.cobsubject.FormattingEnabled = true;
            this.cobsubject.Location = new System.Drawing.Point(221, 84);
            this.cobsubject.Name = "cobsubject";
            this.cobsubject.Size = new System.Drawing.Size(286, 24);
            this.cobsubject.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Subjects";
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(93, 202);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(105, 23);
            this.btndelete.TabIndex = 22;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // LecturerSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 488);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.coblecturer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvlecturersubject);
            this.Controls.Add(this.cobsubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndelete);
            this.Name = "LecturerSubjectForm";
            this.Text = "LecturerSubjectForm";
            this.Load += new System.EventHandler(this.LecturerSubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlecturersubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ComboBox coblecturer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvlecturersubject;
        private System.Windows.Forms.ComboBox cobsubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndelete;
    }
}