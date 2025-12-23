namespace MusicPianoLogic;

public abstract class Lesson
{
    protected string Title { get; set; }
    protected string? Description { get; set; }
    protected Lesson[] Prerequisites { get; set; }
    protected bool IsUnlocked { get; set; }

    public Lesson(string title, string? description, Lesson[] prerequisites, bool isCompleted, bool isUnlocked)
    {
        Title = title;
        Description = description;
        Prerequisites = prerequisites;
        IsUnlocked = isUnlocked;
    }

    public Lesson(string title) : this(title, null, [], false, false)
    {

    }

    public abstract void LaunchLesson();

    public bool CanUserUnlockLesson()
    {
        // TODO
        return true;
    }

    public bool TryUnlockLesson()
    {
        if (CanUserUnlockLesson())
        {
            IsUnlocked = true;
            return true;
        }
        return false;
    }
}
