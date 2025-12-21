using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusiVerse.DTO.Models;

namespace MusiVerse.GUI.Utils
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static int GetCurrentUserID()
        {
            return CurrentUser?.UserID ?? 0;
        }

        public static string GetCurrentUsername()
        {
            return CurrentUser?.Username ?? "Guest";
        }

        public static string GetCurrentUserAvatar()
        {
            return CurrentUser?.Avatar ?? string.Empty;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public static bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "Admin";
        }

        public static bool IsArtist()
        {
            return CurrentUser != null &&
                   (CurrentUser.Role == "Artist" || CurrentUser.Role == "IndieArtist");
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static void UpdateCurrentUser(User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }
            CurrentUser = updatedUser;
        }
    }
}
