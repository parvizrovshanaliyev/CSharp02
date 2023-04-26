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
                new() {Name ="Book 1",Description = "Book 1 Description" },
                new() {Name ="Book 2",Description = "Book 2 Description" },
                new() {Name ="Book 3",Description = "Book 3 Description" },
                new() {Name ="Book 4",Description = "Book 4 Description" }
            };
        }
    }
}
