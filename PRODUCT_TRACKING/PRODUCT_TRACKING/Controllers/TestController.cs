using PRODUCT_TRACKING.Models;
using PRODUCT_TRACKING.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRODUCT_TRACKING.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Context context = new Context();
            User k = new User()
            {
                username = "admin",
                Name = "Admin",
                Password = "adminyzk123",
                Activity = true,
                Surname = "Admins"
            };
            UserRole role = new UserRole()
            {
                Users = k,
                Roles = new Role()
                {
                    RoleName = "Authority"
                }
            };
            context.UserRoles.Add(role);
            context.SaveChanges();
            return View();
        }
    }
}