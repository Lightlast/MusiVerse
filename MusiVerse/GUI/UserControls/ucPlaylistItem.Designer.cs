namespace MusiVerse.GUI.UserControls
{
    partial class ucPlaylistItem
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
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.lblSongCount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();

            // pbCover
            this.pbCover.Location = new System.Drawing.Point(10, 10);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(120, 120);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 0;

            // lblPlaylistName
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.lblPlaylistName.Location = new System.Drawing.Point(140, 10);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(100, 21);
            this.lblPlaylistName.Text = "Playlist Name";

            // lblSongCount
            this.lblSongCount.AutoSize = true;
            this.lblSongCount.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblSongCount.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSongCount.Location = new System.Drawing.Point(140, 35);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(80, 19);
            this.lblSongCount.Text = "0 songs";

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblDescription.Location = new System.Drawing.Point(140, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.Text = "Description";
            this.lblDescription.MaximumSize = new System.Drawing.Size(400, 40);

            // lblCreatedDate
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblCreatedDate.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblCreatedDate.Location = new System.Drawing.Point(140, 80);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(80, 15);
            this.lblCreatedDate.Text = "Created Date";

            // lblVisibility
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.lblVisibility.ForeColor = System.Drawing.Color.FromArgb(50, 150, 100);
            this.lblVisibility.Location = new System.Drawing.Point(140, 100);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(60, 15);
            this.lblVisibility.Text = "Public";

            // btnPlay
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(0, 150, 200);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(580, 20);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 30);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "? Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(100, 150, 200);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(580, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "? Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(580, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "?? Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ucPlaylistItem
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.lblPlaylistName);
            this.Controls.Add(this.lblSongCount);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblVisibility);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Height = 140;
            this.Name = "ucPlaylistItem";
            this.Size = new System.Drawing.Size(680, 140);
            this.MouseEnter += new System.EventHandler(this.ucPlaylistItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucPlaylistItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.Label lblSongCount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
