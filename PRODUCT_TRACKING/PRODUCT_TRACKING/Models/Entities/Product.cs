using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public string ProductSerialNumber { get; set; }

        public bool Stock { get; set; }

        //public int SumNumber { get; set; }
        public string Explanation { get; set;}
    }
}