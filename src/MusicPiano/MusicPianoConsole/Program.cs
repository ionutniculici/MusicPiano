// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using Spectre.Console;

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

using var context = new PianoLessonContext();
while (true)
{
    AnsiConsole.Markup("[underline yellow]Hello to the music piano![/]\n");
    AnsiConsole.Markup("[yellow]Please enter your user name:[/]\n");
    var username = Console.ReadLine();
    AnsiConsole.Markup("[yellow]Please enter your password:[/]\n");
    var password = Console.ReadLine();
    Repository repository = new Repository(context);
    var user = await repository.LoginUser(username, password);

    if (user != null)
    {
        AnsiConsole.Markup($"[green]Welcome, {user.Name}! You have successfully logged in.[/]\n");
        break;
    }
    else
    {
        AnsiConsole.Markup("[red]Invalid username or password. Please try again.[/]\n");
    }
}

Note myNote = new Note();
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
}