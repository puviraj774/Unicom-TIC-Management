namespace Unicom_TIC_Management.View
{
    partial class ViewExamTimetable
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
            this.dgvexam = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvexam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvexam
            // 
            this.dgvexam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvexam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvexam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvexam.Location = new System.Drawing.Point(74, 135);
            this.dgvexam.Name = "dgvexam";
            this.dgvexam.RowHeadersWidth = 51;
            this.dgvexam.RowTemplate.Height = 24;
            this.dgvexam.Size = new System.Drawing.Size(682, 521);
            this.dgvexam.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 29);
            this.label4.TabIndex = 55;
            this.label4.Text = "Exam Timetable";
            // 
            // ViewExamTimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 668);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvexam);
            this.Name = "ViewExamTimetable";
            this.Text = "ViewExamTimetable";
            this.Load += new System.EventHandler(this.ViewExamTimetable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvexam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvexam;
        private System.Windows.Forms.Label label4;
    }
}