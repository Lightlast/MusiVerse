namespace MusiVerse.GUI.Forms.Music
{
    partial class frmPlaylistManager
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
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNewPlaylist = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPlaylists = new System.Windows.Forms.TabPage();
            this.pnlPlaylists = new System.Windows.Forms.Panel();
            this.tabSongsInPlaylist = new System.Windows.Forms.TabPage();
            this.pnlPlaylistSongs = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPlaylists.SuspendLayout();
            this.tabSongsInPlaylist.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnNewPlaylist);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "📝 Playlist Manager";

            // btnNewPlaylist
            this.btnNewPlaylist.BackColor = System.Drawing.Color.FromArgb(100, 150, 50);
            this.btnNewPlaylist.ForeColor = System.Drawing.Color.White;
            this.btnNewPlaylist.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnNewPlaylist.Location = new System.Drawing.Point(500, 12);
            this.btnNewPlaylist.Name = "btnNewPlaylist";
            this.btnNewPlaylist.Size = new System.Drawing.Size(150, 35);
            this.btnNewPlaylist.TabIndex = 0;
            this.btnNewPlaylist.Text = "➕ New Playlist";
            this.btnNewPlaylist.Click += new System.EventHandler(this.btnNewPlaylist_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 100, 150);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(660, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // tabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 500);
            this.tabControl.TabIndex = 0;
            this.tabControl.Controls.Add(this.tabPlaylists);
            this.tabControl.Controls.Add(this.tabSongsInPlaylist);

            // tabPlaylists
            this.tabPlaylists.Controls.Add(this.pnlPlaylists);
            this.tabPlaylists.Location = new System.Drawing.Point(4, 22);
            this.tabPlaylists.Name = "tabPlaylists";
            this.tabPlaylists.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaylists.Size = new System.Drawing.Size(792, 474);
            this.tabPlaylists.TabIndex = 0;
            this.tabPlaylists.Text = "My Playlists";

            // pnlPlaylists
            this.pnlPlaylists.AutoScroll = true;
            this.pnlPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlaylists.Location = new System.Drawing.Point(3, 3);
            this.pnlPlaylists.Name = "pnlPlaylists";
            this.pnlPlaylists.Size = new System.Drawing.Size(786, 468);
            this.pnlPlaylists.TabIndex = 0;

            // tabSongsInPlaylist
            this.tabSongsInPlaylist.Controls.Add(this.pnlPlaylistSongs);
            this.tabSongsInPlaylist.Location = new System.Drawing.Point(4, 22);
            this.tabSongsInPlaylist.Name = "tabSongsInPlaylist";
            this.tabSongsInPlaylist.Padding = new System.Windows.Forms.Padding(3);
            this.tabSongsInPlaylist.Size = new System.Drawing.Size(792, 474);
            this.tabSongsInPlaylist.TabIndex = 1;
            this.tabSongsInPlaylist.Text = "Playlist Songs";

            // pnlPlaylistSongs
            this.pnlPlaylistSongs.AutoScroll = true;
            this.pnlPlaylistSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlaylistSongs.Location = new System.Drawing.Point(3, 3);
            this.pnlPlaylistSongs.Name = "pnlPlaylistSongs";
            this.pnlPlaylistSongs.Size = new System.Drawing.Size(786, 468);
            this.pnlPlaylistSongs.TabIndex = 0;

            // frmPlaylistManager
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmPlaylistManager";
            this.Text = "Playlist Manager 📝";
            this.Load += new System.EventHandler(this.frmPlaylistManager_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPlaylists.ResumeLayout(false);
            this.tabSongsInPlaylist.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnNewPlaylist;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPlaylists;
        private System.Windows.Forms.Panel pnlPlaylists;
        private System.Windows.Forms.TabPage tabSongsInPlaylist;
        private System.Windows.Forms.Panel pnlPlaylistSongs;
    }
}