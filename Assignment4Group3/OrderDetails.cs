using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4Group3
{
    public class OrderDetails
    {
     
        public int ProductId { get; set; }
       
        public int OrderId { get; set; }
     
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public int UnitPrice { get; set; }
        public Product Product { get; set; }
       // public ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            return $"Id: {OrderId}, quantity: {Quantity}, unitprice : {UnitPrice}, discount: {Discount}";
        }
    }
}
