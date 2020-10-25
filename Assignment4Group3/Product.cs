﻿using System;
namespace Assignment4Group3
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UnitQuantity { get; set; }
        public int UnitPrice { get; set; }
        public int UnitStock { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Category: {Category.Name}";
        }
    }
}