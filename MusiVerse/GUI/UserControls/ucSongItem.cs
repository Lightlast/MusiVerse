using MusiVerse.DTO.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucSongItem : UserControl
    {
        // 1. Chứa dữ liệu bài hát
        public Song SongData { get; set; }

        // 2. Tạo sự kiện để Form cha (ucMusicPage) bắt được
        public event EventHandler OnPlayClicked;
        public event EventHandler OnLikeClicked;
        public event EventHandler OnMoreClicked;

        public ucSongItem()
        {
            InitializeComponent();
        }

        public ucSongItem(Song song) : this()
        {
            SongData = song;
            LoadData();
        }

        // Hàm đổ dữ liệu lên giao diện
        private void LoadData()
        {
            if (SongData == null) return;

            lblTitle.Text = SongData.Title;
            lblArtist.Text = SongData.ArtistName;
            lblDuration.Text = TimeSpan.FromSeconds(SongData.Duration).ToString(@"mm\:ss");
            lblPlayCount.Text = $"▶ {SongData.PlayCount}";
            lblGenre.Text = SongData.Genre ?? "N/A";

            // Load cover image
            if (!string.IsNullOrEmpty(SongData.CoverImage) && System.IO.File.Exists(SongData.CoverImage))
            {
                try
                {
                    pbCover.Image = Image.FromFile(SongData.CoverImage);
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

            // Update like button
            btnLike.Text = SongData.IsLiked ? "❤️" : "🤍";
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(98, 94);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("♪", new Font("Arial", 36), Brushes.White, new PointF(20, 15));
            }
            return bmp;
        }

        public void UpdateLikeStatus(bool isLiked)
        {
            if (SongData != null)
            {
                SongData.IsLiked = isLiked;
                btnLike.Text = isLiked ? "❤️" : "🤍";
            }
        }

        public void UpdatePlayCount(int count)
        {
            lblPlayCount.Text = $"▶ {count}";
        }

        // Sự kiện Click nút Play (được tạo từ Designer)
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Bắn tín hiệu ra ngoài: "Tôi bị bấm rồi!"
            OnPlayClicked?.Invoke(this, EventArgs.Empty);
        }

        // Sự kiện Click nút Like
        private void btnLike_Click(object sender, EventArgs e)
        {
            OnLikeClicked?.Invoke(this, EventArgs.Empty);
        }

        // Hiệu ứng Hover chuột (Làm cho đẹp)
        private void ucSongItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 250);
        }

        private void ucSongItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            OnMoreClicked?.Invoke(this, EventArgs.Empty);
        }

        private void lblDuration_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayCount_Click(object sender, EventArgs e)
        {

        }

        private void ucSongItem_Load(object sender, EventArgs e)
        {

        }

        private void lblGenre_Click(object sender, EventArgs e)
        {

        }
    }
}