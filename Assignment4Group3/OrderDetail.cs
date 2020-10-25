using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment4Group3
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public override string ToString()
        {
            return $"Id: {OrderId}, quantity: {Quantity}";
        }
    }
}
