namespace MusiVerse.GUI.Forms.Auth
{
    partial class frmUpgradeToArtist
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.lblUserInfoTitle = new System.Windows.Forms.Label();
            this.lblCurrentUsername = new System.Windows.Forms.Label();
            this.lblCurrentFullName = new System.Windows.Forms.Label();
            this.lblCurrentEmail = new System.Windows.Forms.Label();
            this.lblCurrentRole = new System.Windows.Forms.Label();
            this.panelEligibility = new System.Windows.Forms.Panel();
            this.lblEligibilityIcon = new System.Windows.Forms.Label();
            this.lblEligibilityStatus = new System.Windows.Forms.Label();
            this.lblRoleOptionsTitle = new System.Windows.Forms.Label();
            this.panelArtistOption = new System.Windows.Forms.Panel();
            this.lblArtistTitle = new System.Windows.Forms.Label();
            this.lblArtistDesc = new System.Windows.Forms.Label();
            this.panelIndieOption = new System.Windows.Forms.Panel();
            this.lblIndieTitle = new System.Windows.Forms.Label();
            this.lblIndieDesc = new System.Windows.Forms.Label();
            this.lblRoleDescription = new System.Windows.Forms.Label();
            this.lblBioTitle = new System.Windows.Forms.Label();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.linkLearnMore = new System.Windows.Forms.LinkLabel();

            this.panelMain.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.panelEligibility.SuspendLayout();
            this.panelArtistOption.SuspendLayout();
            this.panelIndieOption.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 700);
            this.panelMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(740, 40);
            this.lblTitle.Text = "⬆️ NÂNG CẤP TÀI KHOẢN LÊN NGHỆ SĨ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panelUserInfo
            this.panelUserInfo.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.panelUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserInfo.Location = new System.Drawing.Point(30, 80);
            this.panelUserInfo.Size = new System.Drawing.Size(350, 140);
            this.panelUserInfo.Controls.Add(this.lblUserInfoTitle);
            this.panelUserInfo.Controls.Add(this.lblCurrentUsername);
            this.panelUserInfo.Controls.Add(this.lblCurrentFullName);
            this.panelUserInfo.Controls.Add(this.lblCurrentEmail);
            this.panelUserInfo.Controls.Add(this.lblCurrentRole);

            this.lblUserInfoTitle.Text = "THÔNG TIN HIỆN TẠI";
            this.lblUserInfoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserInfoTitle.Location = new System.Drawing.Point(10, 10);
            this.lblUserInfoTitle.AutoSize = true;

            this.lblCurrentUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentUsername.Location = new System.Drawing.Point(15, 40);
            this.lblCurrentUsername.AutoSize = true;

            this.lblCurrentFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentFullName.Location = new System.Drawing.Point(15, 65);
            this.lblCurrentFullName.AutoSize = true;

            this.lblCurrentEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentEmail.Location = new System.Drawing.Point(15, 90);
            this.lblCurrentEmail.AutoSize = true;

            this.lblCurrentRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentRole.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentRole.Location = new System.Drawing.Point(15, 115);
            this.lblCurrentRole.AutoSize = true;

            // panelEligibility
            this.panelEligibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEligibility.Location = new System.Drawing.Point(400, 80);
            this.panelEligibility.Size = new System.Drawing.Size(370, 140);
            this.panelEligibility.Controls.Add(this.lblEligibilityIcon);
            this.panelEligibility.Controls.Add(this.lblEligibilityStatus);

            this.lblEligibilityIcon.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.lblEligibilityIcon.Location = new System.Drawing.Point(30, 30);
            this.lblEligibilityIcon.Size = new System.Drawing.Size(80, 80);
            this.lblEligibilityIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblEligibilityStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEligibilityStatus.Location = new System.Drawing.Point(120, 50);
            this.lblEligibilityStatus.Size = new System.Drawing.Size(240, 40);
            this.lblEligibilityStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblRoleOptionsTitle
            this.lblRoleOptionsTitle.Text = "CHỌN LOẠI NGHỆ SĨ:";
            this.lblRoleOptionsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoleOptionsTitle.Location = new System.Drawing.Point(30, 240);
            this.lblRoleOptionsTitle.AutoSize = true;

            // panelArtistOption
            this.panelArtistOption.BackColor = System.Drawing.Color.White;
            this.panelArtistOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelArtistOption.Location = new System.Drawing.Point(30, 280);
            this.panelArtistOption.Size = new System.Drawing.Size(240, 120);
            this.panelArtistOption.Controls.Add(this.lblArtistTitle);
            this.panelArtistOption.Controls.Add(this.lblArtistDesc);

            this.lblArtistTitle.Text = "🎤 NGHỆ SĨ CHÍNH THỨC";
            this.lblArtistTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblArtistTitle.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.lblArtistTitle.Location = new System.Drawing.Point(10, 15);
            this.lblArtistTitle.AutoSize = true;

            this.lblArtistDesc.Text = "• Upload nhạc không giới hạn\n• Tạo và bán vé Concert\n• Badge xác minh (✓)";
            this.lblArtistDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArtistDesc.Location = new System.Drawing.Point(10, 45);
            this.lblArtistDesc.Size = new System.Drawing.Size(220, 60);

            // panelIndieOption
            this.panelIndieOption.BackColor = System.Drawing.Color.White;
            this.panelIndieOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIndieOption.Location = new System.Drawing.Point(290, 280);
            this.panelIndieOption.Size = new System.Drawing.Size(240, 120);
            this.panelIndieOption.Controls.Add(this.lblIndieTitle);
            this.panelIndieOption.Controls.Add(this.lblIndieDesc);

            this.lblIndieTitle.Text = "🎸 NGHỆ SĨ ĐỘC LẬP";
            this.lblIndieTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblIndieTitle.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.lblIndieTitle.Location = new System.Drawing.Point(10, 15);
            this.lblIndieTitle.AutoSize = true;

            this.lblIndieDesc.Text = "• Upload nhạc không giới hạn\n• Đăng bài Social Network\n• Badge nghệ sĩ indie";
            this.lblIndieDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIndieDesc.Location = new System.Drawing.Point(10, 45);
            this.lblIndieDesc.Size = new System.Drawing.Size(220, 60);

            // lblRoleDescription
            this.lblRoleDescription.BackColor = System.Drawing.Color.FromArgb(250, 250, 255);
            this.lblRoleDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRoleDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoleDescription.Location = new System.Drawing.Point(550, 280);
            this.lblRoleDescription.Size = new System.Drawing.Size(220, 200);
            this.lblRoleDescription.Text = "Chọn loại nghệ sĩ để xem quyền lợi";
            this.lblRoleDescription.Padding = new System.Windows.Forms.Padding(10);

            // lblBioTitle
            this.lblBioTitle.Text = "Tiểu sử nghệ sĩ (tùy chọn):";
            this.lblBioTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBioTitle.Location = new System.Drawing.Point(30, 420);
            this.lblBioTitle.AutoSize = true;

            // txtBio
            this.txtBio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBio.Location = new System.Drawing.Point(30, 450);
            this.txtBio.Multiline = true;
            this.txtBio.Size = new System.Drawing.Size(500, 80);
            this.txtBio.MaxLength = 500;
            this.txtBio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(30, 550);
            this.progressBar.Size = new System.Drawing.Size(740, 10);
            this.progressBar.Visible = false;

            // btnUpgrade
            this.btnUpgrade.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.btnUpgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpgrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpgrade.ForeColor = System.Drawing.Color.White;
            this.btnUpgrade.Location = new System.Drawing.Point(400, 580);
            this.btnUpgrade.Size = new System.Drawing.Size(250, 50);
            this.btnUpgrade.Text = "XÁC NHẬN NÂNG CẤP";
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(670, 580);
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // linkLearnMore
            this.linkLearnMore.AutoSize = true;
            this.linkLearnMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkLearnMore.Location = new System.Drawing.Point(30, 650);
            this.linkLearnMore.Text = "ℹ️ Tìm hiểu thêm về các loại tài khoản";
            this.linkLearnMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLearnMore_LinkClicked);

            // Add all controls to panelMain
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.panelUserInfo);
            this.panelMain.Controls.Add(this.panelEligibility);
            this.panelMain.Controls.Add(this.lblRoleOptionsTitle);
            this.panelMain.Controls.Add(this.panelArtistOption);
            this.panelMain.Controls.Add(this.panelIndieOption);
            this.panelMain.Controls.Add(this.lblRoleDescription);
            this.panelMain.Controls.Add(this.lblBioTitle);
            this.panelMain.Controls.Add(this.txtBio);
            this.panelMain.Controls.Add(this.progressBar);
            this.panelMain.Controls.Add(this.btnUpgrade);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.linkLearnMore);

            // frmUpgradeToArtist
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.panelMain);
            this.Name = "frmUpgradeToArtist";
            this.Text = "Nâng Cấp Tài Khoản - Musiverse";
            this.Load += new System.EventHandler(this.frmUpgradeToArtist_Load);
            this.panelMain.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelEligibility.ResumeLayout(false);
            this.panelArtistOption.ResumeLayout(false);
            this.panelIndieOption.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label lblUserInfoTitle;
        private System.Windows.Forms.Label lblCurrentUsername;
        private System.Windows.Forms.Label lblCurrentFullName;
        private System.Windows.Forms.Label lblCurrentEmail;
        private System.Windows.Forms.Label lblCurrentRole;
        private System.Windows.Forms.Panel panelEligibility;
        private System.Windows.Forms.Label lblEligibilityIcon;
        private System.Windows.Forms.Label lblEligibilityStatus;
        private System.Windows.Forms.Label lblRoleOptionsTitle;
        private System.Windows.Forms.Panel panelArtistOption;
        private System.Windows.Forms.Label lblArtistTitle;
        private System.Windows.Forms.Label lblArtistDesc;
        private System.Windows.Forms.Panel panelIndieOption;
        private System.Windows.Forms.Label lblIndieTitle;
        private System.Windows.Forms.Label lblIndieDesc;
        private System.Windows.Forms.Label lblRoleDescription;
        private System.Windows.Forms.Label lblBioTitle;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel linkLearnMore;
    }
}