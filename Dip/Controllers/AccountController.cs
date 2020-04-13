using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dip.Data;
using Dip.Data.Interfaces;
using Dip.Data.Models;
using Dip.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dip.Controllers
{
    public class AccountController : Controller
    {
        private IUser _user;
         private AppDBContent db;
        public AccountController(AppDBContent context, IUser use)
        {
            _user = use;
            db = context;
        }


        [Authorize]
        public ViewResult About()
        {
            User user = _user.GetUser(User.Identity.Name);


            
            var us = new UserViewModel
            { UserInfo = user };
            ViewBag.Title = "Личный кабинет";
            return View(us);


        }






        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация
 
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные Email и(или) пароль");
            }
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User {Name=model.Name , Email = model.Email, Password = model.Password });
                    await db.SaveChangesAsync();
 
                    await Authenticate(model.Email); // аутентификация
 
                    return RedirectToAction("About", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные Email, Имя и(или) пароль");
            }
            return View(model);
        }
 
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterModel model)
        {
            if (ModelState.IsValid)
            {


                User courseToUpdate = await db.Users.FirstOrDefaultAsync(c => c.Email == User.Identity.Name.ToString());

                if (model.Email == courseToUpdate.Email)
                {



                    await TryUpdateModelAsync<User>(courseToUpdate, "", c => c.Name, c => c.Email, c => c.Password);
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("About", "Account");

                }
                else
                {
                    courseToUpdate = await db.Users.FirstOrDefaultAsync(c => c.Email == model.Email);



                    if (courseToUpdate == null)
                    {
                        courseToUpdate = await db.Users.FirstOrDefaultAsync(c => c.Email == User.Identity.Name.ToString());
                        courseToUpdate.Email = model.Email;
                        courseToUpdate.Name = model.Name;
                        courseToUpdate.Password = model.Password;

                        await TryUpdateModelAsync<User>(courseToUpdate, "", c => c.Name, c => c.Email, c => c.Password);
                        await db.SaveChangesAsync();

                        await Authenticate(model.Email); // аутентификация

                        return RedirectToAction("About", "Account");
                    }
                    else
                        ModelState.AddModelError("", "Некорректные Email, Имя и(или) пароль");
                }
            }
            return View(model);
        }
            
           
       
        
            ////db.Users.Update(user);
            //await db.SaveChangesAsync();
            ////await Logout();
            ////await Authenticate(courseToUpdate.Email);
            //return View(courseToUpdate);



       

        public async Task<IActionResult> Details()
        {
            if (User.Identity.Name == null)
            {
                return NotFound();
            }

            var course = await db.Users.AsNoTracking().FirstOrDefaultAsync(m => m.Email == User.Identity.Name);
                               
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }



    }
}