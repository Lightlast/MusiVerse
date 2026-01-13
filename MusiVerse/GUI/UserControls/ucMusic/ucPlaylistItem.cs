using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucPlaylistItem : UserControl
    {
        public Playlist PlaylistData { get; set; }

        public event EventHandler OnPlayClicked;
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;
        public event EventHandler<Playlist> OnPlaylistSelected; // Event m?i khi click vào playlist

        public ucPlaylistItem()
        {
            InitializeComponent();
        }

        public ucPlaylistItem(Playlist playlist) : this()
        {
            PlaylistData = playlist;
            LoadData();
        }

        private void LoadData()
        {
            if (PlaylistData == null) return;

            lblPlaylistName.Text = PlaylistData.Name;
            lblSongCount.Text = $"{PlaylistData.SongCount} songs";
            lblDescription.Text = PlaylistData.Description ?? "No description";
            lblCreatedDate.Text = $"Created: {PlaylistData.CreatedDate:MMM dd, yyyy}";
            lblVisibility.Text = PlaylistData.IsPublic ? "?? Public" : "?? Private";

            // Load cover image from first song in playlist if available
            LoadPlaylistCover();
        }

        private void LoadPlaylistCover()
        {
            try
            {
                // Try to load first song's cover from playlist
                var playlistService = new PlaylistService();
                var playlistSongs = playlistService.GetPlaylistSongs(PlaylistData.PlaylistID);

                if (playlistSongs.Count > 0 && !string.IsNullOrEmpty(playlistSongs[0].CoverImage) 
                    && System.IO.File.Exists(playlistSongs[0].CoverImage))
                {
                    pbCover.Image = Image.FromFile(playlistSongs[0].CoverImage);
                }
                else if (!string.IsNullOrEmpty(PlaylistData.CoverImage) && System.IO.File.Exists(PlaylistData.CoverImage))
                {
                    pbCover.Image = Image.FromFile(PlaylistData.CoverImage);
                }
                else
                {
                    pbCover.Image = CreateDefaultCover();
                }
            }
            catch
            {
                // If any error, use default cover
                if (!string.IsNullOrEmpty(PlaylistData.CoverImage) && System.IO.File.Exists(PlaylistData.CoverImage))
                {
                    try
                    {
                        pbCover.Image = Image.FromFile(PlaylistData.CoverImage);
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
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("?", new Font("Arial", 48), Brushes.White, new PointF(20, 20));
            }
            return bmp;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnPlayClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this playlist?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OnDeleteClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ucPlaylistItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 250);
        }

        private void ucPlaylistItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void pbCover_Click(object sender, EventArgs e)
        {
            OnPlaylistSelected?.Invoke(this, PlaylistData);
        }

        private void ucPlaylistItem_Load(object sender, EventArgs e)
        {
        }

        public void OnPlaylistTitleClicked()
        {
            OnPlaylistSelected?.Invoke(this, PlaylistData);
        }
    }
}
