namespace MusiVerse.GUI.UserControls
{
    partial class ucSocialNetworkPage
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCreatePost;
        private System.Windows.Forms.Button btnSavedPosts;
        private System.Windows.Forms.Panel pnlFeed;
        private System.Windows.Forms.Button btnLoadMore;

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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.btnSavedPosts = new System.Windows.Forms.Button();
            this.pnlFeed = new System.Windows.Forms.Panel();
            this.btnLoadMore = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Controls.Add(this.btnCreatePost);
            this.pnlTopBar.Controls.Add(this.btnSavedPosts);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTopBar.Size = new System.Drawing.Size(1500, 80);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(586, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? MUSIVERSE SOCIAL FEED";
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnCreatePost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreatePost.FlatAppearance.BorderSize = 0;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreatePost.ForeColor = System.Drawing.Color.White;
            this.btnCreatePost.Location = new System.Drawing.Point(1100, 20);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(160, 40);
            this.btnCreatePost.TabIndex = 1;
            this.btnCreatePost.Text = "?? T?o bài vi?t";
            this.btnCreatePost.UseVisualStyleBackColor = false;
            // 
            // btnSavedPosts
            // 
            this.btnSavedPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnSavedPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavedPosts.FlatAppearance.BorderSize = 0;
            this.btnSavedPosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavedPosts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavedPosts.ForeColor = System.Drawing.Color.White;
            this.btnSavedPosts.Location = new System.Drawing.Point(1270, 20);
            this.btnSavedPosts.Name = "btnSavedPosts";
            this.btnSavedPosts.Size = new System.Drawing.Size(180, 40);
            this.btnSavedPosts.TabIndex = 2;
            this.btnSavedPosts.Text = "?? Bài vi?t ?ã l?u";
            this.btnSavedPosts.UseVisualStyleBackColor = false;
            // 
            // pnlFeed
            // 
            this.pnlFeed.AutoScroll = true;
            this.pnlFeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFeed.Location = new System.Drawing.Point(0, 80);
            this.pnlFeed.Name = "pnlFeed";
            this.pnlFeed.Size = new System.Drawing.Size(1500, 720);
            this.pnlFeed.TabIndex = 0;
            // 
            // btnLoadMore
            // 
            this.btnLoadMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnLoadMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadMore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoadMore.FlatAppearance.BorderSize = 0;
            this.btnLoadMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLoadMore.ForeColor = System.Drawing.Color.White;
            this.btnLoadMore.Location = new System.Drawing.Point(0, 0);
            this.btnLoadMore.Name = "btnLoadMore";
            this.btnLoadMore.Size = new System.Drawing.Size(75, 40);
            this.btnLoadMore.TabIndex = 0;
            this.btnLoadMore.Text = "?? T?i thêm bài vi?t";
            this.btnLoadMore.UseVisualStyleBackColor = false;
            // 
            // ucSocialNetworkPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.pnlFeed);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "ucSocialNetworkPage";
            this.Size = new System.Drawing.Size(1500, 800);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
