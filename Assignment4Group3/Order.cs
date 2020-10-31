using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4Group3
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateShipped { get; set; }
        public DateTime Required { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Order id: {Id} " +
                   $"on date: {Date.Year}-{Date.Month}-{Date.Day}" +
                   $"date shipped: {DateShipped.Year}-{DateShipped.Month}-{DateShipped.Day} " +
                   $"date required: {Required.Year}-{Required.Month}-{Required.Day} " +
                   $"freight: {Required.Year}-{Required.Month}-{Required.Day} " +
                   $"ship name: {ShipName} " +
                   $"ship city: {ShipCity} " +
                   $"order details: {OrderDetails}";
        }
    }
}
