using System;
using System.Collections.Generic;

namespace MusicPianoData;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserLesson> UserLessons { get; set; } = new List<UserLesson>();
}
