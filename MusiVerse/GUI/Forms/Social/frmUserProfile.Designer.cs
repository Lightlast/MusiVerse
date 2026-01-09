namespace MusiVerse.GUI.Forms.Social
{
    partial class frmUserProfile
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Panel pnlPosts;
        private System.Windows.Forms.Label lblPostsTitle;
        private System.Windows.Forms.Label lblPostCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.pnlPosts = new System.Windows.Forms.Panel();
            this.lblPostCount = new System.Windows.Forms.Label();
            this.lblPostsTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlPosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.pnlUserInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Size = new System.Drawing.Size(900, 250);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.AutoScroll = true;
            this.pnlUserInfo.BackColor = System.Drawing.Color.White;
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserInfo.Location = new System.Drawing.Point(20, 20);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(858, 208);
            this.pnlUserInfo.TabIndex = 0;
            // 
            // pnlPosts
            // 
            this.pnlPosts.AutoScroll = true;
            this.pnlPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlPosts.Controls.Add(this.lblPostCount);
            this.pnlPosts.Controls.Add(this.lblPostsTitle);
            this.pnlPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPosts.Location = new System.Drawing.Point(0, 250);
            this.pnlPosts.Name = "pnlPosts";
            this.pnlPosts.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlPosts.Size = new System.Drawing.Size(900, 450);
            this.pnlPosts.TabIndex = 0;
            // 
            // lblPostCount
            // 
            this.lblPostCount.AutoSize = true;
            this.lblPostCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPostCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPostCount.Location = new System.Drawing.Point(224, 10);
            this.lblPostCount.Name = "lblPostCount";
            this.lblPostCount.Size = new System.Drawing.Size(200, 37);
            this.lblPostCount.TabIndex = 0;
            this.lblPostCount.Text = "Tổng: 0 bài viết";
            // 
            // lblPostsTitle
            // 
            this.lblPostsTitle.AutoSize = true;
            this.lblPostsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPostsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPostsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblPostsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPostsTitle.Name = "lblPostsTitle";
            this.lblPostsTitle.Size = new System.Drawing.Size(218, 51);
            this.lblPostsTitle.TabIndex = 1;
            this.lblPostsTitle.Text = "📝 Bài viết";
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.pnlPosts);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmUserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ người dùng";
            this.pnlHeader.ResumeLayout(false);
            this.pnlPosts.ResumeLayout(false);
            this.pnlPosts.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
