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
    }
}
