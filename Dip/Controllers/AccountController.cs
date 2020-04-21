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

            IEnumerable<Apiary> api = db.Apiaries.Where(i => i.User.Email.Equals(User.Identity.Name)).OrderBy(i => i.Id);

            var us = new UserViewModel
            { UserInfo = user,
            Apiaries = api};
            ViewBag.Title = "Личный кабинет";
            return View(us);


        }






        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Авторизация";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            ViewBag.Title = "Авторизация";
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация
 
                    return RedirectToAction("About", "Account");
                }
                ModelState.AddModelError("", "Неверный Email и(или) пароль");
            }
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Регистрация";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            ViewBag.Title = "Регистрация";
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
                    ModelState.AddModelError("", "Данный Email уже используется");
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


        [Authorize]
        [HttpGet]
        public  IActionResult Edit()
        {
            

            User user = _user.GetUser(User.Identity.Name);



            var us = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            ViewBag.Title = "Редактирование профиля";
            return View(us);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            ViewBag.Title = "Редактирование профиля";
            User courseToUpdate = await db.Users.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (ModelState.IsValid)
            {
                

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
                        ModelState.AddModelError("", "Данный Email уже используется");
                }
                return View(model);
            }
            model.Name = courseToUpdate.Name;
            model.Email = courseToUpdate.Email;
            model.Password = courseToUpdate.Password;
            return View(model);
        }
            
           
       
        
           


       

       



    }
}