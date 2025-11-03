using System;
using System.Collections.Generic;

namespace MusicPiano;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserLesson> UserLessons { get; set; } = new List<UserLesson>();
}
