namespace MusiVerse.GUI.Forms.Music
{
    partial class frmUploadSong
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.groupBoxCover = new System.Windows.Forms.GroupBox();
            this.lblCoverStatus = new System.Windows.Forms.Label();
            this.btnClearCover = new System.Windows.Forms.Button();
            this.btnSelectCover = new System.Windows.Forms.Button();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.groupBoxSongInfo = new System.Windows.Forms.GroupBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.groupBoxAudioFile = new System.Windows.Forms.GroupBox();
            this.lblMetadataStatus = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.btnSelectAudio = new System.Windows.Forms.Button();
            this.txtAudioFile = new System.Windows.Forms.TextBox();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupBoxCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.groupBoxSongInfo.SuspendLayout();
            this.groupBoxAudioFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblInstructions);
            this.panelMain.Controls.Add(this.lblProgress);
            this.panelMain.Controls.Add(this.progressBar);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnUpload);
            this.panelMain.Controls.Add(this.groupBoxCover);
            this.panelMain.Controls.Add(this.groupBoxSongInfo);
            this.panelMain.Controls.Add(this.groupBoxAudioFile);
            this.panelMain.Controls.Add(this.lblArtistName);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1356, 1057);
            this.panelMain.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(51, 840);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1269, 31);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProgress.ForeColor = System.Drawing.Color.Blue;
            this.lblProgress.Location = new System.Drawing.Point(51, 806);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 37);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Visible = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInstructions.ForeColor = System.Drawing.Color.Gray;
            this.lblInstructions.Location = new System.Drawing.Point(5, 1001);
            this.lblInstructions.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(805, 32);
            this.lblInstructions.TabIndex = 9;
            this.lblInstructions.Text = "💡 Hỗ trợ: MP3, WAV, M4A | Tối đa 50MB | Ảnh bìa: JPG, PNG | Tối đa 5MB";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1183, 890);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 83);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(874, 888);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(257, 83);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "📤 UPLOAD";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBoxCover
            // 
            this.groupBoxCover.Controls.Add(this.lblCoverStatus);
            this.groupBoxCover.Controls.Add(this.btnClearCover);
            this.groupBoxCover.Controls.Add(this.btnSelectCover);
            this.groupBoxCover.Controls.Add(this.pictureBoxCover);
            this.groupBoxCover.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxCover.Location = new System.Drawing.Point(874, 450);
            this.groupBoxCover.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxCover.Name = "groupBoxCover";
            this.groupBoxCover.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxCover.Size = new System.Drawing.Size(446, 373);
            this.groupBoxCover.TabIndex = 4;
            this.groupBoxCover.TabStop = false;
            this.groupBoxCover.Text = "3. Ảnh Bìa (Tùy chọn)";
            // 
            // lblCoverStatus
            // 
            this.lblCoverStatus.AutoSize = true;
            this.lblCoverStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoverStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCoverStatus.Location = new System.Drawing.Point(89, 258);
            this.lblCoverStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCoverStatus.Name = "lblCoverStatus";
            this.lblCoverStatus.Size = new System.Drawing.Size(215, 32);
            this.lblCoverStatus.TabIndex = 3;
            this.lblCoverStatus.Text = "Chưa chọn ảnh bìa";
            this.lblCoverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearCover
            // 
            this.btnClearCover.BackColor = System.Drawing.Color.Gray;
            this.btnClearCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCover.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearCover.ForeColor = System.Drawing.Color.White;
            this.btnClearCover.Location = new System.Drawing.Point(231, 308);
            this.btnClearCover.Margin = new System.Windows.Forms.Padding(5);
            this.btnClearCover.Name = "btnClearCover";
            this.btnClearCover.Size = new System.Drawing.Size(171, 50);
            this.btnClearCover.TabIndex = 2;
            this.btnClearCover.Text = "Xóa";
            this.btnClearCover.UseVisualStyleBackColor = false;
            this.btnClearCover.Click += new System.EventHandler(this.btnClearCover_Click);
            // 
            // btnSelectCover
            // 
            this.btnSelectCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.btnSelectCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCover.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectCover.ForeColor = System.Drawing.Color.White;
            this.btnSelectCover.Location = new System.Drawing.Point(34, 308);
            this.btnSelectCover.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelectCover.Name = "btnSelectCover";
            this.btnSelectCover.Size = new System.Drawing.Size(171, 50);
            this.btnSelectCover.TabIndex = 1;
            this.btnSelectCover.Text = "Chọn ảnh";
            this.btnSelectCover.UseVisualStyleBackColor = false;
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click);
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(94, 50);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(256, 249);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 0;
            this.pictureBoxCover.TabStop = false;
            // 
            // groupBoxSongInfo
            // 
            this.groupBoxSongInfo.Controls.Add(this.txtAlbum);
            this.groupBoxSongInfo.Controls.Add(this.lblAlbum);
            this.groupBoxSongInfo.Controls.Add(this.cmbGenre);
            this.groupBoxSongInfo.Controls.Add(this.lblGenre);
            this.groupBoxSongInfo.Controls.Add(this.txtTitle);
            this.groupBoxSongInfo.Controls.Add(this.lblSongTitle);
            this.groupBoxSongInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxSongInfo.Location = new System.Drawing.Point(51, 450);
            this.groupBoxSongInfo.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxSongInfo.Name = "groupBoxSongInfo";
            this.groupBoxSongInfo.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxSongInfo.Size = new System.Drawing.Size(789, 373);
            this.groupBoxSongInfo.TabIndex = 3;
            this.groupBoxSongInfo.TabStop = false;
            this.groupBoxSongInfo.Text = "2. Thông Tin Bài Hát";
            // 
            // txtAlbum
            // 
            this.txtAlbum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAlbum.Location = new System.Drawing.Point(411, 217);
            this.txtAlbum.Margin = new System.Windows.Forms.Padding(5);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(340, 43);
            this.txtAlbum.TabIndex = 5;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlbum.Location = new System.Drawing.Point(411, 175);
            this.lblAlbum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(208, 37);
            this.lblAlbum.TabIndex = 4;
            this.lblAlbum.Text = "Album (Nếu có):";
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(34, 217);
            this.cmbGenre.Margin = new System.Windows.Forms.Padding(5);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(340, 45);
            this.cmbGenre.TabIndex = 3;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGenre.Location = new System.Drawing.Point(34, 175);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(117, 37);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Thể loại:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(34, 108);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(717, 43);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.AutoSize = true;
            this.lblSongTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSongTitle.Location = new System.Drawing.Point(34, 67);
            this.lblSongTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(170, 37);
            this.lblSongTitle.TabIndex = 0;
            this.lblSongTitle.Text = "Tên bài hát: *";
            // 
            // groupBoxAudioFile
            // 
            this.groupBoxAudioFile.Controls.Add(this.lblMetadataStatus);
            this.groupBoxAudioFile.Controls.Add(this.lblDuration);
            this.groupBoxAudioFile.Controls.Add(this.lblFileSize);
            this.groupBoxAudioFile.Controls.Add(this.btnSelectAudio);
            this.groupBoxAudioFile.Controls.Add(this.txtAudioFile);
            this.groupBoxAudioFile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxAudioFile.Location = new System.Drawing.Point(51, 183);
            this.groupBoxAudioFile.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxAudioFile.Name = "groupBoxAudioFile";
            this.groupBoxAudioFile.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxAudioFile.Size = new System.Drawing.Size(1269, 233);
            this.groupBoxAudioFile.TabIndex = 2;
            this.groupBoxAudioFile.TabStop = false;
            this.groupBoxAudioFile.Text = "1. Chọn File Nhạc";
            // 
            // lblMetadataStatus
            // 
            this.lblMetadataStatus.AutoSize = true;
            this.lblMetadataStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetadataStatus.ForeColor = System.Drawing.Color.Green;
            this.lblMetadataStatus.Location = new System.Drawing.Point(34, 175);
            this.lblMetadataStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMetadataStatus.Name = "lblMetadataStatus";
            this.lblMetadataStatus.Size = new System.Drawing.Size(0, 32);
            this.lblMetadataStatus.TabIndex = 4;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDuration.ForeColor = System.Drawing.Color.Gray;
            this.lblDuration.Location = new System.Drawing.Point(343, 133);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(162, 32);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Thời lượng: --";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFileSize.ForeColor = System.Drawing.Color.Gray;
            this.lblFileSize.Location = new System.Drawing.Point(34, 133);
            this.lblFileSize.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(159, 32);
            this.lblFileSize.TabIndex = 2;
            this.lblFileSize.Text = "Kích thước: --";
            // 
            // btnSelectAudio
            // 
            this.btnSelectAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnSelectAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAudio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectAudio.ForeColor = System.Drawing.Color.White;
            this.btnSelectAudio.Location = new System.Drawing.Point(1011, 58);
            this.btnSelectAudio.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelectAudio.Name = "btnSelectAudio";
            this.btnSelectAudio.Size = new System.Drawing.Size(223, 58);
            this.btnSelectAudio.TabIndex = 1;
            this.btnSelectAudio.Text = "📁 Chọn File";
            this.btnSelectAudio.UseVisualStyleBackColor = false;
            this.btnSelectAudio.Click += new System.EventHandler(this.btnSelectAudio_Click);
            // 
            // txtAudioFile
            // 
            this.txtAudioFile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAudioFile.Location = new System.Drawing.Point(34, 67);
            this.txtAudioFile.Margin = new System.Windows.Forms.Padding(5);
            this.txtAudioFile.Name = "txtAudioFile";
            this.txtAudioFile.ReadOnly = true;
            this.txtAudioFile.Size = new System.Drawing.Size(940, 43);
            this.txtAudioFile.TabIndex = 0;
            this.txtAudioFile.Text = "Chưa chọn file";
            // 
            // lblArtistName
            // 
            this.lblArtistName.AutoSize = true;
            this.lblArtistName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblArtistName.ForeColor = System.Drawing.Color.Gray;
            this.lblArtistName.Location = new System.Drawing.Point(43, 108);
            this.lblArtistName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(280, 41);
            this.lblArtistName.TabIndex = 1;
            this.lblArtistName.Text = "Nghệ sĩ: [Loading...]";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 33);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📤 Upload Bài Hát";
            // 
            // frmUploadSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 1057);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmUploadSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Bài Hát - Musiverse";
            this.Load += new System.EventHandler(this.frmUploadSong_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxCover.ResumeLayout(false);
            this.groupBoxCover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.groupBoxSongInfo.ResumeLayout(false);
            this.groupBoxSongInfo.PerformLayout();
            this.groupBoxAudioFile.ResumeLayout(false);
            this.groupBoxAudioFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.GroupBox groupBoxAudioFile;
        private System.Windows.Forms.TextBox txtAudioFile;
        private System.Windows.Forms.Button btnSelectAudio;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblMetadataStatus;
        private System.Windows.Forms.GroupBox groupBoxSongInfo;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.GroupBox groupBoxCover;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button btnSelectCover;
        private System.Windows.Forms.Button btnClearCover;
        private System.Windows.Forms.Label lblCoverStatus;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
    }
}