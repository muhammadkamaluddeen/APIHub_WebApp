using APIHub_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace APIHub_WebApp.Controllers
{
    public class UserController : Controller
    {
        public  List<User> users = new List<User>() 
         {
           new User(){UserId="202212",UserName="Bello.Musa", UserType="Admin", Password = "12345"},
           new User(){UserId="212360",UserName="Aliyu.Nura", UserType="Sub-Admin", Password = "33445"},
         };

        //Used ViewBag to pass data from the controller to the view
        public IActionResult Index()
        {   
            ViewBag.UserCount = users.Count;
            ViewBag.UserList = users;
            return View();
        }


    }
}
