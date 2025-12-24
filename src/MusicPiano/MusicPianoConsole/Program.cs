// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicPianoBusinessLogic;
using MusicPianoConsole;
using MusicPianoData;
using MusicPianoLogic;
using Spectre.Console;
using System.Text;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

string connectionString = config.GetConnectionString("PianoDatabase");

var optionsBuilder = new DbContextOptionsBuilder<PianoLessonContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new PianoLessonContext(optionsBuilder.Options);

DbInitializer.InitializeDatabase(context);

User? loggedUser = null;
Repository repository = new Repository(context);
loggedUser = await ConsoleApp.LoginUser(repository);

Dictionary<int, UserLesson> lessonsStatusDict = new Dictionary<int, UserLesson>();
List<MusicPianoLogic.Lesson> lessonList = new List<MusicPianoLogic.Lesson>();

List<UserLesson>? lessonsStatus = null;
lessonsStatus = await ConsoleApp.InitLessons(repository, lessonsStatusDict, lessonList, loggedUser.Id);
ConsoleApp.PrintLessons(lessonsStatus, lessonsStatusDict);
ConsoleApp.ChooseLesson(lessonsStatus, lessonList, lessonsStatusDict, context, loggedUser.Id);


/*Note myNote = new Note();
while (true)
{
    AnsiConsole.Markup("[yellow]Please enter a note or 0 to exit.[/]\n");
    var note = Console.ReadLine();
    if (note == "0")
    {
        break;
    }
    bool result = myNote.ChooseNote(note);
    if (result)
    {
        AnsiConsole.Markup("[blue]Note played[/]\n");
    }
    else
    {
        AnsiConsole.Markup("[red]Note did not play[/]\n");
    }
}*/