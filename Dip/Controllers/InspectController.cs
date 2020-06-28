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

namespace Dip.Controllers
{
    public class InspectController : Controller
    {
        private AppDBContent db;
        private IInspect _inspect;

        public InspectController(AppDBContent context, IInspect iInspect)
        {
            _inspect = iInspect;
            db = context;


        }
        
        [Authorize]
        public IActionResult Index(int aid, int hid)
        {
            ViewBag.Title = "Статистика улья";
            IEnumerable<Inspect> insp = db.Inspects.Where(i => i.Hive.Apiary.User.Email.Equals(User.Identity.Name) && i.Hive.Apiary.Id == aid && i.Hive.Id == hid).OrderByDescending(i => i.Date);
            Hive hiv = db.Hives.FirstOrDefault(i => i.Apiary.User.Email.Equals(User.Identity.Name) && i.Apiary.Id == aid && i.Id == hid);
            if (hiv == null)
            {
                return RedirectToAction("HiveView", "Apiary", new { id = aid });
            }

            var ins = new InspectViewModel
            {
                HiveName = hiv.Name,
                Inspects= insp,
                Aid = aid,
                Hid = hid,
                


            };
            return View(ins);
        }
    }
}