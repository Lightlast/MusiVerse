namespace MusiVerse.GUI.Forms.Music
{
    partial class frmEditSong
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnRemoveCover = new System.Windows.Forms.Button();
            this.btnSelectCover = new System.Windows.Forms.Button();
            this.lblCoverStatus = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.lblCover = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new System.Drawing.Size(700, 70);
            this.pnlHeader.TabIndex = 0;
            
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? Ch?nh s?a bài hát";
            
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.btnRemoveCover);
            this.pnlContent.Controls.Add(this.btnSelectCover);
            this.pnlContent.Controls.Add(this.lblCoverStatus);
            this.pnlContent.Controls.Add(this.pictureBoxCover);
            this.pnlContent.Controls.Add(this.lblCover);
            this.pnlContent.Controls.Add(this.cmbGenre);
            this.pnlContent.Controls.Add(this.lblGenre);
            this.pnlContent.Controls.Add(this.txtTitle);
            this.pnlContent.Controls.Add(this.lblSongTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(700, 660);
            this.pnlContent.TabIndex = 1;
            
            this.lblSongTitle.AutoSize = true;
            this.lblSongTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSongTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(100, 23);
            this.lblSongTitle.TabIndex = 0;
            this.lblSongTitle.Text = "Tên bài hát:";
            
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(20, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(640, 27);
            this.txtTitle.TabIndex = 1;
            
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGenre.Location = new System.Drawing.Point(20, 90);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(75, 23);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Th? lo?i:";
            
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(20, 115);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(300, 31);
            this.cmbGenre.TabIndex = 3;
            
            this.lblCover.AutoSize = true;
            this.lblCover.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCover.Location = new System.Drawing.Point(20, 165);
            this.lblCover.Name = "lblCover";
            this.lblCover.Size = new System.Drawing.Size(74, 23);
            this.lblCover.TabIndex = 4;
            this.lblCover.Text = "?nh bìa:";
            
            this.pictureBoxCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(20, 190);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(180, 180);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 5;
            this.pictureBoxCover.TabStop = false;
            
            this.lblCoverStatus.AutoSize = true;
            this.lblCoverStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoverStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCoverStatus.Location = new System.Drawing.Point(220, 190);
            this.lblCoverStatus.Name = "lblCoverStatus";
            this.lblCoverStatus.Size = new System.Drawing.Size(90, 20);
            this.lblCoverStatus.TabIndex = 6;
            this.lblCoverStatus.Text = "Ch?a ch?n file";
            
            this.btnSelectCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnSelectCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectCover.FlatAppearance.BorderSize = 0;
            this.btnSelectCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectCover.ForeColor = System.Drawing.Color.White;
            this.btnSelectCover.Location = new System.Drawing.Point(220, 220);
            this.btnSelectCover.Name = "btnSelectCover";
            this.btnSelectCover.Size = new System.Drawing.Size(150, 35);
            this.btnSelectCover.TabIndex = 7;
            this.btnSelectCover.Text = "?? Ch?n ?nh";
            this.btnSelectCover.UseVisualStyleBackColor = false;
            this.btnSelectCover.Click += new System.EventHandler(this.btnSelectCover_Click);
            
            this.btnRemoveCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnRemoveCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveCover.FlatAppearance.BorderSize = 0;
            this.btnRemoveCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveCover.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCover.Location = new System.Drawing.Point(220, 265);
            this.btnRemoveCover.Name = "btnRemoveCover";
            this.btnRemoveCover.Size = new System.Drawing.Size(150, 35);
            this.btnRemoveCover.TabIndex = 8;
            this.btnRemoveCover.Text = "? Xóa ?nh";
            this.btnRemoveCover.UseVisualStyleBackColor = false;
            this.btnRemoveCover.Click += new System.EventHandler(this.btnRemoveCover_Click);
            
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 730);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlFooter.Size = new System.Drawing.Size(700, 70);
            this.pnlFooter.TabIndex = 2;
            
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(480, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "?? C?p nh?t";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(590, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "? H?y";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmEditSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?? Ch?nh s?a bài hát";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label lblCover;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label lblCoverStatus;
        private System.Windows.Forms.Button btnSelectCover;
        private System.Windows.Forms.Button btnRemoveCover;
    }
}
