namespace TestApplication
{
    partial class frmMain
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
            this.btnRestUser = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoginSinaWeibo = new System.Windows.Forms.Button();
            this.btnPublishSinaWeibo = new System.Windows.Forms.Button();
            this.btnLoginTencentWeibo = new System.Windows.Forms.Button();
            this.btnPublishTencentWeibo = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRestUser
            // 
            this.btnRestUser.Location = new System.Drawing.Point(13, 4);
            this.btnRestUser.Name = "btnRestUser";
            this.btnRestUser.Size = new System.Drawing.Size(150, 21);
            this.btnRestUser.TabIndex = 0;
            this.btnRestUser.Text = "Get User From REST";
            this.btnRestUser.UseVisualStyleBackColor = true;
            this.btnRestUser.Click += new System.EventHandler(this.btnRestUser_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(13, 31);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(150, 21);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post User via JSON";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Parse Byte Array";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoginSinaWeibo
            // 
            this.btnLoginSinaWeibo.Location = new System.Drawing.Point(13, 90);
            this.btnLoginSinaWeibo.Name = "btnLoginSinaWeibo";
            this.btnLoginSinaWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnLoginSinaWeibo.TabIndex = 3;
            this.btnLoginSinaWeibo.Text = "登录新浪微博";
            this.btnLoginSinaWeibo.UseVisualStyleBackColor = true;
            this.btnLoginSinaWeibo.Click += new System.EventHandler(this.btnLoginSinaWeibo_Click);
            // 
            // btnPublishSinaWeibo
            // 
            this.btnPublishSinaWeibo.Location = new System.Drawing.Point(13, 120);
            this.btnPublishSinaWeibo.Name = "btnPublishSinaWeibo";
            this.btnPublishSinaWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnPublishSinaWeibo.TabIndex = 4;
            this.btnPublishSinaWeibo.Text = "发布新浪微博";
            this.btnPublishSinaWeibo.UseVisualStyleBackColor = true;
            // 
            // btnLoginTencentWeibo
            // 
            this.btnLoginTencentWeibo.Location = new System.Drawing.Point(13, 150);
            this.btnLoginTencentWeibo.Name = "btnLoginTencentWeibo";
            this.btnLoginTencentWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnLoginTencentWeibo.TabIndex = 5;
            this.btnLoginTencentWeibo.Text = "登陆腾讯微博";
            this.btnLoginTencentWeibo.UseVisualStyleBackColor = true;
            // 
            // btnPublishTencentWeibo
            // 
            this.btnPublishTencentWeibo.Location = new System.Drawing.Point(13, 180);
            this.btnPublishTencentWeibo.Name = "btnPublishTencentWeibo";
            this.btnPublishTencentWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnPublishTencentWeibo.TabIndex = 6;
            this.btnPublishTencentWeibo.Text = "发布腾讯微博";
            this.btnPublishTencentWeibo.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(170, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(444, 478);
            this.webBrowser1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(620, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 478);
            this.textBox1.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 494);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnPublishTencentWeibo);
            this.Controls.Add(this.btnLoginTencentWeibo);
            this.Controls.Add(this.btnPublishSinaWeibo);
            this.Controls.Add(this.btnLoginSinaWeibo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnRestUser);
            this.Name = "frmMain";
            this.Text = "测试项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestUser;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoginSinaWeibo;
        private System.Windows.Forms.Button btnPublishSinaWeibo;
        private System.Windows.Forms.Button btnLoginTencentWeibo;
        private System.Windows.Forms.Button btnPublishTencentWeibo;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

