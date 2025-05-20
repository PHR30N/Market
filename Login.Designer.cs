namespace Market
{
    partial class Login
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
            this.login_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.login_password_label = new System.Windows.Forms.Label();
            this.login_username = new System.Windows.Forms.TextBox();
            this.login_password = new System.Windows.Forms.TextBox();
            this.login_username_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.login_create_new_account = new System.Windows.Forms.LinkLabel();
            this.login_show_password = new System.Windows.Forms.CheckBox();
            this.login_email_label = new System.Windows.Forms.Label();
            this.login_email = new System.Windows.Forms.TextBox();
            this.login_forgot_your_password = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.login_btn.Location = new System.Drawing.Point(963, 323);
            this.login_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(178, 86);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.Login_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 35);
            this.label1.TabIndex = 6;
            // 
            // login_password_label
            // 
            this.login_password_label.AutoSize = true;
            this.login_password_label.BackColor = System.Drawing.SystemColors.GrayText;
            this.login_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password_label.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.login_password_label.Location = new System.Drawing.Point(506, 235);
            this.login_password_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_password_label.Name = "login_password_label";
            this.login_password_label.Size = new System.Drawing.Size(128, 29);
            this.login_password_label.TabIndex = 2;
            this.login_password_label.Text = "Password";
            // 
            // login_username
            // 
            this.login_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login_username.Location = new System.Drawing.Point(712, 109);
            this.login_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(427, 26);
            this.login_username.TabIndex = 4;
            // 
            // login_password
            // 
            this.login_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login_password.Location = new System.Drawing.Point(712, 238);
            this.login_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_password.Name = "login_password";
            this.login_password.Size = new System.Drawing.Size(427, 26);
            this.login_password.TabIndex = 5;
            this.login_password.TextChanged += new System.EventHandler(this.login_password_TextChanged);
            // 
            // login_username_label
            // 
            this.login_username_label.AutoSize = true;
            this.login_username_label.BackColor = System.Drawing.SystemColors.GrayText;
            this.login_username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_username_label.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.login_username_label.Location = new System.Drawing.Point(506, 109);
            this.login_username_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_username_label.Name = "login_username_label";
            this.login_username_label.Size = new System.Drawing.Size(132, 29);
            this.login_username_label.TabIndex = 7;
            this.login_username_label.Text = "Username";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-8, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 694);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Market.Properties.Resources.login;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 237);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 47);
            this.label4.TabIndex = 0;
            this.label4.Text = "Login Page";
            // 
            // login_create_new_account
            // 
            this.login_create_new_account.AutoSize = true;
            this.login_create_new_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic);
            this.login_create_new_account.Location = new System.Drawing.Point(642, 469);
            this.login_create_new_account.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_create_new_account.Name = "login_create_new_account";
            this.login_create_new_account.Size = new System.Drawing.Size(212, 26);
            this.login_create_new_account.TabIndex = 10;
            this.login_create_new_account.TabStop = true;
            this.login_create_new_account.Text = "Create New Account";
            this.login_create_new_account.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.login_create_new_account_LinkClicked);
            // 
            // login_show_password
            // 
            this.login_show_password.AutoSize = true;
            this.login_show_password.Location = new System.Drawing.Point(988, 275);
            this.login_show_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_show_password.Name = "login_show_password";
            this.login_show_password.Size = new System.Drawing.Size(148, 24);
            this.login_show_password.TabIndex = 27;
            this.login_show_password.Text = "Show Password";
            this.login_show_password.UseVisualStyleBackColor = true;
            this.login_show_password.CheckedChanged += new System.EventHandler(this.login_show_password_CheckedChanged);
            // 
            // login_email_label
            // 
            this.login_email_label.AutoSize = true;
            this.login_email_label.BackColor = System.Drawing.SystemColors.GrayText;
            this.login_email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_email_label.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.login_email_label.Location = new System.Drawing.Point(506, 235);
            this.login_email_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_email_label.Name = "login_email_label";
            this.login_email_label.Size = new System.Drawing.Size(88, 29);
            this.login_email_label.TabIndex = 29;
            this.login_email_label.Text = "E-mail";
            // 
            // login_email
            // 
            this.login_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login_email.Location = new System.Drawing.Point(712, 238);
            this.login_email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_email.Name = "login_email";
            this.login_email.Size = new System.Drawing.Size(427, 26);
            this.login_email.TabIndex = 28;
            // 
            // login_forgot_your_password
            // 
            this.login_forgot_your_password.AutoSize = true;
            this.login_forgot_your_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_forgot_your_password.ForeColor = System.Drawing.Color.Blue;
            this.login_forgot_your_password.Location = new System.Drawing.Point(916, 463);
            this.login_forgot_your_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login_forgot_your_password.Name = "login_forgot_your_password";
            this.login_forgot_your_password.Size = new System.Drawing.Size(280, 33);
            this.login_forgot_your_password.TabIndex = 30;
            this.login_forgot_your_password.Text = "Forgot Your Password";
            this.login_forgot_your_password.UseVisualStyleBackColor = true;
            this.login_forgot_your_password.CheckedChanged += new System.EventHandler(this.login_forgot_your_password_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.login_username_label);
            this.Controls.Add(this.login_forgot_your_password);
            this.Controls.Add(this.login_show_password);
            this.Controls.Add(this.login_create_new_account);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.login_password_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.login_email_label);
            this.Controls.Add(this.login_email);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label login_password_label;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Label login_username_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel login_create_new_account;
        private System.Windows.Forms.CheckBox login_show_password;
        private System.Windows.Forms.Label login_email_label;
        private System.Windows.Forms.TextBox login_email;
        private System.Windows.Forms.CheckBox login_forgot_your_password;
    }
}

