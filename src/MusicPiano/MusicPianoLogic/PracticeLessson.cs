using System.Media;

namespace MusicPianoLogic;

public class PracticeLessson : Lesson
{
    string AudioFilePath { get; set; }

    public PracticeLessson(string title, Lesson[] prerequisites, bool completed, string audioFilePath)
    {
        Title = title;
        Prerequisites = prerequisites;
        IsCompleted = completed;
        AudioFilePath = audioFilePath;
    }

    public override void LaunchLesson()
    {
        SoundPlayer simpleSound = new SoundPlayer(AudioFilePath);
        simpleSound.Play();
    }
}
