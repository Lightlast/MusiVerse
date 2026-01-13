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
    public partial class frmTicketsManagement : Form
    {
        private int _userID;
        private TicketService _ticketService;
        private ConcertService _concertService;
        private List<Concert> _userConcerts;

        public frmTicketsManagement(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _ticketService = new TicketService();
            _concertService = new ConcertService();
        }

        private void frmTicketsManagement_Load(object sender, EventArgs e)
        {
            this.Text = "⚙️ Quản lý vé Concert";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            LoadUserConcerts();
        }

        private void LoadUserConcerts()
        {
            try
            {
                scpConcerts.Controls.Clear();
                pnlEmpty.Visible = false;

                // Lấy danh sách concert của user (artist)
                _userConcerts = _concertService.GetArtistConcerts(_userID);

                if (_userConcerts.Count == 0)
                {
                    pnlEmpty.Visible = true;
                    scpConcerts.Visible = false;
                    return;
                }

                scpConcerts.Visible = true;
                int yPos = 0;

                foreach (var concert in _userConcerts)
                {
                    Panel concertPanel = CreateConcertManagementPanel(concert);
                    concertPanel.Location = new Point(0, yPos);
                    scpConcerts.Controls.Add(concertPanel);
                    yPos += 290;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateConcertManagementPanel(Concert concert)
        {
            Panel panel = new Panel
            {
                Size = new Size(950, 270),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 5, 0, 15),
                AutoSize = false
            };

            Label lblConcertName = new Label
            {
                Text = $"🎵 {concert.Name}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = $"📅 Ngày: {concert.ConcertDate:dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 45),
                AutoSize = true
            };

            Label lblVenue = new Label
            {
                Text = $"📍 Địa điểm: {concert.Venue}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 65),
                AutoSize = true
            };

            Label lblTicketInfo = new Label
            {
                Text = $"🎫 Vé: {concert.AvailableTickets}/{concert.TotalTickets} còn",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 85),
                AutoSize = true,
                ForeColor = concert.AvailableTickets > 0 ? Color.Green : Color.Red
            };

            Label lblPrice = new Label
            {
                Text = $"💰 Giá: {concert.Price:N0}đ",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 105),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = concert.ConcertDate < DateTime.Now ? "❌ Đã diễn ra" : "✅ Sắp diễn ra",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 130),
                ForeColor = concert.ConcertDate < DateTime.Now ? Color.Red : Color.Green,
                AutoSize = true
            };

            Button btnViewTickets = new Button
            {
                Text = "📊 Xem vé",
                Size = new Size(110, 35),
                Location = new Point(600, 45),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                AutoSize = false
            };
            btnViewTickets.Click += (s, e) => ViewConcertTickets(concert);

            Button btnEditConcert = new Button
            {
                Text = "✏️ Chỉnh sửa",
                Size = new Size(110, 35),
                Location = new Point(720, 45),
                BackColor = Color.FromArgb(255, 140, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                AutoSize = false
            };
            btnEditConcert.Click += (s, e) => EditConcert(concert);

            Button btnDeleteConcert = new Button
            {
                Text = "🗑️ Xóa",
                Size = new Size(110, 35),
                Location = new Point(840, 45),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                AutoSize = false
            };
            btnDeleteConcert.Click += (s, e) => DeleteConcert(concert);

            DataGridView dgvTickets = new DataGridView
            {
                Size = new Size(920, 100),
                Location = new Point(15, 165),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSize = false
            };

            dgvTickets.Columns.Add("TicketCode", "Mã vé");
            dgvTickets.Columns.Add("TicketType", "Loại");
            dgvTickets.Columns.Add("PurchaseDate", "Ngày mua");
            dgvTickets.Columns.Add("Status", "Trạng thái");

            var tickets = _ticketService.GetConcertTickets(concert.ConcertID);
            foreach (var ticket in tickets)
            {
                dgvTickets.Rows.Add(
                    ticket.TicketCode,
                    ticket.TicketType == 0 ? "Không sấp chỗ" : ticket.SeatClass,
                    ticket.PurchaseDate.ToString("dd/MM/yyyy"),
                    ticket.Status
                );
            }

            panel.Controls.Add(lblConcertName);
            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblVenue);
            panel.Controls.Add(lblTicketInfo);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(lblStatus);
            panel.Controls.Add(btnViewTickets);
            panel.Controls.Add(btnEditConcert);
            panel.Controls.Add(btnDeleteConcert);
            panel.Controls.Add(dgvTickets);

            return panel;
        }

        private void ViewConcertTickets(Concert concert)
        {
            try
            {
                Form ticketListForm = new Form
                {
                    Text = $"Vé - {concert.Name}",
                    Size = new Size(800, 500),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false
                };

                dgv.Columns.Add("TicketCode", "Mã vé");
                dgv.Columns.Add("TicketType", "Loại vé");
                dgv.Columns.Add("SeatClass", "Hạng/Loại");
                dgv.Columns.Add("PurchaseDate", "Ngày mua");
                dgv.Columns.Add("Status", "Trạng thái");
                dgv.Columns.Add("Price", "Giá");

                var tickets = _ticketService.GetConcertTickets(concert.ConcertID);
                foreach (var ticket in tickets)
                {
                    dgv.Rows.Add(
                        ticket.TicketCode,
                        ticket.TicketType == 0 ? "Không sấp chỗ" : "Có sấp chỗ",
                        ticket.SeatClass ?? "N/A",
                        ticket.PurchaseDate.ToString("dd/MM/yyyy"),
                        ticket.Status,
                        ticket.Price.ToString("N0")
                    );
                }

                ticketListForm.Controls.Add(dgv);
                ticketListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditConcert(Concert concert)
        {
            MessageBox.Show(
                "Chức năng chỉnh sửa concert đang được phát triển",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void DeleteConcert(Concert concert)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa concert '{concert.Name}'?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    _concertService.DeleteConcert(concert.ConcertID);
                    MessageBox.Show("Xóa concert thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserConcerts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
