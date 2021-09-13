using PRODUCT_TRACKING.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductProcess> ProductProcess { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}