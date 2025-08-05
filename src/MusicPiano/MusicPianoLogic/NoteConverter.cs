namespace MusicPianoLogic;

public static class NoteConverter
{
    static Dictionary<string, string> sameNotes = new Dictionary<string, string>
    {
        { "A#", "Bb" },
        { "C#", "Db" },
        { "D#", "Eb" },
        { "F#", "Gb" },
        { "G#", "Ab" },
    };

    public static string ConvertNote(string note)
    {
        if (sameNotes.ContainsKey(note))
        {
            return sameNotes[note];
        }
        else
        {
            return note;
        }
    }
}
