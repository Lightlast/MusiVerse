namespace MusiVerse.GUI.UserControls
{
    partial class ucSongDetailPage
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

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSongInfo = new System.Windows.Forms.Panel();
            this.pbSongCover = new System.Windows.Forms.PictureBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPlayCount = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnAddToPlaylist = new System.Windows.Forms.Button();
            this.lblArtistSongsTitle = new System.Windows.Forms.Label();
            this.pnlArtistSongs = new System.Windows.Forms.Panel();
            this.lblArtistAlbumsTitle = new System.Windows.Forms.Label();
            this.pnlArtistAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMain.SuspendLayout();
            this.pnlSongInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSongCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlSongInfo);
            this.pnlMain.Controls.Add(this.lblArtistSongsTitle);
            this.pnlMain.Controls.Add(this.pnlArtistSongs);
            this.pnlMain.Controls.Add(this.lblArtistAlbumsTitle);
            this.pnlMain.Controls.Add(this.pnlArtistAlbums);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1600, 1154);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlSongInfo
            // 
            this.pnlSongInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSongInfo.Controls.Add(this.pbSongCover);
            this.pnlSongInfo.Controls.Add(this.lblSongTitle);
            this.pnlSongInfo.Controls.Add(this.lblArtistName);
            this.pnlSongInfo.Controls.Add(this.lblGenre);
            this.pnlSongInfo.Controls.Add(this.lblDuration);
            this.pnlSongInfo.Controls.Add(this.lblPlayCount);
            this.pnlSongInfo.Controls.Add(this.lblReleaseDate);
            this.pnlSongInfo.Controls.Add(this.btnPlay);
            this.pnlSongInfo.Controls.Add(this.btnLike);
            this.pnlSongInfo.Controls.Add(this.btnAddToPlaylist);
            this.pnlSongInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSongInfo.Location = new System.Drawing.Point(0, 1352);
            this.pnlSongInfo.Margin = new System.Windows.Forms.Padding(6);
            this.pnlSongInfo.Name = "pnlSongInfo";
            this.pnlSongInfo.Padding = new System.Windows.Forms.Padding(40, 38, 40, 38);
            this.pnlSongInfo.Size = new System.Drawing.Size(1566, 673);
            this.pnlSongInfo.TabIndex = 0;
            // 
            // pbSongCover
            // 
            this.pbSongCover.Location = new System.Drawing.Point(40, 38);
            this.pbSongCover.Margin = new System.Windows.Forms.Padding(6);
            this.pbSongCover.Name = "pbSongCover";
            this.pbSongCover.Size = new System.Drawing.Size(400, 385);
            this.pbSongCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSongCover.TabIndex = 0;
            this.pbSongCover.TabStop = false;
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.AutoSize = true;
            this.lblSongTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSongTitle.Location = new System.Drawing.Point(480, 38);
            this.lblSongTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(286, 72);
            this.lblSongTitle.TabIndex = 1;
            this.lblSongTitle.Text = "Song Title";
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArtistName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblArtistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblArtistName.Location = new System.Drawing.Point(480, 125);
            this.lblArtistName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(190, 45);
            this.lblArtistName.TabIndex = 2;
            this.lblArtistName.Text = "Artist Name";
            this.lblArtistName.Click += new System.EventHandler(this.lblArtistName_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGenre.Location = new System.Drawing.Point(480, 183);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(88, 37);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Genre";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDuration.Location = new System.Drawing.Point(480, 240);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(121, 37);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration";
            // 
            // lblPlayCount
            // 
            this.lblPlayCount.AutoSize = true;
            this.lblPlayCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlayCount.Location = new System.Drawing.Point(480, 298);
            this.lblPlayCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayCount.Name = "lblPlayCount";
            this.lblPlayCount.Size = new System.Drawing.Size(145, 37);
            this.lblPlayCount.TabIndex = 5;
            this.lblPlayCount.Text = "Play Count";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReleaseDate.Location = new System.Drawing.Point(480, 356);
            this.lblReleaseDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(169, 37);
            this.lblReleaseDate.TabIndex = 6;
            this.lblReleaseDate.Text = "Release Date";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(480, 423);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(6);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(200, 67);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "▶ Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnLike
            // 
            this.btnLike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnLike.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLike.ForeColor = System.Drawing.Color.White;
            this.btnLike.Location = new System.Drawing.Point(720, 423);
            this.btnLike.Margin = new System.Windows.Forms.Padding(6);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(200, 67);
            this.btnLike.TabIndex = 2;
            this.btnLike.Text = "🤍 Like";
            this.btnLike.UseVisualStyleBackColor = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnAddToPlaylist
            // 
            this.btnAddToPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.btnAddToPlaylist.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToPlaylist.ForeColor = System.Drawing.Color.White;
            this.btnAddToPlaylist.Location = new System.Drawing.Point(960, 423);
            this.btnAddToPlaylist.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddToPlaylist.Name = "btnAddToPlaylist";
            this.btnAddToPlaylist.Size = new System.Drawing.Size(280, 67);
            this.btnAddToPlaylist.TabIndex = 3;
            this.btnAddToPlaylist.Text = "➕ Add to Playlist";
            this.btnAddToPlaylist.UseVisualStyleBackColor = false;
            this.btnAddToPlaylist.Click += new System.EventHandler(this.btnAddToPlaylist_Click);
            // 
            // lblArtistSongsTitle
            // 
            this.lblArtistSongsTitle.AutoSize = true;
            this.lblArtistSongsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArtistSongsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblArtistSongsTitle.Location = new System.Drawing.Point(0, 1301);
            this.lblArtistSongsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblArtistSongsTitle.Name = "lblArtistSongsTitle";
            this.lblArtistSongsTitle.Size = new System.Drawing.Size(571, 51);
            this.lblArtistSongsTitle.TabIndex = 1;
            this.lblArtistSongsTitle.Text = "🎵 Featured Songs from Artist";
            // 
            // pnlArtistSongs
            // 
            this.pnlArtistSongs.AutoScroll = true;
            this.pnlArtistSongs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArtistSongs.Location = new System.Drawing.Point(0, 436);
            this.pnlArtistSongs.Margin = new System.Windows.Forms.Padding(6);
            this.pnlArtistSongs.Name = "pnlArtistSongs";
            this.pnlArtistSongs.Size = new System.Drawing.Size(1566, 865);
            this.pnlArtistSongs.TabIndex = 2;
            // 
            // lblArtistAlbumsTitle
            // 
            this.lblArtistAlbumsTitle.AutoSize = true;
            this.lblArtistAlbumsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArtistAlbumsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblArtistAlbumsTitle.Location = new System.Drawing.Point(0, 385);
            this.lblArtistAlbumsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblArtistAlbumsTitle.Name = "lblArtistAlbumsTitle";
            this.lblArtistAlbumsTitle.Size = new System.Drawing.Size(389, 51);
            this.lblArtistAlbumsTitle.TabIndex = 3;
            this.lblArtistAlbumsTitle.Text = "💿 Featured Albums";
            // 
            // pnlArtistAlbums
            // 
            this.pnlArtistAlbums.AutoScroll = true;
            this.pnlArtistAlbums.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArtistAlbums.Location = new System.Drawing.Point(0, 0);
            this.pnlArtistAlbums.Margin = new System.Windows.Forms.Padding(6);
            this.pnlArtistAlbums.Name = "pnlArtistAlbums";
            this.pnlArtistAlbums.Size = new System.Drawing.Size(1566, 385);
            this.pnlArtistAlbums.TabIndex = 4;
            // 
            // ucSongDetailPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ucSongDetailPage";
            this.Size = new System.Drawing.Size(1600, 1154);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSongInfo.ResumeLayout(false);
            this.pnlSongInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSongCover)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSongInfo;
        private System.Windows.Forms.PictureBox pbSongCover;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblPlayCount;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnAddToPlaylist;
        private System.Windows.Forms.Label lblArtistSongsTitle;
        private System.Windows.Forms.Panel pnlArtistSongs;
        private System.Windows.Forms.Label lblArtistAlbumsTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlArtistAlbums;
    }
}
