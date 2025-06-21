namespace Unicom_TIC_Management.View
{
    partial class PasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtold = new System.Windows.Forms.TextBox();
            this.btnchange = new System.Windows.Forms.Button();
            this.txtnew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password";
            // 
            // txtold
            // 
            this.txtold.Location = new System.Drawing.Point(248, 68);
            this.txtold.Name = "txtold";
            this.txtold.Size = new System.Drawing.Size(239, 22);
            this.txtold.TabIndex = 1;
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnchange.Location = new System.Drawing.Point(308, 212);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(179, 29);
            this.btnchange.TabIndex = 2;
            this.btnchange.Text = "Change Password";
            this.btnchange.UseVisualStyleBackColor = false;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // txtnew
            // 
            this.txtnew.Location = new System.Drawing.Point(248, 113);
            this.txtnew.Name = "txtnew";
            this.txtnew.Size = new System.Drawing.Size(239, 22);
            this.txtnew.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(248, 158);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(239, 22);
            this.txtconfirm.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm New Password";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 367);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.txtold);
            this.Controls.Add(this.label1);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtold;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.TextBox txtnew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label3;
    }
}