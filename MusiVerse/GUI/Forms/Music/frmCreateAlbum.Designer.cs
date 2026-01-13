namespace MusiVerse.GUI.Forms.Music
{
    partial class frmCreateAlbum
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSongCount = new System.Windows.Forms.Label();
            this.pnlSongs = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnMoveSongDown = new System.Windows.Forms.Button();
            this.btnMoveSongUp = new System.Windows.Forms.Button();
            this.btnRemoveSong = new System.Windows.Forms.Button();
            this.lvAlbumSongs = new System.Windows.Forms.ListView();
            this.colAlbumTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlbumArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlbumDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAlbumSongs = new System.Windows.Forms.Label();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.lvAvailableSongs = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAvailableSongs = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblCoverStatus = new System.Windows.Forms.Label();
            this.btnClearCover = new System.Windows.Forms.Button();
            this.btnSelectCover = new System.Windows.Forms.Button();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.lblCover = new System.Windows.Forms.Label();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.txtAlbumTitle = new System.Windows.Forms.TextBox();
            this.lblAlbumTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlSongs.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlSongs);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1800, 1250);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.lblSongCount);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 1154);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlBottom.Size = new System.Drawing.Size(1800, 96);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1413, 29);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 58);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1610, 29);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 58);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSongCount
            // 
            this.lblSongCount.AutoSize = true;
            this.lblSongCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSongCount.ForeColor = System.Drawing.Color.Gray;
            this.lblSongCount.Location = new System.Drawing.Point(30, 29);
            this.lblSongCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(195, 37);
            this.lblSongCount.TabIndex = 2;
            this.lblSongCount.Text = "Tổng bài hát: 0";
            // 
            // pnlSongs
            // 
            this.pnlSongs.Controls.Add(this.pnlButtons);
            this.pnlSongs.Controls.Add(this.lvAlbumSongs);
            this.pnlSongs.Controls.Add(this.lblAlbumSongs);
            this.pnlSongs.Controls.Add(this.btnAddSong);
            this.pnlSongs.Controls.Add(this.lvAvailableSongs);
            this.pnlSongs.Controls.Add(this.lblAvailableSongs);
            this.pnlSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSongs.Location = new System.Drawing.Point(0, 423);
            this.pnlSongs.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlSongs.Name = "pnlSongs";
            this.pnlSongs.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlSongs.Size = new System.Drawing.Size(1800, 827);
            this.pnlSongs.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnMoveSongDown);
            this.pnlButtons.Controls.Add(this.btnMoveSongUp);
            this.pnlButtons.Controls.Add(this.btnRemoveSong);
            this.pnlButtons.Location = new System.Drawing.Point(1140, 644);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(630, 77);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnMoveSongDown
            // 
            this.btnMoveSongDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.btnMoveSongDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoveSongDown.ForeColor = System.Drawing.Color.White;
            this.btnMoveSongDown.Location = new System.Drawing.Point(340, 10);
            this.btnMoveSongDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMoveSongDown.Name = "btnMoveSongDown";
            this.btnMoveSongDown.Size = new System.Drawing.Size(160, 58);
            this.btnMoveSongDown.TabIndex = 2;
            this.btnMoveSongDown.Text = "Xuống";
            this.btnMoveSongDown.UseVisualStyleBackColor = false;
            this.btnMoveSongDown.Click += new System.EventHandler(this.btnMoveSongDown_Click);
            // 
            // btnMoveSongUp
            // 
            this.btnMoveSongUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.btnMoveSongUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoveSongUp.ForeColor = System.Drawing.Color.White;
            this.btnMoveSongUp.Location = new System.Drawing.Point(200, 10);
            this.btnMoveSongUp.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMoveSongUp.Name = "btnMoveSongUp";
            this.btnMoveSongUp.Size = new System.Drawing.Size(120, 58);
            this.btnMoveSongUp.TabIndex = 1;
            this.btnMoveSongUp.Text = "Lên";
            this.btnMoveSongUp.UseVisualStyleBackColor = false;
            this.btnMoveSongUp.Click += new System.EventHandler(this.btnMoveSongUp_Click);
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRemoveSong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveSong.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSong.Location = new System.Drawing.Point(0, 10);
            this.btnRemoveSong.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(180, 58);
            this.btnRemoveSong.TabIndex = 0;
            this.btnRemoveSong.Text = "Xóa";
            this.btnRemoveSong.UseVisualStyleBackColor = false;
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
            // 
            // lvAlbumSongs
            // 
            this.lvAlbumSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAlbumTitle,
            this.colAlbumArtist,
            this.colAlbumDuration});
            this.lvAlbumSongs.FullRowSelect = true;
            this.lvAlbumSongs.HideSelection = false;
            this.lvAlbumSongs.Location = new System.Drawing.Point(1101, 77);
            this.lvAlbumSongs.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvAlbumSongs.Name = "lvAlbumSongs";
            this.lvAlbumSongs.Size = new System.Drawing.Size(664, 554);
            this.lvAlbumSongs.TabIndex = 2;
            this.lvAlbumSongs.UseCompatibleStateImageBehavior = false;
            this.lvAlbumSongs.View = System.Windows.Forms.View.Details;
            this.lvAlbumSongs.SelectedIndexChanged += new System.EventHandler(this.lvAlbumSongs_SelectedIndexChanged);
            // 
            // colAlbumTitle
            // 
            this.colAlbumTitle.Text = "Bài hát";
            this.colAlbumTitle.Width = 120;
            // 
            // colAlbumArtist
            // 
            this.colAlbumArtist.Text = "Nghệ sĩ";
            this.colAlbumArtist.Width = 100;
            // 
            // colAlbumDuration
            // 
            this.colAlbumDuration.Text = "Thời lượng";
            this.colAlbumDuration.Width = 80;
            // 
            // lblAlbumSongs
            // 
            this.lblAlbumSongs.AutoSize = true;
            this.lblAlbumSongs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlbumSongs.Location = new System.Drawing.Point(1140, 29);
            this.lblAlbumSongs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAlbumSongs.Name = "lblAlbumSongs";
            this.lblAlbumSongs.Size = new System.Drawing.Size(313, 41);
            this.lblAlbumSongs.TabIndex = 4;
            this.lblAlbumSongs.Text = "Bài hát trong Album:";
            // 
            // btnAddSong
            // 
            this.btnAddSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.btnAddSong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSong.ForeColor = System.Drawing.Color.White;
            this.btnAddSong.Location = new System.Drawing.Point(878, 353);
            this.btnAddSong.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(200, 67);
            this.btnAddSong.TabIndex = 1;
            this.btnAddSong.Text = "Thêm >>>";
            this.btnAddSong.UseVisualStyleBackColor = false;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // lvAvailableSongs
            // 
            this.lvAvailableSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colArtist,
            this.colDuration});
            this.lvAvailableSongs.FullRowSelect = true;
            this.lvAvailableSongs.HideSelection = false;
            this.lvAvailableSongs.Location = new System.Drawing.Point(30, 77);
            this.lvAvailableSongs.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvAvailableSongs.Name = "lvAvailableSongs";
            this.lvAvailableSongs.Size = new System.Drawing.Size(836, 554);
            this.lvAvailableSongs.TabIndex = 0;
            this.lvAvailableSongs.UseCompatibleStateImageBehavior = false;
            this.lvAvailableSongs.View = System.Windows.Forms.View.Details;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Bài hát";
            this.colTitle.Width = 150;
            // 
            // colArtist
            // 
            this.colArtist.Text = "Nghệ sĩ";
            this.colArtist.Width = 150;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Thời lượng";
            this.colDuration.Width = 116;
            // 
            // lblAvailableSongs
            // 
            this.lblAvailableSongs.AutoSize = true;
            this.lblAvailableSongs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAvailableSongs.Location = new System.Drawing.Point(30, 29);
            this.lblAvailableSongs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAvailableSongs.Name = "lblAvailableSongs";
            this.lblAvailableSongs.Size = new System.Drawing.Size(219, 41);
            this.lblAvailableSongs.TabIndex = 5;
            this.lblAvailableSongs.Text = "Bài hát có sẵn:";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlInfo.Controls.Add(this.lblCoverStatus);
            this.pnlInfo.Controls.Add(this.btnClearCover);
            this.pnlInfo.Controls.Add(this.btnSelectCover);
            this.pnlInfo.Controls.Add(this.pictureBoxCover);
            this.pnlInfo.Controls.Add(this.lblCover);
            this.pnlInfo.Controls.Add(this.dtpReleaseDate);
            this.pnlInfo.Controls.Add(this.lblReleaseDate);
            this.pnlInfo.Controls.Add(this.txtAlbumTitle);
            this.pnlInfo.Controls.Add(this.lblAlbumTitle);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 115);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlInfo.Size = new System.Drawing.Size(1800, 308);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblCoverStatus
            // 
            this.lblCoverStatus.AutoSize = true;
            this.lblCoverStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCoverStatus.Location = new System.Drawing.Point(673, 138);
            this.lblCoverStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCoverStatus.Name = "lblCoverStatus";
            this.lblCoverStatus.Size = new System.Drawing.Size(193, 25);
            this.lblCoverStatus.TabIndex = 0;
            this.lblCoverStatus.Text = "Chưa chọn ảnh bìa";
            // 
            // btnClearCover
            // 
            this.btnClearCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnClearCover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearCover.ForeColor = System.Drawing.Color.White;
            this.btnClearCover.Location = new System.Drawing.Point(460, 183);
            this.btnClearCover.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClearCover.Name = "btnClearCover";
            this.btnClearCover.Size = new System.Drawing.Size(200, 67);
            this.btnClearCover.TabIndex = 3;
            this.btnClearCover.Text = "Xóa ảnh";
            this.btnClearCover.UseVisualStyleBackColor = false;
            this.btnClearCover.Click += new System.EventHandler(this.btnClearCover_Click);
            // 
            // btnSelectCover
            // 
            this.btnSelectCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.btnSelectCover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectCover.ForeColor = System.Drawing.Color.White;
            this.btnSelectCover.Location = new System.Drawing.Point(460, 96);
            this.btnSelectCover.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSelectCover.Name = "btnSelectCover";
            this.btnSelectCover.Size = new System.Drawing.Size(200, 67);
            this.btnSelectCover.TabIndex = 2;
            this.btnSelectCover.Text = "Chọn ảnh";
            this.btnSelectCover.UseVisualStyleBackColor = false;
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click);
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.White;
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(240, 96);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(198, 190);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCover.TabIndex = 4;
            this.pictureBoxCover.TabStop = false;
            // 
            // lblCover
            // 
            this.lblCover.AutoSize = true;
            this.lblCover.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCover.Location = new System.Drawing.Point(30, 96);
            this.lblCover.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCover.Name = "lblCover";
            this.lblCover.Size = new System.Drawing.Size(118, 37);
            this.lblCover.TabIndex = 5;
            this.lblCover.Text = "Ảnh bìa:";
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(1150, 29);
            this.dtpReleaseDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(596, 31);
            this.dtpReleaseDate.TabIndex = 1;
            this.dtpReleaseDate.Value = new System.DateTime(2026, 1, 11, 21, 51, 8, 222);
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReleaseDate.Location = new System.Drawing.Point(900, 29);
            this.lblReleaseDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(228, 37);
            this.lblReleaseDate.TabIndex = 6;
            this.lblReleaseDate.Text = "Ngày phát hành:";
            // 
            // txtAlbumTitle
            // 
            this.txtAlbumTitle.Location = new System.Drawing.Point(240, 29);
            this.txtAlbumTitle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAlbumTitle.Name = "txtAlbumTitle";
            this.txtAlbumTitle.Size = new System.Drawing.Size(596, 31);
            this.txtAlbumTitle.TabIndex = 0;
            this.txtAlbumTitle.TextChanged += new System.EventHandler(this.txtAlbumTitle_TextChanged);
            // 
            // lblAlbumTitle
            // 
            this.lblAlbumTitle.AutoSize = true;
            this.lblAlbumTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlbumTitle.Location = new System.Drawing.Point(30, 29);
            this.lblAlbumTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAlbumTitle.Name = "lblAlbumTitle";
            this.lblAlbumTitle.Size = new System.Drawing.Size(161, 37);
            this.lblAlbumTitle.TabIndex = 7;
            this.lblAlbumTitle.Text = "Tên Album:";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlTop.Size = new System.Drawing.Size(1800, 115);
            this.pnlTop.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 23);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo Album";
            // 
            // frmCreateAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 1250);
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmCreateAlbum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Album";
            this.Load += new System.EventHandler(this.frmCreateAlbum_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlSongs.ResumeLayout(false);
            this.pnlSongs.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label lblAlbumTitle;
        private System.Windows.Forms.TextBox txtAlbumTitle;
        private System.Windows.Forms.Label lblCover;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button btnSelectCover;
        private System.Windows.Forms.Button btnClearCover;
        private System.Windows.Forms.Label lblCoverStatus;
        private System.Windows.Forms.Panel pnlSongs;
        private System.Windows.Forms.Label lblAvailableSongs;
        private System.Windows.Forms.ListView lvAvailableSongs;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Label lblAlbumSongs;
        private System.Windows.Forms.ListView lvAlbumSongs;
        private System.Windows.Forms.ColumnHeader colAlbumTitle;
        private System.Windows.Forms.ColumnHeader colAlbumArtist;
        private System.Windows.Forms.ColumnHeader colAlbumDuration;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRemoveSong;
        private System.Windows.Forms.Button btnMoveSongUp;
        private System.Windows.Forms.Button btnMoveSongDown;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSongCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
