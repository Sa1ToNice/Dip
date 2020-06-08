using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dip.Data;
using Dip.Data.Interfaces;
using Dip.Data.Models;
using Dip.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dip.Controllers
{
    public class ApiaryController : Controller
    {
        private IApiary _apiary;
       

        
        private AppDBContent db;

        public ApiaryController(AppDBContent context,IApiary iApiary)
        {
            _apiary = iApiary;
            db = context;
           
            
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Title = "Пасечное хозяйство";

            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);

            var apObj = new ApiaryViewModel
            {
                Apiaries = api,
               
            };
            return View(apObj);
        }

        [Authorize]
        public  IActionResult About(int id)
        {
            ViewBag.Title = "Информация о пасеке";
            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            Apiary apiar = api.FirstOrDefault(i => i.Id == id);
            if (apiar == null)
            { return RedirectToAction("", "Apiary"); }
            else
            {
                var ap = new ApiaryViewModel
                {
                    Id = apiar.Id,
                    Map = apiar.Map,
                    Name = apiar.Name,
                    Desc = apiar.Desc
                };
                return View(ap);
            }
        }


        [Authorize]
        public IActionResult HiveView(int id, string sortOrder)
        {
            ViewBag.Title = "Информация о пасеке";
            
            ViewData["DateSortParm"] = sortOrder == "Asc" ? "Desc" : "Asc";
            
            

            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            IEnumerable<Hive> hives = db.Hives.Where(u =>  u.Apiary.Id == id);
            IEnumerable<Event> ev = db.Events.Where(u => u.Hive.Apiary.Id == id).OrderByDescending(i => i.Date);
            switch (sortOrder)
            {
                
                case "Asc":
                    ev = ev.OrderBy(s => s.Date);
                    break;
                
                default:
                    ev = ev.OrderByDescending(s => s.Date);
                    break;
            }




            Apiary apiar = api.FirstOrDefault(i => i.Id == id);
            if (apiar == null)
            { return RedirectToAction("", "Apiary"); }
            else
            {
                var ap = new ApiaryViewModel
                {
                    Id = apiar.Id,
                    Map = apiar.Map,
                    Name = apiar.Name,
                    Hives = hives,
                    VEvents = ev,

                    
                };
                return View(ap);
            }
        }


        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            Apiary apiar = api.FirstOrDefault(i => i.Id == id);
            if (apiar == null)
            {
                return RedirectToAction("", "Apiary");
            }

            IEnumerable<Event> eve = db.Events.Where(i => i.Hive.Apiary.Id == id).OrderBy(i => i.Id);
            foreach (Event var in eve)
            {
                db.Events.Remove(var);
            }

            IEnumerable<Honey> hon = db.Honey.Where(i => i.Hive.Apiary.Id == id).OrderBy(i => i.Id);
            foreach (Honey dhon in hon)
            {
                db.Honey.Remove(dhon);
            }

            IEnumerable<Hive> hive = db.Hives.Where(i => i.Apiary.Id == id).OrderBy(i => i.Id);
            foreach (Hive var in hive)
            {
                db.Hives.Remove(var);
            }

            db.Apiaries.Remove(apiar);
            await db.SaveChangesAsync();
            return RedirectToAction("", "Apiary");
        }





        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Добавление пасеки";
            
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(ApiaryViewModel apiaryViewModel)
        {


            if (ModelState.IsValid)
            {   IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
                
                Apiary apia = api.FirstOrDefault(i => i.Name == apiaryViewModel.Name);
                

                if (apia == null)
                {
                    User courseToUpdate = await db.Users.FirstOrDefaultAsync(c => c.Email == User.Identity.Name.ToString());
                    db.Apiaries.Add(new Apiary { Name = apiaryViewModel.Name, Map = apiaryViewModel.Map, Desc = apiaryViewModel.Desc, User = courseToUpdate});
                    await db.SaveChangesAsync();
                    return RedirectToAction("", "Apiary");
                }
                else
                {
                    ModelState.AddModelError("", "Данное Название уже используется");
                    return View(apiaryViewModel);
                }

            }
            else
            {
                return View(apiaryViewModel);
            }

        }



        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Редактирование пасеки";
            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            Apiary apiar = api.FirstOrDefault(i => i.Id == id);
            if (apiar == null)
            { return RedirectToAction("", "Apiary"); }
            else
            {
                var ap = new ApiaryViewModel
                {
                    Id = apiar.Id,
                    Map = apiar.Map,
                    Name = apiar.Name,
                    Desc = apiar.Desc
                };
                return View(ap);
            }
            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApiaryViewModel apiaryViewModel)
        {
            ViewBag.Title = "Редактирование пасеки";
            

            if (ModelState.IsValid)
            {
                IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);

                Apiary apiar = api.FirstOrDefault(i => i.Name == apiaryViewModel.Name);
                

                if (apiar == null)
                {
                    apiar = _apiary.Apiaries.FirstOrDefault(i => i.Id == apiaryViewModel.Id);
                    apiar.Name = apiaryViewModel.Name;
                    apiar.Map = apiaryViewModel.Map;
                    apiar.Desc = apiaryViewModel.Desc;

                    await TryUpdateModelAsync<Apiary>(apiar, "", c => c.Name, c => c.Map, c => c.Desc);
                    await db.SaveChangesAsync();
                    return RedirectToAction("", "Apiary");

                }
                else
                {
                    apiar = _apiary.Apiaries.FirstOrDefault(i => i.Id == apiaryViewModel.Id);
                    if(apiar.Name == apiaryViewModel.Name)
                    {
                        apiar.Name = apiaryViewModel.Name;
                        apiar.Map = apiaryViewModel.Map;
                        apiar.Desc = apiaryViewModel.Desc;

                        await TryUpdateModelAsync<Apiary>(apiar, "", c => c.Name, c => c.Map, c => c.Desc);
                        await db.SaveChangesAsync();
                        return RedirectToAction("", "Apiary");


                    }
                    else
                    {
                        ModelState.AddModelError("", "Данное Название уже используется");
                        return View(apiaryViewModel);
                    }
                    
                }
            }
            else
            {
                return View(apiaryViewModel);
            }
        }
    }
}