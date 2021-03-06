﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4Group3
{
    public class Order
    {
        public Order()
        {
            Date = default(DateTime);
            DateShipped = default(DateTime);
            Required = default(DateTime);

        }

        public Order(int id, DateTime? date, DateTime? dateShipped, DateTime? required, int freight, string shipName, string shipCity, ICollection<OrderDetails> orderDetails)
        {
            Id = id;
            Date = date;
            DateShipped = dateShipped;
            Required = required;
            Freight = freight;
            ShipName = shipName;
            ShipCity = shipCity;
            OrderDetails = orderDetails;
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateShipped { get; set; }
        public DateTime? Required { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

     
        public override string ToString()
        {
            return $"Order id: {Id} " +
                   $"on date: {Date.Value.Year}-{Date.Value.Month}-{Date.Value.Day}" +
                   $"date shipped: {DateShipped.Value.Year}-{DateShipped.Value.Month}-{DateShipped.Value.Day} " +
                   $"date required: {Required.Value.Year}-{Required.Value.Month}-{Required.Value.Day} " +
                   $"freight: {Freight}" +
                   $"ship name: {ShipName} " +
                   $"ship city: {ShipCity} "+
                  $"order details: {OrderDetails.First()}";
        }
    }
}
