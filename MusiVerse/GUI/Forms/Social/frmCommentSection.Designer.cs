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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCommentCount = new System.Windows.Forms.Label();
            this.pnlPostPreview = new System.Windows.Forms.Panel();
            this.pnlComments = new System.Windows.Forms.Panel();
            this.pnlCommentInput = new System.Windows.Forms.Panel();
            this.btnSendComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlCommentInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblCommentCount);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHeader.Size = new System.Drawing.Size(900, 80);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(23, -1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? Bình lu?n";
            // 
            // lblCommentCount
            // 
            this.lblCommentCount.AutoSize = true;
            this.lblCommentCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCommentCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCommentCount.Location = new System.Drawing.Point(25, 42);
            this.lblCommentCount.Name = "lblCommentCount";
            this.lblCommentCount.Size = new System.Drawing.Size(218, 37);
            this.lblCommentCount.TabIndex = 1;
            this.lblCommentCount.Text = "T?ng: 0 bình lu?n";
            // 
            // pnlPostPreview
            // 
            this.pnlPostPreview.AutoScroll = true;
            this.pnlPostPreview.BackColor = System.Drawing.Color.White;
            this.pnlPostPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPostPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPostPreview.Location = new System.Drawing.Point(0, 80);
            this.pnlPostPreview.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlPostPreview.Name = "pnlPostPreview";
            this.pnlPostPreview.Padding = new System.Windows.Forms.Padding(20);
            this.pnlPostPreview.Size = new System.Drawing.Size(900, 150);
            this.pnlPostPreview.TabIndex = 2;
            // 
            // pnlComments
            // 
            this.pnlComments.AutoScroll = true;
            this.pnlComments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComments.Location = new System.Drawing.Point(0, 230);
            this.pnlComments.Name = "pnlComments";
            this.pnlComments.Padding = new System.Windows.Forms.Padding(20);
            this.pnlComments.Size = new System.Drawing.Size(900, 390);
            this.pnlComments.TabIndex = 0;
            // 
            // pnlCommentInput
            // 
            this.pnlCommentInput.BackColor = System.Drawing.Color.White;
            this.pnlCommentInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommentInput.Controls.Add(this.btnSendComment);
            this.pnlCommentInput.Controls.Add(this.txtComment);
            this.pnlCommentInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommentInput.Location = new System.Drawing.Point(0, 620);
            this.pnlCommentInput.Name = "pnlCommentInput";
            this.pnlCommentInput.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCommentInput.Size = new System.Drawing.Size(900, 80);
            this.pnlCommentInput.TabIndex = 1;
            // 
            // btnSendComment
            // 
            this.btnSendComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSendComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendComment.FlatAppearance.BorderSize = 0;
            this.btnSendComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendComment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendComment.ForeColor = System.Drawing.Color.White;
            this.btnSendComment.Location = new System.Drawing.Point(630, 20);
            this.btnSendComment.Name = "btnSendComment";
            this.btnSendComment.Size = new System.Drawing.Size(80, 30);
            this.btnSendComment.TabIndex = 0;
            this.btnSendComment.Text = "G?i";
            this.btnSendComment.UseVisualStyleBackColor = false;
            // 
            // txtComment
            // 
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComment.Location = new System.Drawing.Point(20, 20);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(600, 43);
            this.txtComment.TabIndex = 1;
            this.txtComment.Text = "Viết bình luận...";
            // 
            // frmCommentSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.pnlComments);
            this.Controls.Add(this.pnlCommentInput);
            this.Controls.Add(this.pnlPostPreview);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCommentSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?? Bình lu?n";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCommentInput.ResumeLayout(false);
            this.pnlCommentInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
