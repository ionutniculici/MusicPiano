using System.Media;

namespace MusicPianoLogic;

public class PracticeLessson : Lesson
{
    string[] AudioFiles { get; set; }
    string[] Answers { get; set; }

    public PracticeLessson(string title, string? description, string[] audioFiles, string[] answers, Lesson[] prerequisites, bool isCompleted, bool isUnlocked) : base(title, description, prerequisites, isCompleted, false)
    {
        AudioFiles = audioFiles;
        Answers = answers;
    }

    public PracticeLessson(string title) : this(title, null, [], [], [], false, false)
    {

    }

    public override void LaunchLesson()
    {
        //SoundPlayer simpleSound = new SoundPlayer(AudioFilePath);
        //simpleSound.Play();
    }
}
