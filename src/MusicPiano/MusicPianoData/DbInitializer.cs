namespace MusicPianoData;

public static class DbInitializer
{
    public static void InitializeDatabase(PianoLessonContext context)
    {
        context.Database.EnsureCreated();

        var expectedLessons = new Lesson[]
            {
                new Lesson { Name = "Lesson 1", Description = "Keyboard introduction", Questions = "The black keys are arranged in groups of 2 and groups of ...?\nThe white note immediately to the left of the two black keys is called?", Answers = "3\nc", IsTheoretical = true },
                new Lesson { Name = "Lesson 2", Description = "The Staff & Clefs", Questions = "Which clef is usually used for higher notes (Right Hand)?\nHow many lines make up a standard music staff?", Answers = "treble clef\n5", IsTheoretical = true },
                new Lesson { Name = "Lesson 3", Description = "Practice 1", Questions = "C\nD", Answers = "c\nd", IsTheoretical = false },
                new Lesson { Name = "Lesson 4", Description = "Finger Numbering & Basic Rhythm", Questions = "In piano numbering, what number represents the Thumb?\nHow many beats does a Quarter Note usually get?\nHow many beats does a Whole Note usually get?", Answers = "1\n1\n4", IsTheoretical = true },
                new Lesson { Name = "Lesson 5", Description = "The Grand Staff", Questions = "Which clef is usually used for lower notes (Left Hand)?\nWhat connects the Treble and Bass staves to form the Grand Staff?\nIn 4/4 time, what does the top number represent?", Answers = "bass clef\nbrace\nbeats per measure", IsTheoretical = true },
                new Lesson { Name = "Lesson 6", Description = "Practice 2", Questions = "E\nD\nDb", Answers = "e\nd\nc#", IsTheoretical = false },
                new Lesson { Name = "Lesson 7", Description = "Rests & Dynamics", Questions = "What is the symbol for silence in music called?\nWhat does the dynamic marking \"p\" (piano) mean?\nWhat does the dynamic marking \"f\" (forte) mean?\nWhich rests hangs below the 4th line (looks like a hole)?", Answers = "rest\nsoft\nloud\nwhole rest", IsTheoretical = true },
                new Lesson { Name = "Lesson 8", Description = "Sharps, Flats & Steps", Questions = "What symbol raises a note by one half-step?\nWhat symbol lowers a note by one half-step?\nWhat is the distance from one key to the very next key (black or white)?\nWhat is the distance of two half steps combined?", Answers = "sharp\nflat\nhalf step\nwhole step", IsTheoretical = true },
                new Lesson { Name = "Lesson 9", Description = "Practice 3", Questions = "F\nG\nEb\nAb", Answers = "f\ng\neb\nab", IsTheoretical = false },
                new Lesson { Name = "Lesson 10", Description = "Final Practice", Questions = "C\nE\nGb\nB\nEb", Answers = "c\ne\nf#\nb\neb", IsTheoretical = false },
            };

        var expectedPrerequisites = new LessonPrerequisite[]
        {
            new LessonPrerequisite{
                IdLesson = 2,
                PrerequisiteLessonId = 1
            },
            new LessonPrerequisite{
                IdLesson = 3,
                PrerequisiteLessonId = 2
            },
            new LessonPrerequisite{
                IdLesson = 4,
                PrerequisiteLessonId = 3
            },
            new LessonPrerequisite{
                IdLesson = 5,
                PrerequisiteLessonId = 4
            },
            new LessonPrerequisite{
                IdLesson = 6,
                PrerequisiteLessonId = 5
            },
            new LessonPrerequisite{
                IdLesson = 7,
                PrerequisiteLessonId = 6
            },
            new LessonPrerequisite{
                IdLesson = 8,
                PrerequisiteLessonId = 7
            },
            new LessonPrerequisite{
                IdLesson = 9,
                PrerequisiteLessonId = 8
            },
            new LessonPrerequisite{
                IdLesson = 10,
                PrerequisiteLessonId = 9
            },
        };

        foreach (var lesson in expectedLessons)
        {
            var existingLesson = context.Lessons.SingleOrDefault(l => l.Name == lesson.Name);
            if (existingLesson == null)
            {
                context.Lessons.Add(lesson);
            }
            else
            {
                if (lesson.Description != existingLesson.Description ||
                    lesson.Questions != existingLesson.Questions ||
                    lesson.Answers != existingLesson.Answers ||
                    lesson.IsTheoretical != existingLesson.IsTheoretical)
                {
                    existingLesson.Description = lesson.Description;
                    existingLesson.Questions = lesson.Questions;
                    existingLesson.Answers = lesson.Answers;
                    existingLesson.IsTheoretical = lesson.IsTheoretical;
                }
            }

            var allowedNames = expectedLessons.Select(x => x.Name).ToList();
            var unwantedLessons = context.Lessons
                .Where(l => !allowedNames.Contains(l.Name))
                .ToList();
            if (unwantedLessons.Any())
            {
                context.Lessons.RemoveRange(unwantedLessons);
            }
        }

        foreach (var prerequisite in expectedPrerequisites)
        {
            var existingPrerequisite = context.LessonPrerequisites.SingleOrDefault(lp =>
                lp.IdLesson == prerequisite.IdLesson &&
                lp.PrerequisiteLessonId == prerequisite.PrerequisiteLessonId);
            if (existingPrerequisite == null)
            {
                context.LessonPrerequisites.Add(prerequisite);
            }
            var allExistingPrerequisites = context.LessonPrerequisites.ToList();
            var unwantedLessonPrerequisites = allExistingPrerequisites
                .Where(lp => !expectedPrerequisites.Any(expected =>
                    expected.IdLesson == lp.IdLesson &&
                    expected.PrerequisiteLessonId == lp.PrerequisiteLessonId))
                .ToList();
            if (unwantedLessonPrerequisites.Any())
            {
                context.LessonPrerequisites.RemoveRange(unwantedLessonPrerequisites);
            }
        }

        if (!context.Users.Any())
        {
            var newUser = new User
            {
                Name = "Test",
                Password = "test",
            };

            context.Users.Add(newUser);
            
        }
        else if (context.Users.FirstOrDefault(u => u.Name == "Test") == null)
        {
            var newUser = new User
            {
                Name = "Test",
                Password = "test",
            };
            context.Users.Add(newUser);
        }

        context.SaveChanges();

        var testUser = context.Users.FirstOrDefault(u => u.Name == "Test");
        if (testUser != null)
        {
            int userId = testUser.Id;

            var expectedCompletions = new UserLesson[]
            {
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 1,
                    IsCompleted = false,
                    IsUnlocked = true,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 2,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 3,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 4,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 5,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 6,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 7,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 8,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 9,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
                new UserLesson {
                    IdUser = userId,
                    IdLesson = 10,
                    IsCompleted = false,
                    IsUnlocked = false,
                },
            };

            foreach (var completion in expectedCompletions)
            {
                var existingCompletion = context.UserLessons.SingleOrDefault(c => c.IdUser == completion.IdUser
                    && c.IdLesson == completion.IdLesson);
                if (existingCompletion == null)
                {
                    context.UserLessons.Add(completion);
                }
            }

            context.SaveChanges();
        }
    }
}
