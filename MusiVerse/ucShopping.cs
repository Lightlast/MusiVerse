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
        private List<Concert> _filteredConcerts;
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
            SetupSearchBox();
            LoadConcerts();
        }

        private void SetupUIByRole()
        {
            // Hiện nút "Tạo Concert" nếu là artist
            btnCreateTicket.Visible = (_currentUserRole == "Artist" || _currentUserRole == "IndieArtist");
            // Hiện nút "Quản lý vé" nếu là artist
            btnManageTickets.Visible = (_currentUserRole == "Artist" || _currentUserRole == "IndieArtist");
        }

        private void SetupSearchBox()
        {
            // Setup placeholder text
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Tìm kiếm vé concert...";
            
            // Subscribe to focus events cho placeholder text
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm vé concert...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Text = "Tìm kiếm vé concert...";
            }
        }

        private void LoadConcerts()
        {
            try
            {
                flowLayoutPanel.Controls.Clear();

                _allConcerts = _concertService.GetAllActiveConcerts();
                _filteredConcerts = new List<Concert>(_allConcerts);

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

                DisplayConcerts(_filteredConcerts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải concert: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayConcerts(List<Concert> concerts)
        {
            flowLayoutPanel.Controls.Clear();

            if (concerts.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "Không tìm thấy concert nào phù hợp",
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(20, 100)
                };
                flowLayoutPanel.Controls.Add(lblNoData);
                return;
            }

            foreach (var concert in concerts)
            {
                ucConcertCard concertCard = new ucConcertCard();
                concertCard.LoadConcert(concert);
                concertCard.OnBuyClicked += (s, e) => ShowBuyingForm(concert);
                concertCard.OnViewDetailsClicked += (s, e) => ShowConcertDetails(concert);

                flowLayoutPanel.Controls.Add(concertCard);
            }
        }

        private void FilterConcerts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword) || keyword == "Tìm kiếm vé concert...")
            {
                _filteredConcerts = new List<Concert>(_allConcerts);
            }
            else
            {
                // Tìm kiếm theo tên concert, địa điểm, hoặc tên nghệ sĩ
                keyword = keyword.ToLower();
                _filteredConcerts = _allConcerts.Where(c =>
                    c.Name.ToLower().Contains(keyword) ||
                    c.Venue.ToLower().Contains(keyword) ||
                    c.ArtistName.ToLower().Contains(keyword) ||
                    c.Description.ToLower().Contains(keyword)
                ).ToList();
            }

            DisplayConcerts(_filteredConcerts);
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
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Tìm kiếm vé concert...";
            LoadConcerts();
        }

        private void btnManageTickets_Click(object sender, EventArgs e)
        {
            frmTicketsManagement managementForm = new frmTicketsManagement(_currentUserID);
            managementForm.ShowDialog();
            LoadConcerts(); // Reload danh sách concert sau khi quay lại
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex > 0)
            {
                string sortOption = cmbSort.SelectedItem.ToString();
                SortConcerts(sortOption);
            }
        }

        private void SortConcerts(string sortBy)
        {
            try
            {
                // Sắp xếp danh sách vé đã lọc hiện tại
                switch (sortBy)
                {
                    case "Mới nhất":
                        _filteredConcerts.Sort((a, b) => b.ConcertDate.CompareTo(a.ConcertDate));
                        break;
                    case "Cũ nhất":
                        _filteredConcerts.Sort((a, b) => a.ConcertDate.CompareTo(b.ConcertDate));
                        break;
                    case "Phổ biến":
                        // Sắp xếp theo số vé còn lại (càng ít vé còn lại = càng phổ biến)
                        _filteredConcerts.Sort((a, b) => a.AvailableTickets.CompareTo(b.AvailableTickets));
                        break;
                    default:
                        _filteredConcerts.Sort((a, b) => b.ConcertDate.CompareTo(a.ConcertDate));
                        break;
                }

                // Hiển thị lại danh sách đã sắp xếp
                DisplayConcerts(_filteredConcerts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sắp xếp concert: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua nếu là placeholder text
            if (txtSearch.Text == "Tìm kiếm vé concert..." || txtSearch.ForeColor == Color.Gray)
            {
                return;
            }

            // Thực hiện tìm kiếm real-time
            FilterConcerts(txtSearch.Text);
        }
    }
}
