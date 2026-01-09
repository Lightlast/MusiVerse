namespace MusiVerse.GUI.UserControls
{
    partial class ucPostCard
    {
        private System.ComponentModel.IContainer components = null;
        
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.PictureBox pbMedia;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblLikes;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblShares;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnSave;

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
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblLikes = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblShares = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pbAvatar);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Controls.Add(this.btnMenu);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeader.Size = new System.Drawing.Size(916, 60);
            this.pnlHeader.TabIndex = 4;
            // 
            // pbAvatar
            // 
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAvatar.Location = new System.Drawing.Point(10, 6);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(48, 48);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 0;
            this.pbAvatar.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(70, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(158, 41);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(86, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 32);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.White;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Arial", 14F);
            this.btnMenu.ForeColor = System.Drawing.Color.Gray;
            this.btnMenu.Location = new System.Drawing.Point(650, 10);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(40, 40);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "⋮";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContent.ForeColor = System.Drawing.Color.Black;
            this.lblContent.Location = new System.Drawing.Point(15, 75);
            this.lblContent.Name = "lblContent";
            this.lblContent.Padding = new System.Windows.Forms.Padding(15);
            this.lblContent.Size = new System.Drawing.Size(916, 60);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Post Content";
            // 
            // pbMedia
            // 
            this.pbMedia.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbMedia.Location = new System.Drawing.Point(15, 135);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(916, 300);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedia.TabIndex = 2;
            this.pbMedia.TabStop = false;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlStats.Controls.Add(this.lblLikes);
            this.pnlStats.Controls.Add(this.lblComments);
            this.pnlStats.Controls.Add(this.lblShares);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(15, 435);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.pnlStats.Size = new System.Drawing.Size(916, 30);
            this.pnlStats.TabIndex = 1;
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLikes.Location = new System.Drawing.Point(7, -2);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(67, 32);
            this.lblLikes.TabIndex = 0;
            this.lblLikes.Text = "❤️ 0";
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComments.Location = new System.Drawing.Point(80, -2);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(67, 32);
            this.lblComments.TabIndex = 1;
            this.lblComments.Text = "💬 0";
            // 
            // lblShares
            // 
            this.lblShares.AutoSize = true;
            this.lblShares.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShares.Location = new System.Drawing.Point(153, -2);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(67, 32);
            this.lblShares.TabIndex = 2;
            this.lblShares.Text = "📤 0";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnLike);
            this.pnlActions.Controls.Add(this.btnComment);
            this.pnlActions.Controls.Add(this.btnShare);
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(15, 465);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlActions.Size = new System.Drawing.Size(916, 57);
            this.pnlActions.TabIndex = 0;
            // 
            // btnLike
            // 
            this.btnLike.BackColor = System.Drawing.Color.White;
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.FlatAppearance.BorderSize = 0;
            this.btnLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLike.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLike.ForeColor = System.Drawing.Color.Black;
            this.btnLike.Location = new System.Drawing.Point(10, 8);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(80, 48);
            this.btnLike.TabIndex = 0;
            this.btnLike.Text = "🤍 Thích";
            this.btnLike.UseVisualStyleBackColor = false;
            // 
            // btnComment
            // 
            this.btnComment.BackColor = System.Drawing.Color.White;
            this.btnComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComment.FlatAppearance.BorderSize = 0;
            this.btnComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComment.Location = new System.Drawing.Point(104, 8);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(100, 48);
            this.btnComment.TabIndex = 1;
            this.btnComment.Text = "💬 Bình luận";
            this.btnComment.UseVisualStyleBackColor = false;
            // 
            // btnShare
            // 
            this.btnShare.BackColor = System.Drawing.Color.White;
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShare.FlatAppearance.BorderSize = 0;
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShare.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShare.Location = new System.Drawing.Point(210, 8);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(80, 48);
            this.btnShare.TabIndex = 2;
            this.btnShare.Text = "📤 Chia sẻ";
            this.btnShare.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(300, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 48);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "📌 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // ucPostCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pbMedia);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ucPostCard";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(946, 633);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
