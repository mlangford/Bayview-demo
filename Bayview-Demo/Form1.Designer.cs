namespace Bayview_Demo
{
    partial class Form1
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
            this.btncnl = new System.Windows.Forms.Button();
            this.btnpwd = new System.Windows.Forms.Button();
            this.tbreset1 = new System.Windows.Forms.TextBox();
            this.lbnewpwd1 = new System.Windows.Forms.Label();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnbook = new System.Windows.Forms.Button();
            this.btncust = new System.Windows.Forms.Button();
            this.btnnewpwd = new System.Windows.Forms.Button();
            this.tbpasswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncnl
            // 
            this.btncnl.Location = new System.Drawing.Point(388, 344);
            this.btncnl.Name = "btncnl";
            this.btncnl.Size = new System.Drawing.Size(75, 28);
            this.btncnl.TabIndex = 33;
            this.btncnl.Text = "Cancel";
            this.btncnl.UseVisualStyleBackColor = true;
            this.btncnl.Visible = false;
            // 
            // btnpwd
            // 
            this.btnpwd.Location = new System.Drawing.Point(469, 344);
            this.btnpwd.Name = "btnpwd";
            this.btnpwd.Size = new System.Drawing.Size(75, 28);
            this.btnpwd.TabIndex = 32;
            this.btnpwd.Text = "Submit";
            this.btnpwd.UseVisualStyleBackColor = true;
            this.btnpwd.Visible = false;
            // 
            // tbreset1
            // 
            this.tbreset1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbreset1.Location = new System.Drawing.Point(232, 291);
            this.tbreset1.Name = "tbreset1";
            this.tbreset1.Size = new System.Drawing.Size(312, 34);
            this.tbreset1.TabIndex = 31;
            this.tbreset1.Visible = false;
            // 
            // lbnewpwd1
            // 
            this.lbnewpwd1.AutoSize = true;
            this.lbnewpwd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnewpwd1.Location = new System.Drawing.Point(59, 291);
            this.lbnewpwd1.Name = "lbnewpwd1";
            this.lbnewpwd1.Size = new System.Drawing.Size(140, 25);
            this.lbnewpwd1.TabIndex = 30;
            this.lbnewpwd1.Text = "New password";
            this.lbnewpwd1.Visible = false;
            // 
            // btnlogout
            // 
            this.btnlogout.Enabled = false;
            this.btnlogout.Location = new System.Drawing.Point(651, 19);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(86, 42);
            this.btnlogout.TabIndex = 29;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = true;
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(469, 118);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 28);
            this.btnlogin.TabIndex = 27;
            this.btnlogin.Text = "Submit";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnbook
            // 
            this.btnbook.Enabled = false;
            this.btnbook.Location = new System.Drawing.Point(651, 118);
            this.btnbook.Name = "btnbook";
            this.btnbook.Size = new System.Drawing.Size(86, 71);
            this.btnbook.TabIndex = 26;
            this.btnbook.Text = "Bookings";
            this.btnbook.UseVisualStyleBackColor = true;
            // 
            // btncust
            // 
            this.btncust.Enabled = false;
            this.btncust.Location = new System.Drawing.Point(651, 196);
            this.btncust.Name = "btncust";
            this.btncust.Size = new System.Drawing.Size(86, 71);
            this.btncust.TabIndex = 25;
            this.btncust.Text = "Customers";
            this.btncust.UseVisualStyleBackColor = true;
            // 
            // btnnewpwd
            // 
            this.btnnewpwd.Enabled = false;
            this.btnnewpwd.Location = new System.Drawing.Point(651, 325);
            this.btnnewpwd.Name = "btnnewpwd";
            this.btnnewpwd.Size = new System.Drawing.Size(86, 47);
            this.btnnewpwd.TabIndex = 24;
            this.btnnewpwd.Text = "New\r\nPassword";
            this.btnnewpwd.UseVisualStyleBackColor = true;
            // 
            // tbpasswd
            // 
            this.tbpasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpasswd.Location = new System.Drawing.Point(232, 69);
            this.tbpasswd.Name = "tbpasswd";
            this.tbpasswd.Size = new System.Drawing.Size(312, 34);
            this.tbpasswd.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Password";
            // 
            // tbusername
            // 
            this.tbusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbusername.Location = new System.Drawing.Point(232, 19);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(312, 34);
            this.tbusername.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Staff Username";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(786, 459);
            this.Controls.Add(this.btncnl);
            this.Controls.Add(this.btnpwd);
            this.Controls.Add(this.tbreset1);
            this.Controls.Add(this.lbnewpwd1);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.btnbook);
            this.Controls.Add(this.btncust);
            this.Controls.Add(this.btnnewpwd);
            this.Controls.Add(this.tbpasswd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bay View Hotel Inormation System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncnl;
        private System.Windows.Forms.Button btnpwd;
        private System.Windows.Forms.TextBox tbreset1;
        private System.Windows.Forms.Label lbnewpwd1;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnbook;
        private System.Windows.Forms.Button btncust;
        private System.Windows.Forms.Button btnnewpwd;
        private System.Windows.Forms.TextBox tbpasswd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.Label label1;
    }
}

