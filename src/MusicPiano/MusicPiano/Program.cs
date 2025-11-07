// See https://aka.ms/new-console-template for more information
using MusicPianoLogic;
using Spectre.Console;

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