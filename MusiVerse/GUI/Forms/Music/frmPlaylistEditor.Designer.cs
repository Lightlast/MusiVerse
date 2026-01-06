namespace MusiVerse.GUI.Forms.Music
{
    partial class frmPlaylistEditor
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.txtPlaylistName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.pnlSongs = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.pnlAvailable = new System.Windows.Forms.Panel();
            this.lblAvailableSongs = new System.Windows.Forms.Label();
            this.lvAvailableSongs = new System.Windows.Forms.ListView();
            this.colAvailableTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvailableArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvailableDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddSong = new System.Windows.Forms.Button();
            this.pnlPlaylist = new System.Windows.Forms.Panel();
            this.lblPlaylistSongs = new System.Windows.Forms.Label();
            this.lvPlaylistSongs = new System.Windows.Forms.ListView();
            this.colPlaylistTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlaylistArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlaylistDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPlaylistButtons = new System.Windows.Forms.Panel();
            this.btnRemoveSong = new System.Windows.Forms.Button();
            this.btnMoveSongUp = new System.Windows.Forms.Button();
            this.btnMoveSongDown = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.pnlSongs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlAvailable.SuspendLayout();
            this.pnlPlaylist.SuspendLayout();
            this.pnlPlaylistButtons.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // pnlInfo
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlInfo.Controls.Add(this.lblPlaylistName);
            this.pnlInfo.Controls.Add(this.txtPlaylistName);
            this.pnlInfo.Controls.Add(this.lblDescription);
            this.pnlInfo.Controls.Add(this.txtDescription);
            this.pnlInfo.Controls.Add(this.chkPublic);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height = 120;
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);

            // lblPlaylistName
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.lblPlaylistName.Location = new System.Drawing.Point(10, 10);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(100, 19);
            this.lblPlaylistName.Text = "Playlist Name:";

            // txtPlaylistName
            this.txtPlaylistName.Location = new System.Drawing.Point(120, 10);
            this.txtPlaylistName.Name = "txtPlaylistName";
            this.txtPlaylistName.Size = new System.Drawing.Size(300, 25);
            this.txtPlaylistName.TabIndex = 0;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(10, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 19);
            this.lblDescription.Text = "Description:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 45);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.TabIndex = 1;

            // chkPublic
            this.chkPublic.AutoSize = true;
            this.chkPublic.Font = new System.Drawing.Font("Segoe UI", 10);
            this.chkPublic.Location = new System.Drawing.Point(440, 15);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.Size = new System.Drawing.Size(120, 25);
            this.chkPublic.TabIndex = 2;
            this.chkPublic.Text = "?? Public";

            // pnlSongs
            this.pnlSongs.Controls.Add(this.splitter);
            this.pnlSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSongs.Location = new System.Drawing.Point(0, 120);
            this.pnlSongs.Name = "pnlSongs";
            this.pnlSongs.Size = new System.Drawing.Size(800, 340);
            this.pnlSongs.TabIndex = 1;

            // splitter
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitter.Size = new System.Drawing.Size(800, 340);
            this.splitter.TabIndex = 0;

            // splitter.Panel1
            this.splitter.Panel1.Controls.Add(this.pnlAvailable);

            // splitter.Panel2
            this.splitter.Panel2.Controls.Add(this.pnlPlaylist);

            // pnlAvailable
            this.pnlAvailable.Controls.Add(this.btnAddSong);
            this.pnlAvailable.Controls.Add(this.lvAvailableSongs);
            this.pnlAvailable.Controls.Add(this.lblAvailableSongs);
            this.pnlAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailable.Padding = new System.Windows.Forms.Padding(10);

            // lblAvailableSongs
            this.lblAvailableSongs.AutoSize = true;
            this.lblAvailableSongs.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.lblAvailableSongs.Location = new System.Drawing.Point(10, 10);
            this.lblAvailableSongs.Name = "lblAvailableSongs";
            this.lblAvailableSongs.Size = new System.Drawing.Size(150, 20);
            this.lblAvailableSongs.Text = "Available Songs:";

            // lvAvailableSongs
            this.lvAvailableSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colAvailableTitle,
                this.colAvailableArtist,
                this.colAvailableDuration
            });
            this.lvAvailableSongs.FullRowSelect = true;
            this.lvAvailableSongs.Location = new System.Drawing.Point(10, 35);
            this.lvAvailableSongs.Name = "lvAvailableSongs";
            this.lvAvailableSongs.Size = new System.Drawing.Size(780, 100);
            this.lvAvailableSongs.TabIndex = 0;
            this.lvAvailableSongs.UseCompatibleStateImageBehavior = false;
            this.lvAvailableSongs.View = System.Windows.Forms.View.Details;
            this.lvAvailableSongs.MultiSelect = true;

            // colAvailableTitle
            this.colAvailableTitle.Text = "Song";
            this.colAvailableTitle.Width = 350;

            // colAvailableArtist
            this.colAvailableArtist.Text = "Artist";
            this.colAvailableArtist.Width = 250;

            // colAvailableDuration
            this.colAvailableDuration.Text = "Duration";
            this.colAvailableDuration.Width = 80;

            // btnAddSong
            this.btnAddSong.BackColor = System.Drawing.Color.FromArgb(100, 150, 50);
            this.btnAddSong.ForeColor = System.Drawing.Color.White;
            this.btnAddSong.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnAddSong.Location = new System.Drawing.Point(10, 140);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(100, 30);
            this.btnAddSong.TabIndex = 1;
            this.btnAddSong.Text = "? Add >>";
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);

            // pnlPlaylist
            this.pnlPlaylist.Controls.Add(this.pnlPlaylistButtons);
            this.pnlPlaylist.Controls.Add(this.lvPlaylistSongs);
            this.pnlPlaylist.Controls.Add(this.lblPlaylistSongs);
            this.pnlPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlaylist.Padding = new System.Windows.Forms.Padding(10);

            // lblPlaylistSongs
            this.lblPlaylistSongs.AutoSize = true;
            this.lblPlaylistSongs.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.lblPlaylistSongs.Location = new System.Drawing.Point(10, 10);
            this.lblPlaylistSongs.Name = "lblPlaylistSongs";
            this.lblPlaylistSongs.Size = new System.Drawing.Size(150, 20);
            this.lblPlaylistSongs.Text = "Playlist Songs:";

            // lvPlaylistSongs
            this.lvPlaylistSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colPlaylistTitle,
                this.colPlaylistArtist,
                this.colPlaylistDuration
            });
            this.lvPlaylistSongs.FullRowSelect = true;
            this.lvPlaylistSongs.Location = new System.Drawing.Point(10, 35);
            this.lvPlaylistSongs.Name = "lvPlaylistSongs";
            this.lvPlaylistSongs.Size = new System.Drawing.Size(680, 100);
            this.lvPlaylistSongs.TabIndex = 0;
            this.lvPlaylistSongs.UseCompatibleStateImageBehavior = false;
            this.lvPlaylistSongs.View = System.Windows.Forms.View.Details;

            // colPlaylistTitle
            this.colPlaylistTitle.Text = "Song";
            this.colPlaylistTitle.Width = 280;

            // colPlaylistArtist
            this.colPlaylistArtist.Text = "Artist";
            this.colPlaylistArtist.Width = 220;

            // colPlaylistDuration
            this.colPlaylistDuration.Text = "Duration";
            this.colPlaylistDuration.Width = 80;

            // pnlPlaylistButtons
            this.pnlPlaylistButtons.Controls.Add(this.btnMoveSongDown);
            this.pnlPlaylistButtons.Controls.Add(this.btnMoveSongUp);
            this.pnlPlaylistButtons.Controls.Add(this.btnRemoveSong);
            this.pnlPlaylistButtons.Location = new System.Drawing.Point(10, 140);
            this.pnlPlaylistButtons.Name = "pnlPlaylistButtons";
            this.pnlPlaylistButtons.Size = new System.Drawing.Size(780, 30);
            this.pnlPlaylistButtons.TabIndex = 1;

            // btnRemoveSong
            this.btnRemoveSong.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnRemoveSong.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSong.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnRemoveSong.Location = new System.Drawing.Point(0, 0);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveSong.TabIndex = 0;
            this.btnRemoveSong.Text = "?? Remove";
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);

            // btnMoveSongUp
            this.btnMoveSongUp.BackColor = System.Drawing.Color.FromArgb(100, 100, 150);
            this.btnMoveSongUp.ForeColor = System.Drawing.Color.White;
            this.btnMoveSongUp.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnMoveSongUp.Location = new System.Drawing.Point(110, 0);
            this.btnMoveSongUp.Name = "btnMoveSongUp";
            this.btnMoveSongUp.Size = new System.Drawing.Size(80, 30);
            this.btnMoveSongUp.TabIndex = 1;
            this.btnMoveSongUp.Text = "? Up";
            this.btnMoveSongUp.Click += new System.EventHandler(this.btnMoveSongUp_Click);

            // btnMoveSongDown
            this.btnMoveSongDown.BackColor = System.Drawing.Color.FromArgb(100, 100, 150);
            this.btnMoveSongDown.ForeColor = System.Drawing.Color.White;
            this.btnMoveSongDown.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnMoveSongDown.Location = new System.Drawing.Point(200, 0);
            this.btnMoveSongDown.Name = "btnMoveSongDown";
            this.btnMoveSongDown.Size = new System.Drawing.Size(100, 30);
            this.btnMoveSongDown.TabIndex = 2;
            this.btnMoveSongDown.Text = "? Down";
            this.btnMoveSongDown.Click += new System.EventHandler(this.btnMoveSongDown_Click);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 50;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 150, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(620, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "?? Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(710, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "? Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmPlaylistEditor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.pnlSongs);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlInfo);
            this.Name = "frmPlaylistEditor";
            this.Text = "Playlist Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlSongs.ResumeLayout(false);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.pnlAvailable.ResumeLayout(false);
            this.pnlAvailable.PerformLayout();
            this.pnlPlaylist.ResumeLayout(false);
            this.pnlPlaylist.PerformLayout();
            this.pnlPlaylistButtons.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.TextBox txtPlaylistName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.Panel pnlSongs;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.Panel pnlAvailable;
        private System.Windows.Forms.Label lblAvailableSongs;
        private System.Windows.Forms.ListView lvAvailableSongs;
        private System.Windows.Forms.ColumnHeader colAvailableTitle;
        private System.Windows.Forms.ColumnHeader colAvailableArtist;
        private System.Windows.Forms.ColumnHeader colAvailableDuration;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Panel pnlPlaylist;
        private System.Windows.Forms.Label lblPlaylistSongs;
        private System.Windows.Forms.ListView lvPlaylistSongs;
        private System.Windows.Forms.ColumnHeader colPlaylistTitle;
        private System.Windows.Forms.ColumnHeader colPlaylistArtist;
        private System.Windows.Forms.ColumnHeader colPlaylistDuration;
        private System.Windows.Forms.Panel pnlPlaylistButtons;
        private System.Windows.Forms.Button btnRemoveSong;
        private System.Windows.Forms.Button btnMoveSongUp;
        private System.Windows.Forms.Button btnMoveSongDown;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
