namespace MusiVerse.GUI.UserControls
{
    partial class ucAlbumItem
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
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblSongCount = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCover
            // 
            this.pbCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.pbCover.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pbCover.Location = new System.Drawing.Point(10, 10);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(180, 180);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 0;
            this.pbCover.TabStop = false;
            this.pbCover.Click += new System.EventHandler(this.pbCover_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(10, 195);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = false;
            this.lblArtist.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(10, 235);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(180, 20);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblArtist.Click += new System.EventHandler(this.lblArtist_Click);
            // 
            // lblSongCount
            // 
            this.lblSongCount.AutoSize = false;
            this.lblSongCount.Font = new System.Drawing.Font("Segoe UI", 8);
            this.lblSongCount.ForeColor = System.Drawing.Color.Gray;
            this.lblSongCount.Location = new System.Drawing.Point(10, 255);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(180, 15);
            this.lblSongCount.TabIndex = 3;
            this.lblSongCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSongCount.Click += new System.EventHandler(this.lblSongCount_Click);
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = false;
            this.lblReleaseDate.Font = new System.Drawing.Font("Segoe UI", 8);
            this.lblReleaseDate.ForeColor = System.Drawing.Color.LightGray;
            this.lblReleaseDate.Location = new System.Drawing.Point(10, 270);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(180, 15);
            this.lblReleaseDate.TabIndex = 4;
            this.lblReleaseDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblReleaseDate.Click += new System.EventHandler(this.lblReleaseDate_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(10, 290);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 30);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "?";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(55, 290);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(40, 30);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "??";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(100, 290);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 30);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "?";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(145, 290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "??";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucAlbumItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.lblSongCount);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbCover);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ucAlbumItem";
            this.Size = new System.Drawing.Size(200, 330);
            this.MouseEnter += new System.EventHandler(this.ucAlbumItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucAlbumItem_MouseLeave);
            this.Load += new System.EventHandler(this.ucAlbumItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblSongCount;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
