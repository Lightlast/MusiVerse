using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Shopping
{
    public partial class frmConcertDetail : Form
    {
        private Concert _concert;

        public frmConcertDetail(Concert concert)
        {
            InitializeComponent();
            _concert = concert;
        }

        private void frmConcertDetail_Load(object sender, EventArgs e)
        {
            this.Text = _concert.Name;
            this.Size = new Size(700, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            DisplayConcertDetail();
        }

        private void DisplayConcertDetail()
        {
            // Xóa các controls cũ
            this.Controls.Clear();

            // Panel chính
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            int yPos = 10;

            // Tiêu đề
            Label lblTitle = new Label
            {
                Text = _concert.Name,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(0, yPos),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTitle);
            yPos += 40;

            // Poster
            if (!string.IsNullOrEmpty(_concert.PosterImage) && System.IO.File.Exists(_concert.PosterImage))
            {
                try
                {
                    PictureBox pbPoster = new PictureBox
                    {
                        Image = Image.FromFile(_concert.PosterImage),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(300, 300),
                        Location = new Point(150, yPos)
                    };
                    mainPanel.Controls.Add(pbPoster);
                    yPos += 320;
                }
                catch { }
            }

            // Thông tin
            Label lblArtist = CreateLabel($"🎤 Nghệ sĩ: {_concert.ArtistName}", 12, yPos);
            mainPanel.Controls.Add(lblArtist);
            yPos += 35;

            Label lblDate = CreateLabel($"📅 Ngày: {_concert.ConcertDate:dd/MM/yyyy HH:mm}", 12, yPos);
            mainPanel.Controls.Add(lblDate);
            yPos += 35;

            Label lblVenue = CreateLabel($"📍 Địa điểm: {_concert.Venue}", 12, yPos);
            mainPanel.Controls.Add(lblVenue);
            yPos += 35;

            Label lblPrice = CreateLabel($"💰 Giá: {_concert.Price:N0}đ", 13, yPos);
            lblPrice.ForeColor = Color.FromArgb(255, 140, 0);
            mainPanel.Controls.Add(lblPrice);
            yPos += 35;

            Label lblTickets = CreateLabel($"🎫 Vé còn lại: {_concert.AvailableTickets}/{_concert.TotalTickets}", 12, yPos);
            lblTickets.ForeColor = _concert.AvailableTickets > 0 ? Color.Green : Color.Red;
            mainPanel.Controls.Add(lblTickets);
            yPos += 35;

            Label lblTicketType = CreateLabel(
                _concert.TicketType == 0 ? "🎫 Loại vé: Không sấp chỗ" : "💺 Loại vé: Có sấp chỗ (VIP/Standard/Economy)",
                12, yPos);
            mainPanel.Controls.Add(lblTicketType);
            yPos += 40;

            // Mô tả
            if (!string.IsNullOrEmpty(_concert.Description))
            {
                Label lblDescTitle = new Label
                {
                    Text = "📝 Mô tả:",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(0, yPos),
                    AutoSize = true
                };
                mainPanel.Controls.Add(lblDescTitle);
                yPos += 30;

                TextBox txtDescription = new TextBox
                {
                    Text = _concert.Description,
                    Multiline = true,
                    ReadOnly = true,
                    Size = new Size(600, 150),
                    Location = new Point(0, yPos),
                    ScrollBars = ScrollBars.Vertical,
                    BorderStyle = BorderStyle.FixedSingle
                };
                mainPanel.Controls.Add(txtDescription);
                yPos += 160;
            }

            this.Controls.Add(mainPanel);
        }

        private Label CreateLabel(string text, int fontSize, int yPos)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", fontSize),
                Location = new Point(0, yPos),
                AutoSize = true
            };
        }
    }
}
