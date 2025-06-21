namespace Unicom_TIC_Management.View
{
    partial class LecturerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturerForm));
            this.linkbtn = new System.Windows.Forms.Button();
            this.backpicbox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvlecturer = new System.Windows.Forms.DataGridView();
            this.btnedit = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnic = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlecturer)).BeginInit();
            this.SuspendLayout();
            // 
            // linkbtn
            // 
            this.linkbtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkbtn.Location = new System.Drawing.Point(224, 371);
            this.linkbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.linkbtn.Name = "linkbtn";
            this.linkbtn.Size = new System.Drawing.Size(226, 30);
            this.linkbtn.TabIndex = 29;
            this.linkbtn.Text = "Link Subject with Lecturer";
            this.linkbtn.UseVisualStyleBackColor = false;
            this.linkbtn.Click += new System.EventHandler(this.linkbtn_Click);
            // 
            // backpicbox
            // 
            this.backpicbox.BackColor = System.Drawing.SystemColors.Control;
            this.backpicbox.Image = ((System.Drawing.Image)(resources.GetObject("backpicbox.Image")));
            this.backpicbox.Location = new System.Drawing.Point(22, 24);
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
            this.label2.Location = new System.Drawing.Point(139, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "Lecturer Management";
            // 
            // dgvlecturer
            // 
            this.dgvlecturer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlecturer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlecturer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvlecturer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlecturer.Location = new System.Drawing.Point(87, 417);
            this.dgvlecturer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvlecturer.Name = "dgvlecturer";
            this.dgvlecturer.RowHeadersWidth = 62;
            this.dgvlecturer.RowTemplate.Height = 28;
            this.dgvlecturer.Size = new System.Drawing.Size(363, 174);
            this.dgvlecturer.TabIndex = 26;
            this.dgvlecturer.SelectionChanged += new System.EventHandler(this.dgvlecturer_SelectionChanged);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(352, 308);
            this.btnedit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(98, 30);
            this.btnedit.TabIndex = 25;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(224, 91);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(226, 22);
            this.txtname.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Lecturer Name";
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(87, 308);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(91, 30);
            this.btndelete.TabIndex = 22;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "NIC";
            // 
            // txtnic
            // 
            this.txtnic.Location = new System.Drawing.Point(224, 146);
            this.txtnic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnic.Name = "txtnic";
            this.txtnic.Size = new System.Drawing.Size(226, 22);
            this.txtnic.TabIndex = 31;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(224, 195);
            this.txtusername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(226, 22);
            this.txtusername.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Username";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(224, 246);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(226, 22);
            this.txtpassword.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Password";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(224, 308);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(95, 30);
            this.btnadd.TabIndex = 36;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 640);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkbtn);
            this.Controls.Add(this.backpicbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvlecturer);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndelete);
            this.Name = "LecturerForm";
            this.Text = "LecturerForm";
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backpicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlecturer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button linkbtn;
        private System.Windows.Forms.PictureBox backpicbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvlecturer;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnic;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnadd;
    }
}