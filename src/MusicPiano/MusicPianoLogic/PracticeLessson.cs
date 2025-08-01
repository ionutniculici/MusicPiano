using System.Media;

namespace MusicPianoLogic;

public class PracticeLessson : Lesson
{
    string AudioFilePath { get; set; }

    public PracticeLessson(string title, Lesson[] prerequisites, bool completed, string audioFilePath) : base(title, prerequisites, completed, false)
    {
        AudioFilePath = audioFilePath;
    }

    public PracticeLessson(string title) : this(title, [], false, string.Empty)
    {

    }

    public override void LaunchLesson()
    {
        SoundPlayer simpleSound = new SoundPlayer(AudioFilePath);
        simpleSound.Play();
    }
}
