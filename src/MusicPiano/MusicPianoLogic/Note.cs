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
        bool result = false;
        if (note.Length > 2)
        {
            return false;
        }
        switch (note)
        {
            case "A":
                result = PlayNote("A");
                //output = "Will play A";
                break;
            case "A#":
            case "Bb":
                result = PlayNote("Bb");
                //output = "Will play Bb";
                break;
            case "B":
                result = PlayNote("B");
                //output = "Will play B";
                break;
            case "C":
                result = PlayNote("C");
                //output = "Will play C";
                break;
            case "C#":
            case "Db":
                result = PlayNote("Db");
                //output = "Will play C#";
                break;
            case "D":
                result = PlayNote("D");
                //output = "Will play D";
                break;
            case "D#":
            case "Eb":
                result = PlayNote("Eb");
                //output = "Will play Eb";
                break;
            case "E":
                result = PlayNote("E");
                //output = "Will play E";
                break;
            case "F":
                result = PlayNote("F");
                //output = "Will play F";
                break;
            case "F#":
            case "Gb":
                result = PlayNote("Gb");
                //output = "Will play F#";
                break;
            case "G":
                result = PlayNote("G");
                //output = "Will play G";
                break;
            case "G#":
            case "Ab":
                result = PlayNote("Ab");
                //output = "Will play G#";
                break;
            default:
                //output = "Not a note";
                return false;
        }
        return result;
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
