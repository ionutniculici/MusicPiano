// See https://aka.ms/new-console-template for more information
using MusicPianoData;
using MusicPianoLogic;
using Spectre.Console;

#region Database Setup
using var context = new PianoLessonContext();

// Create
var lessons = new List<MusicPianoData.Lesson>
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
await context.SaveChangesAsync();

// Read
context.Lessons.ToList().ForEach(lesson =>
{
    Console.WriteLine($"Lesson ID: {lesson.Id}, Name: {lesson.Name}, Description: {lesson.Description}");
});

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

AnsiConsole.Markup("[underline yellow]Hello to the music piano![/]\n");

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