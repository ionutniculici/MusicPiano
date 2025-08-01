namespace MusicPianoLogic;

public class TheoryLesson : Lesson
{
    string Content { get; set; }

    public TheoryLesson(string title, Lesson[] prerequisites, bool completed, string content)
    {
        Title = title;
        Prerequisites = prerequisites;
        IsCompleted = completed;
        Content = content;
    }

    public override void LaunchLesson()
    {
        Console.WriteLine(Content);
    }
}
