using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;

namespace MusiVerse.BLL.Services
{
    public class ConcertService
    {
        private readonly ConcertRepository _concertRepository;

        public ConcertService()
        {
            _concertRepository = new ConcertRepository();
        }

        // Lấy tất cả concert còn hiệu lực
        public List<Concert> GetAllActiveConcerts()
        {
            try
            {
                return _concertRepository.GetAllActiveConcerts();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting active concerts: " + ex.Message);
            }
        }

        // Lấy concert theo ID
        public Concert GetConcertById(int concertID)
        {
            try
            {
                var concert = _concertRepository.GetConcertById(concertID);
                if (concert == null)
                    throw new Exception("Concert not found");
                return concert;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting concert: " + ex.Message);
            }
        }

        // Lấy concert của một nghệ sĩ
        public List<Concert> GetConcertsByArtist(int artistID)
        {
            try
            {
                return _concertRepository.GetConcertsByArtist(artistID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting artist concerts: " + ex.Message);
            }
        }

        // Alias cho GetConcertsByArtist
        public List<Concert> GetArtistConcerts(int artistID)
        {
            return GetConcertsByArtist(artistID);
        }

        // Thêm concert mới (chỉ dành cho artist)
        public int CreateConcert(Concert concert)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(concert.Name))
                    throw new Exception("Concert name is required");
                if (string.IsNullOrWhiteSpace(concert.Venue))
                    throw new Exception("Venue is required");
                if (concert.ConcertDate <= DateTime.Now)
                    throw new Exception("Concert date must be in the future");
                if (concert.TotalTickets <= 0)
                    throw new Exception("Total tickets must be greater than 0");
                if (concert.Price < 0)
                    throw new Exception("Price cannot be negative");

                concert.IsActive = true;
                concert.AvailableTickets = concert.TotalTickets;
                concert.CreatedDate = DateTime.Now;

                return _concertRepository.AddConcert(concert);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating concert: " + ex.Message);
            }
        }

        // Cập nhật concert
        public bool UpdateConcert(Concert concert)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(concert.Name))
                    throw new Exception("Concert name is required");
                if (string.IsNullOrWhiteSpace(concert.Venue))
                    throw new Exception("Venue is required");
                if (concert.ConcertDate <= DateTime.Now)
                    throw new Exception("Concert date must be in the future");
                if (concert.TotalTickets <= 0)
                    throw new Exception("Total tickets must be greater than 0");
                if (concert.Price < 0)
                    throw new Exception("Price cannot be negative");

                return _concertRepository.UpdateConcert(concert);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating concert: " + ex.Message);
            }
        }

        // Xóa concert
        public bool DeleteConcert(int concertID)
        {
            try
            {
                return _concertRepository.DeleteConcert(concertID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting concert: " + ex.Message);
            }
        }
    }
}
