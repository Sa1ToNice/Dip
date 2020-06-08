using Dip.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data
{
    public class DBObjects
    {
        public static void initial(AppDBContent content)
        {
           
            //if (!content.Category.Any())
            //    content.Category.AddRange(Categories.Select(c => c.Value));

            //if (!content.Car.Any())
            //{
            //    content.AddRange(


            //            new Car { name = "Tesla", desc = "lol", img = "/img/1.jpg", price = 50000, favorite = true, available = true, Category = Categories["Электро"] },
            //            new Car { name = "Benz", desc = "kek", img = "/img/1.jpg", price = 30000, favorite = true, available = true, Category = Categories["Бенз"] },
            //            new Car { name = "Tesla", desc = "lol", img = "/img/1.jpg", price = 50000, favorite = true, available = true, Category = Categories["Электро"] },
            //            new Car { name = "Benz", desc = "kek", img = "/img/1.jpg", price = 30000, favorite = true, available = true, Category = Categories["Бенз"] },
            //            new Car { name = "Tesla", desc = "lol", img = "/img/1.jpg", price = 50000, favorite = true, available = true, Category = Categories["Электро"] },
            //            new Car { name = "Benz", desc = "kek", img = "/img/1.jpg", price = 30000, favorite = true, available = true, Category = Categories["Бенз"] }
            //        );
            //}


            if (!content.Info.Any())
            {
                content.AddRange(


                        new Info { Name = "Инф1", Desc = "Текст1" },
                        new Info { Name = "Инф2", Desc = "Текст2" },
                        new Info { Name = "Инф3", Desc = "Текст3" }


                    );
            }

            content.SaveChanges();
        }

        //private static Dictionary<string, Category> category;
        //public static Dictionary<string, Category> Categories
        //{
        //    get
        //    {
        //        if(category == null)
        //        {
        //            var list = new Category[]
        //            {
        //                new Category {categoryName = "Электро", desc = "ЭЛЕКТРО"},
        //                new Category {categoryName = "Бенз", desc = "БЕНЗ"}
        //            };

        //            category = new Dictionary<string, Category>();

        //            foreach(Category el in list)
        //            {
        //                category.Add(el.categoryName, el);
        //            }

        //        }
                
        //        return category;

        //    }
        //}
    }
}
