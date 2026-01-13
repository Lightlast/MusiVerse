using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NAudio.Wave;
using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;

namespace MusiVerse.BLL.Utilities
{
    /// <summary>
    /// Utility class ?? c?p nh?t Duration c?a bài hát t? file audio
    /// </summary>
    public class SongDurationUpdater
    {
        private SongRepository _songRepository;
        private readonly string[] _supportedFormats = { ".mp3", ".wav", ".m4a", ".flac", ".ogg" };

        public SongDurationUpdater()
        {
            _songRepository = new SongRepository();
        }

        /// <summary>
        /// C?p nh?t Duration cho bài hát t? file audio
        /// </summary>
        public bool UpdateDurationFromFile(int songID, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"? File không t?n t?i: {filePath}");
                    return false;
                }

                int duration = GetAudioDuration(filePath);
                
                if (duration > 0)
                {
                    // C?p nh?t vào database
                    string query = "UPDATE Songs SET Duration = @Duration WHERE SongID = @SongID";
                    
                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@Duration", duration),
                        new System.Data.SqlClient.SqlParameter("@SongID", songID)
                    };

                    int result = DAL.DatabaseConnection.ExecuteNonQuery(query, parameters);
                    
                    if (result > 0)
                    {
                        Console.WriteLine($"? ?ã c?p nh?t: SongID={songID}, Duration={duration}s ({FormatDuration(duration)})");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"??  SongID={songID} không ???c c?p nh?t (không tìm th?y)");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"? Không th? l?y duration t? file: {filePath}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? L?i c?p nh?t SongID={songID}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Quét t?t c? bài hát và c?p nh?t Duration
        /// </summary>
        public void UpdateAllSongDurations()
        {
            try
            {
                Console.WriteLine("?? B?t ??u quét t?t c? bài hát...\n");

                // L?y t?t c? bài hát
                string query = "SELECT SongID, Title, FilePath, Duration FROM Songs WHERE FilePath IS NOT NULL AND FilePath != ''";
                System.Data.DataTable dt = DAL.DatabaseConnection.ExecuteQuery(query, null);

                int totalUpdated = 0;
                int totalFailed = 0;
                int totalSkipped = 0;

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    int songID = Convert.ToInt32(row["SongID"]);
                    string title = row["Title"].ToString();
                    string filePath = row["FilePath"].ToString();
                    int oldDuration = Convert.ToInt32(row["Duration"]);

                    Console.WriteLine($"\n?? ?ang x? lý: {title}");
                    Console.WriteLine($"   FilePath: {filePath}");
                    Console.WriteLine($"   Duration c?: {oldDuration}s ({FormatDuration(oldDuration)})");

                    if (UpdateDurationFromFile(songID, filePath))
                    {
                        totalUpdated++;
                    }
                    else
                    {
                        totalFailed++;
                    }
                }

                Console.WriteLine($"\n\n? HOÀN THÀNH!");
                Console.WriteLine($"?? T?ng c?p nh?t: {totalUpdated} bài hát");
                Console.WriteLine($"? L?i: {totalFailed} bài hát");
                Console.WriteLine($"??  B? qua: {totalSkipped} bài hát");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? L?i: {ex.Message}");
            }
        }

        /// <summary>
        /// L?y th?i l??ng t? file audio (tính b?ng giây)
        /// </summary>
        private int GetAudioDuration(string filePath)
        {
            try
            {
                using (var reader = new AudioFileReader(filePath))
                {
                    return (int)Math.Round(reader.TotalTime.TotalSeconds);
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Format th?i l??ng t? giây thành MM:SS
        /// </summary>
        private string FormatDuration(int seconds)
        {
            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            return $"{(int)ts.TotalMinutes}:{ts.Seconds:D2}";
        }

        /// <summary>
        /// L?y danh sách bài hát có Duration sai (Duration < 5 giây)
        /// </summary>
        public List<SongInfo> GetSongsWithInvalidDuration()
        {
            try
            {
                List<SongInfo> invalidSongs = new List<SongInfo>();

                string query = @"
                    SELECT SongID, Title, FilePath, Duration 
                    FROM Songs 
                    WHERE FilePath IS NOT NULL 
                    AND FilePath != '' 
                    AND Duration < 5";

                System.Data.DataTable dt = DAL.DatabaseConnection.ExecuteQuery(query, null);

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    invalidSongs.Add(new SongInfo
                    {
                        SongID = Convert.ToInt32(row["SongID"]),
                        Title = row["Title"].ToString(),
                        FilePath = row["FilePath"].ToString(),
                        Duration = Convert.ToInt32(row["Duration"])
                    });
                }

                return invalidSongs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? L?i: {ex.Message}");
                return new List<SongInfo>();
            }
        }

        /// <summary>
        /// Báo cáo bài hát có Duration sai
        /// </summary>
        public void ReportInvalidDurations()
        {
            var invalidSongs = GetSongsWithInvalidDuration();

            if (invalidSongs.Count == 0)
            {
                Console.WriteLine("? T?t c? bài hát ??u có Duration h?p l?!");
                return;
            }

            Console.WriteLine($"??  Tìm th?y {invalidSongs.Count} bài hát có Duration sai:\n");
            Console.WriteLine("SongID | Tiêu ?? | Duration hi?n t?i | Duration th?c t?");
            Console.WriteLine(new string('-', 80));

            foreach (var song in invalidSongs)
            {
                int actualDuration = GetAudioDuration(song.FilePath);
                Console.WriteLine($"{song.SongID,-6} | {song.Title,-30} | {song.Duration}s | {actualDuration}s");
            }
        }

        /// <summary>
        /// Class gi? thông tin bài hát
        /// </summary>
        public class SongInfo
        {
            public int SongID { get; set; }
            public string Title { get; set; }
            public string FilePath { get; set; }
            public int Duration { get; set; }
        }
    }
}
