using System;
using System.Collections.Generic;

namespace MusicPiano;

public partial class LessonNew
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? UnlocksLessonId { get; set; }

    public virtual ICollection<UserLesson> UserLessons { get; set; } = new List<UserLesson>();
}
