using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "UserName")]
        [StringLength(20)]
        public string username { get; set; }

        [Display(Name = "Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "SurName")]
        [StringLength(30)]
        public string Surname { get; set; }


        [Display(Name = "Password")]
        [StringLength(30)]
        public string Password { get; set; }
        public bool Activity { get; set; }

    }
}