namespace MusicPianoLogic;

public class TheoryLesson : Lesson
{
    string Content { get; set; }

    public TheoryLesson(string title, Lesson[] prerequisites, bool completed, string content) : base(title, prerequisites, completed, false)
    {
        Content = content;
    }

    public TheoryLesson(string title) : this(title, [], false, string.Empty)
    {

    }

    public override void LaunchLesson()
    {
        Console.WriteLine(Content);
    }
}
