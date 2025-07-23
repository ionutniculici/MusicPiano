namespace MusicPianoLogic;

public class Note
{
    /// <summary>
    /// PlayNote
    /// </summary>
    /// <param name="note"></param>
    /// <returns>Returns true if it has successfully played the note</returns>
    public bool PlayNote(string note)
    {
        switch (note)
        {
            case "A":
                Console.WriteLine("Will play A");
                break;
            case "B":
                Console.WriteLine("Will play B");
                break;
            case "C":
                Console.WriteLine("Will play C");
                break;
            case "D":
                Console.WriteLine("Will play D");
                break;
            case "E":
                Console.WriteLine("Will play E");
                break;
            case "F":
                Console.WriteLine("Will play F");
                break;
            case "G":
                Console.WriteLine("Will play G");
                break;
            case "0":
                return false;
            default:
                Console.WriteLine("Not a note");
                break;
        }
        return true;
    }
}
