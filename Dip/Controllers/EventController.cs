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
    public class EventController : Controller
    {
       

        private AppDBContent db;
        private IEvent _event;

        public EventController(AppDBContent context, IEvent iEvent)
        {
            _event = iEvent;
            db = context;


        } 
        
      


        [Authorize]
        [HttpGet]
        public IActionResult Add(int aId)
        {
            ViewBag.Title = "Добавление события";

            
            IEnumerable<Hive> hiv = db.Hives.Where(i => i.Apiary.Id == aId).OrderBy(i => i.Id);
            IEnumerable<Apiary> ap = db.Apiaries.Where(i => i.Id == aId && i.User.Email == User.Identity.Name.ToString()).OrderBy(i => i.Id);
            Apiary app = ap.FirstOrDefault(i => i.Id == aId);

            if (app == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }
            else
            {
                var eve = new EventViewModel
                {


                    Aid = aId,
                    Hives = hiv
                    

                };
                return View(eve);
            }

           

        }

        [HttpPost]
        public async Task<IActionResult> Add(EventViewModel eventViewModel)
        {
            ViewBag.Title = "Добавление события";

            IEnumerable<Hive> hiv = db.Hives.Where(i => i.Apiary.Id == eventViewModel.Aid).OrderBy(i => i.Id);
            eventViewModel.Hives = hiv;



            if (ModelState.IsValid)
            {
                if (eventViewModel.Date < DateTime.Today)
                {
                    ModelState.AddModelError("", "Вы не можете выбрать дату в прошлом");
                    return View(eventViewModel);
                }

                IEnumerable<Event> eves = db.Events.Where(i => i.Hive.Apiary.Id == eventViewModel.Aid && i.Hive.Name == eventViewModel.HiveName).OrderBy(i => i.Id);
                Event ev = eves.FirstOrDefault(i => i.Name == eventViewModel.Name && i.Date == eventViewModel.Date);
                

                if (ev == null)
                {
                    
                    Hive courseToUpdate2 = await db.Hives.FirstOrDefaultAsync(c => c.Apiary.Id == eventViewModel.Aid && c.Name == eventViewModel.HiveName);
                    db.Events.Add(new Event { Name = eventViewModel.Name, Desc = eventViewModel.Desc, Date = eventViewModel.Date, Hive = courseToUpdate2});
                    await db.SaveChangesAsync();
                    return RedirectToAction("HiveView", "Apiary", new { id = eventViewModel.Aid });
                }
                else
                {
                    ModelState.AddModelError("", "Данное событие уже существует");
                    return View(eventViewModel);
                }

            }
            else
            {
                return View(eventViewModel);
            }


        }


        [Authorize]
        public async Task<IActionResult> Delete(int id, int aId, int hid)
        {
           
            IEnumerable<Event> eves = db.Events.Where(i => i.Hive.Apiary.Id == aId && i.Hive.Id == hid && i.Hive.Apiary.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            Event eve = eves.FirstOrDefault(i => i.Id == id);
            if (eve == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }

            db.Events.Remove(eve);
            await db.SaveChangesAsync();
            return RedirectToAction("HiveView", "Apiary", new { id = aId });
        }


        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id, int aId, int hid)
        {
            ViewBag.Title = "Редактирование события";
            IEnumerable<Apiary> ap = db.Apiaries.Where(i => i.User.Email == User.Identity.Name.ToString()).OrderBy(i => i.Id);
            Apiary app = ap.FirstOrDefault(i => i.Id == aId);
            IEnumerable<Hive> hives = db.Hives.Where(i => i.Apiary.Id == app.Id ).OrderBy(i => i.Id);
            Hive hive = hives.FirstOrDefault(i => i.Id == hid);
            IEnumerable<Event> eves = db.Events.Where(i => i.Hive.Apiary.Id == hive.Apiary.Id && i.Hive.Id == hive.Id).OrderBy(i => i.Id);
            Event eve = eves.FirstOrDefault(i => i.Id == id);

            

            if (app == null || hive == null || eve == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }
            else
            {
                if (eve.Date < DateTime.Today)
                {
                    return RedirectToAction("HiveView", "Apiary", new { id = aId });
                }
                var hv = new EventViewModel
                {
                    Id = eve.Id,
                    Name = eve.Name,
                    Desc = eve.Desc,
                    Date = eve.Date,
                    Aid = aId,
                    Hid = hid,
                    HiveName = eve.Hive.Name,
                    Hives = hives
                    
                };
                return View(hv);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventViewModel eventViewModel)
        {
            ViewBag.Title = "Редактирование события";
            IEnumerable<Hive> hiv = db.Hives.Where(i => i.Apiary.Id == eventViewModel.Aid).OrderBy(i => i.Id);
            eventViewModel.Hives = hiv;
            

            if (ModelState.IsValid)
            {
                if (eventViewModel.Date < DateTime.Today)
                {
                    ModelState.AddModelError("", "Вы не можете выбрать дату в прошлом");
                    return View(eventViewModel);
                }

                Hive hive = db.Hives.FirstOrDefault(i => i.Apiary.Id == eventViewModel.Aid && i.Name == eventViewModel.HiveName);
                eventViewModel.Hid = hive.Id;

                IEnumerable<Event> eves = db.Events.Where(i => i.Hive.Apiary.Id == eventViewModel.Aid && i.Hive.Id == eventViewModel.Hid).OrderBy(i => i.Id);

                Event eve = eves.FirstOrDefault(i => i.Name == eventViewModel.Name && i.Date == eventViewModel.Date);


                if (eve == null)
                {
                    eve = db.Events.FirstOrDefault(i => i.Id == eventViewModel.Id);
                    eve.Name = eventViewModel.Name;
                    eve.Desc = eventViewModel.Desc;
                    eve.Date = eventViewModel.Date;

                    
                    eve.Hive = hive;

                    await TryUpdateModelAsync<Event>(eve, "", c => c.Name, c => c.Desc, c => c.Date, c => c.Hive);
                    await db.SaveChangesAsync();
                    return RedirectToAction("HiveView", "Apiary", new { id = eventViewModel.Aid });

                }
                else
                {
                   
                    if (eve.Id == eventViewModel.Id)
                    {
                        eve = db.Events.FirstOrDefault(i => i.Id == eventViewModel.Id);
                        eve.Name = eventViewModel.Name;
                        eve.Desc = eventViewModel.Desc;
                        eve.Date = eventViewModel.Date;

                        
                        eve.Hive = hive;

                        await TryUpdateModelAsync<Event>(eve, "", c => c.Name, c => c.Desc, c => c.Date, c => c.Hive);
                        await db.SaveChangesAsync();
                        return RedirectToAction("HiveView", "Apiary", new { id = eventViewModel.Aid });


                    }
                    else
                    {
                        ModelState.AddModelError("", "Событие с указанной датой и названием уже содержится в выбранной пасеке");
                        return View(eventViewModel);
                    }

                }
            }
            else
            {
                return View(eventViewModel);
            }
        }





    }




}
