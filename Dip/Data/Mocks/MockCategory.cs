using Dip.Data.Interfaces;
using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "Электро", desc = "ЭЛЕКТРО"},
                    new Category {categoryName = "Бенз", desc = "БЕНЗ"}
                };
            }
        }
    }
}
