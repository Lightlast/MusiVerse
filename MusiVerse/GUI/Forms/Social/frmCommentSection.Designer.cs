namespace MusiVerse.GUI.Forms.Social
{
    partial class frmCommentSection
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
            this.pnlComments = new System.Windows.Forms.Panel();
            this.flowLayoutPanelComments = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCommentsTitle = new System.Windows.Forms.Label();
            this.pnlAddComment = new System.Windows.Forms.Panel();
            this.lblAddComment = new System.Windows.Forms.Label();
            this.txtNewComment = new System.Windows.Forms.TextBox();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.pnlComments.SuspendLayout();
            this.pnlAddComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlComments
            // 
            this.pnlComments.AutoScroll = true;
            this.pnlComments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlComments.Controls.Add(this.flowLayoutPanelComments);
            this.pnlComments.Controls.Add(this.lblCommentsTitle);
            this.pnlComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComments.Location = new System.Drawing.Point(0, 0);
            this.pnlComments.Name = "pnlComments";
            this.pnlComments.Padding = new System.Windows.Forms.Padding(10);
            this.pnlComments.Size = new System.Drawing.Size(1095, 537);
            this.pnlComments.TabIndex = 1;
            // 
            // flowLayoutPanelComments
            // 
            this.flowLayoutPanelComments.AutoScroll = true;
            this.flowLayoutPanelComments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.flowLayoutPanelComments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelComments.Location = new System.Drawing.Point(0, 53);
            this.flowLayoutPanelComments.Name = "flowLayoutPanelComments";
            this.flowLayoutPanelComments.Size = new System.Drawing.Size(1059, 517);
            this.flowLayoutPanelComments.TabIndex = 1;
            this.flowLayoutPanelComments.WrapContents = false;
            // 
            // lblCommentsTitle
            // 
            this.lblCommentsTitle.AutoSize = true;
            this.lblCommentsTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.lblCommentsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCommentsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCommentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblCommentsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCommentsTitle.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.lblCommentsTitle.Name = "lblCommentsTitle";
            this.lblCommentsTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 137);
            this.lblCommentsTitle.Size = new System.Drawing.Size(181, 174);
            this.lblCommentsTitle.TabIndex = 0;
            this.lblCommentsTitle.Text = "💬 Bình luận";
            this.lblCommentsTitle.Click += new System.EventHandler(this.lblCommentsTitle_Click);
            // 
            // pnlAddComment
            // 
            this.pnlAddComment.BackColor = System.Drawing.Color.White;
            this.pnlAddComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddComment.Controls.Add(this.lblAddComment);
            this.pnlAddComment.Controls.Add(this.txtNewComment);
            this.pnlAddComment.Controls.Add(this.btnAddComment);
            this.pnlAddComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAddComment.Location = new System.Drawing.Point(0, 576);
            this.pnlAddComment.Name = "pnlAddComment";
            this.pnlAddComment.Padding = new System.Windows.Forms.Padding(15);
            this.pnlAddComment.Size = new System.Drawing.Size(1095, 187);
            this.pnlAddComment.TabIndex = 2;
            // 
            // lblAddComment
            // 
            this.lblAddComment.AutoSize = true;
            this.lblAddComment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblAddComment.Location = new System.Drawing.Point(10, 40);
            this.lblAddComment.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.lblAddComment.Name = "lblAddComment";
            this.lblAddComment.Size = new System.Drawing.Size(199, 32);
            this.lblAddComment.TabIndex = 0;
            this.lblAddComment.Text = "Thêm bình luận:";
            // 
            // txtNewComment
            // 
            this.txtNewComment.BackColor = System.Drawing.Color.White;
            this.txtNewComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewComment.Location = new System.Drawing.Point(11, 86);
            this.txtNewComment.Multiline = true;
            this.txtNewComment.Name = "txtNewComment";
            this.txtNewComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewComment.Size = new System.Drawing.Size(720, 60);
            this.txtNewComment.TabIndex = 1;
            // 
            // btnAddComment
            // 
            this.btnAddComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAddComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddComment.FlatAppearance.BorderSize = 0;
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(958, 113);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(100, 46);
            this.btnAddComment.TabIndex = 2;
            this.btnAddComment.Text = "✔️ Gửi";
            this.btnAddComment.UseVisualStyleBackColor = false;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // frmCommentSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1095, 763);
            this.Controls.Add(this.pnlComments);
            this.Controls.Add(this.pnlAddComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommentSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💬 Bình luận";
            this.Load += new System.EventHandler(this.frmCommentSection_Load);
            this.pnlComments.ResumeLayout(false);
            this.pnlComments.PerformLayout();
            this.pnlAddComment.ResumeLayout(false);
            this.pnlAddComment.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel pnlComments;
        private System.Windows.Forms.Label lblCommentsTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelComments;
        private System.Windows.Forms.Panel pnlAddComment;
        private System.Windows.Forms.Label lblAddComment;
        private System.Windows.Forms.TextBox txtNewComment;
        private System.Windows.Forms.Button btnAddComment;
    }
}
