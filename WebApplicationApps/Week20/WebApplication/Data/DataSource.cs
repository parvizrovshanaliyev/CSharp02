using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Data
{
    public static class DataSource
    {
        public static List<Product> Products;
        static DataSource()
        {
            Products = new List<Product>()
            {
                new Product {Id = 1,Quantity =1,Name = "PRD1" },
                new Product {Id = 2,Quantity =2,Name = "PRD2" },
                new Product {Id = 3,Quantity =3,Name = "PRD3" },
                new Product {Id = 4,Quantity =4,Name = "PRD4" }
            };
        }
    }
}
