using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Data
{
    public static class DataSource
    {
        public static List<Book> Books;
        static DataSource()
        {
            Books = new List<Book>()
            {
                new Book {Id = 1,Name ="Book 1",Description = "Book 1 Description" },
                new Book {Id = 2,Name ="Book 2",Description = "Book 2 Description" },
                new Book {Id = 3,Name ="Book 3",Description = "Book 3 Description" },
                new Book {Id = 4,Name ="Book 4",Description = "Book 4 Description" }
            };
        }
    }
}
