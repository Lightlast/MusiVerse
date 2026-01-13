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
            SetupUIByRole();
            LoadConcerts();
        }

        private void SetupUIByRole()
        {
            // Hiện nút "Tạo Concert" nếu là artist
            btnCreateTicket.Visible = (_currentUserRole == "Artist" || _currentUserRole == "IndieArtist");
            // Hiện nút "Quản lý vé" nếu là artist
            btnManageTickets.Visible = (_currentUserRole == "Artist" || _currentUserRole == "IndieArtist");
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

        private void btnMyTickets_Click(object sender, EventArgs e)
        {
            frmMyTickets myTicketsForm = new frmMyTickets(_currentUserID);
            myTicketsForm.ShowDialog();
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            frmCreateTicket createForm = new frmCreateTicket(_currentUserID);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadConcerts(); // Reload danh sách
                MessageBox.Show("✨ Concert tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadConcerts();
        }

        private void btnManageTickets_Click(object sender, EventArgs e)
        {
            frmTicketsManagement managementForm = new frmTicketsManagement(_currentUserID);
            managementForm.ShowDialog();
            LoadConcerts(); // Reload danh sách concert sau khi quay lại
        }
    }
}
