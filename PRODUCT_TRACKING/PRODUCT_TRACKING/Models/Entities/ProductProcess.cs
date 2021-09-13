using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Entities
{
    public class ProductProcess
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //public virtual List<ProductsReceived> productsReceiveds { get; set; }
        public int productsId { get; set; } 
        public virtual Product products { get; set; }
        public int Number { get; set; }
        public int userId { get; set; }
        public virtual User users { get; set; }
        public DateTime loanDate { get; set; }
        public DateTime estimatedDeliveryDate { get; set; }
        public DateTime deliveryDate { get; set; }
        //public int deliveredUserId { get; set; }
        //public virtual User deliveredUser { get; set; }
        public bool DeliveryStatus { get; set; }
    }
}