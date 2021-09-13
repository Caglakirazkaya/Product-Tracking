using PRODUCT_TRACKING.Models;
using PRODUCT_TRACKING.Models.Entities;
using PRODUCT_TRACKING.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PRODUCT_TRACKING.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        UserManagers um = new UserManagers();
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User loginvalue = c.Users.FirstOrDefault(x => x.username == user.username && x.Password == user.Password);
            if (loginvalue != null && loginvalue.Activity==true)
            {
                FormsAuthentication.SetAuthCookie(loginvalue.username, false);
                Session["UserName"] = loginvalue.username.ToString();
                var Role = c.UserRoles.FirstOrDefault(x => x.Users.Id == loginvalue.Id);                
                if (Role.Roles.RoleName == "Authority")
                {
                    return RedirectToAction("Index", "Authority");
                }
                else if(Role.Roles.RoleName== "Customer")
                {
                    return RedirectToAction("Index", "Customer");
                }
                return RedirectToAction("Index", "Authority");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User users)
        {
            c.Users.Add(users);
            User user=c.Users.FirstOrDefault(u => u.username == users.Name && u.Password == users.Password);
            um.AddCustomer(user);
            c.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}