namespace Unicom_TIC_Management.View
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.label1 = new System.Windows.Forms.Label();
            this.labelusername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnchange = new System.Windows.Forms.Button();
            this.labelrole = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(52, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelusername
            // 
            this.labelusername.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelusername.ForeColor = System.Drawing.Color.Orange;
            this.labelusername.Location = new System.Drawing.Point(219, 198);
            this.labelusername.Name = "labelusername";
            this.labelusername.Size = new System.Drawing.Size(225, 42);
            this.labelusername.TabIndex = 1;
            this.labelusername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(52, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnchange.Location = new System.Drawing.Point(303, 330);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(141, 29);
            this.btnchange.TabIndex = 4;
            this.btnchange.Text = "Change Password";
            this.btnchange.UseVisualStyleBackColor = false;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // labelrole
            // 
            this.labelrole.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelrole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrole.ForeColor = System.Drawing.Color.Orange;
            this.labelrole.Location = new System.Drawing.Point(219, 133);
            this.labelrole.Name = "labelrole";
            this.labelrole.Size = new System.Drawing.Size(225, 42);
            this.labelrole.TabIndex = 6;
            this.labelrole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(52, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 42);
            this.label4.TabIndex = 5;
            this.label4.Text = "Role";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtpassword.Enabled = false;
            this.txtpassword.Location = new System.Drawing.Point(223, 284);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.ReadOnly = true;
            this.txtpassword.Size = new System.Drawing.Size(221, 22);
            this.txtpassword.TabIndex = 7;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(533, 568);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.labelrole);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelusername);
            this.Controls.Add(this.label1);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.Label labelrole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpassword;
    }
}