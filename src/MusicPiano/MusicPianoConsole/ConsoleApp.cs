using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using Spectre.Console;
using System.Text;

namespace MusicPianoConsole;

internal class ConsoleApp
{
    public static async Task<User?> LoginUser(Repository repository)
    {
        while (true)
        {
            AnsiConsole.Markup("[underline yellow]Hello to the music piano![/]\n");
            AnsiConsole.Markup("[yellow]Please enter your user name:[/]\n");
            var username = Console.ReadLine();
            AnsiConsole.Markup("[yellow]Please enter your password:[/]\n");
            var password = Console.ReadLine();

            User? user = await repository.LoginUser(username, password);

            if (user != null)
            {
                AnsiConsole.Clear();
                AnsiConsole.Markup($"[green]Welcome, {user.Name}! You have successfully logged in.[/]\n");
                return user;
            }
            else
            {
                AnsiConsole.Clear();
                AnsiConsole.Markup("[red]Invalid username or password. Please try again.[/]\n");
            }
        }
    }

    public static async Task<List<UserLesson>> InitLessons(Repository repository, Dictionary<int, UserLesson> lessonsStatusDict, List<MusicPianoLogic.Lesson> lessonList, int userId)
    {
        var lessonsStatus = await repository.GetLessonsForUser(userId);
        foreach (var lessonStatus in lessonsStatus)
        {
            lessonsStatusDict[lessonStatus.IdLesson] = lessonStatus;
            MusicPianoData.Lesson lesson = lessonStatus.IdLessonNavigation;
            MusicPianoLogic.Lesson newLesson;
            if (lesson.IsTheoretical)
            {
                newLesson = new TheoryLesson(lesson.Name, lesson.Description, lesson.Questions.Split('\n'), lesson.Answers.Split('\n'), [], false, false);
            }
            else
            {
                newLesson = new PracticeLessson(lesson.Name, lesson.Description, lesson.Questions.Split('\n'), lesson.Answers.Split('\n'), [], false, false);
            }
            lessonList.Add(newLesson);
        }
        return lessonsStatus;
    }

    public static void PrintLessons(List<UserLesson> lessonsStatus, Dictionary<int, UserLesson> lessonsStatusDict)
    {
        AnsiConsole.Markup("[yellow]Music Piano:[/]\n");
        int completedLessons = lessonsStatus
                            .Where(ul => ul.IsCompleted)
                            .Count();
        if (completedLessons > 8)
        {
            AnsiConsole.Markup("[yellow]Advanced ***[/]\n");
        }
        else if (completedLessons > 5)
        {
            AnsiConsole.Markup("[yellow]Intermediate **[/]\n");
        }
        else if (completedLessons > 2)
        {
            AnsiConsole.Markup("[yellow]Beginner *[/]\n");
        }
        foreach (var lessonStatus in lessonsStatus)
        {
            MusicPianoData.Lesson lesson = lessonStatus.IdLessonNavigation;
            string color;
            StringBuilder lessonText = new StringBuilder();
            lessonText.Append("[[");
            if (lessonsStatusDict[lesson.Id].IsCompleted)
            {
                color = "green";
                lessonText.Append("✓");
            }
            else if (lessonsStatusDict[lesson.Id].IsUnlocked)
            {
                color = "yellow";
                lessonText.Append('■');
            }
            else
            {
                color = "grey";
                lessonText.Append(" ");
            }
            lessonText.Append("]]");
            lessonText.Append(lesson.Name);
            lessonText.Append(" - ");
            lessonText.Append(lesson.Description);
            AnsiConsole.Markup($"[{color}]{lessonText}[/]\n");
        }
    }

    public static void ChooseLesson(List<UserLesson> lessonsStatus, List<MusicPianoLogic.Lesson> lessonList, Dictionary<int, UserLesson> lessonsStatusDict, PianoLessonContext context, int userId)
    {
        while (true)
        {
            AnsiConsole.Markup("[yellow]Input the lesson number you want to start[/]\n");
            var lesson = Console.ReadLine();
            if (lesson.Equals("resetALL"))
            {
                ResetALLProgressForUser(lessonsStatus, context, userId);
                AnsiConsole.Clear();
                PrintLessons(lessonsStatus, lessonsStatusDict);
                continue;
            }
            if (int.TryParse(lesson, out int result))
            {
                if (result >= 1 && result <= lessonList.Count)
                {
                    if (lessonsStatusDict[result].IsUnlocked)
                    {
                        AnsiConsole.Clear();
                        bool complete = StartLesson(lessonList[result - 1], lessonsStatusDict[result].IdLessonNavigation.IsTheoretical);
                        if (complete)
                        {
                            MarkLessonAsComplete(lessonsStatus, context, userId, result);
                        }
                        PrintLessons(lessonsStatus, lessonsStatusDict);
                    }
                    else
                    {
                        AnsiConsole.Markup("[red]You have not yet unlocked this lesson.[/]\n");
                    }
                }
                else
                {
                    AnsiConsole.Markup("[red]That is not a valid lesson.[/]\n");
                }
            }
            else
            {
                AnsiConsole.Markup("[red]That is not a valid lesson.[/]\n");
            }
        }
    }

    public static bool StartLesson(MusicPianoLogic.Lesson lesson, bool isTheory)
    {
        if (isTheory)
        {
            return StartTheoryLesson((TheoryLesson)lesson);
        }
        else
        {
            return StartPracticeLesson((PracticeLessson)lesson);
        }
    }

    public static bool StartTheoryLesson(TheoryLesson lesson)
    {
        AnsiConsole.Markup($"[yellow]{lesson.Title} - {lesson.Description}[/]\n");
        for (int i = 0; i < lesson.Questions.Length; i++)
        {
            AnsiConsole.Markup($"[yellow]{lesson.Questions[i]}[/]\n");
            while (true)
            {
                AnsiConsole.Markup("[yellow]Your answer:[/] ");
                var answer = Console.ReadLine();
                if (answer.Equals("back"))
                {
                    AnsiConsole.Clear();
                    return false;
                }
                if (answer.Contains(lesson.Answers[i]))
                {
                    AnsiConsole.Markup("[green]Correct![/]\n");
                    break;
                }
                else
                {
                    AnsiConsole.Markup("[red]Wrong answer, try again.[/]\n");
                }
            }
        }
        AnsiConsole.Markup("[yellow]You have completed this lesson! Press any key to continue...[/]\n");
        Console.ReadKey();
        AnsiConsole.Clear();
        return true;
    }

    public static bool StartPracticeLesson(PracticeLessson lesson)
    {
        AnsiConsole.Markup($"[yellow]{lesson.Title} - {lesson.Description}[/]\n");
        AnsiConsole.Markup("[yellow]Input the notes you hear[/]\n");
        Note myNote = new Note();
        for (int i = 0; i < lesson.AudioFiles.Length; i++)
        {
            myNote.ChooseNote(lesson.AudioFiles[i]);
            while (true)
            {
                AnsiConsole.Markup("[yellow]Your answer:[/] ");
                var answer = Console.ReadLine();
                if (answer.Equals("back"))
                {
                    AnsiConsole.Clear();
                    return false;
                }
                if (answer.Equals("repeat"))
                {
                    myNote.ChooseNote(lesson.AudioFiles[i]);
                }
                else if (answer.Contains(lesson.Answers[i]))
                {
                    AnsiConsole.Markup("[green]Correct![/]\n");
                    break;
                }
                else
                {
                    AnsiConsole.Markup("[red]Wrong answer, try again.[/]\n");
                }
            }
        }
        AnsiConsole.Markup("[yellow]You have completed this lesson! Press any key to continue...[/]\n");
        Console.ReadKey();
        AnsiConsole.Clear();
        return true;
    }

    public static void MarkLessonAsComplete(List<UserLesson> lessonsStatus, PianoLessonContext context, int userId, int lessonId)
    {
        var nextLessonsIds = context.LessonPrerequisites
            .Where(lp => lp.PrerequisiteLessonId == lessonId)
            .Select(lp => lp.IdLesson)
            .ToList();

        if (nextLessonsIds.Any())
        {
            var lessonsToUnlock = context.UserLessons
                .Where(ul => ul.IdUser == userId && nextLessonsIds.Contains(ul.IdLesson))
                .ToList();

            foreach (var ul in lessonsToUnlock)
            {
                if (!ul.IsUnlocked)
                {
                    ul.IsUnlocked = true;
                }
            }
        }

        var currentLesson = context.UserLessons
            .FirstOrDefault(ul => ul.IdUser == userId && ul.IdLesson == lessonId);

        if (currentLesson != null)
        {
            if (!currentLesson.IsCompleted)
            {
                currentLesson.IsCompleted = true;
            }
        }

        context.SaveChanges();
    }

    public static void ResetALLProgressForUser(List<UserLesson> lessonsStatus, PianoLessonContext context, int userId)
    {
        var currentLesson = context.UserLessons
            .Where(ul => ul.IdUser == userId)
            .ToList();

        foreach (var userlesson in lessonsStatus)
        {
            userlesson.IsCompleted = false;
            if (userlesson.IdLesson == 1)
            {
                userlesson.IsUnlocked = true;
            }
            else
            {
                userlesson.IsUnlocked = false;
            }
        }
        context.SaveChanges();
    }
}
