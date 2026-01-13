namespace MusiVerse.GUI.Forms.Social
{
    partial class frmEditComment
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
            this.pnlHeaderEdit = new System.Windows.Forms.Panel();
            this.lblTitleEdit = new System.Windows.Forms.Label();
            this.pnlContentEdit = new System.Windows.Forms.Panel();
            this.lblContentEdit = new System.Windows.Forms.Label();
            this.txtContentEdit = new System.Windows.Forms.TextBox();
            this.pnlFooterEdit = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeaderEdit.SuspendLayout();
            this.pnlContentEdit.SuspendLayout();
            this.pnlFooterEdit.SuspendLayout();
            this.SuspendLayout();

            // pnlHeaderEdit
            this.pnlHeaderEdit.BackColor = System.Drawing.Color.White;
            this.pnlHeaderEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderEdit.Controls.Add(this.lblTitleEdit);
            this.pnlHeaderEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderEdit.Height = 50;
            this.pnlHeaderEdit.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderEdit.Name = "pnlHeaderEdit";
            this.pnlHeaderEdit.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeaderEdit.Size = new System.Drawing.Size(450, 50);
            this.pnlHeaderEdit.TabIndex = 0;

            // lblTitleEdit
            this.lblTitleEdit.AutoSize = true;
            this.lblTitleEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitleEdit.Location = new System.Drawing.Point(15, 12);
            this.lblTitleEdit.Name = "lblTitleEdit";
            this.lblTitleEdit.Size = new System.Drawing.Size(150, 20);
            this.lblTitleEdit.TabIndex = 0;
            this.lblTitleEdit.Text = "?? Ch?nh s?a bình lu?n";

            // pnlContentEdit
            this.pnlContentEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContentEdit.Controls.Add(this.lblContentEdit);
            this.pnlContentEdit.Controls.Add(this.txtContentEdit);
            this.pnlContentEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentEdit.Location = new System.Drawing.Point(0, 50);
            this.pnlContentEdit.Name = "pnlContentEdit";
            this.pnlContentEdit.Padding = new System.Windows.Forms.Padding(15);
            this.pnlContentEdit.Size = new System.Drawing.Size(450, 130);
            this.pnlContentEdit.TabIndex = 1;

            // lblContentEdit
            this.lblContentEdit.AutoSize = true;
            this.lblContentEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContentEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblContentEdit.Location = new System.Drawing.Point(15, 15);
            this.lblContentEdit.Name = "lblContentEdit";
            this.lblContentEdit.Size = new System.Drawing.Size(130, 19);
            this.lblContentEdit.TabIndex = 0;
            this.lblContentEdit.Text = "N?i dung bình lu?n:";

            // txtContentEdit
            this.txtContentEdit.BackColor = System.Drawing.Color.White;
            this.txtContentEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContentEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContentEdit.Location = new System.Drawing.Point(15, 40);
            this.txtContentEdit.Multiline = true;
            this.txtContentEdit.Name = "txtContentEdit";
            this.txtContentEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContentEdit.Size = new System.Drawing.Size(420, 75);
            this.txtContentEdit.TabIndex = 1;

            // pnlFooterEdit
            this.pnlFooterEdit.BackColor = System.Drawing.Color.White;
            this.pnlFooterEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooterEdit.Controls.Add(this.btnSave);
            this.pnlFooterEdit.Controls.Add(this.btnCancel);
            this.pnlFooterEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterEdit.Height = 50;
            this.pnlFooterEdit.Location = new System.Drawing.Point(0, 180);
            this.pnlFooterEdit.Name = "pnlFooterEdit";
            this.pnlFooterEdit.Padding = new System.Windows.Forms.Padding(15);
            this.pnlFooterEdit.Size = new System.Drawing.Size(450, 50);
            this.pnlFooterEdit.TabIndex = 2;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(240, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "?? C?p nh?t";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(330, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "? H?y";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmEditComment
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.Controls.Add(this.pnlContentEdit);
            this.Controls.Add(this.pnlFooterEdit);
            this.Controls.Add(this.pnlHeaderEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?? Ch?nh s?a bình lu?n";
            this.pnlHeaderEdit.ResumeLayout(false);
            this.pnlHeaderEdit.PerformLayout();
            this.pnlContentEdit.ResumeLayout(false);
            this.pnlContentEdit.PerformLayout();
            this.pnlFooterEdit.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeaderEdit;
        private System.Windows.Forms.Label lblTitleEdit;
        private System.Windows.Forms.Panel pnlContentEdit;
        private System.Windows.Forms.Label lblContentEdit;
        private System.Windows.Forms.TextBox txtContentEdit;
        private System.Windows.Forms.Panel pnlFooterEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
