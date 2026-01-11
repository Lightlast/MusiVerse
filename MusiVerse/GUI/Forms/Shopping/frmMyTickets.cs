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
    public partial class frmMyTickets : Form
    {
        private int _userID;
        private TicketService _ticketService;

        public frmMyTickets(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _ticketService = new TicketService();
        }

        private void frmMyTickets_Load(object sender, EventArgs e)
        {
            this.Text = "🎫 Vé của tôi";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            LoadTickets();
        }

        private void LoadTickets()
        {
            try
            {
                // Xóa các controls cũ
                this.Controls.Clear();

                // Tạo panel chứa danh sách vé
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    Padding = new Padding(15),
                    BackColor = Color.FromArgb(240, 240, 245)
                };

                // Tạo label tiêu đề
                Label lblTitle = new Label
                {
                    Text = "🎫 Vé Concert Của Tôi",
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 144, 255),
                    AutoSize = true
                };
                flowPanel.Controls.Add(lblTitle);

                // Lấy danh sách vé
                var tickets = _ticketService.GetUserTickets(_userID);

                if (tickets.Count == 0)
                {
                    Label lblNoTickets = new Label
                    {
                        Text = "Bạn chưa có vé concert nào",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };
                    flowPanel.Controls.Add(lblNoTickets);
                }
                else
                {
                    foreach (var ticket in tickets)
                    {
                        Panel ticketCard = CreateTicketCard(ticket);
                        flowPanel.Controls.Add(ticketCard);
                    }
                }

                this.Controls.Add(flowPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateTicketCard(Ticket ticket)
        {
            Panel card = new Panel
            {
                Size = new Size(850, 200),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5, 10, 5, 10)
            };

            // Thông tin vé
            Label lblConcert = new Label
            {
                Text = $"🎵 {ticket.ConcertName}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = $"📅 {ticket.ConcertDate:dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 45),
                AutoSize = true
            };

            Label lblVenue = new Label
            {
                Text = $"📍 {ticket.Venue}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 65),
                AutoSize = true
            };

            Label lblTicketCode = new Label
            {
                Text = $"Mã vé: {ticket.TicketCode}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                Location = new Point(15, 90),
                AutoSize = true
            };

            // Hiển thị hạng ghế nếu có
            Label lblSeatClass = new Label
            {
                Text = ticket.TicketType == 1 ? $"Hạng: {ticket.SeatClass}" : "Loại: Không sấp chỗ",
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 110),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            // Trạng thái vé
            bool isExpired = _ticketService.IsTicketExpired(ticket);
            Label lblStatus = new Label
            {
                Text = isExpired ? "❌ Hết hạn" : "✅ Còn hiệu lực",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = isExpired ? Color.Red : Color.Green,
                Location = new Point(15, 135),
                AutoSize = true
            };

            // Giá vé
            Label lblPrice = new Label
            {
                Text = $"Giá: {ticket.Price:N0}đ",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 160),
                AutoSize = true
            };

            // Nút xem QR code
            Button btnViewQR = new Button
            {
                Text = "📱 Xem QR Code",
                Size = new Size(130, 35),
                Location = new Point(710, 80),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9)
            };
            btnViewQR.Click += (s, e) => ViewQRCode(ticket);

            // Nút tải xuống QR code
            Button btnDownloadQR = new Button
            {
                Text = "⬇️ Tải QR Code",
                Size = new Size(130, 35),
                Location = new Point(710, 125),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9)
            };
            btnDownloadQR.Click += (s, e) => DownloadQRCode(ticket);

            card.Controls.Add(lblConcert);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblVenue);
            card.Controls.Add(lblTicketCode);
            card.Controls.Add(lblSeatClass);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnViewQR);
            card.Controls.Add(btnDownloadQR);

            return card;
        }

        private void ViewQRCode(Ticket ticket)
        {
            if (!System.IO.File.Exists(ticket.QRCodeImage))
            {
                MessageBox.Show("Không tìm thấy file QR code", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form qrForm = new Form
            {
                Text = $"QR Code - {ticket.TicketCode}",
                Size = new Size(450, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            PictureBox pbQR = new PictureBox
            {
                Image = Image.FromFile(ticket.QRCodeImage),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                Size = new Size(450, 400)
            };

            Label lblTicketCode = new Label
            {
                Text = $"Mã vé: {ticket.TicketCode}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            qrForm.Controls.Add(lblTicketCode);
            qrForm.Controls.Add(pbQR);
            qrForm.ShowDialog();
        }

        private void DownloadQRCode(Ticket ticket)
        {
            if (!System.IO.File.Exists(ticket.QRCodeImage))
            {
                MessageBox.Show("Không tìm thấy file QR code", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                FileName = $"QR_{ticket.TicketCode}.png",
                Filter = "PNG Image (*.png)|*.png"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.Copy(ticket.QRCodeImage, saveDialog.FileName, true);
                    MessageBox.Show("Tải xuống thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
