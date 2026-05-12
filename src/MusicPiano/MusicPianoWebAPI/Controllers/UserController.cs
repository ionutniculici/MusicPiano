using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPianoBusinessLogic;
using MusicPianoData;

namespace MusicPianoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        public async Task<User[]> GetUsers([FromServices]Repository repository)
        {
            return await repository.GetAllUsers();
        }


    }
}
