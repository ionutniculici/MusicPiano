// See https://aka.ms/new-console-template for more information
using MusicPiano;
using MusicPianoLogic;

#region Database Setup
using var context = new PianoLessonContext();

// Create
/*var customers = new List<MusicPiano.Lesson>
{
    new MusicPiano.Lesson { 
        Name = "Reading", 
        Description = "How to read sheet music" 
    },
    new MusicPiano.Lesson {
        Name = "Counting",
        Description = "How to count basic rhythms"
    },
    new MusicPiano.Lesson {
        Name = "Chords",
        Description = "How to add chords to a melody"
    },
    new MusicPiano.Lesson {
        Name = "Symbols",
        Description = "Learn the basic musical symbols"
    },
    new MusicPiano.Lesson {
        Name = "Arpeggios",
        Description = "How to play arpeggios on the piano"
    }
};

context.Lessons.AddRange(customers);
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

Console.WriteLine("Hello to the music piano!");

bool willContinue = true;
Note myNote = new Note();
while (willContinue)
{
    Console.WriteLine("Please enter a note or 0 to exit.");
    var note = Console.ReadLine();
    if (note == "0")
    {
        break;
    }
    bool result = myNote.ChooseNote(note);
    if (result)
    {
        Console.WriteLine("Note played");
    }
    else
    {
        Console.WriteLine("Note did not play");
    }
}