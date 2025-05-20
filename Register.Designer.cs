namespace Market
{
    partial class Register
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
            this.register_login = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.register_password = new System.Windows.Forms.TextBox();
            this.register_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Register_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.register_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.register_full_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.register_confirm_password = new System.Windows.Forms.TextBox();
            this.register_show_password = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // register_login
            // 
            this.register_login.AutoSize = true;
            this.register_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic);
            this.register_login.Location = new System.Drawing.Point(1034, 498);
            this.register_login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.register_login.Name = "register_login";
            this.register_login.Size = new System.Drawing.Size(65, 26);
            this.register_login.TabIndex = 19;
            this.register_login.TabStop = true;
            this.register_login.Text = "Login";
            this.register_login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_login_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 694);
            this.panel1.TabIndex = 17;
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
            this.label4.Location = new System.Drawing.Point(70, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 47);
            this.label4.TabIndex = 0;
            this.label4.Text = "Register Page";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GrayText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(482, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username";
            // 
            // register_password
            // 
            this.register_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_password.Location = new System.Drawing.Point(720, 235);
            this.register_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_password.Name = "register_password";
            this.register_password.Size = new System.Drawing.Size(427, 26);
            this.register_password.TabIndex = 14;
            this.register_password.TextChanged += new System.EventHandler(this.register_password_TextChanged);
            // 
            // register_username
            // 
            this.register_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_username.Location = new System.Drawing.Point(720, 112);
            this.register_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_username.Name = "register_username";
            this.register_username.Size = new System.Drawing.Size(427, 26);
            this.register_username.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(482, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 35);
            this.label1.TabIndex = 15;
            // 
            // Register_btn
            // 
            this.Register_btn.AutoSize = true;
            this.Register_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.Register_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Register_btn.Location = new System.Drawing.Point(970, 380);
            this.Register_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(178, 86);
            this.Register_btn.TabIndex = 11;
            this.Register_btn.Text = "Register";
            this.Register_btn.UseVisualStyleBackColor = false;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GrayText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(482, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "E-mail";
            // 
            // register_email
            // 
            this.register_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_email.Location = new System.Drawing.Point(720, 52);
            this.register_email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_email.Name = "register_email";
            this.register_email.Size = new System.Drawing.Size(427, 26);
            this.register_email.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GrayText;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(482, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Full Name";
            // 
            // register_full_name
            // 
            this.register_full_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_full_name.Location = new System.Drawing.Point(720, 175);
            this.register_full_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_full_name.Name = "register_full_name";
            this.register_full_name.Size = new System.Drawing.Size(427, 26);
            this.register_full_name.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GrayText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(482, 286);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Confirm Password";
            // 
            // register_confirm_password
            // 
            this.register_confirm_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_confirm_password.Location = new System.Drawing.Point(720, 286);
            this.register_confirm_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_confirm_password.Name = "register_confirm_password";
            this.register_confirm_password.Size = new System.Drawing.Size(427, 26);
            this.register_confirm_password.TabIndex = 24;
            this.register_confirm_password.TextChanged += new System.EventHandler(this.register_confirm_password_TextChanged);
            // 
            // register_show_password
            // 
            this.register_show_password.AutoSize = true;
            this.register_show_password.Location = new System.Drawing.Point(996, 326);
            this.register_show_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.register_show_password.Name = "register_show_password";
            this.register_show_password.Size = new System.Drawing.Size(148, 24);
            this.register_show_password.TabIndex = 26;
            this.register_show_password.Text = "Show Password";
            this.register_show_password.UseVisualStyleBackColor = true;
            this.register_show_password.CheckedChanged += new System.EventHandler(this.register_show_password_CheckedChanged);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.register_show_password);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.register_confirm_password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.register_full_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.register_email);
            this.Controls.Add(this.register_login);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.register_password);
            this.Controls.Add(this.register_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Register_btn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Register";
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel register_login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox register_password;
        private System.Windows.Forms.TextBox register_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox register_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox register_full_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox register_confirm_password;
        private System.Windows.Forms.CheckBox register_show_password;
    }
}