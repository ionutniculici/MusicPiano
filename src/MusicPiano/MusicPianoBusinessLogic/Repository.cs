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
    }
}
