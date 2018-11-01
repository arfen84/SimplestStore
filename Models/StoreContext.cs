using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loudclothes.net.Models
{
    public class StoreContext : DbContext
    {
        // public StoreContext() : base("DefaultConnection")   
        public StoreContext() : base("DefaultConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AppUser> Users { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
    }
}
