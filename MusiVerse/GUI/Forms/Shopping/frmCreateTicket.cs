using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Shopping
{
    public partial class frmCreateTicket : Form
    {
        private ConcertService _concertService;
        private int _artistID;
        private string _posterImagePath = "";
        private int _editingConcertID = 0; // N?u = 0 thì là t?o m?i, n?u > 0 thì là ch?nh s?a

        public frmCreateTicket(int artistID)
        {
            InitializeComponent();
            _artistID = artistID;
            _concertService = new ConcertService();
        }

        // Constructor cho ch?nh s?a
        public frmCreateTicket(int artistID, Concert concert)
        {
            InitializeComponent();
            _artistID = artistID;
            _concertService = new ConcertService();
            _editingConcertID = concert.ConcertID;
        }

        private void frmCreateTicket_Load(object sender, EventArgs e)
        {
            SetupUI();
            if (_editingConcertID > 0)
            {
                LoadConcertData();
            }
        }

        private void SetupUI()
        {
            this.Text = _editingConcertID > 0 ? "?? Ch?nh S?a Concert" : "?? T?o Concert M?i";
            this.Size = new Size(700, 800);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnChoosePoster.Text = "?? Ch?n Poster";
            btnChoosePoster.BackColor = Color.FromArgb(100, 149, 237);
            btnChoosePoster.ForeColor = Color.White;
            btnChoosePoster.FlatStyle = FlatStyle.Flat;

            btnCreate.Text = _editingConcertID > 0 ? "?? C?p Nh?t" : "? T?o Concert";
            btnCreate.BackColor = Color.FromArgb(0, 150, 136);
            btnCreate.ForeColor = Color.White;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnCancel.Text = "H?y";
            btnCancel.BackColor = Color.FromArgb(200, 200, 200);
            btnCancel.FlatStyle = FlatStyle.Flat;
        }

        private void LoadConcertData()
        {
            try
            {
                var concert = _concertService.GetConcertById(_editingConcertID);
                if (concert != null)
                {
                    txtConcertName.Text = concert.Name;
                    txtVenue.Text = concert.Venue;
                    dtConcertDate.Value = concert.ConcertDate;
                    numTotalTickets.Value = concert.TotalTickets;
                    numPrice.Value = (decimal)concert.Price;
                    txtDescription.Text = concert.Description;
                    cbTicketType.SelectedIndex = concert.TicketType;
                    _posterImagePath = concert.PosterImage;

                    if (!string.IsNullOrEmpty(_posterImagePath) && File.Exists(_posterImagePath))
                    {
                        pbPoster.Image = Image.FromFile(_posterImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoosePoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Ch?n Poster Concert"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _posterImagePath = openDialog.FileName;
                pbPoster.Image = Image.FromFile(_posterImagePath);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtConcertName.Text))
                {
                    MessageBox.Show("Vui lòng nh?p tên concert!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtVenue.Text))
                {
                    MessageBox.Show("Vui lòng nh?p ??a ?i?m!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtConcertDate.Value <= DateTime.Now)
                {
                    MessageBox.Show("Ngày concert ph?i trong t??ng lai!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numTotalTickets.Value <= 0)
                {
                    MessageBox.Show("S? vé ph?i l?n h?n 0!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numPrice.Value < 0)
                {
                    MessageBox.Show("Giá vé không ???c âm!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // T?o ho?c c?p nh?t concert
                var concert = new Concert
                {
                    ConcertID = _editingConcertID,
                    ArtistID = _artistID,
                    Name = txtConcertName.Text,
                    Venue = txtVenue.Text,
                    ConcertDate = dtConcertDate.Value,
                    TotalTickets = (int)numTotalTickets.Value,
                    AvailableTickets = _editingConcertID == 0 ? (int)numTotalTickets.Value : 0, // C?p nh?t khi t?o m?i
                    Price = (decimal)numPrice.Value,
                    Description = txtDescription.Text,
                    PosterImage = _posterImagePath,
                    TicketType = cbTicketType.SelectedIndex,
                    IsActive = true
                };

                if (_editingConcertID == 0)
                {
                    // T?o m?i
                    int concertID = _concertService.CreateConcert(concert);
                    MessageBox.Show($"? Concert t?o thành công! ID: {concertID}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // C?p nh?t
                    bool success = _concertService.UpdateConcert(concert);
                    if (success)
                    {
                        MessageBox.Show("?? Concert c?p nh?t thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có th? thêm logic n?u c?n thi?t
        }
    }
}
