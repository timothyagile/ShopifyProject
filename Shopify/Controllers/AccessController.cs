using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopify.Models;

namespace Shopify.Controllers
{
    public class AccessController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("User Name") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]

        public IActionResult Login(TUser user)
        {
            var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
            if(u != null)
            {
                HttpContext.Session.SetString("UserName", user.Username.ToString());
                if(u.LoaiUser == 0)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Index", "admin");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }
    }
}