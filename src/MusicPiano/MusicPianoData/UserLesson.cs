using System;
using System.Collections.Generic;

namespace MusicPianoData;

public partial class UserLesson
{
    public int IdUser { get; set; }

    public int IdLesson { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsUnlocked { get; set; }

    public virtual Lesson IdLessonNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
