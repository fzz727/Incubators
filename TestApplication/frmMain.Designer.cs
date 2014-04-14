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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 286);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnRestUser);
            this.Name = "frmMain";
            this.Text = "测试项目";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestUser;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button button1;
    }
}

