
namespace MusiVerse.GUI.Forms.Shopping
{
    partial class frmBuying
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
            this.lblConcertName = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblSeatClass = new System.Windows.Forms.Label();
            this.cbSeatClass = new System.Windows.Forms.ComboBox();
            this.panelSeatClass = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelSeatClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConcertName
            // 
            this.lblConcertName.AutoSize = true;
            this.lblConcertName.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.lblConcertName.Location = new System.Drawing.Point(20, 20);
            this.lblConcertName.Name = "lblConcertName";
            this.lblConcertName.Size = new System.Drawing.Size(144, 25);
            this.lblConcertName.TabIndex = 0;
            this.lblConcertName.Text = "Concert Name";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(20, 50);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(80, 13);
            this.lblArtist.TabIndex = 1;
            this.lblArtist.Text = "?? Artist Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "?? 01/01/2024";
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(20, 90);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(71, 13);
            this.lblVenue.TabIndex = 3;
            this.lblVenue.Text = "?? Venue";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblPrice.Location = new System.Drawing.Point(20, 115);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(104, 20);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "?? 100.000?/vé";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.ForeColor = System.Drawing.Color.Green;
            this.lblAvailable.Location = new System.Drawing.Point(20, 140);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(77, 13);
            this.lblAvailable.TabIndex = 5;
            this.lblAvailable.Text = "Còn: 50 vé";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblQuantity.Location = new System.Drawing.Point(20, 180);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(75, 19);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "S? l??ng vé:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(100, 178);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 20);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // lblSeatClass
            // 
            this.lblSeatClass.AutoSize = true;
            this.lblSeatClass.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblSeatClass.Location = new System.Drawing.Point(20, 20);
            this.lblSeatClass.Name = "lblSeatClass";
            this.lblSeatClass.Size = new System.Drawing.Size(76, 19);
            this.lblSeatClass.TabIndex = 8;
            this.lblSeatClass.Text = "H?ng gh?:";
            // 
            // cbSeatClass
            // 
            this.cbSeatClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeatClass.FormattingEnabled = true;
            this.cbSeatClass.Location = new System.Drawing.Point(100, 18);
            this.cbSeatClass.Name = "cbSeatClass";
            this.cbSeatClass.Size = new System.Drawing.Size(200, 21);
            this.cbSeatClass.TabIndex = 9;
            this.cbSeatClass.SelectedIndexChanged += new System.EventHandler(this.cbSeatClass_SelectedIndexChanged);
            // 
            // panelSeatClass
            // 
            this.panelSeatClass.Controls.Add(this.cbSeatClass);
            this.panelSeatClass.Controls.Add(this.lblSeatClass);
            this.panelSeatClass.Location = new System.Drawing.Point(20, 210);
            this.panelSeatClass.Name = "panelSeatClass";
            this.panelSeatClass.Size = new System.Drawing.Size(350, 50);
            this.panelSeatClass.TabIndex = 10;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 280);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(104, 25);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "T?ng: 0?";
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnBuy.Location = new System.Drawing.Point(350, 420);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(110, 40);
            this.btnBuy.TabIndex = 12;
            this.btnBuy.Text = "Mua vé";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnCancel.Location = new System.Drawing.Point(470, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "H?y";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBuying
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelSeatClass);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblConcertName);
            this.Name = "frmBuying";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mua vé concert";
            this.Load += new System.EventHandler(this.frmBuying_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelSeatClass.ResumeLayout(false);
            this.panelSeatClass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConcertName;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblSeatClass;
        private System.Windows.Forms.ComboBox cbSeatClass;
        private System.Windows.Forms.Panel panelSeatClass;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnCancel;
    }
}
