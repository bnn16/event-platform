using event_platform_classLibrary;

namespace event_platform_backendwinform
{
    internal static class Program
    {
        private static DBController _dbController;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _dbController = new DBController();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(_dbController));
        }
    }
}