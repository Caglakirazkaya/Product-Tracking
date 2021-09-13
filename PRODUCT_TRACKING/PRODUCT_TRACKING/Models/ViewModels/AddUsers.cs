using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.ViewModels
{
    public class AddUsers
    {
        
        public string username { get; set; }

        
        public string Name { get; set; }

        
        public string Surname { get; set; }


        public string Password { get; set; }

        public bool Authority { get; set; }
    }
}