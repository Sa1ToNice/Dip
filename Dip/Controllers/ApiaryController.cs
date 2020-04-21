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
                    Name = apiar.Name
                };
                return View(ap);
            }


        }
        [Authorize]
        public IActionResult HiveView(int id)
        {
            ViewBag.Title = "Информация о пасеке";
            IEnumerable<Apiary> api = _apiary.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            IEnumerable<Hive> hives = db.Hives.Where(u =>  u.Apiary.Id == id);
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
                    Hives = hives
                    
                };
                return View(ap);
            }


        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Apiary apiar = _apiary.GetApId(id);
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
                    db.Apiaries.Add(new Apiary { Name = apiaryViewModel.Name, Map = apiaryViewModel.Map, User = courseToUpdate});
                    await db.SaveChangesAsync();
                    return RedirectToAction("", "Apiary");
                }
                else
                {
                    ModelState.AddModelError("", "Данное Навзвание уже используется");
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
                    Name = apiar.Name
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

                    await TryUpdateModelAsync<Apiary>(apiar, "", c => c.Name);
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

                        await TryUpdateModelAsync<Apiary>(apiar, "", c => c.Name);
                        await db.SaveChangesAsync();
                        return RedirectToAction("", "Apiary");


                    }
                    else
                    {
                        ModelState.AddModelError("", "Данное Навзвание уже используется");
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