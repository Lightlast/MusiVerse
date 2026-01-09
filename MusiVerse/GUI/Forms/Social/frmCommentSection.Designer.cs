namespace MusiVerse.GUI.Forms.Social
{
    partial class frmCommentSection
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCommentCount;
        private System.Windows.Forms.Panel pnlPostPreview;
        private System.Windows.Forms.Panel pnlComments;
        private System.Windows.Forms.Panel pnlCommentInput;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSendComment;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCommentCount = new System.Windows.Forms.Label();
            this.pnlPostPreview = new System.Windows.Forms.Panel();
            this.pnlComments = new System.Windows.Forms.Panel();
            this.pnlCommentInput = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSendComment = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblCommentCount);

            // Title
            this.lblTitle.Text = "?? Bình lu?n";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            // Comment count
            this.lblCommentCount.Text = "T?ng: 0 bình lu?n";
            this.lblCommentCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCommentCount.Location = new System.Drawing.Point(20, 50);
            this.lblCommentCount.AutoSize = true;
            this.lblCommentCount.ForeColor = System.Drawing.Color.Gray;

            // Post preview
            this.pnlPostPreview.BackColor = System.Drawing.Color.White;
            this.pnlPostPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPostPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPostPreview.Height = 150;
            this.pnlPostPreview.Padding = new System.Windows.Forms.Padding(20);
            this.pnlPostPreview.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlPostPreview.AutoScroll = true;

            // Comments panel
            this.pnlComments.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.pnlComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComments.AutoScroll = true;
            this.pnlComments.Padding = new System.Windows.Forms.Padding(20);

            // Comment input panel
            this.pnlCommentInput.BackColor = System.Drawing.Color.White;
            this.pnlCommentInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommentInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommentInput.Height = 80;
            this.pnlCommentInput.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCommentInput.Controls.Add(this.btnSendComment);
            this.pnlCommentInput.Controls.Add(this.txtComment);

            // Comment textbox
            this.txtComment.Location = new System.Drawing.Point(20, 20);
            this.txtComment.Size = new System.Drawing.Size(600, 30);
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComment.PlaceholderText = "Vi?t bình lu?n...";
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Send button
            this.btnSendComment.Text = "G?i";
            this.btnSendComment.Location = new System.Drawing.Point(630, 20);
            this.btnSendComment.Size = new System.Drawing.Size(80, 30);
            this.btnSendComment.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.btnSendComment.ForeColor = System.Drawing.Color.White;
            this.btnSendComment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendComment.FlatAppearance.BorderSize = 0;
            this.btnSendComment.Cursor = System.Windows.Forms.Cursors.Hand;

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "?? Bình lu?n";
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.Controls.Add(this.pnlComments);
            this.Controls.Add(this.pnlCommentInput);
            this.Controls.Add(this.pnlPostPreview);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
