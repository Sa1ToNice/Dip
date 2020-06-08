using Dip.Data;
using Dip.Data.Interfaces;
using Dip.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Controllers
{
    public class HomeController : Controller
    {

        private AppDBContent _db;


        public HomeController(AppDBContent context)
        {
            _db = context;
           
        }

        
        public ViewResult Index()
        {
           
            ViewBag.Title = "Главная страница";
            return View();

        }
        
        public ViewResult About()
        {
            
            ViewBag.Title = "О нас";
           
            return View();
        }



    }
}
