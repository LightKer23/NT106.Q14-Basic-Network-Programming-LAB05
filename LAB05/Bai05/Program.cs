using Bai05.Services;
using System.Windows.Forms;

namespace Bai05
{
    internal static class Program
    {
        public static ApiClient apiCli { get; set; } = null!;
        public static AuthService authSer { get; set; } = null!;
        public static FoodService foodSer { get; set; } = null!;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            apiCli = new ApiClient(); ;
            authSer = new AuthService(apiCli);
            foodSer = new FoodService(apiCli);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}