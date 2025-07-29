// See https://aka.ms/new-console-template for more information
using MusicPianoLogic;

Console.WriteLine("Hello to the music piano!");

bool willContinue = true;
Note myNote = new Note();
while (willContinue)
{
    Console.WriteLine("Please enter a note or 0 to exit.");
    var note = Console.ReadLine();
    string output;
    willContinue = myNote.ChooseNote(note, out output);
    Console.WriteLine(output);
}