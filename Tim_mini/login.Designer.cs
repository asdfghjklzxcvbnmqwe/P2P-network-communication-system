namespace Tim_mini
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.login_button = new System.Windows.Forms.Button();
            this.student_ID = new System.Windows.Forms.Label();
            this.key = new System.Windows.Forms.Label();
            this.ID_text = new System.Windows.Forms.TextBox();
            this.key_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(189, 190);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "登录";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // student_ID
            // 
            this.student_ID.AutoSize = true;
            this.student_ID.Location = new System.Drawing.Point(148, 82);
            this.student_ID.Name = "student_ID";
            this.student_ID.Size = new System.Drawing.Size(52, 15);
            this.student_ID.TabIndex = 1;
            this.student_ID.Text = "学号：";
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Location = new System.Drawing.Point(148, 126);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(52, 15);
            this.key.TabIndex = 2;
            this.key.Text = "密码：";
            // 
            // ID_text
            // 
            this.ID_text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_text.Location = new System.Drawing.Point(217, 79);
            this.ID_text.Name = "ID_text";
            this.ID_text.Size = new System.Drawing.Size(100, 25);
            this.ID_text.TabIndex = 3;
            this.ID_text.Text = "2016011455";
            this.ID_text.TextChanged += new System.EventHandler(this.ID_text_TextChanged);
            // 
            // key_text
            // 
            this.key_text.Location = new System.Drawing.Point(217, 126);
            this.key_text.Name = "key_text";
            this.key_text.PasswordChar = '*';
            this.key_text.Size = new System.Drawing.Size(100, 25);
            this.key_text.TabIndex = 4;
            this.key_text.Text = "net2018";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 285);
            this.Controls.Add(this.key_text);
            this.Controls.Add(this.ID_text);
            this.Controls.Add(this.key);
            this.Controls.Add(this.student_ID);
            this.Controls.Add(this.login_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.Text = "login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label student_ID;
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.TextBox ID_text;
        private System.Windows.Forms.TextBox key_text;
    }
}