using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dip.Data.Interfaces;
using Dip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dip.Data.Models;

namespace Dip.Controllers
{
    public class InfoController : Controller
    {
        private IInfo _info;



        public InfoController(IInfo info)
        {
            _info = info;

        }

        [Route("Info/Search")]
        public ViewResult Search(string sea)
        {
            ViewBag.Title = "Справочник";
            

           
            
                InfoViewModel inf = new InfoViewModel
                { getInf = _info.SomeInf(sea) 
                
                };
                return View(inf);
          
          
            

        }

        [Route("Info/List")]
        public ViewResult Index()
        {

           

            var inf = new InfoViewModel
            { getInf = _info.AllInf};
            ViewBag.Title = "Справочник";
            return View(inf);


        }


       
        [Route("Info/List/{name}")]
        public ViewResult List(string name)
        {
            Info info = _info.getInfo(name);



            var inf = new InfoViewModel
            { oneInf = info };
            ViewBag.Title = "Справочник";
            return View(inf);


        }


    }
}