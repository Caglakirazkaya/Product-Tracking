using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Entities
{
    public class UserRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public virtual User Users { get; set; }
        public int RoleID { get; set; }
        public virtual Role Roles { get; set; }
    }
}