 namespace MusiVerse.GUI.Forms.Shopping
{
    partial class frmTicketsManagement
    {
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scpConcerts = new System.Windows.Forms.Panel();
            this.pnlEmpty = new System.Windows.Forms.Panel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlEmpty.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlEmpty);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(2000, 1250);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlHeader.Size = new System.Drawing.Size(2000, 115);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(548, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ Quản Lý Vé Concert";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.scpConcerts);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 29, 30, 29);
            this.pnlContent.Size = new System.Drawing.Size(2000, 1250);
            this.pnlContent.TabIndex = 1;
            // 
            // scpConcerts
            // 
            this.scpConcerts.AutoScroll = true;
            this.scpConcerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.scpConcerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scpConcerts.Location = new System.Drawing.Point(30, 29);
            this.scpConcerts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.scpConcerts.Name = "scpConcerts";
            this.scpConcerts.Size = new System.Drawing.Size(1940, 1192);
            this.scpConcerts.TabIndex = 2;
            // 
            // pnlEmpty
            // 
            this.pnlEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlEmpty.Controls.Add(this.lblEmpty);
            this.pnlEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmpty.Location = new System.Drawing.Point(0, 0);
            this.pnlEmpty.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlEmpty.Name = "pnlEmpty";
            this.pnlEmpty.Size = new System.Drawing.Size(2000, 1250);
            this.pnlEmpty.TabIndex = 2;
            this.pnlEmpty.Visible = false;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblEmpty.Location = new System.Drawing.Point(700, 481);
            this.lblEmpty.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(381, 45);
            this.lblEmpty.TabIndex = 0;
            this.lblEmpty.Text = "Bạn chưa tạo concert nào";
            // 
            // frmTicketsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(2000, 1250);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTicketsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "⚙️ Quản lý vé Concert";
            this.Load += new System.EventHandler(this.frmTicketsManagement_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlEmpty.ResumeLayout(false);
            this.pnlEmpty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlEmpty;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Panel scpConcerts;
    }
}
