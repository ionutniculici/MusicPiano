using Microsoft.AspNetCore.Mvc;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoWeb.Classes;

namespace MusicPianoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly PianoLessonContext _context;

        public UserController(PianoLessonContext context)
        {
            _context = context;
        }

        [HttpGet("hello")]
        public async Task<string> GetHelloAsync()
        {
            await Task.Delay(100); // Simulate some asynchronous work
            return "Hello user";
        }

        [HttpPost()]
        public async Task<int> LoginUser(UserLogin login)
        {
            Repository repository = new Repository(_context);
            User? user = await repository.LoginUser(login.username, login.password);
            return user?.Id ?? -1;
        }
    }
}
