using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4Group3
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }

    }
}
