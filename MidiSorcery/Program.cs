namespace MidiSorcery
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.



            ApplicationConfiguration.Initialize();
            try
            {
                string song = Environment.GetCommandLineArgs()[1];
                //string song = Path.Combine(Directory.GetCurrentDirectory(), "E1M1.mid");

                Application.Run(new Form1(song));

            }
            catch
            {

            }

            SongPlayer.Exit();
        }
    }
}