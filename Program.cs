namespace ExamenModuloC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public const string CONNECTION_STRING = "server = DESKTOP-HUSJS3N; database = prod; integrated security = true";

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            new Start.Starter().start();
            Application.Run(new View.Form1());
        }
    }
}