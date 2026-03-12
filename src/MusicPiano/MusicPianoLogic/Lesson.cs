namespace MusicPianoLogic;

public abstract class Lesson
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Lesson[] Prerequisites { get; private set; }
    public bool IsUnlocked { get; private set; }

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
