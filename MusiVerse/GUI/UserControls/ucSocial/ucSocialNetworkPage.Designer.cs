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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.btnSavedPosts = new System.Windows.Forms.Button();
            this.pnlFeed = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.pnlTopBar.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.panelSearch);
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopBar.Size = new System.Drawing.Size(1000, 107);
            this.pnlTopBar.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.lblSearchIcon);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Location = new System.Drawing.Point(446, 36);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(400, 37);
            this.panelSearch.TabIndex = 3;
            this.panelSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSearch_Paint);
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSearchIcon.Location = new System.Drawing.Point(4, 3);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(47, 32);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "🔍";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(67, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(319, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Tìm kiếm nghệ sĩ..";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 36);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(381, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📱 MUSIVERSE SOCIAL FEED";
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnCreatePost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreatePost.FlatAppearance.BorderSize = 0;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreatePost.ForeColor = System.Drawing.Color.White;
            this.btnCreatePost.Location = new System.Drawing.Point(20, 10);
            this.btnCreatePost.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(182, 43);
            this.btnCreatePost.TabIndex = 1;
            this.btnCreatePost.Text = "✏️ Tạo bài viết";
            this.btnCreatePost.UseVisualStyleBackColor = false;
            this.btnCreatePost.Click += new System.EventHandler(this.BtnCreatePost_Click);
            // 
            // btnSavedPosts
            // 
            this.btnSavedPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnSavedPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavedPosts.FlatAppearance.BorderSize = 0;
            this.btnSavedPosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavedPosts.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSavedPosts.ForeColor = System.Drawing.Color.White;
            this.btnSavedPosts.Location = new System.Drawing.Point(206, 10);
            this.btnSavedPosts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavedPosts.Name = "btnSavedPosts";
            this.btnSavedPosts.Size = new System.Drawing.Size(194, 43);
            this.btnSavedPosts.TabIndex = 2;
            this.btnSavedPosts.Text = "📌 Bài viết đã lưu";
            this.btnSavedPosts.UseVisualStyleBackColor = false;
            this.btnSavedPosts.Click += new System.EventHandler(this.BtnSavedPosts_Click);
            // 
            // pnlFeed
            // 
            this.pnlFeed.AutoScroll = true;
            this.pnlFeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlFeed.Location = new System.Drawing.Point(0, 172);
            this.pnlFeed.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFeed.Name = "pnlFeed";
            this.pnlFeed.Size = new System.Drawing.Size(1000, 340);
            this.pnlFeed.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.cmbSort);
            this.panel1.Controls.Add(this.btnCreatePost);
            this.panel1.Controls.Add(this.btnSavedPosts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 64);
            this.panel1.TabIndex = 2;
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất",
            "Nhiều lượt thích",
            "Nhiều bình luận"});
            this.cmbSort.Location = new System.Drawing.Point(405, 18);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(206, 31);
            this.cmbSort.TabIndex = 6;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // ucSocialNetworkPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFeed);
            this.Controls.Add(this.pnlTopBar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucSocialNetworkPage";
            this.Size = new System.Drawing.Size(1000, 512);
            this.Load += new System.EventHandler(this.ucSocialNetworkPage_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
