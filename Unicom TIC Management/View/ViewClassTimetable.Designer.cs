namespace Unicom_TIC_Management.View
{
    partial class ViewClassTimetable
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
            this.dgvtimetable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvtimetable
            // 
            this.dgvtimetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtimetable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvtimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtimetable.Location = new System.Drawing.Point(58, 89);
            this.dgvtimetable.Name = "dgvtimetable";
            this.dgvtimetable.RowHeadersWidth = 51;
            this.dgvtimetable.RowTemplate.Height = 24;
            this.dgvtimetable.Size = new System.Drawing.Size(659, 551);
            this.dgvtimetable.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "View Class Timetable";
            // 
            // ViewClassTimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 652);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvtimetable);
            this.Name = "ViewClassTimetable";
            this.Text = "ViewClassTimetable";
            this.Load += new System.EventHandler(this.ViewClassTimetable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvtimetable;
        private System.Windows.Forms.Label label2;
    }
}