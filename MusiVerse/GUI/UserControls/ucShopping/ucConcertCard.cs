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

namespace MusiVerse.GUI.UserControls
{
    public partial class ucConcertCard : UserControl
    {
        private Concert _concert;

        public Concert ConcertData { get => _concert; set => _concert = value; }
        
        public event EventHandler OnBuyClicked;
        public event EventHandler OnViewDetailsClicked;

        public ucConcertCard()
        {
            InitializeComponent();
        }

        public void LoadConcert(Concert concert)
        {
            _concert = concert;
            DisplayConcert();
        }

        private void DisplayConcert()
        {
            if (_concert == null) return;

            // Hiển thị poster
            if (!string.IsNullOrEmpty(_concert.PosterImage) && System.IO.File.Exists(_concert.PosterImage))
            {
                try
                {
                    pictureBoxPoster.Image = Image.FromFile(_concert.PosterImage);
                }
                catch
                {
                    pictureBoxPoster.BackColor = Color.FromArgb(200, 200, 200);
                }
            }
            else
            {
                pictureBoxPoster.BackColor = Color.FromArgb(200, 200, 200);
            }

            // Thông tin concert
            lblConcertName.Text = _concert.Name;
            lblArtist.Text = $"🎤 {_concert.ArtistName}";
            lblDate.Text = $"📅 {_concert.ConcertDate:dd/MM/yyyy HH:mm}";
            lblVenue.Text = $"📍 {_concert.Venue}";
            lblPrice.Text = $"💰 {_concert.Price:N0}đ";
            
            // Hiển thị số vé còn lại
            lblAvailable.Text = $"Còn: {_concert.AvailableTickets}/{_concert.TotalTickets} vé";
            lblAvailable.ForeColor = _concert.AvailableTickets > 0 ? Color.Green : Color.Red;

            // Hiển thị loại vé
            lblTicketType.Text = _concert.TicketType == 0 ? "🎫 Không sấp chỗ" : "💺 Có sấp chỗ (VIP/Standard/Economy)";
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            OnViewDetailsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (_concert.AvailableTickets <= 0)
            {
                MessageBox.Show("Vé concert này đã hết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnBuyClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
