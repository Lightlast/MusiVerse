namespace MusiVerse.GUI.UserControls
{
    partial class ucConcertCard
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
            this.pictureBoxPoster = new System.Windows.Forms.PictureBox();
            this.lblConcertName = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblTicketType = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPoster
            // 
            this.pictureBoxPoster.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxPoster.Name = "pictureBoxPoster";
            this.pictureBoxPoster.Size = new System.Drawing.Size(180, 180);
            this.pictureBoxPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPoster.TabIndex = 0;
            this.pictureBoxPoster.TabStop = false;
            // 
            // lblConcertName
            // 
            this.lblConcertName.AutoSize = true;
            this.lblConcertName.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.lblConcertName.Location = new System.Drawing.Point(200, 10);
            this.lblConcertName.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblConcertName.Name = "lblConcertName";
            this.lblConcertName.Size = new System.Drawing.Size(123, 20);
            this.lblConcertName.TabIndex = 1;
            this.lblConcertName.Text = "Concert Name";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(200, 35);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(80, 15);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "🎤 Artist Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblDate.Location = new System.Drawing.Point(200, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 15);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "📅 01/01/2024";
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblVenue.Location = new System.Drawing.Point(200, 75);
            this.lblVenue.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(71, 15);
            this.lblVenue.TabIndex = 4;
            this.lblVenue.Text = "📍 Venue";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblPrice.Location = new System.Drawing.Point(200, 100);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(92, 21);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "💰 100.000đ";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblAvailable.ForeColor = System.Drawing.Color.Green;
            this.lblAvailable.Location = new System.Drawing.Point(200, 130);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(77, 15);
            this.lblAvailable.TabIndex = 6;
            this.lblAvailable.Text = "Còn: 50/100";
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.Font = new System.Drawing.Font("Segoe UI", 8);
            this.lblTicketType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTicketType.Location = new System.Drawing.Point(200, 150);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(120, 13);
            this.lblTicketType.TabIndex = 7;
            this.lblTicketType.Text = "🎫 Không sấp chỗ";
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(200, 175);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 35);
            this.btnViewDetails.TabIndex = 8;
            this.btnViewDetails.Text = "Chi tiết";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnBuy.ForeColor = System.Drawing.Color.White;
            this.btnBuy.Location = new System.Drawing.Point(330, 175);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(120, 35);
            this.btnBuy.TabIndex = 9;
            this.btnBuy.Text = "Mua vé";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // ucConcertCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lblTicketType);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblConcertName);
            this.Controls.Add(this.pictureBoxPoster);
            this.Name = "ucConcertCard";
            this.Size = new System.Drawing.Size(470, 220);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPoster;
        private System.Windows.Forms.Label lblConcertName;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblTicketType;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnBuy;
    }
}
