namespace Unicom_TIC_Management.View
{
    partial class MarkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkForm));
            this.dgvmarks = new System.Windows.Forms.DataGridView();
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobexamname = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cobstudent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtmark = new System.Windows.Forms.TextBox();
            this.cobsubject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvmarks
            // 
            this.dgvmarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvmarks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvmarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmarks.Location = new System.Drawing.Point(40, 384);
            this.dgvmarks.Name = "dgvmarks";
            this.dgvmarks.RowHeadersWidth = 51;
            this.dgvmarks.RowTemplate.Height = 24;
            this.dgvmarks.Size = new System.Drawing.Size(500, 228);
            this.dgvmarks.TabIndex = 57;
            this.dgvmarks.SelectionChanged += new System.EventHandler(this.dgvmarks_SelectionChanged);
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(40, 33);
            this.backpicbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backpicbox.Name = "backpicbox";
            this.backpicbox.Size = new System.Drawing.Size(35, 31);
            this.backpicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backpicbox.TabIndex = 55;
            this.backpicbox.TabStop = false;
            this.backpicbox.Click += new System.EventHandler(this.backpicbox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 29);
            this.label4.TabIndex = 54;
            this.label4.Text = "Marks Management";
            // 
            // cobexamname
            // 
            this.cobexamname.FormattingEnabled = true;
            this.cobexamname.Location = new System.Drawing.Point(218, 170);
            this.cobexamname.Name = "cobexamname";
            this.cobexamname.Size = new System.Drawing.Size(322, 24);
            this.cobexamname.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Exam Name";
            // 
            // cobstudent
            // 
            this.cobstudent.FormattingEnabled = true;
            this.cobstudent.Location = new System.Drawing.Point(218, 118);
            this.cobstudent.Name = "cobstudent";
            this.cobstudent.Size = new System.Drawing.Size(322, 24);
            this.cobstudent.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "Student Name";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnedit.Location = new System.Drawing.Point(218, 317);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 32);
            this.btnedit.TabIndex = 47;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Marks";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnadd.Location = new System.Drawing.Point(465, 317);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 32);
            this.btnadd.TabIndex = 60;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtmark
            // 
            this.txtmark.Location = new System.Drawing.Point(218, 271);
            this.txtmark.Name = "txtmark";
            this.txtmark.Size = new System.Drawing.Size(322, 22);
            this.txtmark.TabIndex = 61;
            // 
            // cobsubject
            // 
            this.cobsubject.FormattingEnabled = true;
            this.cobsubject.Location = new System.Drawing.Point(218, 220);
            this.cobsubject.Name = "cobsubject";
            this.cobsubject.Size = new System.Drawing.Size(322, 24);
            this.cobsubject.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Subject Name";
            // 
            // MarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 713);
            this.Controls.Add(this.cobsubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmark);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvmarks);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cobexamname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cobstudent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnedit);
            this.Name = "MarkForm";
            this.Text = "MarkForm";
            this.Load += new System.EventHandler(this.MarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvmarks;
        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cobexamname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobstudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtmark;
        private System.Windows.Forms.ComboBox cobsubject;
        private System.Windows.Forms.Label label5;
    }
}