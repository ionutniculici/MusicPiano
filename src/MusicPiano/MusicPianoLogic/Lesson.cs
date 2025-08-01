namespace MusicPianoLogic;

public abstract class Lesson
{
    protected string Title { get; set; }
    protected Lesson[] Prerequisites { get; set; }
    protected bool IsCompleted { get; set; }
    protected bool IsUnlocked { get; set; }

    public Lesson(string title, Lesson[] prerequisites, bool isCompleted, bool isUnlocked)
    {
        Title = title;
        Prerequisites = prerequisites;
        IsCompleted = isCompleted;
        IsUnlocked = isUnlocked;
    }

    public Lesson(string title) : this(title, [], false, false)
    {

    }

    public void CompleteLesson()
    {
        IsCompleted = true;
    }

    public abstract void LaunchLesson();

    public bool CanLessonBeUnlocked()
    {
        foreach (var lesson in Prerequisites)
        {
            if (!lesson.IsCompleted)
            {
                return false;
            }
        }
        return true;
    }

    public void UnlockLesson()
    {
        if (CanLessonBeUnlocked())
        {
            IsUnlocked = true;
        }
    }
}
