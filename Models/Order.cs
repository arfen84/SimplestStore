using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loudclothes.net.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }

        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public bool Paid { get; set; }

//we can add string prperty UserName or Email and assign email from AppUser class to show it in grid
    }

    public enum OrderState
    {
        New,
        Shipped
    }
}
