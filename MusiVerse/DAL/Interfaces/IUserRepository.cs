using MusiVerse.DTO.Models;

namespace MusiVerse.DAL.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        bool Register(User user);
        bool IsUsernameExists(string username);
        bool IsEmailExists(string email);
        bool ChangePassword(int userId, string oldPass, string newPass);
        (bool, string) CheckUpgradeEligibility(int userId);
        bool UpgradeToArtist(int userId, string newRole, string bio);
        User GetUserByID(int userId);
    }
}