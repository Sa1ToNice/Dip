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
            IEnumerable<Hive> hive = db.Hives.Where(i => i.Apiary.Id == aId && i.Apiary.User.Email == User.Identity.Name.ToString()).OrderBy(i => i.Id);
            Hive hiv = hive.FirstOrDefault(i => i.Id == id);
            if (hiv == null)
            { return RedirectToAction("HiveView", "Apiary", new { id = aId }); }
            else
            {
                var ap = new HiveViewModel
                {
                    Id = hiv.Id,                 
                    Name = hiv.Name,
                    Aid = aId,
                    Desc = hiv.Desc,
                    Force = hiv.Force,
                    Mass = hiv.Mass,
                    Frame = hiv.Frame,
                    Wframe = hiv.Wframe,
                    Hframe = hiv.Hframe,
                    Porod = hiv.Porod,
                    Heal = hiv.Heal,
                    Heal1 = hiv.Heal1,
                    Heal2 = hiv.Heal2,
                    Heal3 = hiv.Heal3,
                    Heal4 = hiv.Heal4,
                    Heal5 = hiv.Heal5,
                    Heal6 = hiv.Heal6,
                    Heal7 = hiv.Heal7,
                    Heal8 = hiv.Heal8,
                    Heal9 = hiv.Heal9,
                    Matka = hiv.Matka,
                    DatePods = hiv.DatePods,
                    Plod = hiv.Plod,
                    Prois = hiv.Prois
                };
                return View(ap);
            }


        }

        [Authorize]
        [HttpGet]
        public IActionResult Add(int aId)
        {
            ViewBag.Title = "Добавление улья";
            IEnumerable<Apiary> ap = db.Apiaries.Where(i => i.Id == aId && i.User.Email == User.Identity.Name.ToString()).OrderBy(i => i.Id);
            Apiary app = ap.FirstOrDefault(i => i.Id == aId);
            if (app == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }
            else
            {
                var ap1 = new HiveViewModel
                {
                
              
                 Aid = aId,
                
                };
             return View(ap1);
            }


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
                    db.Hives.Add(new Hive { Name = hiveViewModel.Name, Desc = hiveViewModel.Desc, Apiary = courseToUpdate, Img= "/img/улей.png",
                        Force = hiveViewModel.Force,
                        Mass = hiveViewModel.Mass,
                        Frame = hiveViewModel.Frame,
                        Wframe = hiveViewModel.Wframe,
                        Hframe = hiveViewModel.Hframe,
                        Porod = hiveViewModel.Porod,
                        Heal = hiveViewModel.Heal,
                        Heal1 = hiveViewModel.Heal1,
                        Heal2 = hiveViewModel.Heal2,
                        Heal3 = hiveViewModel.Heal3,
                        Heal4 = hiveViewModel.Heal4,
                        Heal5 = hiveViewModel.Heal5,
                        Heal6 = hiveViewModel.Heal6,
                        Heal7 = hiveViewModel.Heal7,
                        Heal8 = hiveViewModel.Heal8,
                        Heal9= hiveViewModel.Heal9,
                        Matka = hiveViewModel.Matka,
                        DatePods = hiveViewModel.DatePods,
                        Plod = hiveViewModel.Plod,
                        Prois = hiveViewModel.Prois
                    });
                    await db.SaveChangesAsync();

                    hiv = db.Hives.FirstOrDefault(i => i.Name == hiveViewModel.Name && i.Apiary.Id == hiveViewModel.Aid);
                    db.Inspects.Add(new Inspect
                    {
                        
                        Force = hiveViewModel.Force,
                        Mass = hiveViewModel.Mass,
                        Frame = hiveViewModel.Frame,
                        Date = DateTime.Today,
                        Matka = hiveViewModel.Matka,
                        DatePods = hiveViewModel.DatePods,
                        Plod = hiveViewModel.Plod,
                        Hive = hiv,
                        
                    });
                    await db.SaveChangesAsync();

                    return RedirectToAction("HiveView", "Apiary", new {id = hiveViewModel.Aid });
                }
                else
                {
                    ModelState.AddModelError("", "Данное Название уже используется");
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
        public IActionResult Edit(int id, int aId)
        {
            ViewBag.Title = "Редактирование улья";
            IEnumerable<Apiary> ap = db.Apiaries.Where(i => i.Id == aId && i.User.Email == User.Identity.Name.ToString()).OrderBy(i => i.Id);
            Apiary app = ap.FirstOrDefault(i => i.Id == aId);
            if (app == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }
            

            IEnumerable<Hive> api = _hive.Hives.Where(i => i.Apiary.Id == aId).OrderBy(i => i.Id);
            Hive hive = api.FirstOrDefault(i => i.Id == id);
            if (hive == null)
            { return RedirectToAction("HiveView", "Apiary", new { id = aId }); }
            else
            {
                var hv = new HiveViewModel
                {
                    Id = hive.Id,
                    Name = hive.Name,
                    Desc = hive.Desc,
                    Aid = aId,
                    Force = hive.Force,
                    Mass = hive.Mass,
                    Frame = hive.Frame,
                    Hframe = hive.Hframe,
                    Wframe = hive.Wframe,
                    Porod = hive.Porod,
                    Heal = hive.Heal,
                    Heal1 = hive.Heal1,
                    Heal2 = hive.Heal2,
                    Heal3 = hive.Heal3,
                    Heal4 = hive.Heal4,
                    Heal5 = hive.Heal5,
                    Heal6 = hive.Heal6,
                    Heal7 = hive.Heal7,
                    Heal8 = hive.Heal8,
                    Heal9 = hive.Heal9,
                    Matka = hive.Matka,
                    DatePods = hive.DatePods,
                    Plod = hive.Plod,
                    Prois = hive.Prois
                };
                return View(hv);
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
                    hive = _hive.Hives.FirstOrDefault(i => i.Id == hiveViewModel.Id);
                    hive.Name = hiveViewModel.Name;
                    hive.Desc = hiveViewModel.Desc;
                    hive.Force = hiveViewModel.Force;
                    hive.Mass = hiveViewModel.Mass;
                    hive.Frame = hiveViewModel.Frame;
                    hive.Wframe = hiveViewModel.Wframe;
                    hive.Hframe = hiveViewModel.Hframe;
                    hive.Porod = hiveViewModel.Porod;
                    hive.Heal = hiveViewModel.Heal;
                    hive.Heal1 = hiveViewModel.Heal1;
                    hive.Heal2 = hiveViewModel.Heal2;
                    hive.Heal3 = hiveViewModel.Heal3;
                    hive.Heal4 = hiveViewModel.Heal4;
                    hive.Heal5 = hiveViewModel.Heal5;
                    hive.Heal6 = hiveViewModel.Heal6;
                    hive.Heal7 = hiveViewModel.Heal7;
                    hive.Heal8 = hiveViewModel.Heal8;
                    hive.Heal9 = hiveViewModel.Heal9;
                    hive.Matka = hiveViewModel.Matka;
                    hive.DatePods = hiveViewModel.DatePods;
                    hive.Plod = hiveViewModel.Plod;
                    hive.Prois = hiveViewModel.Prois;



                    await TryUpdateModelAsync<Hive>(hive, "", c => c.Name, c => c.Desc, c => c.Force, c => c.Mass, c => c.Frame, c => c.Hframe, c => c.Wframe, c => c.Porod, c => c.Heal, c => c.Heal1, c => c.Heal2,
                        c => c.Heal3, c => c.Heal4, c => c.Heal5, c => c.Heal6, c => c.Heal6, c => c.Heal7, c => c.Heal8, c => c.Heal9, c => c.Matka, c => c.DatePods, c => c.Plod, c => c.Prois);
                    await db.SaveChangesAsync();

                    
                    hive = db.Hives.FirstOrDefault(i => i.Name == hiveViewModel.Name && i.Apiary.Id == hiveViewModel.Aid);
                    Inspect insp = db.Inspects.FirstOrDefault(i => i.Hive == hive && i.Date == DateTime.Today);                   
                    if (insp == null)
                    {
                        db.Inspects.Add(new Inspect
                        {

                            Force = hiveViewModel.Force,
                            Mass = hiveViewModel.Mass,
                            Frame = hiveViewModel.Frame,
                            Date = DateTime.Today,
                            Matka = hiveViewModel.Matka,
                            DatePods = hiveViewModel.DatePods,
                            Plod = hiveViewModel.Plod,
                            Hive = hive,

                        });
                    }
                    else
                    {
                        insp.Force = hiveViewModel.Force;
                        insp.Mass = hiveViewModel.Mass;
                        insp.Frame = hiveViewModel.Frame;
                        insp.Matka = hiveViewModel.Matka;
                        insp.DatePods = hiveViewModel.DatePods;
                        insp.Plod = hiveViewModel.Plod;
                        await TryUpdateModelAsync<Inspect>(insp, "", c => c.Force, c => c.Mass, c => c.Frame, c => c.Date, c => c.Matka, c => c.DatePods, c => c.Plod, c => c.Hive);
                        
                    }                   
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
                        hive.Force = hiveViewModel.Force;
                        hive.Mass = hiveViewModel.Mass;
                        hive.Frame = hiveViewModel.Frame;
                        hive.Wframe = hiveViewModel.Wframe;
                        hive.Hframe = hiveViewModel.Hframe;
                        hive.Porod = hiveViewModel.Porod;
                        hive.Heal = hiveViewModel.Heal;
                        hive.Heal1 = hiveViewModel.Heal1;
                        hive.Heal2 = hiveViewModel.Heal2;
                        hive.Heal3 = hiveViewModel.Heal3;
                        hive.Heal4 = hiveViewModel.Heal4;
                        hive.Heal5 = hiveViewModel.Heal5;
                        hive.Heal6 = hiveViewModel.Heal6;
                        hive.Heal7 = hiveViewModel.Heal7;
                        hive.Heal8 = hiveViewModel.Heal8;
                        hive.Heal9 = hiveViewModel.Heal9;
                        hive.Matka = hiveViewModel.Matka;
                        hive.DatePods = hiveViewModel.DatePods;
                        hive.Plod = hiveViewModel.Plod;
                        hive.Prois = hiveViewModel.Prois;

                        await TryUpdateModelAsync<Hive>(hive, "", c => c.Name, c => c.Desc, c => c.Force, c => c.Mass, c => c.Frame, c => c.Hframe, c => c.Wframe, c => c.Porod, c => c.Heal, c => c.Heal1, c => c.Heal2,
                        c => c.Heal3, c => c.Heal4, c => c.Heal5, c => c.Heal6, c => c.Heal6, c => c.Heal7, c => c.Heal8, c => c.Heal9, c => c.Matka, c => c.DatePods, c => c.Plod, c => c.Prois);
                        await db.SaveChangesAsync();


                        hive = db.Hives.FirstOrDefault(i => i.Name == hiveViewModel.Name && i.Apiary.Id == hiveViewModel.Aid);
                        Inspect insp = db.Inspects.FirstOrDefault(i => i.Hive == hive && i.Date == DateTime.Today);
                        if (insp == null)
                        {
                            db.Inspects.Add(new Inspect
                            {

                                Force = hiveViewModel.Force,
                                Mass = hiveViewModel.Mass,
                                Frame = hiveViewModel.Frame,
                                Date = DateTime.Today,
                                Matka = hiveViewModel.Matka,
                                DatePods = hiveViewModel.DatePods,
                                Plod = hiveViewModel.Plod,
                                Hive = hive,

                            });
                        }
                        else
                        {
                            insp.Force = hiveViewModel.Force;
                            insp.Mass = hiveViewModel.Mass;
                            insp.Frame = hiveViewModel.Frame;
                            insp.Matka = hiveViewModel.Matka;
                            insp.DatePods = hiveViewModel.DatePods;
                            insp.Plod = hiveViewModel.Plod;
                            await TryUpdateModelAsync<Inspect>(insp, "", c => c.Force, c => c.Mass, c => c.Frame, c => c.Date, c => c.Matka, c => c.DatePods, c => c.Plod, c => c.Hive);

                        }
                        await db.SaveChangesAsync();
                        return RedirectToAction("HiveView", "Apiary", new { id = hiveViewModel.Aid });


                    }
                    else
                    {
                        ModelState.AddModelError("", "Данное Название уже используется");
                        return View(hiveViewModel);
                    }

                }
            }
            else
            {
                return View(hiveViewModel);
            }
        }


        [Authorize]
        public async Task<IActionResult> Delete(int id, int aId)
        {
         
            IEnumerable<Hive> hive = db.Hives.Where(i => i.Apiary.Id == aId && i.Apiary.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);
            Hive hiv = hive.FirstOrDefault(i => i.Id == id);
            
            if (hiv == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aId });
            }

            IEnumerable<Event> eve = db.Events.Where(i => i.Hive.Id == id).OrderBy(i => i.Id);
            foreach (Event var in eve)
            {
                db.Events.Remove(var);
            }

            IEnumerable<Honey> hon = db.Honey.Where(i => i.Hive.Id == id).OrderBy(i => i.Id);
            foreach (Honey dhon in hon)
            {
                db.Honey.Remove(dhon);
            }

            IEnumerable<Inspect> insp = db.Inspects.Where(i => i.Hive.Id == id).OrderBy(i => i.Id);
            foreach (Inspect ins in insp)
            {
                db.Inspects.Remove(ins);
            }

            db.Hives.Remove(hiv);
            await db.SaveChangesAsync();
            return RedirectToAction("HiveView", "Apiary", new { id = aId });
        }



    }
}
