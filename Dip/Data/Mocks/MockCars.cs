using Dip.Data.Interfaces;
using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {name = "Tesla", desc = "lol", img="/img/1.jpg", price = 50000, favorite=true, available=true, Category = _categoryCars.AllCategories.First()},
                    new Car {name = "Benz", desc = "kek", img="/img/1.jpg", price = 30000, favorite=true, available=true, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Tesla", desc = "lol", img="/img/1.jpg", price = 50000, favorite=true, available=true, Category = _categoryCars.AllCategories.First()},
                    new Car {name = "Benz", desc = "kek", img="/img/1.jpg", price = 30000, favorite=true, available=true, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Tesla", desc = "lol", img="/img/1.jpg", price = 50000, favorite=true, available=true, Category = _categoryCars.AllCategories.First()},
                    new Car {name = "Benz", desc = "kek", img="/img/1.jpg", price = 30000, favorite=true, available=true, Category = _categoryCars.AllCategories.Last()}
                };
            }
        }

        public IEnumerable<Car> getFawCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
