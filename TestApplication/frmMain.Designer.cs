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
            this.btnLoginSinaWeibo = new System.Windows.Forms.Button();
            this.btnPublishSinaWeibo = new System.Windows.Forms.Button();
            this.btnLoginTencentWeibo = new System.Windows.Forms.Button();
            this.btnPublishTencentWeibo = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPublishSinaPicWeibo = new System.Windows.Forms.Button();
            this.btnConvertDocToJpg = new System.Windows.Forms.Button();
            this.btnLoginTencentWeibo2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRegEx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoginSinaWeibo
            // 
            this.btnLoginSinaWeibo.Location = new System.Drawing.Point(12, 12);
            this.btnLoginSinaWeibo.Name = "btnLoginSinaWeibo";
            this.btnLoginSinaWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnLoginSinaWeibo.TabIndex = 3;
            this.btnLoginSinaWeibo.Text = "登录新浪微博";
            this.btnLoginSinaWeibo.UseVisualStyleBackColor = true;
            this.btnLoginSinaWeibo.Click += new System.EventHandler(this.btnLoginSinaWeibo_Click);
            // 
            // btnPublishSinaWeibo
            // 
            this.btnPublishSinaWeibo.Location = new System.Drawing.Point(12, 42);
            this.btnPublishSinaWeibo.Name = "btnPublishSinaWeibo";
            this.btnPublishSinaWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnPublishSinaWeibo.TabIndex = 4;
            this.btnPublishSinaWeibo.Text = "发布新浪微博";
            this.btnPublishSinaWeibo.UseVisualStyleBackColor = true;
            this.btnPublishSinaWeibo.Click += new System.EventHandler(this.btnPublishSinaWeibo_Click);
            // 
            // btnLoginTencentWeibo
            // 
            this.btnLoginTencentWeibo.Location = new System.Drawing.Point(12, 131);
            this.btnLoginTencentWeibo.Name = "btnLoginTencentWeibo";
            this.btnLoginTencentWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnLoginTencentWeibo.TabIndex = 5;
            this.btnLoginTencentWeibo.Text = "登陆腾讯微博";
            this.btnLoginTencentWeibo.UseVisualStyleBackColor = true;
            this.btnLoginTencentWeibo.Click += new System.EventHandler(this.btnLoginTencentWeibo_Click);
            // 
            // btnPublishTencentWeibo
            // 
            this.btnPublishTencentWeibo.Location = new System.Drawing.Point(12, 161);
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
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(620, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 478);
            this.textBox1.TabIndex = 8;
            // 
            // btnPublishSinaPicWeibo
            // 
            this.btnPublishSinaPicWeibo.Location = new System.Drawing.Point(12, 71);
            this.btnPublishSinaPicWeibo.Name = "btnPublishSinaPicWeibo";
            this.btnPublishSinaPicWeibo.Size = new System.Drawing.Size(150, 23);
            this.btnPublishSinaPicWeibo.TabIndex = 9;
            this.btnPublishSinaPicWeibo.Text = "发布新浪图片微博";
            this.btnPublishSinaPicWeibo.UseVisualStyleBackColor = true;
            this.btnPublishSinaPicWeibo.Click += new System.EventHandler(this.btnPublishSinaPicWeibo_Click);
            // 
            // btnConvertDocToJpg
            // 
            this.btnConvertDocToJpg.Location = new System.Drawing.Point(14, 218);
            this.btnConvertDocToJpg.Name = "btnConvertDocToJpg";
            this.btnConvertDocToJpg.Size = new System.Drawing.Size(150, 23);
            this.btnConvertDocToJpg.TabIndex = 10;
            this.btnConvertDocToJpg.Text = "Word 2 JPG";
            this.btnConvertDocToJpg.UseVisualStyleBackColor = true;
            this.btnConvertDocToJpg.Click += new System.EventHandler(this.btnConvertDocToJpg_Click);
            // 
            // btnLoginTencentWeibo2
            // 
            this.btnLoginTencentWeibo2.Location = new System.Drawing.Point(14, 261);
            this.btnLoginTencentWeibo2.Name = "btnLoginTencentWeibo2";
            this.btnLoginTencentWeibo2.Size = new System.Drawing.Size(150, 23);
            this.btnLoginTencentWeibo2.TabIndex = 11;
            this.btnLoginTencentWeibo2.Text = "登陆腾讯微博2";
            this.btnLoginTencentWeibo2.UseVisualStyleBackColor = true;
            this.btnLoginTencentWeibo2.Click += new System.EventHandler(this.btnLoginTencentWeibo2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "去除白边";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegEx
            // 
            this.btnRegEx.Location = new System.Drawing.Point(16, 319);
            this.btnRegEx.Name = "btnRegEx";
            this.btnRegEx.Size = new System.Drawing.Size(148, 23);
            this.btnRegEx.TabIndex = 13;
            this.btnRegEx.Text = "正则查找";
            this.btnRegEx.UseVisualStyleBackColor = true;
            this.btnRegEx.Click += new System.EventHandler(this.btnRegEx_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 494);
            this.Controls.Add(this.btnRegEx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoginTencentWeibo2);
            this.Controls.Add(this.btnConvertDocToJpg);
            this.Controls.Add(this.btnPublishSinaPicWeibo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnPublishTencentWeibo);
            this.Controls.Add(this.btnLoginTencentWeibo);
            this.Controls.Add(this.btnPublishSinaWeibo);
            this.Controls.Add(this.btnLoginSinaWeibo);
            this.Name = "frmMain";
            this.Text = "测试项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginSinaWeibo;
        private System.Windows.Forms.Button btnPublishSinaWeibo;
        private System.Windows.Forms.Button btnLoginTencentWeibo;
        private System.Windows.Forms.Button btnPublishTencentWeibo;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnPublishSinaPicWeibo;
        private System.Windows.Forms.Button btnConvertDocToJpg;
        private System.Windows.Forms.Button btnLoginTencentWeibo2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegEx;
    }
}

