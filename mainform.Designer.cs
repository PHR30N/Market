namespace Market
{
    partial class mainform
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.admin_search = new System.Windows.Forms.Button();
            this.admin_electronics_groupBox = new System.Windows.Forms.GroupBox();
            this.two_in_one_radioButton = new System.Windows.Forms.RadioButton();
            this.gaming_laptop_radioButton = new System.Windows.Forms.RadioButton();
            this.fold_radioButton = new System.Windows.Forms.RadioButton();
            this.gpu_radioButton = new System.Windows.Forms.RadioButton();
            this.cpu_radioButton = new System.Windows.Forms.RadioButton();
            this.laptop_radioButton = new System.Windows.Forms.RadioButton();
            this.phones_radioButton = new System.Windows.Forms.RadioButton();
            this.sign_out = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.money = new System.Windows.Forms.TextBox();
            this.discount_label = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.admin_electronics_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.admin_search);
            this.panel1.Controls.Add(this.admin_electronics_groupBox);
            this.panel1.Controls.Add(this.sign_out);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 686);
            this.panel1.TabIndex = 0;
            // 
            // admin_search
            // 
            this.admin_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            this.admin_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.admin_search.Location = new System.Drawing.Point(33, 431);
            this.admin_search.Name = "admin_search";
            this.admin_search.Size = new System.Drawing.Size(150, 55);
            this.admin_search.TabIndex = 25;
            this.admin_search.Text = "Search";
            this.admin_search.UseVisualStyleBackColor = false;
            this.admin_search.Click += new System.EventHandler(this.admin_search_Click);
            // 
            // admin_electronics_groupBox
            // 
            this.admin_electronics_groupBox.Controls.Add(this.two_in_one_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.gaming_laptop_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.fold_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.gpu_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.cpu_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.laptop_radioButton);
            this.admin_electronics_groupBox.Controls.Add(this.phones_radioButton);
            this.admin_electronics_groupBox.Location = new System.Drawing.Point(33, 78);
            this.admin_electronics_groupBox.Name = "admin_electronics_groupBox";
            this.admin_electronics_groupBox.Size = new System.Drawing.Size(150, 336);
            this.admin_electronics_groupBox.TabIndex = 25;
            this.admin_electronics_groupBox.TabStop = false;
            this.admin_electronics_groupBox.Text = "Electronics";
            // 
            // two_in_one_radioButton
            // 
            this.two_in_one_radioButton.AutoSize = true;
            this.two_in_one_radioButton.Location = new System.Drawing.Point(13, 146);
            this.two_in_one_radioButton.Name = "two_in_one_radioButton";
            this.two_in_one_radioButton.Size = new System.Drawing.Size(88, 17);
            this.two_in_one_radioButton.TabIndex = 4;
            this.two_in_one_radioButton.TabStop = true;
            this.two_in_one_radioButton.Text = "2 In 1 Laptop";
            this.two_in_one_radioButton.UseVisualStyleBackColor = true;
            this.two_in_one_radioButton.CheckedChanged += new System.EventHandler(this.two_in_one_radioButton_CheckedChanged);
            // 
            // gaming_laptop_radioButton
            // 
            this.gaming_laptop_radioButton.AutoSize = true;
            this.gaming_laptop_radioButton.Location = new System.Drawing.Point(13, 123);
            this.gaming_laptop_radioButton.Name = "gaming_laptop_radioButton";
            this.gaming_laptop_radioButton.Size = new System.Drawing.Size(97, 17);
            this.gaming_laptop_radioButton.TabIndex = 3;
            this.gaming_laptop_radioButton.TabStop = true;
            this.gaming_laptop_radioButton.Text = "Gaming Laptop";
            this.gaming_laptop_radioButton.UseVisualStyleBackColor = true;
            this.gaming_laptop_radioButton.CheckedChanged += new System.EventHandler(this.gaming_laptop_radioButton_CheckedChanged);
            // 
            // fold_radioButton
            // 
            this.fold_radioButton.AutoSize = true;
            this.fold_radioButton.Location = new System.Drawing.Point(13, 60);
            this.fold_radioButton.Name = "fold_radioButton";
            this.fold_radioButton.Size = new System.Drawing.Size(79, 17);
            this.fold_radioButton.TabIndex = 1;
            this.fold_radioButton.TabStop = true;
            this.fold_radioButton.Text = "Fold Phone";
            this.fold_radioButton.UseVisualStyleBackColor = true;
            this.fold_radioButton.CheckedChanged += new System.EventHandler(this.fold_radioButton_CheckedChanged);
            // 
            // gpu_radioButton
            // 
            this.gpu_radioButton.AutoSize = true;
            this.gpu_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpu_radioButton.Location = new System.Drawing.Point(13, 217);
            this.gpu_radioButton.Name = "gpu_radioButton";
            this.gpu_radioButton.Size = new System.Drawing.Size(51, 19);
            this.gpu_radioButton.TabIndex = 6;
            this.gpu_radioButton.TabStop = true;
            this.gpu_radioButton.Text = "Gpu";
            this.gpu_radioButton.UseVisualStyleBackColor = true;
            this.gpu_radioButton.CheckedChanged += new System.EventHandler(this.gpu_radioButton_CheckedChanged);
            // 
            // cpu_radioButton
            // 
            this.cpu_radioButton.AutoSize = true;
            this.cpu_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpu_radioButton.Location = new System.Drawing.Point(13, 178);
            this.cpu_radioButton.Name = "cpu_radioButton";
            this.cpu_radioButton.Size = new System.Drawing.Size(50, 19);
            this.cpu_radioButton.TabIndex = 5;
            this.cpu_radioButton.TabStop = true;
            this.cpu_radioButton.Text = "Cpu";
            this.cpu_radioButton.UseVisualStyleBackColor = true;
            this.cpu_radioButton.CheckedChanged += new System.EventHandler(this.cpu_radioButton_CheckedChanged);
            // 
            // laptop_radioButton
            // 
            this.laptop_radioButton.AutoSize = true;
            this.laptop_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laptop_radioButton.Location = new System.Drawing.Point(13, 94);
            this.laptop_radioButton.Name = "laptop_radioButton";
            this.laptop_radioButton.Size = new System.Drawing.Size(69, 19);
            this.laptop_radioButton.TabIndex = 2;
            this.laptop_radioButton.TabStop = true;
            this.laptop_radioButton.Text = "Laptop";
            this.laptop_radioButton.UseVisualStyleBackColor = true;
            this.laptop_radioButton.CheckedChanged += new System.EventHandler(this.laptop_radioButton_CheckedChanged);
            // 
            // phones_radioButton
            // 
            this.phones_radioButton.AutoSize = true;
            this.phones_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phones_radioButton.Location = new System.Drawing.Point(13, 23);
            this.phones_radioButton.Name = "phones_radioButton";
            this.phones_radioButton.Size = new System.Drawing.Size(73, 19);
            this.phones_radioButton.TabIndex = 0;
            this.phones_radioButton.TabStop = true;
            this.phones_radioButton.Text = "Phones";
            this.phones_radioButton.UseVisualStyleBackColor = true;
            this.phones_radioButton.CheckedChanged += new System.EventHandler(this.phones_radioButton_CheckedChanged);
            // 
            // sign_out
            // 
            this.sign_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            this.sign_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_out.Location = new System.Drawing.Point(33, 626);
            this.sign_out.Name = "sign_out";
            this.sign_out.Size = new System.Drawing.Size(150, 48);
            this.sign_out.TabIndex = 27;
            this.sign_out.Text = "Sign Out";
            this.sign_out.UseVisualStyleBackColor = false;
            this.sign_out.Click += new System.EventHandler(this.sign_out_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 55);
            this.label4.TabIndex = 26;
            this.label4.Text = "martek\'";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(1073, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(240, 78);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(528, 595);
            this.flowLayoutPanel.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(240, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(563, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 26;
            this.label2.Text = "Money";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.username.Location = new System.Drawing.Point(376, 3);
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Size = new System.Drawing.Size(181, 29);
            this.username.TabIndex = 27;
            // 
            // money
            // 
            this.money.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.money.Location = new System.Drawing.Point(658, 3);
            this.money.Name = "money";
            this.money.ReadOnly = true;
            this.money.Size = new System.Drawing.Size(181, 29);
            this.money.TabIndex = 28;
            // 
            // discount_label
            // 
            this.discount_label.AutoSize = true;
            this.discount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.discount_label.Location = new System.Drawing.Point(845, 3);
            this.discount_label.Name = "discount_label";
            this.discount_label.Size = new System.Drawing.Size(83, 24);
            this.discount_label.TabIndex = 29;
            this.discount_label.Text = "Discount";
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(934, 8);
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Size = new System.Drawing.Size(100, 20);
            this.discount.TabIndex = 30;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1160, 686);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.discount_label);
            this.Controls.Add(this.money);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.admin_electronics_groupBox.ResumeLayout(false);
            this.admin_electronics_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sign_out;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox admin_electronics_groupBox;
        private System.Windows.Forms.RadioButton fold_radioButton;
        private System.Windows.Forms.RadioButton gaming_laptop_radioButton;
        private System.Windows.Forms.RadioButton two_in_one_radioButton;
        private System.Windows.Forms.RadioButton gpu_radioButton;
        private System.Windows.Forms.RadioButton cpu_radioButton;
        private System.Windows.Forms.RadioButton laptop_radioButton;
        private System.Windows.Forms.RadioButton phones_radioButton;
        private System.Windows.Forms.Button admin_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox money;
        private System.Windows.Forms.Label discount_label;
        private System.Windows.Forms.TextBox discount;
    }
}