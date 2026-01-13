using MusiVerse.DTO.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucAlbumItem : UserControl
    {
        // Chứa dữ liệu album
        public Album AlbumData { get; set; }

        // Tạo sự kiện để Form cha (ucMusicPage) bắt được
        public event EventHandler OnPlayClicked;
        public event EventHandler OnViewClicked;
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;

        public ucAlbumItem()
        {
            InitializeComponent();
        }

        public ucAlbumItem(Album album) : this()
        {
            AlbumData = album;
            LoadData();
        }

        // Hàm đổ dữ liệu lên giao diện
        private void LoadData()
        {
            if (AlbumData == null) return;

            lblTitle.Text = AlbumData.Title;
            lblArtist.Text = AlbumData.ArtistName;
            lblSongCount.Text = $"🎵 {AlbumData.SongCount} bài hát";
            lblReleaseDate.Text = AlbumData.ReleaseDate.ToString("MMM yyyy");

            // Load cover image
            if (!string.IsNullOrEmpty(AlbumData.CoverImage) && System.IO.File.Exists(AlbumData.CoverImage))
            {
                try
                {
                    pbCover.Image = Image.FromFile(AlbumData.CoverImage);
                }
                catch
                {
                    pbCover.Image = CreateDefaultCover();
                }
            }
            else
            {
                pbCover.Image = CreateDefaultCover();
            }
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(180, 180);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("💿", new Font("Arial", 80), Brushes.White, new PointF(25, 30));
            }
            return bmp;
        }

        // Sự kiện Click nút Play
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // ✅ Kiểm tra album có bài hát không trước khi phát
            if (AlbumData == null || AlbumData.SongCount == 0)
            {
                MessageBox.Show("Album này không có bài hát nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OnPlayClicked?.Invoke(this, EventArgs.Empty);
        }

        // Sự kiện Click nút View
        private void btnView_Click(object sender, EventArgs e)
        {
            // ✅ Kiểm tra album có bài hát không trước khi xem
            if (AlbumData == null || AlbumData.SongCount == 0)
            {
                MessageBox.Show("Album này không có bài hát nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OnViewClicked?.Invoke(this, EventArgs.Empty);
        }

        // Sự kiện Click nút Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (AlbumData == null)
            {
                MessageBox.Show("Album không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnEditClicked?.Invoke(this, EventArgs.Empty);
        }

        // Sự kiện Click nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc muốn xóa album '{AlbumData.Title}'?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OnDeleteClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        // Hiệu ứng Hover chuột
        private void ucAlbumItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 250);
        }

        private void ucAlbumItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        // Click vào cover cũng mở chi tiết
        private void pbCover_Click(object sender, EventArgs e)
        {
            OnViewClicked?.Invoke(this, EventArgs.Empty);
        }

        // Click vào title cũng mở chi tiết
        private void lblTitle_Click(object sender, EventArgs e)
        {
            OnViewClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ucAlbumItem_Load(object sender, EventArgs e)
        {
        }

        private void lblSongCount_Click(object sender, EventArgs e)
        {
        }

        private void lblReleaseDate_Click(object sender, EventArgs e)
        {
        }

        private void lblArtist_Click(object sender, EventArgs e)
        {
        }
    }
}
