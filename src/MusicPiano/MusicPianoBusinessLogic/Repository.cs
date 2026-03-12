using Microsoft.EntityFrameworkCore;
using MusicPianoData;

namespace MusicPianoBusinessLogic
{
    public class Repository
    {
        PianoLessonContext context;

        public Repository(PianoLessonContext context) 
        {
            this.context = context;
        } 

        public async Task<User?> LoginUser(string user, string password)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Name == user && u.Password == password);
        }

        public async Task<User> AddUser(string user, string password)
        {
            User newUser = new User { Name = user, Password = password };
            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await context.Lessons.OrderBy(l => l.Name).ToListAsync();
        }

        public async Task<List<UserLesson>> GetLessonsForUser(int userId)
        {
            return await context.UserLessons
                .Include(ul => ul.IdLessonNavigation)
                .Include(ul => ul.IdUserNavigation)
                .Where(ul => ul.IdUser == userId)
                .OrderBy(ul => ul.IdLesson).ToListAsync();
        }

        public void MarkLessonAsComplete(List<UserLesson> lessonsStatus, int userId, int lessonId)
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

        public void ResetALLProgressForUser(List<UserLesson> lessonsStatus, int userId)
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
}
