
namespace MusiVerse.GUI.Forms.Shopping
{
    partial class frmCreateTicket
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
            this.txtConcertName = new System.Windows.Forms.TextBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtConcertDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.numTotalTickets = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTicketType = new System.Windows.Forms.Label();
            this.cbTicketType = new System.Windows.Forms.ComboBox();
            this.lblPoster = new System.Windows.Forms.Label();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.btnChoosePoster = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConcertName
            // 
            this.lblConcertName.AutoSize = true;
            this.lblConcertName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConcertName.Location = new System.Drawing.Point(40, 38);
            this.lblConcertName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConcertName.Name = "lblConcertName";
            this.lblConcertName.Size = new System.Drawing.Size(162, 37);
            this.lblConcertName.TabIndex = 0;
            this.lblConcertName.Text = "Tên Concert:";
            // 
            // txtConcertName
            // 
            this.txtConcertName.Location = new System.Drawing.Point(40, 87);
            this.txtConcertName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtConcertName.Name = "txtConcertName";
            this.txtConcertName.Size = new System.Drawing.Size(1296, 31);
            this.txtConcertName.TabIndex = 1;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVenue.Location = new System.Drawing.Point(40, 144);
            this.lblVenue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(130, 37);
            this.lblVenue.TabIndex = 2;
            this.lblVenue.Text = "Địa điểm:";
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(40, 192);
            this.txtVenue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(1296, 31);
            this.txtVenue.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(40, 250);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(185, 37);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Ngày Diễn Ra:";
            // 
            // dtConcertDate
            // 
            this.dtConcertDate.Location = new System.Drawing.Point(40, 298);
            this.dtConcertDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtConcertDate.Name = "dtConcertDate";
            this.dtConcertDate.Size = new System.Drawing.Size(596, 31);
            this.dtConcertDate.TabIndex = 5;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.AutoSize = true;
            this.lblTotalTickets.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalTickets.Location = new System.Drawing.Point(740, 250);
            this.lblTotalTickets.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(89, 37);
            this.lblTotalTickets.TabIndex = 6;
            this.lblTotalTickets.Text = "Số Vé:";
            // 
            // numTotalTickets
            // 
            this.numTotalTickets.Location = new System.Drawing.Point(740, 298);
            this.numTotalTickets.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numTotalTickets.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTotalTickets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalTickets.Name = "numTotalTickets";
            this.numTotalTickets.Size = new System.Drawing.Size(200, 31);
            this.numTotalTickets.TabIndex = 7;
            this.numTotalTickets.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(40, 356);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(130, 37);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Giá (vnđ):";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(40, 404);
            this.numPrice.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(300, 31);
            this.numPrice.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(40, 462);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(96, 37);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Mô T?:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(40, 510);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1296, 150);
            this.txtDescription.TabIndex = 13;
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTicketType.Location = new System.Drawing.Point(740, 356);
            this.lblTicketType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(109, 37);
            this.lblTicketType.TabIndex = 10;
            this.lblTicketType.Text = "Loại Vé:";
            // 
            // cbTicketType
            // 
            this.cbTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTicketType.FormattingEnabled = true;
            this.cbTicketType.Items.AddRange(new object[] {
            "Không S?p Ch?",
            "Có S?p Ch? (VIP/Standard/Economy)"});
            this.cbTicketType.Location = new System.Drawing.Point(740, 404);
            this.cbTicketType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbTicketType.Name = "cbTicketType";
            this.cbTicketType.Size = new System.Drawing.Size(596, 33);
            this.cbTicketType.TabIndex = 11;
            this.cbTicketType.SelectedIndexChanged += new System.EventHandler(this.cbTicketType_SelectedIndexChanged);
            // 
            // lblPoster
            // 
            this.lblPoster.AutoSize = true;
            this.lblPoster.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPoster.Location = new System.Drawing.Point(40, 683);
            this.lblPoster.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPoster.Name = "lblPoster";
            this.lblPoster.Size = new System.Drawing.Size(96, 37);
            this.lblPoster.TabIndex = 14;
            this.lblPoster.Text = "Poster:";
            // 
            // pbPoster
            // 
            this.pbPoster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPoster.Location = new System.Drawing.Point(40, 731);
            this.pbPoster.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(298, 383);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 15;
            this.pbPoster.TabStop = false;
            // 
            // btnChoosePoster
            // 
            this.btnChoosePoster.Location = new System.Drawing.Point(380, 731);
            this.btnChoosePoster.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnChoosePoster.Name = "btnChoosePoster";
            this.btnChoosePoster.Size = new System.Drawing.Size(260, 67);
            this.btnChoosePoster.TabIndex = 16;
            this.btnChoosePoster.Text = "Chọn Poster";
            this.btnChoosePoster.UseVisualStyleBackColor = true;
            this.btnChoosePoster.Click += new System.EventHandler(this.btnChoosePoster_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(800, 1154);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(260, 77);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "button1";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1080, 1154);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(260, 77);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreateTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 1308);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnChoosePoster);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.lblPoster);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cbTicketType);
            this.Controls.Add(this.lblTicketType);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numTotalTickets);
            this.Controls.Add(this.lblTotalTickets);
            this.Controls.Add(this.dtConcertDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtVenue);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.txtConcertName);
            this.Controls.Add(this.lblConcertName);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmCreateTicket";
            this.Text = "Create Concert";
            this.Load += new System.EventHandler(this.frmCreateTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTotalTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConcertName;
        private System.Windows.Forms.TextBox txtConcertName;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtConcertDate;
        private System.Windows.Forms.Label lblTotalTickets;
        private System.Windows.Forms.NumericUpDown numTotalTickets;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTicketType;
        private System.Windows.Forms.ComboBox cbTicketType;
        private System.Windows.Forms.Label lblPoster;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Button btnChoosePoster;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}
