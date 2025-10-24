using System.Media;

namespace MusicPianoLogic;

public class Note
{
    /// <summary>
    /// PlayNote
    /// </summary>
    /// <param name="note"></param>
    /// <returns>Returns true if it has successfully played the note</returns>
    public bool ChooseNote(string note)
    {
        if (note.Length > 2)
        {
            return false;
        }
        return PlayNote(NoteConverter.ConvertNote(note));     
    }

    bool PlayNote(string note)
    {
        string soundPath = Path.Combine(Utils.SolutionDir, "Sounds", note + ".wav");
        if (!File.Exists(soundPath))
        {
            return false;
        }
        SoundPlayer simpleSound = new SoundPlayer(soundPath);
        simpleSound.Play();
        return true;
    }
}
