namespace MusiVerse.GUI.UserControls
{
    partial class ucMusicPlayer
    {
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.btnMute = new System.Windows.Forms.Button();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.panelPlayer.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.panelCenter.SuspendLayout();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            this.panelControls.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.panelPlayer.Controls.Add(this.panelRight);
            this.panelPlayer.Controls.Add(this.panelCenter);
            this.panelPlayer.Controls.Add(this.panelLeft);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(1714, 200);
            this.panelPlayer.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnStop);
            this.panelRight.Controls.Add(this.trackBarVolume);
            this.panelRight.Controls.Add(this.btnMute);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1371, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(343, 200);
            this.panelRight.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(274, 67);
            this.btnStop.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 50);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "⏹";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(94, 67);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(171, 90);
            this.trackBarVolume.TabIndex = 1;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.Transparent;
            this.btnMute.FlatAppearance.BorderSize = 0;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.btnMute.ForeColor = System.Drawing.Color.White;
            this.btnMute.Location = new System.Drawing.Point(17, 58);
            this.btnMute.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(69, 67);
            this.btnMute.TabIndex = 0;
            this.btnMute.Text = "🔊";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelProgress);
            this.panelCenter.Controls.Add(this.panelControls);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(514, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1200, 200);
            this.panelCenter.TabIndex = 1;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.lblCurrentTime);
            this.panelProgress.Controls.Add(this.trackBarSeek);
            this.panelProgress.Controls.Add(this.lblTotalTime);
            this.panelProgress.Location = new System.Drawing.Point(17, 117);
            this.panelProgress.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(823, 67);
            this.panelProgress.TabIndex = 1;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTime.Location = new System.Drawing.Point(9, 17);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(77, 33);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "0:00";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.Location = new System.Drawing.Point(94, 8);
            this.trackBarSeek.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.trackBarSeek.Maximum = 1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(634, 90);
            this.trackBarSeek.TabIndex = 1;
            this.trackBarSeek.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            this.trackBarSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSeek_MouseDown);
            this.trackBarSeek.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarSeek_MouseUp);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalTime.ForeColor = System.Drawing.Color.White;
            this.lblTotalTime.Location = new System.Drawing.Point(737, 17);
            this.lblTotalTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(77, 33);
            this.lblTotalTime.TabIndex = 2;
            this.lblTotalTime.Text = "0:00";
            this.lblTotalTime.Click += new System.EventHandler(this.lblTotalTime_Click);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnShuffle);
            this.panelControls.Controls.Add(this.btnPrevious);
            this.panelControls.Controls.Add(this.btnBackward);
            this.panelControls.Controls.Add(this.btnPlayPause);
            this.panelControls.Controls.Add(this.btnForward);
            this.panelControls.Controls.Add(this.btnNext);
            this.panelControls.Controls.Add(this.btnRepeat);
            this.panelControls.Location = new System.Drawing.Point(86, 17);
            this.panelControls.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(686, 83);
            this.panelControls.TabIndex = 0;
            // 
            // btnShuffle
            // 
            this.btnShuffle.BackColor = System.Drawing.Color.Gray;
            this.btnShuffle.FlatAppearance.BorderSize = 0;
            this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShuffle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShuffle.ForeColor = System.Drawing.Color.White;
            this.btnShuffle.Location = new System.Drawing.Point(0, 17);
            this.btnShuffle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(69, 67);
            this.btnShuffle.TabIndex = 0;
            this.btnShuffle.Text = "🔀";
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Gray;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(86, 17);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(69, 67);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "⏮";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.BackColor = System.Drawing.Color.Gray;
            this.btnBackward.FlatAppearance.BorderSize = 0;
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackward.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnBackward.ForeColor = System.Drawing.Color.White;
            this.btnBackward.Location = new System.Drawing.Point(171, 17);
            this.btnBackward.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(69, 67);
            this.btnBackward.TabIndex = 2;
            this.btnBackward.Text = "⏪";
            this.btnBackward.UseVisualStyleBackColor = false;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnPlayPause.FlatAppearance.BorderSize = 0;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnPlayPause.ForeColor = System.Drawing.Color.White;
            this.btnPlayPause.Location = new System.Drawing.Point(257, 8);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(86, 83);
            this.btnPlayPause.TabIndex = 3;
            this.btnPlayPause.Text = "▶";
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.Gray;
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnForward.ForeColor = System.Drawing.Color.White;
            this.btnForward.Location = new System.Drawing.Point(360, 17);
            this.btnForward.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(69, 67);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = "⏩";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Gray;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(446, 17);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(69, 67);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "⏭";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackColor = System.Drawing.Color.Gray;
            this.btnRepeat.FlatAppearance.BorderSize = 0;
            this.btnRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepeat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRepeat.ForeColor = System.Drawing.Color.White;
            this.btnRepeat.Location = new System.Drawing.Point(531, 17);
            this.btnRepeat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(69, 67);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "🔁";
            this.btnRepeat.UseVisualStyleBackColor = false;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblArtistName);
            this.panelLeft.Controls.Add(this.lblSongTitle);
            this.panelLeft.Controls.Add(this.pictureBoxCover);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(514, 200);
            this.panelLeft.TabIndex = 0;
            // 
            // lblArtistName
            // 
            this.lblArtistName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArtistName.ForeColor = System.Drawing.Color.LightGray;
            this.lblArtistName.Location = new System.Drawing.Point(206, 92);
            this.lblArtistName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(291, 33);
            this.lblArtistName.TabIndex = 2;
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSongTitle.ForeColor = System.Drawing.Color.White;
            this.lblSongTitle.Location = new System.Drawing.Point(206, 42);
            this.lblSongTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(291, 42);
            this.lblSongTitle.TabIndex = 1;
            this.lblSongTitle.Text = "Chưa có bài hát";
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(17, 17);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(170, 165);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 0;
            this.pictureBoxCover.TabStop = false;
            // 
            // ucMusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPlayer);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucMusicPlayer";
            this.Size = new System.Drawing.Size(1714, 200);
            this.Load += new System.EventHandler(this.ucMusicPlayer_Load);
            this.panelPlayer.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button btnStop;
    }
}