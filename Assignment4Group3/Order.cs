using System;
namespace Assignment4Group3
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateShipped { get; set; }
        public DateTime DateRequired { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }

        public override string ToString()
        {
            return $"Order id: {Id} " +
                   $"on date: {DateOrder.Year}-{DateOrder.Month}-{DateOrder.Day}" +
                   $"date shipped: {DateShipped.Year}-{DateShipped.Month}-{DateShipped.Day} " +
                   $"date required: {DateRequired.Year}-{DateRequired.Month}-{DateRequired.Day} " +
                   $"freight: {DateRequired.Year}-{DateRequired.Month}-{DateRequired.Day} " +
                   $"ship name: {ShipName} " +
                   $"ship city: {ShipCity} ";
        }
    }
}
