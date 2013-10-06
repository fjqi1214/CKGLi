namespace CKGL
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegUserName = new System.Windows.Forms.TextBox();
            this.btnRegOk = new System.Windows.Forms.Button();
            this.cbAuth = new System.Windows.Forms.ComboBox();
            this.btnRegRetset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegPwd = new System.Windows.Forms.TextBox();
            this.txtRegPwd2 = new System.Windows.Forms.TextBox();
            this.labTip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请输入密码：";
            // 
            // txtRegUserName
            // 
            this.txtRegUserName.Location = new System.Drawing.Point(150, 41);
            this.txtRegUserName.Name = "txtRegUserName";
            this.txtRegUserName.Size = new System.Drawing.Size(139, 21);
            this.txtRegUserName.TabIndex = 1;
            this.txtRegUserName.Leave += new System.EventHandler(this.txtRegUserName_Leave);
            // 
            // btnRegOk
            // 
            this.btnRegOk.Location = new System.Drawing.Point(58, 254);
            this.btnRegOk.Name = "btnRegOk";
            this.btnRegOk.Size = new System.Drawing.Size(75, 23);
            this.btnRegOk.TabIndex = 2;
            this.btnRegOk.Text = "确定";
            this.btnRegOk.UseVisualStyleBackColor = true;
            this.btnRegOk.Click += new System.EventHandler(this.btnRegOk_Click);
            // 
            // cbAuth
            // 
            this.cbAuth.FormattingEnabled = true;
            this.cbAuth.Items.AddRange(new object[] {
            "普通成员",
            "管理员"});
            this.cbAuth.Location = new System.Drawing.Point(150, 197);
            this.cbAuth.Name = "cbAuth";
            this.cbAuth.Size = new System.Drawing.Size(139, 20);
            this.cbAuth.TabIndex = 3;
            this.cbAuth.Text = "普通成员";
            // 
            // btnRegRetset
            // 
            this.btnRegRetset.Location = new System.Drawing.Point(196, 254);
            this.btnRegRetset.Name = "btnRegRetset";
            this.btnRegRetset.Size = new System.Drawing.Size(75, 23);
            this.btnRegRetset.TabIndex = 2;
            this.btnRegRetset.Text = "重置";
            this.btnRegRetset.UseVisualStyleBackColor = true;
            this.btnRegRetset.Click += new System.EventHandler(this.btnRegRetset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "请确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "请选择权限";
            // 
            // txtRegPwd
            // 
            this.txtRegPwd.Location = new System.Drawing.Point(150, 93);
            this.txtRegPwd.Name = "txtRegPwd";
            this.txtRegPwd.PasswordChar = '*';
            this.txtRegPwd.Size = new System.Drawing.Size(139, 21);
            this.txtRegPwd.TabIndex = 1;
            // 
            // txtRegPwd2
            // 
            this.txtRegPwd2.Location = new System.Drawing.Point(150, 146);
            this.txtRegPwd2.Name = "txtRegPwd2";
            this.txtRegPwd2.PasswordChar = '*';
            this.txtRegPwd2.Size = new System.Drawing.Size(139, 21);
            this.txtRegPwd2.TabIndex = 1;
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.ForeColor = System.Drawing.Color.Red;
            this.labTip.Location = new System.Drawing.Point(56, 20);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(0, 12);
            this.labTip.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(295, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "*必填";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(295, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "*必填";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(295, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "*必填";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 312);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labTip);
            this.Controls.Add(this.cbAuth);
            this.Controls.Add(this.btnRegRetset);
            this.Controls.Add(this.btnRegOk);
            this.Controls.Add(this.txtRegPwd2);
            this.Controls.Add(this.txtRegPwd);
            this.Controls.Add(this.txtRegUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "新用户注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegUserName;
        private System.Windows.Forms.Button btnRegOk;
        private System.Windows.Forms.ComboBox cbAuth;
        private System.Windows.Forms.Button btnRegRetset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegPwd;
        private System.Windows.Forms.TextBox txtRegPwd2;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}