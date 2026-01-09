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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnRemoveMedia = new System.Windows.Forms.Button();
            this.btnSelectMedia = new System.Windows.Forms.Button();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.lblMedia = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.btnRemoveMedia);
            this.pnlMain.Controls.Add(this.btnSelectMedia);
            this.pnlMain.Controls.Add(this.pbMedia);
            this.pnlMain.Controls.Add(this.lblMedia);
            this.pnlMain.Controls.Add(this.txtContent);
            this.pnlMain.Controls.Add(this.lblContent);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(757, 573);
            this.pnlMain.TabIndex = 0;
            // 
            // btnRemoveMedia
            // 
            this.btnRemoveMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnRemoveMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveMedia.Enabled = false;
            this.btnRemoveMedia.FlatAppearance.BorderSize = 0;
            this.btnRemoveMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMedia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRemoveMedia.ForeColor = System.Drawing.Color.White;
            this.btnRemoveMedia.Location = new System.Drawing.Point(240, 393);
            this.btnRemoveMedia.Name = "btnRemoveMedia";
            this.btnRemoveMedia.Size = new System.Drawing.Size(140, 57);
            this.btnRemoveMedia.TabIndex = 3;
            this.btnRemoveMedia.Text = "? Xóa";
            this.btnRemoveMedia.UseVisualStyleBackColor = false;
            // 
            // btnSelectMedia
            // 
            this.btnSelectMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnSelectMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectMedia.FlatAppearance.BorderSize = 0;
            this.btnSelectMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMedia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelectMedia.ForeColor = System.Drawing.Color.White;
            this.btnSelectMedia.Location = new System.Drawing.Point(240, 326);
            this.btnSelectMedia.Name = "btnSelectMedia";
            this.btnSelectMedia.Size = new System.Drawing.Size(140, 51);
            this.btnSelectMedia.TabIndex = 2;
            this.btnSelectMedia.Text = "?? Ch?n hình ?nh";
            this.btnSelectMedia.UseVisualStyleBackColor = false;
            // 
            // pbMedia
            // 
            this.pbMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pbMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMedia.Location = new System.Drawing.Point(20, 300);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(200, 150);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedia.TabIndex = 1;
            this.pbMedia.TabStop = false;
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMedia.Location = new System.Drawing.Point(23, 260);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(223, 37);
            this.lblMedia.TabIndex = 0;
            this.lblMedia.Text = "Hình ?nh/Video:";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(20, 130);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(660, 120);
            this.txtContent.TabIndex = 4;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContent.Location = new System.Drawing.Point(23, 90);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(138, 37);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = "N?i dung:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Size = new System.Drawing.Size(717, 71);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(379, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? Ch?nh s?a bài vi?t";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 573);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(757, 72);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(480, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "?? L?u";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "H?y";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmEditPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(757, 645);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEditPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ch?nh s?a bài vi?t";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
