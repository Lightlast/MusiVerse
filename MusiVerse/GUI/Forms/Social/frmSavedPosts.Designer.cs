namespace MusiVerse.GUI.Forms.Social
{
    partial class frmSavedPosts
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlPosts;

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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlPosts = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // Title
            this.lblTitle.Text = "?? Bài vi?t ?ã l?u";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 144, 255);

            // Subtitle
            this.lblSubtitle.Text = "Danh sách t?t c? bài vi?t b?n ?ã l?u";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.Location = new System.Drawing.Point(20, 50);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;

            // Posts panel
            this.pnlPosts.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.pnlPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPosts.AutoScroll = true;
            this.pnlPosts.Padding = new System.Windows.Forms.Padding(20);

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "?? Bài vi?t ?ã l?u";
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.Controls.Add(this.pnlPosts);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
