using Dip.Data;
using Dip.Data.Interfaces;
using Dip.Data.Models;
using Dip.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Controllers
{
    public class HiveController : Controller
    {

        private IHive _hive;

        private AppDBContent db;

        public HiveController(AppDBContent context, IHive iHive)
        {
            _hive = iHive;
            db = context;
        }

        [Authorize]
        public IActionResult About(int id, int aId)
        {
            ViewBag.Title = "Информация об улье";
           
            Hive hiv = _hive.Hives.FirstOrDefault(i => i.Id == id);
            if (hiv == null)
            { return RedirectToAction("HiveView", "Apiary", new { id = aId }); }
            else
            {
                var ap = new HiveViewModel
                {
                    Id = hiv.Id,                 
                    Name = hiv.Name,
                    Aid = aId,
                    Desc = hiv.Desc
                };
                return View(ap);
            }


        }

        [Authorize]
        [HttpGet]
        public IActionResult Add(int aId)
        {
            ViewBag.Title = "Добавление улья";
            var ap = new HiveViewModel
            {
                
              
                Aid = aId,
                
            };
            return View(ap);

           

        }

        [HttpPost]
        public async Task<IActionResult> Add(HiveViewModel hiveViewModel)
        {
            ViewBag.Title = "Добавление улья";

            if (ModelState.IsValid)
            {
                IEnumerable<Hive> api = _hive.Hives.Where(i => i.Apiary.Id == hiveViewModel.Aid).OrderBy(i => i.Id);

                Hive hiv = api.FirstOrDefault(i => i.Name == hiveViewModel.Name);


                if (hiv == null)
                {
                    Apiary courseToUpdate = await db.Apiaries.FirstOrDefaultAsync(c => c.Id == hiveViewModel.Aid);
                    db.Hives.Add(new Hive { Name = hiveViewModel.Name, Desc = hiveViewModel.Desc, Apiary = courseToUpdate, Img= "/img/улей.png" });
                    await db.SaveChangesAsync();
                    return RedirectToAction("HiveView", "Apiary", new {id = hiveViewModel.Aid });
                }
                else
                {
                    ModelState.AddModelError("", "Данное Навзвание уже используется");
                    return View(hiveViewModel);
                }

            }
            else
            {
                return View(hiveViewModel);
            }
        }




        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id, int aid)
        {
            ViewBag.Title = "Редактирование улья";
            IEnumerable<Hive> api = _hive.Hives.Where(i => i.Apiary.Id == aid).OrderBy(i => i.Id);
            Hive hive = api.FirstOrDefault(i => i.Id == id);
            if (hive == null)
            { return RedirectToAction("HiveView", "Apiary", new { id = aid }); }
            else
            {
                var ap = new HiveViewModel
                {
                    Id = hive.Id,
                    Name = hive.Name,
                    Desc = hive.Desc,
                    Aid = aid
                };
                return View(ap);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Edit(HiveViewModel hiveViewModel)
        {
            ViewBag.Title = "Редактирование улья";


            if (ModelState.IsValid)
            {
                IEnumerable<Hive> api = _hive.Hives.Where(i => i.Apiary.Id == hiveViewModel.Aid).OrderBy(i => i.Id);

                Hive hive = api.FirstOrDefault(i => i.Name == hiveViewModel.Name);


                if (hive == null)
                {
                   // hive = _hive.Hives.FirstOrDefault(i => i.Id == hiveViewModel.Id);
                    hive.Name = hiveViewModel.Name;
                    hive.Desc = hiveViewModel.Desc;
                    

                    await TryUpdateModelAsync<Hive>(hive, "", c => c.Name, c=> c.Desc);
                    await db.SaveChangesAsync();
                    return RedirectToAction("HiveView", "Apiary", new { id = hiveViewModel.Aid });

                }
                else
                {
                    hive = _hive.Hives.FirstOrDefault(i => i.Id == hiveViewModel.Id);
                    if (hive.Name == hiveViewModel.Name)
                    {
                        hive.Name = hiveViewModel.Name;
                        hive.Desc = hiveViewModel.Desc;

                        await TryUpdateModelAsync<Hive>(hive, "", c => c.Name, c => c.Desc);
                        await db.SaveChangesAsync();
                        return RedirectToAction("HiveView", "Apiary", new { id = hiveViewModel.Aid });


                    }
                    else
                    {
                        ModelState.AddModelError("", "Данное Навзвание уже используется");
                        return View(hiveViewModel);
                    }

                }
            }
            else
            {
                return View(hiveViewModel);
            }
        }



    }
}
