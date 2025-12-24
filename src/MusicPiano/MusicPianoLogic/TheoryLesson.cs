namespace MusicPianoLogic;

public class TheoryLesson : Lesson
{
    public string[] Questions { get; private set; }
    public string[] Answers { get; private set; }

    public TheoryLesson(string title, string? description, string[] questions, string[] answers, Lesson[] prerequisites, bool isCompleted, bool isUnlocked) : base(title, description, prerequisites, isCompleted, false)
    {
        Questions = questions;
        Answers = answers;
    }

    public TheoryLesson(string title) : this(title, null, [], [], [], false, false)
    {

    }

    public override void LaunchLesson()
    {
        
    }
}
