using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusiVerse.BLL.Services
{
    public class PlaylistService
    {
        private PlaylistRepository _playlistRepository;

        public PlaylistService()
        {
            _playlistRepository = new PlaylistRepository();
        }

        // Lấy danh sách playlist của user
        public List<Playlist> GetUserPlaylists(int userID)
        {
            return _playlistRepository.GetUserPlaylists(userID);
        }

        // Lấy chi tiết playlist
        public Playlist GetPlaylist(int playlistID)
        {
            return _playlistRepository.GetPlaylistById(playlistID);
        }

        // Lấy danh sách bài hát trong playlist
        public List<Song> GetPlaylistSongs(int playlistID)
        {
            return _playlistRepository.GetPlaylistSongs(playlistID);
        }

        // Tạo playlist mới
        public bool CreatePlaylist(string name, string description, int userID, bool isPublic = false)
        {
            Playlist playlist = new Playlist
            {
                Name = name,
                UserID = userID,
                Description = description,
                IsPublic = isPublic,
                CreatedDate = DateTime.Now
            };

            return _playlistRepository.CreatePlaylist(playlist);
        }

        // Cập nhật playlist
        public bool UpdatePlaylist(int playlistID, string name, string description = "", bool isPublic = false)
        {
            Playlist playlist = _playlistRepository.GetPlaylistById(playlistID);
            if (playlist == null) return false;

            playlist.Name = name;
            playlist.Description = description;
            playlist.IsPublic = isPublic;

            return _playlistRepository.UpdatePlaylist(playlist);
        }

        // Xóa playlist
        public bool DeletePlaylist(int playlistID)
        {
            return _playlistRepository.DeletePlaylist(playlistID);
        }

        // Thêm bài hát vào playlist
        public bool AddSongToPlaylist(int playlistID, int songID)
        {
            return _playlistRepository.AddSongToPlaylist(playlistID, songID);
        }

        // Xóa bài hát khỏi playlist
        public bool RemoveSongFromPlaylist(int playlistID, int songID)
        {
            return _playlistRepository.RemoveSongFromPlaylist(playlistID, songID);
        }

        // Thay đổi thứ tự bài hát
        public bool ReorderPlaylistSongs(int playlistID, List<int> songIDs)
        {
            return _playlistRepository.ReorderSongs(playlistID, songIDs);
        }

        public int GetPlaylistSongCount(int playlistID)
        {
            var playlist = _playlistRepository.GetPlaylistById(playlistID);
            return playlist?.SongCount ?? 0;
        }
    }
}
