namespace MusiVerse.GUI.UserControls
{
    partial class ucSongItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPlayCount = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(20, 29);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(6);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 77);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "▶";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbCover
            // 
            this.pbCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.pbCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCover.Location = new System.Drawing.Point(120, 19);
            this.pbCover.Margin = new System.Windows.Forms.Padding(6);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(98, 94);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 1;
            this.pbCover.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(240, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 48);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Song Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblArtist
            // 
            this.lblArtist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(240, 77);
            this.lblArtist.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(600, 38);
            this.lblArtist.TabIndex = 3;
            this.lblArtist.Text = "Artist Name";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGenre
            // 
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGenre.ForeColor = System.Drawing.Color.Gray;
            this.lblGenre.Location = new System.Drawing.Point(783, 52);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(200, 38);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre";
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGenre.Click += new System.EventHandler(this.lblGenre_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDuration.ForeColor = System.Drawing.Color.Gray;
            this.lblDuration.Location = new System.Drawing.Point(1043, 52);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(100, 38);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "00:00";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDuration.Click += new System.EventHandler(this.lblDuration_Click);
            // 
            // lblPlayCount
            // 
            this.lblPlayCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPlayCount.Location = new System.Drawing.Point(1203, 52);
            this.lblPlayCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayCount.Name = "lblPlayCount";
            this.lblPlayCount.Size = new System.Drawing.Size(160, 38);
            this.lblPlayCount.TabIndex = 6;
            this.lblPlayCount.Text = "▶ 0";
            this.lblPlayCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlayCount.Click += new System.EventHandler(this.lblPlayCount_Click);
            // 
            // btnLike
            // 
            this.btnLike.BackColor = System.Drawing.Color.Transparent;
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.FlatAppearance.BorderSize = 0;
            this.btnLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLike.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnLike.ForeColor = System.Drawing.Color.Red;
            this.btnLike.Location = new System.Drawing.Point(1423, 33);
            this.btnLike.Margin = new System.Windows.Forms.Padding(6);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(80, 77);
            this.btnLike.TabIndex = 7;
            this.btnLike.Text = "🤍";
            this.btnLike.UseVisualStyleBackColor = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.Color.Transparent;
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.FlatAppearance.BorderSize = 0;
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnMore.ForeColor = System.Drawing.Color.Gray;
            this.btnMore.Location = new System.Drawing.Point(1523, 33);
            this.btnMore.Margin = new System.Windows.Forms.Padding(6);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(80, 77);
            this.btnMore.TabIndex = 8;
            this.btnMore.Text = "⋮";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // ucSongItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblPlayCount);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.btnPlay);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ucSongItem";
            this.Size = new System.Drawing.Size(1800, 135);
            this.Load += new System.EventHandler(this.ucSongItem_Load);
            this.MouseEnter += new System.EventHandler(this.ucSongItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucSongItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.PictureBox pbCover;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblArtist;
        public System.Windows.Forms.Label lblGenre;
        public System.Windows.Forms.Label lblDuration;
        public System.Windows.Forms.Label lblPlayCount;
        public System.Windows.Forms.Button btnLike;
        public System.Windows.Forms.Button btnMore;
    }
}
