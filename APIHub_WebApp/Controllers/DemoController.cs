﻿using APIHub_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIHub_WebApp.Controllers
{
    public class DemoController : Controller
    {
        public List<User> users = new List<User>()
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

        
        
        //Used ViewData to pass data from the controller to the view
        public IActionResult Index2()
        {
            ViewData["UserCount"] = users.Count;
            ViewData["UserList"]= users;
            return View();
        }


        //TempData is used to move data from one Action method to another eg from TempData_Demo to TempData_Demo2
        public IActionResult TempData_Demo()
        {
            TempData["Message"] = "This is TempData Demo Message";
            return View();
        }

        public IActionResult TempData_Demo2()
        {
            if (TempData["Message"] == null)
                return RedirectToAction("Index");

            TempData["Message2"] = TempData["Message"].ToString();
            return View();
        }
    }
}