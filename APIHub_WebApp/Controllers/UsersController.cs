using APIHub_WebApp.Interfaces;
using APIHub_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHub_WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user; 
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser req)
        {
            var res = new CreateUserRes();
            if (req != null)
            {
             res = await _user.CreateUser(req);
            }
            else
            {

            }

            return View(res);
        }


        public IActionResult AllUsers()
        {

            return View();
        }



    }
}
