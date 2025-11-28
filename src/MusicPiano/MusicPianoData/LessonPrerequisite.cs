using System;
using System.Collections.Generic;

namespace MusicPianoData;

public partial class LessonPrerequisite
{
    public int IdLesson { get; set; }

    public int PrerequisiteLessonId { get; set; }

    public virtual Lesson IdLessonNavigation { get; set; } = null!;
}
