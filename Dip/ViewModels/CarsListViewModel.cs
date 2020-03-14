using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> getAllCars { get; set; }
        public string curCategory { get; set; }
    }
}
