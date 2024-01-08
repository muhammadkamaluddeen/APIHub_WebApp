using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_API.Interfaces;
using WebApp_API.Models;

namespace WebApp_API.Controllers
{
  
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsers _users;
        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<CreateUserResponse> CreateUser(CreateUser request) 
        {
            var response = await _users.CreateUser(request);
            
            return response;

        }

        [HttpGet]
        [Route("api/GetUser")]
        public async Task<User> GetUser(string userId)
        {
            var response = await _users.GetUser(userId);

            return response;

        }

        [HttpGet]
        [Route("api/GetAllUser")]
        public async Task<List<User>> GetUserAll()
        {
            var response = await _users.GetAllUser();

            return response;

        }
    }
}
