using MusiVerse.GUI.Forms.Auth;
using MusiVerse.GUI.Forms.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusiVerse
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Use ApplicationContext for proper form lifecycle management
            ApplicationContext appContext = new ApplicationContext();
            
            frmLogin loginForm = new frmLogin();
            loginForm.FormClosed += (s, e) =>
            {
                if (loginForm.DialogResult != DialogResult.OK)
                {
                    appContext.ExitThread();
                }
            };
            
            appContext.MainForm = loginForm;
            loginForm.Show();
            
            Application.Run(appContext);
        }
    }
}
