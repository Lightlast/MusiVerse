using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using QRCoder;
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
                flpTickets.Controls.Clear();
                pnlEmpty.Visible = false;

                // Lấy danh sách vé
                var tickets = _ticketService.GetUserTickets(_userID);

                if (tickets.Count == 0)
                {
                    pnlEmpty.Visible = true;
                    return;
                }

                foreach (var ticket in tickets)
                {
                    Panel ticketCard = CreateTicketCard(ticket);
                    flpTickets.Controls.Add(ticketCard);
                }
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
                Margin = new Padding(0, 10, 0, 10),
                AutoSize = false
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

            Label lblSeatClass = new Label
            {
                Text = ticket.TicketType == 1 ? $"Hạng: {ticket.SeatClass}" : "Loại: Không sấp chỗ",
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 110),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            bool isExpired = _ticketService.IsTicketExpired(ticket);
            Label lblStatus = new Label
            {
                Text = isExpired ? "❌ Hết hạn" : "✅ Còn hiệu lực",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = isExpired ? Color.Red : Color.Green,
                Location = new Point(15, 135),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = $"Giá: {ticket.Price:N0}đ",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 160),
                AutoSize = true
            };

            Button btnViewQR = new Button
            {
                Text = "📱 Xem QR Code",
                Size = new Size(130, 35),
                Location = new Point(710, 80),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                AutoSize = false
            };
            btnViewQR.Click += (s, e) => ViewQRCode(ticket);

            Button btnDownloadQR = new Button
            {
                Text = "⬇️ Tải QR Code",
                Size = new Size(130, 35),
                Location = new Point(710, 125),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                AutoSize = false
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
            try
            {
                // Tạo QR code từ mã vé sử dụng QRCoder
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.TicketCode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                
                Bitmap qrBitmap = qrCode.GetGraphic(20);

                Form qrForm = new Form
                {
                    Text = $"QR Code - {ticket.TicketCode}",
                    Size = new Size(500, 600),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                // Panel chứa QR code
                Panel pnlQR = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 420,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pbQR = new PictureBox
                {
                    Image = qrBitmap,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Dock = DockStyle.Fill
                };
                pnlQR.Controls.Add(pbQR);

                // Label mã vé
                Label lblTicketCode = new Label
                {
                    Text = $"Mã vé: {ticket.TicketCode}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = Color.FromArgb(240, 240, 245)
                };

                // Label thông tin
                Label lblInfo = new Label
                {
                    Text = $"Concert: {ticket.ConcertName}\nNgày: {ticket.ConcertDate:dd/MM/yyyy HH:mm}\nGiá: {ticket.Price:N0}đ",
                    Font = new Font("Segoe UI", 9),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Height = 80,
                    BackColor = Color.White
                };

                qrForm.Controls.Add(pnlQR);
                qrForm.Controls.Add(lblTicketCode);
                qrForm.Controls.Add(lblInfo);
                qrForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo QR code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadQRCode(Ticket ticket)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = $"QR_{ticket.TicketCode}_{DateTime.Now:yyyyMMdd_HHmmss}.png",
                    Filter = "PNG Image (*.png)|*.png|JPG Image (*.jpg)|*.jpg"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo QR code từ mã vé sử dụng QRCoder
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.TicketCode, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    
                    Bitmap qrBitmap = qrCode.GetGraphic(20);

                    // Lưu file
                    if (saveDialog.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        qrBitmap.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        qrBitmap.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    MessageBox.Show(
                        $"Tải xuống thành công!\nĐường dẫn: {saveDialog.FileName}",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải QR code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
