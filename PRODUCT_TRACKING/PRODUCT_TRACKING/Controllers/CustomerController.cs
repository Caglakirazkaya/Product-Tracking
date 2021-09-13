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
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        ProductProcessesManagers productProcessesManagers = new ProductProcessesManagers();
        Context c = new Context();
    
        public ActionResult Index()
        {
            var products = c.Product.ToList();
            return View(products);
        }

        public ActionResult TakeProduct(int? ID)
        {  
            if(ID==null)
            {
                return RedirectToAction("Index");
            }
            return View(c.Product.FirstOrDefault(x=>x.ID==ID));
        }
        [HttpPost]
        public ActionResult TakeProduct(Product product, int TimeID)
        {
            product = c.Product.FirstOrDefault(x => x.ID == product.ID);
            string name = Session["UserName"].ToString();            
            User user = c.Users.FirstOrDefault(x => x.username == name);
            productProcessesManagers.AddProductProcesses(product, TimeID, user);
            return RedirectToAction("ItemsIborrowed");
        }

        public ActionResult ItemsIborrowed()
        {
            if(Session["UserName"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(productProcessesManagers.GetList(Session["UserName"].ToString()));
        }

        public ActionResult History()
        {
            return View(productProcessesManagers.GetListHistory(Session["UserName"].ToString()));
        }
    }
}