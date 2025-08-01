// See https://aka.ms/new-console-template for more information
using MusicPianoLogic;

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