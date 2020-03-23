using Dip.Data.Interfaces;
using Dip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRep;
       

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
           
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel 
            { fawCars = _carRep.getFawCars
            };
            return View(homeCars);
        }

    }
}
