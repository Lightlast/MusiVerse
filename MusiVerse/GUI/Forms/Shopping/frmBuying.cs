using MusiVerse.BLL.Services;
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
    public partial class frmBuying : Form
    {
        private Concert _concert;
        private int _userID;
        private TicketService _ticketService;
        private int _quantity = 1;
        private string _selectedSeatClass = "Standard";

        public frmBuying(Concert concert, int userID)
        {
            InitializeComponent();
            _concert = concert;
            _userID = userID;
            _ticketService = new TicketService();
        }

        private void frmBuying_Load(object sender, EventArgs e)
        {
            DisplayConcertInfo();
            SetupUI();
            LoadSeatClasses();
            UpdateTotal();
        }

        private void DisplayConcertInfo()
        {
            lblConcertName.Text = _concert.Name;
            lblArtist.Text = $"?? {_concert.ArtistName}";
            lblDate.Text = $"?? {_concert.ConcertDate:dd/MM/yyyy HH:mm}";
            lblVenue.Text = $"?? {_concert.Venue}";
            lblPrice.Text = $"?? {_concert.Price:N0}?/vé";
            lblAvailable.Text = $"Còn: {_concert.AvailableTickets} vé";
        }

        private void SetupUI()
        {
            this.Text = "Mua vé concert";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            numQuantity.Maximum = _concert.AvailableTickets;
            numQuantity.Value = 1;

            btnBuy.BackColor = Color.FromArgb(0, 150, 136);
            btnBuy.ForeColor = Color.White;
            btnBuy.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(200, 200, 200);
            btnCancel.Font = new Font("Segoe UI", 10);
        }

        private void LoadSeatClasses()
        {
            if (_concert.TicketType == 0)
            {
                // Không s?p ch?
                panelSeatClass.Visible = false;
                lblSeatClass.Visible = false;
                cbSeatClass.Visible = false;
            }
            else
            {
                // Có s?p ch?
                cbSeatClass.Items.Clear();
                cbSeatClass.Items.Add("VIP - 150% giá g?c");
                cbSeatClass.Items.Add("Standard - Giá bình th??ng");
                cbSeatClass.Items.Add("Economy - 70% giá g?c");
                cbSeatClass.SelectedIndex = 1;
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            _quantity = (int)numQuantity.Value;
            UpdateTotal();
        }

        private void cbSeatClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSeatClass.SelectedIndex)
            {
                case 0:
                    _selectedSeatClass = "VIP";
                    break;
                case 1:
                    _selectedSeatClass = "Standard";
                    break;
                case 2:
                    _selectedSeatClass = "Economy";
                    break;
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal unitPrice = _concert.Price;

            // Áp d?ng h? s? giá theo h?ng gh?
            if (_concert.TicketType == 1)
            {
                switch (_selectedSeatClass)
                {
                    case "VIP":
                        unitPrice = _concert.Price * 1.5m;
                        break;
                    case "Economy":
                        unitPrice = _concert.Price * 0.7m;
                        break;
                }
            }

            decimal total = unitPrice * _quantity;
            lblTotal.Text = $"T?ng: {total:N0}?";
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_quantity > _concert.AvailableTickets)
                {
                    MessageBox.Show("S? l??ng vé không ??!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mua vé
                for (int i = 0; i < _quantity; i++)
                {
                    int ticketID = _ticketService.BuyTicket(_concert.ConcertID, _userID, 
                        _concert.TicketType == 1 ? _selectedSeatClass : "");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi mua vé: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
