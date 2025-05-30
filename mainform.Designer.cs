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
            this.fold_radioButton = new System.Windows.Forms.RadioButton();
            this.gaming_laptop_radioButton = new System.Windows.Forms.RadioButton();
            this.two_in_one_radioButton = new System.Windows.Forms.RadioButton();
            this.gpu_radioButton = new System.Windows.Forms.RadioButton();
            this.cpu_radioButton = new System.Windows.Forms.RadioButton();
            this.laptop_radioButton = new System.Windows.Forms.RadioButton();
            this.phones_radioButton = new System.Windows.Forms.RadioButton();
            this.sign_out = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.admin_electronics_groupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.groupBox8);
            this.flowLayoutPanel.Controls.Add(this.groupBox9);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(240, 20);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(528, 653);
            this.flowLayoutPanel.TabIndex = 24;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pictureBox1);
            this.groupBox8.Controls.Add(this.linkLabel1);
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(256, 153);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 113);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(84, 135);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pictureBox2);
            this.groupBox9.Controls.Add(this.linkLabel2);
            this.groupBox9.Location = new System.Drawing.Point(3, 162);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(256, 153);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(254, 113);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(84, 135);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(55, 13);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1160, 686);
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
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sign_out;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox admin_electronics_groupBox;
        private System.Windows.Forms.RadioButton fold_radioButton;
        private System.Windows.Forms.RadioButton gaming_laptop_radioButton;
        private System.Windows.Forms.RadioButton two_in_one_radioButton;
        private System.Windows.Forms.RadioButton gpu_radioButton;
        private System.Windows.Forms.RadioButton cpu_radioButton;
        private System.Windows.Forms.RadioButton laptop_radioButton;
        private System.Windows.Forms.RadioButton phones_radioButton;
        private System.Windows.Forms.Button admin_search;
    }
}