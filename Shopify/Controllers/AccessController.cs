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
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Register(TUser user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                var existingUser = db.TUsers.FirstOrDefault(x => x.Username == user.Username);
                if (existingUser == null)
                {
                    // Lưu người dùng mới vào database
                    db.TUsers.Add(user);
                    db.SaveChanges();
                    // Đăng ký thành công thì chuyển hướng tới trang Login
                    return RedirectToAction("Login", "Access");
                }
                else
                {
                    ModelState.AddModelError("Username", "Tên người dùng đã tồn tại.");
                }
            }
            return View(user);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }
    }
}