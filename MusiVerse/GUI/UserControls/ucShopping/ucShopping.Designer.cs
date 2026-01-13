namespace MusiVerse.GUI.UserControls
{
    partial class ucShopping
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCreateTicket = new System.Windows.Forms.Button();
            this.btnManageTickets = new System.Windows.Forms.Button();
            this.btnMyTickets = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnCreateTicket);
            this.panelTop.Controls.Add(this.btnManageTickets);
            this.panelTop.Controls.Add(this.btnMyTickets);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(950, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎫 MUA VÉ CONCERT";
            // 
            // btnCreateTicket
            // 
            this.btnCreateTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnCreateTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTicket.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnCreateTicket.ForeColor = System.Drawing.Color.White;
            this.btnCreateTicket.Location = new System.Drawing.Point(430, 22);
            this.btnCreateTicket.Name = "btnCreateTicket";
            this.btnCreateTicket.Size = new System.Drawing.Size(130, 35);
            this.btnCreateTicket.TabIndex = 3;
            this.btnCreateTicket.Text = "✨ Tạo Concert";
            this.btnCreateTicket.UseVisualStyleBackColor = false;
            this.btnCreateTicket.Visible = false;
            this.btnCreateTicket.Click += new System.EventHandler(this.btnCreateTicket_Click);
            // 
            // btnManageTickets
            // 
            this.btnManageTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnManageTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTickets.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnManageTickets.ForeColor = System.Drawing.Color.White;
            this.btnManageTickets.Location = new System.Drawing.Point(570, 22);
            this.btnManageTickets.Name = "btnManageTickets";
            this.btnManageTickets.Size = new System.Drawing.Size(120, 35);
            this.btnManageTickets.TabIndex = 4;
            this.btnManageTickets.Text = "⚙️ Quản lý vé";
            this.btnManageTickets.UseVisualStyleBackColor = false;
            this.btnManageTickets.Visible = false;
            this.btnManageTickets.Click += new System.EventHandler(this.btnManageTickets_Click);
            // 
            // btnMyTickets
            // 
            this.btnMyTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnMyTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyTickets.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnMyTickets.ForeColor = System.Drawing.Color.White;
            this.btnMyTickets.Location = new System.Drawing.Point(700, 22);
            this.btnMyTickets.Name = "btnMyTickets";
            this.btnMyTickets.Size = new System.Drawing.Size(110, 35);
            this.btnMyTickets.TabIndex = 1;
            this.btnMyTickets.Text = "🎫 Vé của tôi";
            this.btnMyTickets.UseVisualStyleBackColor = false;
            this.btnMyTickets.Click += new System.EventHandler(this.btnMyTickets_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(820, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel.Size = new System.Drawing.Size(950, 520);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // ucShopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.panelTop);
            this.Name = "ucShopping";
            this.Size = new System.Drawing.Size(950, 600);
            this.Load += new System.EventHandler(this.ucShopping_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCreateTicket;
        private System.Windows.Forms.Button btnManageTickets;
        private System.Windows.Forms.Button btnMyTickets;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}
