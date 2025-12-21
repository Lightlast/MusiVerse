namespace MusiVerse.GUI.UserControls
{
    partial class ucPersonalPage
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnSwitchToArtistMode = new System.Windows.Forms.Button();
            this.lblRoleDisplay = new System.Windows.Forms.Label();
            this.lblVerifiedBadge = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMusic = new System.Windows.Forms.TabPage();
            this.panelMusicContent = new System.Windows.Forms.Panel();
            this.tabSocial = new System.Windows.Forms.TabPage();
            this.panelSocialContent = new System.Windows.Forms.Panel();
            this.tabShopping = new System.Windows.Forms.TabPage();
            this.panelShoppingContent = new System.Windows.Forms.Panel();
            this.tabArtistMusic = new System.Windows.Forms.TabPage();
            this.panelArtistMusicContent = new System.Windows.Forms.Panel();
            this.tabArtistPost = new System.Windows.Forms.TabPage();
            this.tabArtistConcert = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.panelStatisticsContent = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabMusic.SuspendLayout();
            this.tabSocial.SuspendLayout();
            this.tabShopping.SuspendLayout();
            this.tabArtistMusic.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeader.Controls.Add(this.btnSwitchToArtistMode);
            this.panelHeader.Controls.Add(this.lblRoleDisplay);
            this.panelHeader.Controls.Add(this.lblVerifiedBadge);
            this.panelHeader.Controls.Add(this.lblEmail);
            this.panelHeader.Controls.Add(this.lblUsername);
            this.panelHeader.Controls.Add(this.pictureBoxAvatar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 180);
            this.panelHeader.TabIndex = 0;

            // 
            // btnSwitchToArtistMode
            // 
            this.btnSwitchToArtistMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnSwitchToArtistMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchToArtistMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSwitchToArtistMode.ForeColor = System.Drawing.Color.White;
            this.btnSwitchToArtistMode.Location = new System.Drawing.Point(750, 20);
            this.btnSwitchToArtistMode.Name = "btnSwitchToArtistMode";
            this.btnSwitchToArtistMode.Size = new System.Drawing.Size(230, 45);
            this.btnSwitchToArtistMode.TabIndex = 5;
            this.btnSwitchToArtistMode.Text = "🎤 Chuyển sang chế độ Nghệ sĩ";
            this.btnSwitchToArtistMode.UseVisualStyleBackColor = false;
            this.btnSwitchToArtistMode.Visible = false;
            this.btnSwitchToArtistMode.Click += new System.EventHandler(this.btnSwitchToArtistMode_Click);

            // 
            // lblRoleDisplay
            // 
            this.lblRoleDisplay.AutoSize = true;
            this.lblRoleDisplay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblRoleDisplay.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoleDisplay.Location = new System.Drawing.Point(180, 100);
            this.lblRoleDisplay.Name = "lblRoleDisplay";
            this.lblRoleDisplay.Size = new System.Drawing.Size(78, 19);
            this.lblRoleDisplay.TabIndex = 4;
            this.lblRoleDisplay.Text = "Người dùng";

            // 
            // lblVerifiedBadge
            // 
            this.lblVerifiedBadge.AutoSize = true;
            this.lblVerifiedBadge.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblVerifiedBadge.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblVerifiedBadge.Location = new System.Drawing.Point(400, 30);
            this.lblVerifiedBadge.Name = "lblVerifiedBadge";
            this.lblVerifiedBadge.Size = new System.Drawing.Size(26, 25);
            this.lblVerifiedBadge.TabIndex = 3;
            this.lblVerifiedBadge.Text = "✓";
            this.lblVerifiedBadge.Visible = false;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(180, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(140, 19);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "email@example.com";

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(180, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(117, 30);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";

            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 0;
            this.pictureBoxAvatar.TabStop = false;

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabMusic);
            this.tabControlMain.Controls.Add(this.tabSocial);
            this.tabControlMain.Controls.Add(this.tabShopping);
            this.tabControlMain.Controls.Add(this.tabArtistMusic);
            this.tabControlMain.Controls.Add(this.tabArtistPost);
            this.tabControlMain.Controls.Add(this.tabArtistConcert);
            this.tabControlMain.Controls.Add(this.tabStatistics);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlMain.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControlMain.Location = new System.Drawing.Point(0, 180);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1000, 620);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);

            // 
            // tabMusic
            // 
            this.tabMusic.Controls.Add(this.panelMusicContent);
            this.tabMusic.Location = new System.Drawing.Point(4, 34);
            this.tabMusic.Name = "tabMusic";
            this.tabMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusic.Size = new System.Drawing.Size(992, 582);
            this.tabMusic.TabIndex = 0;
            this.tabMusic.Text = "🎵 Nhạc của tôi";
            this.tabMusic.UseVisualStyleBackColor = true;

            // 
            // panelMusicContent
            // 
            this.panelMusicContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMusicContent.Location = new System.Drawing.Point(3, 3);
            this.panelMusicContent.Name = "panelMusicContent";
            this.panelMusicContent.Size = new System.Drawing.Size(986, 576);
            this.panelMusicContent.TabIndex = 0;

            // 
            // tabSocial
            // 
            this.tabSocial.Controls.Add(this.panelSocialContent);
            this.tabSocial.Location = new System.Drawing.Point(4, 34);
            this.tabSocial.Name = "tabSocial";
            this.tabSocial.Size = new System.Drawing.Size(992, 582);
            this.tabSocial.TabIndex = 1;
            this.tabSocial.Text = "📱 Social";
            this.tabSocial.UseVisualStyleBackColor = true;

            // 
            // panelSocialContent
            // 
            this.panelSocialContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSocialContent.Location = new System.Drawing.Point(0, 0);
            this.panelSocialContent.Name = "panelSocialContent";
            this.panelSocialContent.Size = new System.Drawing.Size(992, 582);
            this.panelSocialContent.TabIndex = 0;

            // 
            // tabShopping
            // 
            this.tabShopping.Controls.Add(this.panelShoppingContent);
            this.tabShopping.Location = new System.Drawing.Point(4, 34);
            this.tabShopping.Name = "tabShopping";
            this.tabShopping.Size = new System.Drawing.Size(992, 582);
            this.tabShopping.TabIndex = 2;
            this.tabShopping.Text = "🎫 Vé Concert";
            this.tabShopping.UseVisualStyleBackColor = true;

            // 
            // panelShoppingContent
            // 
            this.panelShoppingContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShoppingContent.Location = new System.Drawing.Point(0, 0);
            this.panelShoppingContent.Name = "panelShoppingContent";
            this.panelShoppingContent.Size = new System.Drawing.Size(992, 582);
            this.panelShoppingContent.TabIndex = 0;

            // 
            // tabArtistMusic
            // 
            this.tabArtistMusic.Controls.Add(this.panelArtistMusicContent);
            this.tabArtistMusic.Location = new System.Drawing.Point(4, 34);
            this.tabArtistMusic.Name = "tabArtistMusic";
            this.tabArtistMusic.Size = new System.Drawing.Size(992, 582);
            this.tabArtistMusic.TabIndex = 3;
            this.tabArtistMusic.Text = "🎤 Quản lý Nhạc";
            this.tabArtistMusic.UseVisualStyleBackColor = true;

            // 
            // panelArtistMusicContent
            // 
            this.panelArtistMusicContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArtistMusicContent.Location = new System.Drawing.Point(0, 0);
            this.panelArtistMusicContent.Name = "panelArtistMusicContent";
            this.panelArtistMusicContent.Size = new System.Drawing.Size(992, 582);
            this.panelArtistMusicContent.TabIndex = 0;

            // 
            // tabArtistPost
            // 
            this.tabArtistPost.Location = new System.Drawing.Point(4, 34);
            this.tabArtistPost.Name = "tabArtistPost";
            this.tabArtistPost.Size = new System.Drawing.Size(992, 582);
            this.tabArtistPost.TabIndex = 4;
            this.tabArtistPost.Text = "📝 Quản lý Post";
            this.tabArtistPost.UseVisualStyleBackColor = true;

            // 
            // tabArtistConcert
            // 
            this.tabArtistConcert.Location = new System.Drawing.Point(4, 34);
            this.tabArtistConcert.Name = "tabArtistConcert";
            this.tabArtistConcert.Size = new System.Drawing.Size(992, 582);
            this.tabArtistConcert.TabIndex = 5;
            this.tabArtistConcert.Text = "🎟️ Quản lý Concert";
            this.tabArtistConcert.UseVisualStyleBackColor = true;

            // 
            // tabStatistics
            // 
            this.tabStatistics.Controls.Add(this.panelStatisticsContent);
            this.tabStatistics.Location = new System.Drawing.Point(4, 34);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Size = new System.Drawing.Size(992, 582);
            this.tabStatistics.TabIndex = 6;
            this.tabStatistics.Text = "📊 Thống kê";
            this.tabStatistics.UseVisualStyleBackColor = true;

            // 
            // panelStatisticsContent
            // 
            this.panelStatisticsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatisticsContent.Location = new System.Drawing.Point(0, 0);
            this.panelStatisticsContent.Name = "panelStatisticsContent";
            this.panelStatisticsContent.Size = new System.Drawing.Size(992, 582);
            this.panelStatisticsContent.TabIndex = 0;

            // 
            // ucPersonalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelHeader);
            this.Name = "ucPersonalPage";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.ucPersonalPage_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabMusic.ResumeLayout(false);
            this.tabSocial.ResumeLayout(false);
            this.tabShopping.ResumeLayout(false);
            this.tabArtistMusic.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblVerifiedBadge;
        private System.Windows.Forms.Label lblRoleDisplay;
        private System.Windows.Forms.Button btnSwitchToArtistMode;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMusic;
        private System.Windows.Forms.TabPage tabSocial;
        private System.Windows.Forms.TabPage tabShopping;
        private System.Windows.Forms.TabPage tabArtistMusic;
        private System.Windows.Forms.TabPage tabArtistPost;
        private System.Windows.Forms.TabPage tabArtistConcert;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.Panel panelMusicContent;
        private System.Windows.Forms.Panel panelSocialContent;
        private System.Windows.Forms.Panel panelShoppingContent;
        private System.Windows.Forms.Panel panelArtistMusicContent;
        private System.Windows.Forms.Panel panelStatisticsContent;
    }
}