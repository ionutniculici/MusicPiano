using Microsoft.EntityFrameworkCore;
using MusicPianoData;
using System.Configuration;

namespace MusicPianoForms
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
            InitializeDatabase();
            Application.Run(new PianoApp());
        }

        static void InitializeDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PianoDatabase"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<PianoLessonContext>();
            optionsBuilder.UseSqlServer(connectionString);
            using var context = new PianoLessonContext(optionsBuilder.Options);
            DbInitializer.InitializeDatabase(context);
        }
    }
}