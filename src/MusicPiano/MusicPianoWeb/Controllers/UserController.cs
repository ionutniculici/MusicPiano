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
        [HttpGet("hello")]
        public async Task<string> GetHelloAsync()
        {
            await Task.Delay(100); // Simulate some asynchronous work
            return "Hello user";
        }

        [HttpPost()]
        public async Task<int> LoginUser(UserLogin login)
        {
            using PianoLessonContext context = new PianoLessonContext();
            Repository repository = new Repository(context);
            User? user = await repository.LoginUser(login.username, login.password);
            return user?.Id ?? -1;
        }
    }
}
