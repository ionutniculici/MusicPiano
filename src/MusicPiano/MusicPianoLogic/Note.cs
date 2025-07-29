using System.Media;

namespace MusicPianoLogic;

public class Note
{
    string solutionDir;

    public Note()
    {
        solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    }

    /// <summary>
    /// PlayNote
    /// </summary>
    /// <param name="note"></param>
    /// <returns>Returns true if it has successfully played the note</returns>
    public bool ChooseNote(string note)
    {
        switch (note)
        {
            case "A":
                PlayNote("A");
                Console.WriteLine("Will play A");
                break;
            case "A#":
            case "Bb":
                PlayNote("Bb");
                Console.WriteLine("Will play Bb");
                break;
            case "B":
                PlayNote("B");
                Console.WriteLine("Will play B");
                break;
            case "C":
                PlayNote("C");
                Console.WriteLine("Will play C");
                break;
            case "C#":
            case "Db":
                PlayNote("Db");
                Console.WriteLine("Will play C#");
                break;
            case "D":
                PlayNote("D");
                Console.WriteLine("Will play D");
                break;
            case "D#":
            case "Eb":
                PlayNote("Eb");
                Console.WriteLine("Will play Eb");
                break;
            case "E":
                PlayNote("E");
                Console.WriteLine("Will play E");
                break;
            case "F":
                PlayNote("F");
                Console.WriteLine("Will play F");
                break;
            case "F#":
            case "Gb":
                PlayNote("Gb");
                Console.WriteLine("Will play F#");
                break;
            case "G":
                PlayNote("G");
                Console.WriteLine("Will play G");
                break;
            case "G#":
            case "Ab":
                PlayNote("Ab");
                Console.WriteLine("Will play G#");
                break;
            case "0":
                return false;
            default:
                Console.WriteLine("Not a note");
                break;
        }
        return true;
    }

    void PlayNote(string note)
    {
        string soundPath = Path.Combine(solutionDir, "Sounds", note + ".wav");
        SoundPlayer simpleSound = new SoundPlayer(soundPath);
        simpleSound.Play();
    }
}
