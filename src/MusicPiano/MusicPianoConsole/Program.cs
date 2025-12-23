// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using Spectre.Console;
using System.Text;

#region Database Setup
//using var context = new PianoLessonContext();

/*var users = new List<MusicPianoData.User>
{
    new User { 
        Name = "Alice", 
        Password = "1234" 
    },
    new User {
        Name = "Bob",
        Password = "5678"
    },
    new User {
        Name = "Charlie",
        Password = "1235"
    },
    new User {
        Name = "Dillan",
        Password = "4567"
    },
    new User {
        Name = "Eve",
        Password = "6789"
    }
};

context.Users.AddRange(users);
await context.SaveChangesAsync();

context.Users.ToList().ForEach(user =>
{
    Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Password: {user.Password}");
});*/

// Create
/*var lessons = new List<MusicPianoData.Lesson>
{
    new MusicPianoData.Lesson { 
        Name = "Reading", 
        Description = "How to read sheet music" 
    },
    new MusicPianoData.Lesson {
        Name = "Counting",
        Description = "How to count basic rhythms"
    },
    new MusicPianoData.Lesson {
        Name = "Chords",
        Description = "How to add chords to a melody"
    },
    new MusicPianoData.Lesson {
        Name = "Symbols",
        Description = "Learn the basic musical symbols"
    },
    new MusicPianoData.Lesson {
        Name = "Arpeggios",
        Description = "How to play arpeggios on the piano"
    }
};

context.Lessons.AddRange(lessons);
await context.SaveChangesAsync();*/

// Read
/*context.Lessons.ToList().ForEach(lesson =>
{
    Console.WriteLine($"Lesson ID: {lesson.Id}, Name: {lesson.Name}, Description: {lesson.Description}");
});*/

// Update
/*context.Lessons.Where(lesson => lesson.Name == "Reading").ToList().ForEach(lesson =>
{
    lesson.Description = "Learn to read sheet music effectively";
});
await context.SaveChangesAsync();*/

// Delete
/*context.Lessons.Where(lesson => lesson.Name == "Arpeggios").ToList().ForEach(lesson =>
{
    context.Lessons.Remove(lesson);
});
await context.SaveChangesAsync();*/

#endregion

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

string connectionString = config.GetConnectionString("PianoDatabase");

var optionsBuilder = new DbContextOptionsBuilder<PianoLessonContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new PianoLessonContext(optionsBuilder.Options);

DbInitializer.InitializeDatabase(context);

User? loggedUser;
Repository repository = new Repository(context);

while (true)
{
    AnsiConsole.Markup("[underline yellow]Hello to the music piano![/]\n");
    AnsiConsole.Markup("[yellow]Please enter your user name:[/]\n");
    var username = Console.ReadLine();
    AnsiConsole.Markup("[yellow]Please enter your password:[/]\n");
    var password = Console.ReadLine();
    
    loggedUser = await repository.LoginUser(username, password);

    if (loggedUser != null)
    {
        AnsiConsole.Clear();
        AnsiConsole.Markup($"[green]Welcome, {loggedUser.Name}! You have successfully logged in.[/]\n");
        break;
    }
    else
    {
        AnsiConsole.Clear();
        AnsiConsole.Markup("[red]Invalid username or password. Please try again.[/]\n");
    }
}

AnsiConsole.Markup("[yellow]Music Piano:[/]\n");
var lessons = await repository.GetAllLessons();
int userId = loggedUser.Id;
var lessonsStatus = await repository.GetLessonsForUser(userId);
Dictionary<int, UserLesson> lessonsStatusDict = new Dictionary<int, UserLesson>();
foreach (var lessonStatus in lessonsStatus)
{
    lessonsStatusDict[lessonStatus.IdLesson] = lessonStatus;
}
List<MusicPianoLogic.Lesson> lessonList = new List<MusicPianoLogic.Lesson>();
foreach (var lessonStatus in lessonsStatus)
{
    MusicPianoData.Lesson lesson = lessonStatus.IdLessonNavigation;
    MusicPianoLogic.Lesson newLesson;
    string color;
    if (lesson.IsTheoretical)
    {
        newLesson = new TheoryLesson(lesson.Name, lesson.Description, lesson.Questions.Split('\n'), lesson.Answers.Split('\n'), [], false, false);
    }
    else
    {
        newLesson = new PracticeLessson(lesson.Name, lesson.Description, lesson.Questions.Split('\n'), lesson.Answers.Split('\n'), [], false, false);
    }
    lessonList.Add(newLesson);
    StringBuilder lessonText = new StringBuilder();
    lessonText.Append("[[");
    if (lessonsStatusDict[lesson.Id].IsCompleted)
    {
        color = "green";
        lessonText.Append("✔");
    }
    else if (lessonsStatusDict[lesson.Id].IsUnlocked)
    {
        color = "yellow";
        lessonText.Append('■');
    }
    else
    {
        color = "grey";
        lessonText.Append(" ");
    }
    lessonText.Append("]]");
    lessonText.Append(lesson.Name);
    lessonText.Append(" - ");
    lessonText.Append(lesson.Description);
    AnsiConsole.Markup($"[{color}]{lessonText}[/]\n");
}

while (true)
{
    AnsiConsole.Markup("[yellow]Input the lesson number you want to start[/]\n");
    var lesson = Console.ReadLine();
    if (int.TryParse(lesson, out int result))
    {
        // TODO: Start lesson
        if (result >= 1 && result <= lessonList.Count)
        {
            lessonList[result - 1].LaunchLesson();
        }
        else
        {
            AnsiConsole.Markup("[red]That is not a valid lesson.[/]\n");
        }
    }
    else
    {
        AnsiConsole.Markup("[red]That is not a valid lesson.[/]\n");
    }
}


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