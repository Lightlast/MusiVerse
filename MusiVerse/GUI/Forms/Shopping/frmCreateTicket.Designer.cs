
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
            this.lblConcertName.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblConcertName.Location = new System.Drawing.Point(20, 20);
            this.lblConcertName.Name = "lblConcertName";
            this.lblConcertName.Size = new System.Drawing.Size(94, 19);
            this.lblConcertName.TabIndex = 0;
            this.lblConcertName.Text = "Tên Concert:";
            // 
            // txtConcertName
            // 
            this.txtConcertName.Location = new System.Drawing.Point(20, 45);
            this.txtConcertName.Name = "txtConcertName";
            this.txtConcertName.Size = new System.Drawing.Size(650, 20);
            this.txtConcertName.TabIndex = 1;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblVenue.Location = new System.Drawing.Point(20, 75);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(66, 19);
            this.lblVenue.TabIndex = 2;
            this.lblVenue.Text = "??a ?i?m:";
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(20, 100);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(650, 20);
            this.txtVenue.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblDate.Location = new System.Drawing.Point(20, 130);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(99, 19);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Ngày Di?n Ra:";
            // 
            // dtConcertDate
            // 
            this.dtConcertDate.Location = new System.Drawing.Point(20, 155);
            this.dtConcertDate.Name = "dtConcertDate";
            this.dtConcertDate.Size = new System.Drawing.Size(300, 20);
            this.dtConcertDate.TabIndex = 5;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.AutoSize = true;
            this.lblTotalTickets.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblTotalTickets.Location = new System.Drawing.Point(370, 130);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(90, 19);
            this.lblTotalTickets.TabIndex = 6;
            this.lblTotalTickets.Text = "T?ng Vé (cái):";
            // 
            // numTotalTickets
            // 
            this.numTotalTickets.Location = new System.Drawing.Point(370, 155);
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
            this.numTotalTickets.Size = new System.Drawing.Size(100, 20);
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
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblPrice.Location = new System.Drawing.Point(20, 185);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(58, 19);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Giá (?):";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(20, 210);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(150, 20);
            this.numPrice.TabIndex = 9;
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblTicketType.Location = new System.Drawing.Point(370, 185);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(87, 19);
            this.lblTicketType.TabIndex = 10;
            this.lblTicketType.Text = "Lo?i Vé (VIP):";
            // 
            // cbTicketType
            // 
            this.cbTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTicketType.FormattingEnabled = true;
            this.cbTicketType.Items.AddRange(new object[] {
            "Không S?p Ch?",
            "Có S?p Ch? (VIP/Standard/Economy)"});
            this.cbTicketType.Location = new System.Drawing.Point(370, 210);
            this.cbTicketType.Name = "cbTicketType";
            this.cbTicketType.Size = new System.Drawing.Size(300, 21);
            this.cbTicketType.TabIndex = 11;
            this.cbTicketType.SelectedIndexChanged += new System.EventHandler(this.cbTicketType_SelectedIndexChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblDescription.Location = new System.Drawing.Point(20, 240);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(58, 19);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Mô T?:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 265);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(650, 80);
            this.txtDescription.TabIndex = 13;
            // 
            // lblPoster
            // 
            this.lblPoster.AutoSize = true;
            this.lblPoster.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblPoster.Location = new System.Drawing.Point(20, 355);
            this.lblPoster.Name = "lblPoster";
            this.lblPoster.Size = new System.Drawing.Size(62, 19);
            this.lblPoster.TabIndex = 14;
            this.lblPoster.Text = "Poster:";
            // 
            // pbPoster
            // 
            this.pbPoster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPoster.Location = new System.Drawing.Point(20, 380);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(150, 200);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 15;
            this.pbPoster.TabStop = false;
            // 
            // btnChoosePoster
            // 
            this.btnChoosePoster.Location = new System.Drawing.Point(190, 380);
            this.btnChoosePoster.Name = "btnChoosePoster";
            this.btnChoosePoster.Size = new System.Drawing.Size(130, 35);
            this.btnChoosePoster.TabIndex = 16;
            this.btnChoosePoster.Text = "button1";
            this.btnChoosePoster.UseVisualStyleBackColor = true;
            this.btnChoosePoster.Click += new System.EventHandler(this.btnChoosePoster_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(400, 600);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(130, 40);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "button1";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(540, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreateTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 680);
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
