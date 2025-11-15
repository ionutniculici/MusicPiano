using System;
using System.Collections.Generic;

namespace MusicPianoData;

public partial class Lesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<LessonPrerequisite> LessonPrerequisites { get; set; } = new List<LessonPrerequisite>();

    public virtual ICollection<UserLesson> UserLessons { get; set; } = new List<UserLesson>();
}
