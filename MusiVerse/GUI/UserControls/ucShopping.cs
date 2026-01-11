using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Forms.Shopping;
using MusiVerse.GUI.Utils;
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
    public partial class ucShopping : UserControl
    {
        private ConcertService _concertService;
        private TicketService _ticketService;
        private List<Concert> _allConcerts;
        private int _currentUserID;
        private string _currentUserRole;

        public ucShopping()
        {
            InitializeComponent();
            _concertService = new ConcertService();
            _ticketService = new TicketService();
            _currentUserID = SessionManager.GetCurrentUserID();
            _currentUserRole = SessionManager.CurrentUser?.Role ?? "User";
        }

        private void ucShopping_Load(object sender, EventArgs e)
        {
            LoadConcerts();
            SetupUI();
        }

        private void SetupUI()
        {
            lblTitle.Text = "🎫 MUA VÉ CONCERT";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 144, 255);

            btnMyTickets.Text = "🎫 Vé của tôi";
            btnMyTickets.BackColor = Color.FromArgb(100, 149, 237);
            btnMyTickets.FlatStyle = FlatStyle.Flat;
            btnMyTickets.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnMyTickets.Click += BtnMyTickets_Click;

            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.BackColor = Color.FromArgb(0, 150, 136);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10);
            btnRefresh.Click += (s, e) => LoadConcerts();

            // Thêm nút tạo concert cho nghệ sĩ
            if (_currentUserRole == "Artist" || _currentUserRole == "IndieArtist")
            {
                Button btnCreateConcert = new Button
                {
                    Text = "✨ Tạo Concert",
                    Size = new Size(130, 35),
                    Location = new Point(550, 22),
                    BackColor = Color.FromArgb(255, 140, 0),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnCreateConcert.Click += BtnCreateConcert_Click;
                ((Panel)this.Controls["panelTop"]).Controls.Add(btnCreateConcert);
            }
        }

        private void LoadConcerts()
        {
            try
            {
                flowLayoutPanel.Controls.Clear();

                _allConcerts = _concertService.GetAllActiveConcerts();

                if (_allConcerts.Count == 0)
                {
                    Label lblNoData = new Label
                    {
                        Text = "Hiện tại không có concert nào",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(20, 100)
                    };
                    flowLayoutPanel.Controls.Add(lblNoData);
                    return;
                }

                foreach (var concert in _allConcerts)
                {
                    ucConcertCard concertCard = new ucConcertCard();
                    concertCard.LoadConcert(concert);
                    concertCard.OnBuyClicked += (s, e) => ShowBuyingForm(concert);
                    concertCard.OnViewDetailsClicked += (s, e) => ShowConcertDetails(concert);
                    
                    flowLayoutPanel.Controls.Add(concertCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải concert: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowBuyingForm(Concert concert)
        {
            frmBuying buyingForm = new frmBuying(concert, _currentUserID);
            if (buyingForm.ShowDialog() == DialogResult.OK)
            {
                LoadConcerts(); // Reload để cập nhật số vé
                MessageBox.Show("Mua vé thành công! Vé của bạn đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowConcertDetails(Concert concert)
        {
            frmConcertDetail detailForm = new frmConcertDetail(concert);
            detailForm.ShowDialog();
        }

        private void BtnMyTickets_Click(object sender, EventArgs e)
        {
            frmMyTickets myTicketsForm = new frmMyTickets(_currentUserID);
            myTicketsForm.ShowDialog();
        }

        private void BtnCreateConcert_Click(object sender, EventArgs e)
        {
            frmCreateTicket createForm = new frmCreateTicket(_currentUserID);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadConcerts(); // Reload danh sách
                MessageBox.Show("✨ Concert tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
