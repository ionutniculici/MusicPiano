using Microsoft.EntityFrameworkCore;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using System.Configuration;

namespace MusicPianoForms;

public static class AppState
{
    public static Repository repository;
    public static Dictionary<int, UserLesson> lessonsStatusDict;
    public static List<MusicPianoLogic.Lesson> lessonList;
    public static List<UserLesson>? lessonsStatus;

    public static async Task Initialize(DbContextOptions<PianoLessonContext> options, User? user)
    {
        var context = new PianoLessonContext(options);
        repository = new Repository(context);
        lessonsStatusDict = new Dictionary<int, UserLesson>();
        lessonList = new List<MusicPianoLogic.Lesson>();
        lessonsStatus = await InitLessons(repository, lessonsStatusDict, lessonList, user.Id);
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
}
