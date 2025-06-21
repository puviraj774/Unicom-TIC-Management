namespace Unicom_TIC_Management.View
{
    partial class ViewOwnMarks
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
            this.dgvOwnMarks = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOwnMarks
            // 
            this.dgvOwnMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOwnMarks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOwnMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwnMarks.Location = new System.Drawing.Point(49, 105);
            this.dgvOwnMarks.Name = "dgvOwnMarks";
            this.dgvOwnMarks.RowHeadersWidth = 51;
            this.dgvOwnMarks.RowTemplate.Height = 24;
            this.dgvOwnMarks.Size = new System.Drawing.Size(497, 401);
            this.dgvOwnMarks.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Marks";
            // 
            // ViewOwnMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 518);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvOwnMarks);
            this.Name = "ViewOwnMarks";
            this.Text = "ViewOwnMarks";
            this.Load += new System.EventHandler(this.ViewOwnMarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOwnMarks;
        private System.Windows.Forms.Label label2;
    }
}