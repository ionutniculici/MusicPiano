using System.Media;

namespace MusicPianoLogic;

public class Note
{
    /// <summary>
    /// PlayNote
    /// </summary>
    /// <param name="note"></param>
    /// <returns>Returns true if it has successfully played the note</returns>
    public bool ChooseNote(string note, out string output)
    {
        output = string.Empty;
        try
        {
            if (note.Length > 2)
            {
                throw new Exception("User input too large");
            }
            switch (note)
            {
                case "A":
                    PlayNote("A");
                    output = "Will play A";
                    break;
                case "A#":
                case "Bb":
                    PlayNote("Bb");
                    output = "Will play Bb";
                    break;
                case "B":
                    PlayNote("B");
                    output = "Will play B";
                    break;
                case "C":
                    PlayNote("C");
                    output = "Will play C";
                    break;
                case "C#":
                case "Db":
                    PlayNote("Db");
                    output = "Will play C#";
                    break;
                case "D":
                    PlayNote("D");
                    output = "Will play D";
                    break;
                case "D#":
                case "Eb":
                    PlayNote("Eb");
                    output = "Will play Eb";
                    break;
                case "E":
                    PlayNote("E");
                    output = "Will play E";
                    break;
                case "F":
                    PlayNote("F");
                    output = "Will play F";
                    break;
                case "F#":
                case "Gb":
                    PlayNote("Gb");
                    output = "Will play F#";
                    break;
                case "G":
                    PlayNote("G");
                    output = "Will play G";
                    break;
                case "G#":
                case "Ab":
                    PlayNote("Ab");
                    output = "Will play G#";
                    break;
                case "0":
                    output = "Exiting...";
                    return false;
                default:
                    output = "Not a note";
                    break;
            }
        }
        catch (Exception e)
        {
            output = e.Message;
        }
        return true;
    }

    void PlayNote(string note)
    {
        string soundPath = Path.Combine(Utils.solutionDir, "Sounds", note + ".wav");
        SoundPlayer simpleSound = new SoundPlayer(soundPath);
        simpleSound.Play();
    }
}
