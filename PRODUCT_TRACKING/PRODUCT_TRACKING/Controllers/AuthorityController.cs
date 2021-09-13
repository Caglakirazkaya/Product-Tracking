using PRODUCT_TRACKING.Models;
using PRODUCT_TRACKING.Models.Entities;
using PRODUCT_TRACKING.Models.Managers;
using PRODUCT_TRACKING.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRODUCT_TRACKING.Controllers
{
    [Authorize(Roles = "Authority")]
    public class AuthorityController : Controller
    {
        UserManagers um = new UserManagers();
        ProductProcessesManagers productProcessManagers = new ProductProcessesManagers();
        Context c = new Context();
        // GET: Authority
        public ActionResult Index()
        {
            var products = c.Product.ToList();
            return View(products);
        }

        [HttpPost]
        public JsonResult AddProduct(Product products)
        {
            products.Stock = true;
            c.Product.Add(products);
            c.SaveChanges();
            int productID = c.Product.Max(u => u.ID);
            return Json(productID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(Product products)
        {
            Product removeProduct= c.Product.Find(products.ID);
            c.Product.Remove(removeProduct);
            c.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Onloan()
        {
            var ProductProcess = productProcessManagers.GetListOnload();
            return View(ProductProcess);
        }

        [HttpPost]
        public JsonResult ProductTakeDelivery(ProductProcess productProcess)
        {
            var updateProduct = c.ProductProcess.Find(productProcess.ID);            
            updateProduct.DeliveryStatus = true;
            updateProduct.deliveryDate = DateTime.Now;
            c.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult History()
        {
            return View(productProcessManagers.GetListHistory());
        }

        public ActionResult ActivityUser()
        {            
            return View(um.ActivtyUser());
        }
        [HttpPost]
        public JsonResult Activate(User Users)
        {
            var updateUser = c.Users.Find(Users.Id);
            updateUser.Activity = true;
            c.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AuthorityUser()
        {
            return View(um.ListUser());
        }
        [HttpPost]
        public JsonResult DeleteUser(User users)
        {
            User removeUser = c.Users.Find(users.Id);
            c.Users.Remove(removeUser);
            c.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUser(AddUsers users)
        {
            User newUser = new User();
            newUser.Name = users.Name;
            newUser.Surname = users.Surname;
            newUser.username = users.username;
            newUser.Password = users.Password;
            newUser.Activity = true;
            c.Users.Add(newUser);
            c.SaveChanges();
            newUser.Id = c.Users.Max(u => u.Id);
            if (users.Authority==true)
            {
                um.AddAuthority(newUser);
            }
            else
            {
                um.AddCustomer(newUser);
            }
            
            return Json(newUser.Id, JsonRequestBehavior.AllowGet);
        }

    }
}