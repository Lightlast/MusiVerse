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
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(20, 19);
            this.pbCover.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(240, 231);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 0;
            this.pbCover.TabStop = false;
            this.pbCover.Click += new System.EventHandler(this.pbCover_Click);
            // 
            // lblPlaylistName
            // 
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPlaylistName.Location = new System.Drawing.Point(280, 19);
            this.lblPlaylistName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(224, 45);
            this.lblPlaylistName.TabIndex = 1;
            this.lblPlaylistName.Text = "Playlist Name";
            // 
            // lblSongCount
            // 
            this.lblSongCount.AutoSize = true;
            this.lblSongCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSongCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSongCount.Location = new System.Drawing.Point(280, 67);
            this.lblSongCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(108, 37);
            this.lblSongCount.TabIndex = 2;
            this.lblSongCount.Text = "0 songs";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(280, 106);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescription.MaximumSize = new System.Drawing.Size(800, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(135, 32);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCreatedDate.Location = new System.Drawing.Point(280, 154);
            this.lblCreatedDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(154, 32);
            this.lblCreatedDate.TabIndex = 4;
            this.lblCreatedDate.Text = "Created Date";
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVisibility.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.lblVisibility.Location = new System.Drawing.Point(280, 192);
            this.lblVisibility.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(85, 32);
            this.lblVisibility.TabIndex = 5;
            this.lblVisibility.Text = "Public";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(1160, 38);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(160, 58);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "? Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(1160, 106);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 58);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "? Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1160, 173);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 58);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "?? Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucPlaylistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ucPlaylistItem";
            this.Size = new System.Drawing.Size(1360, 269);
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
