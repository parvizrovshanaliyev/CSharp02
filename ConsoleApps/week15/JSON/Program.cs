using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using FakeData;
using LinqToXML.Models;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            // write
            #region write

            //List<Person> persons = new List<Person>();

            //for (int i = 1; i <= 100; i++)
            //{
            //    persons.Add(new Person
            //    {
            //        Id = i,
            //        Name = NameData.GetFirstName(),
            //        Surname = NameData.GetSurname(),
            //        Email = $"{NameData.GetFirstName()}.{NameData.GetSurname()}@{ NetworkData.GetDomain()}"
            //    });
            //}

            //string json = JsonSerializer.Serialize(persons, typeof(List<Person>), new JsonSerializerOptions()
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            //    WriteIndented = true
            //});

            //File.WriteAllText(AppRoot() + "/persons.json", json);

            #endregion
            // read
            #region read

            string data = File.ReadAllText(AppRoot() + "/persons.json");

            var persons = JsonSerializer.Deserialize<List<Person>>(data);

            #endregion
        }
        private static string AppRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher
                .Match(exePath ?? string.Empty).Value;
            return appRoot;
        }
    }
}
