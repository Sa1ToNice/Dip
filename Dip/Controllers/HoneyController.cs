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
    public class HoneyController : Controller
    {
        private AppDBContent db;
        private IHoney _honey;

        public HoneyController(AppDBContent context, IHoney iHoney)
        {
            _honey = iHoney;
            db = context;


        }
        [HttpGet]
        [Authorize]
        public IActionResult Index(int aid, int hid)
        {
            ViewBag.Title = "Сбор меда";
            IEnumerable<Honey> hone = db.Honey.Where(i => i.Hive.Apiary.User.Email.Equals(User.Identity.Name) && i.Hive.Apiary.Id == aid && i.Hive.Id == hid).OrderByDescending(i => i.Date);
            Hive hiv = db.Hives.FirstOrDefault(i => i.Apiary.User.Email.Equals(User.Identity.Name) && i.Apiary.Id == aid && i.Id == hid);
            if (hiv == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aid });
            }

            var hon = new HoneyViewModel
            {
                HiveName = hiv.Name,
                Honeys = hone,
                Aid = aid,
                Hid = hid,


            };
            return View(hon);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(HoneyViewModel hvm)
        {
            ViewBag.Title = "Сбор меда";
            IEnumerable<Honey> hone = db.Honey.Where(i => i.Hive.Apiary.User.Email.Equals(User.Identity.Name) && i.Hive.Apiary.Id == hvm.Aid && i.Hive.Id == hvm.Hid).OrderByDescending(i => i.Date);
            hvm.Honeys = hone;
            Hive hiv = db.Hives.FirstOrDefault(i => i.Apiary.User.Email.Equals(User.Identity.Name) && i.Apiary.Id == hvm.Aid && i.Id == hvm.Hid);
            hvm.HiveName = hiv.Name;

            if (ModelState.IsValid)
            {
               

               
               

                    Hive courseToUpdate = await db.Hives.FirstOrDefaultAsync(c => c.Apiary.Id == hvm.Aid && c.Id == hvm.Hid);
                    db.Honey.Add(new Honey { Get = hvm.Get, Date = hvm.Date, Hive = courseToUpdate });
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Honey", new { aid = hvm.Aid, hid = hvm.Hid });



            }
            else
            {
                return View(hvm);
            }
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id, int aid, int hid)
        {
            ViewBag.Title = "Сбор меда";
            
            Honey hone = db.Honey.FirstOrDefault(i => i.Id == id && i.Hive.Id == hid && i.Hive.Apiary.Id == aid && i.Hive.Apiary.User.Email.Equals(User.Identity.Name));
            if (hone == null)
            {
                return RedirectToAction("Index", "Honey", new { aid = aid, hid = hid });
            }

            db.Honey.Remove(hone);
            await db.SaveChangesAsync();

           
            return RedirectToAction("Index", "Honey", new { aid = aid, hid = hid });

        }



    }
}