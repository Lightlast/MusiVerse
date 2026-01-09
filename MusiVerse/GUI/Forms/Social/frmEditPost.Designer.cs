namespace MusiVerse.GUI.Forms.Social
{
    partial class frmEditPost
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.PictureBox pbMedia;
        private System.Windows.Forms.Button btnSelectMedia;
        private System.Windows.Forms.Button btnRemoveMedia;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblMedia = new System.Windows.Forms.Label();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.btnSelectMedia = new System.Windows.Forms.Button();
            this.btnRemoveMedia = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.SuspendLayout();

            // Main panel
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Controls.Add(this.lblMedia);
            this.pnlMain.Controls.Add(this.pbMedia);
            this.pnlMain.Controls.Add(this.btnSelectMedia);
            this.pnlMain.Controls.Add(this.btnRemoveMedia);
            this.pnlMain.Controls.Add(this.txtContent);
            this.pnlMain.Controls.Add(this.lblContent);
            this.pnlMain.Controls.Add(this.pnlHeader);

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // Title
            this.lblTitle.Text = "?? Ch?nh s?a bài vi?t";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // Content label
            this.lblContent.Text = "N?i dung:";
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(20, 100);
            this.pnlMain.Controls.SetChildIndex(this.lblContent, 0);

            // Content textbox
            this.txtContent.Location = new System.Drawing.Point(20, 130);
            this.txtContent.Size = new System.Drawing.Size(660, 120);
            this.txtContent.Multiline = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlMain.Controls.SetChildIndex(this.txtContent, 0);

            // Media label
            this.lblMedia.Text = "Hình ?nh/Video:";
            this.lblMedia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(20, 270);
            this.pnlMain.Controls.SetChildIndex(this.lblMedia, 0);

            // Media preview
            this.pbMedia.Location = new System.Drawing.Point(20, 300);
            this.pbMedia.Size = new System.Drawing.Size(200, 150);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMedia.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlMain.Controls.SetChildIndex(this.pbMedia, 0);

            // Select media button
            this.btnSelectMedia.Text = "?? Ch?n hình ?nh";
            this.btnSelectMedia.Location = new System.Drawing.Point(240, 300);
            this.btnSelectMedia.Size = new System.Drawing.Size(140, 35);
            this.btnSelectMedia.BackColor = System.Drawing.Color.FromArgb(100, 149, 237);
            this.btnSelectMedia.ForeColor = System.Drawing.Color.White;
            this.btnSelectMedia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelectMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMedia.FlatAppearance.BorderSize = 0;
            this.btnSelectMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMain.Controls.SetChildIndex(this.btnSelectMedia, 0);

            // Remove media button
            this.btnRemoveMedia.Text = "? Xóa";
            this.btnRemoveMedia.Location = new System.Drawing.Point(240, 345);
            this.btnRemoveMedia.Size = new System.Drawing.Size(140, 35);
            this.btnRemoveMedia.BackColor = System.Drawing.Color.FromArgb(220, 20, 60);
            this.btnRemoveMedia.ForeColor = System.Drawing.Color.White;
            this.btnRemoveMedia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRemoveMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMedia.FlatAppearance.BorderSize = 0;
            this.btnRemoveMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveMedia.Enabled = false;
            this.pnlMain.Controls.SetChildIndex(this.btnRemoveMedia, 0);

            // Buttons panel
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 50;
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);

            // Save button
            this.btnSave.Text = "?? L?u";
            this.btnSave.Location = new System.Drawing.Point(480, 10);
            this.btnSave.Size = new System.Drawing.Size(200, 35);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;

            // Cancel button
            this.btnCancel.Text = "H?y";
            this.btnCancel.Location = new System.Drawing.Point(20, 10);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Ch?nh s?a bài vi?t";
            this.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);

            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
