using PRODUCT_TRACKING.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Managers
{
    public class ProductProcessesManagers
    {
        Context c = new Context();

        public void AddProductProcesses(Product product, int TimeID,User users)
        {
            ProductProcess productProcess = new ProductProcess();
            productProcess.productsId = product.ID;            
            productProcess.Number = 1;
            productProcess.userId = users.Id;
            //productProcess.UserId= users.Id;
            productProcess.loanDate = DateTime.Now;
            productProcess.estimatedDeliveryDate = productProcess.loanDate.AddDays(TimeID);
            productProcess.deliveryDate = DateTime.Now;
            //productProcess.deliveredUserId = 0;
            productProcess.DeliveryStatus = false;
            c.ProductProcess.Add(productProcess);
            c.SaveChanges();
        }

        public List<ProductProcess> GetList(string username)
        {
            List<ProductProcess> getproductProcesses= c.ProductProcess.ToList();
            List<ProductProcess> productProcesses = (from i in getproductProcesses.ToList()
                                       where i.users.username == username && i.DeliveryStatus==false
                                       select new ProductProcess
                                       {
                                           ID = i.ID,
                                           //UserId=i.users.Id,
                                           //deliveredUserId=i.deliveredUser.Id,
                                           deliveryDate=i.deliveryDate,
                                           estimatedDeliveryDate=i.estimatedDeliveryDate,
                                           loanDate=i.loanDate,
                                           Number=i.Number,
                                           products=i.products                                           
                                       }).ToList();

            return productProcesses;
        }

        public List<ProductProcess> GetListHistory(string username)
        {
            List<ProductProcess> getproductProcesses = c.ProductProcess.ToList();
            List<ProductProcess> productProcesses = (from i in getproductProcesses.ToList()
                                                     where i.users.username == username && i.DeliveryStatus == true
                                                     select new ProductProcess
                                                     {
                                                         ID = i.ID,
                                                         users = i.users,
                                                         //deliveredUser = i.deliveredUser,
                                                         deliveryDate = i.deliveryDate,
                                                         estimatedDeliveryDate = i.estimatedDeliveryDate,
                                                         loanDate = i.loanDate,
                                                         Number = i.Number,
                                                         products = i.products
                                                     }).ToList();

            return productProcesses;
        }

        public List<ProductProcess> GetListHistory()
        {
            List<ProductProcess> getproductProcesses = c.ProductProcess.ToList();
            List<ProductProcess> productProcesses = (from i in getproductProcesses.ToList()
                                                     where i.DeliveryStatus == true
                                                     select new ProductProcess
                                                     {
                                                         ID = i.ID,
                                                         users = i.users,
                                                         //deliveredUser = i.deliveredUser,
                                                         deliveryDate = i.deliveryDate,
                                                         estimatedDeliveryDate = i.estimatedDeliveryDate,
                                                         loanDate = i.loanDate,
                                                         Number = i.Number,
                                                         products = i.products
                                                     }).ToList();

            return productProcesses;
        }
        public List<ProductProcess> GetListOnload()
        {
            List<ProductProcess> getproductProcesses = c.ProductProcess.ToList();
            List<ProductProcess> productProcesses = (from i in getproductProcesses.ToList()
                                                     where i.DeliveryStatus == false
                                                     select new ProductProcess
                                                     {
                                                         ID = i.ID,
                                                         //userId=i.userId,
                                                         users=i.users,
                                                         //deliveredUserId=i.deliveredUser.Id,
                                                         deliveryDate = i.deliveryDate,
                                                         estimatedDeliveryDate = i.estimatedDeliveryDate,
                                                         loanDate = i.loanDate,
                                                         Number = i.Number,
                                                         products = i.products
                                                     }).ToList();

            return productProcesses;
        }


    }
}