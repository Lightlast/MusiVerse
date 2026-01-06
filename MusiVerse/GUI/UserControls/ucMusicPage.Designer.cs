namespace MusiVerse.GUI.UserControls
{
    partial class ucMusicPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.btnUpload = new System.Windows.Forms.Panel();
            this.btnUploadMS = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnRecentPlayed = new System.Windows.Forms.Button();
            this.btnMyPlaylists = new System.Windows.Forms.Button();
            this.btnLikedSongs = new System.Windows.Forms.Button();
            this.btnAllSongs = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowPanelSongs = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSongCount = new System.Windows.Forms.Label();
            this.btnUpload.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.btnUpload.Controls.Add(this.btnUploadMS);
            this.btnUpload.Controls.Add(this.panelSearch);
            this.btnUpload.Controls.Add(this.lblTitle);
            this.btnUpload.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpload.Location = new System.Drawing.Point(0, 0);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(1714, 167);
            this.btnUpload.TabIndex = 0;
            // 
            // btnUploadMS
            // 
            this.btnUploadMS.ForeColor = System.Drawing.Color.Black;
            this.btnUploadMS.Location = new System.Drawing.Point(1475, 55);
            this.btnUploadMS.Name = "btnUploadMS";
            this.btnUploadMS.Size = new System.Drawing.Size(205, 59);
            this.btnUploadMS.TabIndex = 2;
            this.btnUploadMS.Text = "UpLoad nhạc";
            this.btnUploadMS.UseVisualStyleBackColor = true;
            this.btnUploadMS.Visible = false;
            this.btnUploadMS.Click += new System.EventHandler(this.btnUploadMS_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.lblSearchIcon);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Location = new System.Drawing.Point(514, 42);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(5);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(600, 58);
            this.panelSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSearchIcon.Location = new System.Drawing.Point(6, 5);
            this.lblSearchIcon.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(74, 51);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "🔍";
            this.lblSearchIcon.Click += new System.EventHandler(this.lblSearchIcon_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(101, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(478, 40);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Tìm kiếm bài hát, nghệ sĩ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(34, 33);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(476, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎵 Thư viện nhạc";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất",
            "Tên A-Z",
            "Tên Z-A",
            "Nhiều lượt nghe"});
            this.cmbSort.Location = new System.Drawing.Point(1413, 29);
            this.cmbSort.Margin = new System.Windows.Forms.Padding(5);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(190, 45);
            this.cmbSort.TabIndex = 3;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "Tất cả thể loại",
            "Pop",
            "Rock",
            "Ballad",
            "Rap/Hip-hop",
            "EDM",
            "Jazz",
            "Classical",
            "Country"});
            this.cmbGenre.Location = new System.Drawing.Point(1164, 29);
            this.cmbGenre.Margin = new System.Windows.Forms.Padding(5);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(220, 45);
            this.cmbGenre.TabIndex = 2;
            this.cmbGenre.SelectedIndexChanged += new System.EventHandler(this.cmbGenre_SelectedIndexChanged);
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Controls.Add(this.btnRecentPlayed);
            this.panelFilters.Controls.Add(this.cmbGenre);
            this.panelFilters.Controls.Add(this.btnMyPlaylists);
            this.panelFilters.Controls.Add(this.btnLikedSongs);
            this.panelFilters.Controls.Add(this.btnAllSongs);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 167);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(5);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1714, 100);
            this.panelFilters.TabIndex = 1;
            // 
            // btnRecentPlayed
            // 
            this.btnRecentPlayed.BackColor = System.Drawing.Color.Transparent;
            this.btnRecentPlayed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecentPlayed.FlatAppearance.BorderSize = 0;
            this.btnRecentPlayed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentPlayed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRecentPlayed.ForeColor = System.Drawing.Color.White;
            this.btnRecentPlayed.Location = new System.Drawing.Point(874, 17);
            this.btnRecentPlayed.Margin = new System.Windows.Forms.Padding(5);
            this.btnRecentPlayed.Name = "btnRecentPlayed";
            this.btnRecentPlayed.Size = new System.Drawing.Size(257, 67);
            this.btnRecentPlayed.TabIndex = 3;
            this.btnRecentPlayed.Text = "🕒 Nghe gần đây";
            this.btnRecentPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecentPlayed.UseVisualStyleBackColor = false;
            this.btnRecentPlayed.Click += new System.EventHandler(this.btnRecentPlayed_Click);
            // 
            // btnMyPlaylists
            // 
            this.btnMyPlaylists.BackColor = System.Drawing.Color.Transparent;
            this.btnMyPlaylists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyPlaylists.FlatAppearance.BorderSize = 0;
            this.btnMyPlaylists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyPlaylists.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMyPlaylists.ForeColor = System.Drawing.Color.White;
            this.btnMyPlaylists.Location = new System.Drawing.Point(617, 17);
            this.btnMyPlaylists.Margin = new System.Windows.Forms.Padding(5);
            this.btnMyPlaylists.Name = "btnMyPlaylists";
            this.btnMyPlaylists.Size = new System.Drawing.Size(240, 67);
            this.btnMyPlaylists.TabIndex = 2;
            this.btnMyPlaylists.Text = "📝 Playlist của tôi";
            this.btnMyPlaylists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyPlaylists.UseVisualStyleBackColor = false;
            this.btnMyPlaylists.Click += new System.EventHandler(this.btnMyPlaylists_Click);
            // 
            // btnLikedSongs
            // 
            this.btnLikedSongs.BackColor = System.Drawing.Color.Transparent;
            this.btnLikedSongs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLikedSongs.FlatAppearance.BorderSize = 0;
            this.btnLikedSongs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLikedSongs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLikedSongs.ForeColor = System.Drawing.Color.White;
            this.btnLikedSongs.Location = new System.Drawing.Point(309, 17);
            this.btnLikedSongs.Margin = new System.Windows.Forms.Padding(5);
            this.btnLikedSongs.Name = "btnLikedSongs";
            this.btnLikedSongs.Size = new System.Drawing.Size(291, 67);
            this.btnLikedSongs.TabIndex = 1;
            this.btnLikedSongs.Text = "❤️ Bài hát yêu thích";
            this.btnLikedSongs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLikedSongs.UseVisualStyleBackColor = false;
            this.btnLikedSongs.Click += new System.EventHandler(this.btnLikedSongs_Click);
            // 
            // btnAllSongs
            // 
            this.btnAllSongs.BackColor = System.Drawing.Color.Transparent;
            this.btnAllSongs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllSongs.FlatAppearance.BorderSize = 0;
            this.btnAllSongs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllSongs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAllSongs.ForeColor = System.Drawing.Color.White;
            this.btnAllSongs.Location = new System.Drawing.Point(34, 17);
            this.btnAllSongs.Margin = new System.Windows.Forms.Padding(5);
            this.btnAllSongs.Name = "btnAllSongs";
            this.btnAllSongs.Size = new System.Drawing.Size(257, 67);
            this.btnAllSongs.TabIndex = 0;
            this.btnAllSongs.Text = "📀 Tất cả bài hát";
            this.btnAllSongs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllSongs.UseVisualStyleBackColor = false;
            this.btnAllSongs.Click += new System.EventHandler(this.btnAllSongs_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panelContent.Controls.Add(this.flowPanelSongs);
            this.panelContent.Controls.Add(this.lblSongCount);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 267);
            this.panelContent.Margin = new System.Windows.Forms.Padding(5);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1714, 900);
            this.panelContent.TabIndex = 2;
            // 
            // flowPanelSongs
            // 
            this.flowPanelSongs.AutoScroll = true;
            this.flowPanelSongs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelSongs.Location = new System.Drawing.Point(34, 75);
            this.flowPanelSongs.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelSongs.Name = "flowPanelSongs";
            this.flowPanelSongs.Size = new System.Drawing.Size(1646, 800);
            this.flowPanelSongs.TabIndex = 1;
            this.flowPanelSongs.WrapContents = false;
            // 
            // lblSongCount
            // 
            this.lblSongCount.AutoSize = true;
            this.lblSongCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSongCount.ForeColor = System.Drawing.Color.Gray;
            this.lblSongCount.Location = new System.Drawing.Point(34, 25);
            this.lblSongCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(121, 37);
            this.lblSongCount.TabIndex = 0;
            this.lblSongCount.Text = "0 bài hát";
            // 
            // ucMusicPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.btnUpload);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucMusicPage";
            this.Size = new System.Drawing.Size(1714, 1167);
            this.Load += new System.EventHandler(this.ucMusicPage_Load);
            this.btnUpload.ResumeLayout(false);
            this.btnUpload.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnUpload;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Button btnAllSongs;
        private System.Windows.Forms.Button btnLikedSongs;
        private System.Windows.Forms.Button btnMyPlaylists;
        private System.Windows.Forms.Button btnRecentPlayed;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblSongCount;
        private System.Windows.Forms.FlowLayoutPanel flowPanelSongs;
        private System.Windows.Forms.Button btnUploadMS;
    }
}