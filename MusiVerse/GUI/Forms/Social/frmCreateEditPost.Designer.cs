namespace MusiVerse.GUI.Forms.Social
{
    partial class frmCreateEditPost
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.gbMedia = new System.Windows.Forms.GroupBox();
            this.btnRemoveMedia = new System.Windows.Forms.Button();
            this.btnBrowseMedia = new System.Windows.Forms.Button();
            this.lblMediaPath = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            this.gbMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnPost);
            this.pnlMain.Controls.Add(this.gbMedia);
            this.pnlMain.Controls.Add(this.txtContent);
            this.pnlMain.Controls.Add(this.lblContent);
            this.pnlMain.Controls.Add(this.lblUserInfo);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(884, 741);
            this.pnlMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(493, 669);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 49);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "✕ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPost
            // 
            this.btnPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.FlatAppearance.BorderSize = 0;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPost.ForeColor = System.Drawing.Color.White;
            this.btnPost.Location = new System.Drawing.Point(692, 669);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(180, 49);
            this.btnPost.TabIndex = 0;
            this.btnPost.Text = "📤 Đăng bài";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.BtnPost_Click);
            // 
            // gbMedia
            // 
            this.gbMedia.Controls.Add(this.pictureBoxCover);
            this.gbMedia.Controls.Add(this.btnRemoveMedia);
            this.gbMedia.Controls.Add(this.lblMediaPath);
            this.gbMedia.Controls.Add(this.btnBrowseMedia);
            this.gbMedia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbMedia.ForeColor = System.Drawing.Color.Gray;
            this.gbMedia.Location = new System.Drawing.Point(26, 340);
            this.gbMedia.Name = "gbMedia";
            this.gbMedia.Size = new System.Drawing.Size(755, 314);
            this.gbMedia.TabIndex = 4;
            this.gbMedia.TabStop = false;
            this.gbMedia.Text = "📷 Ảnh/Video";
            // 
            // btnRemoveMedia
            // 
            this.btnRemoveMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnRemoveMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveMedia.FlatAppearance.BorderSize = 0;
            this.btnRemoveMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMedia.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnRemoveMedia.ForeColor = System.Drawing.Color.White;
            this.btnRemoveMedia.Location = new System.Drawing.Point(257, 201);
            this.btnRemoveMedia.Name = "btnRemoveMedia";
            this.btnRemoveMedia.Size = new System.Drawing.Size(131, 57);
            this.btnRemoveMedia.TabIndex = 2;
            this.btnRemoveMedia.Text = "Xóa";
            this.btnRemoveMedia.UseVisualStyleBackColor = false;
            this.btnRemoveMedia.Click += new System.EventHandler(this.BtnRemoveMedia_Click);
            // 
            // btnBrowseMedia
            // 
            this.btnBrowseMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnBrowseMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseMedia.FlatAppearance.BorderSize = 0;
            this.btnBrowseMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseMedia.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBrowseMedia.ForeColor = System.Drawing.Color.White;
            this.btnBrowseMedia.Location = new System.Drawing.Point(257, 44);
            this.btnBrowseMedia.Name = "btnBrowseMedia";
            this.btnBrowseMedia.Size = new System.Drawing.Size(135, 69);
            this.btnBrowseMedia.TabIndex = 1;
            this.btnBrowseMedia.Text = "Chọn ảnh";
            this.btnBrowseMedia.UseVisualStyleBackColor = false;
            this.btnBrowseMedia.Click += new System.EventHandler(this.BtnBrowseMedia_Click);
            // 
            // lblMediaPath
            // 
            this.lblMediaPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMediaPath.ForeColor = System.Drawing.Color.Black;
            this.lblMediaPath.Location = new System.Drawing.Point(6, 272);
            this.lblMediaPath.Name = "lblMediaPath";
            this.lblMediaPath.Size = new System.Drawing.Size(480, 36);
            this.lblMediaPath.TabIndex = 0;
            this.lblMediaPath.Text = "Chưa chọn ảnh/video";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(26, 144);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(755, 176);
            this.txtContent.TabIndex = 3;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContent.Location = new System.Drawing.Point(31, 104);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(246, 37);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Nội dung bài viết:";
            this.lblContent.Click += new System.EventHandler(this.lblContent_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblUserInfo.Location = new System.Drawing.Point(20, 55);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(265, 32);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Đăng bằng: [Username]";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(17, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo bài viết mới";
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(12, 44);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(213, 214);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 5;
            this.pictureBoxCover.TabStop = false;
            // 
            // frmCreateEditPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 741);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCreateEditPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo bài viết mới";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbMedia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.GroupBox gbMedia;
        private System.Windows.Forms.Label lblMediaPath;
        private System.Windows.Forms.Button btnBrowseMedia;
        private System.Windows.Forms.Button btnRemoveMedia;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBoxCover;
    }
}
