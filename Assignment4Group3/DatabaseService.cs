using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Assignment4Group3
{
    public class DataService
    {

        public IList<Product> GetProducts()
        {
            using var ctx = new DatabaseContext();
            return ctx.Products
                .Include(x => x.Category)
                .ToList();
        }
    }
}
