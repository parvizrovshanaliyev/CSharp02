using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using LinqToXML.Models;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string appRoot = AppRoot();

            // write
            // write
            List<Person> persons = new List<Person>();

            for (int i = 1; i <= 100; i++)
            {
                persons.Add(new Person
                {
                    Id = i,
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = $"{FakeData.NameData.GetFirstName()}.{FakeData.NameData.GetSurname()}@{ FakeData.NetworkData.GetDomain()}"
                });
            }

            using var mem = new MemoryStream();
            using var writer = new StreamWriter(mem);
            // install CsvHelper nuget package
            using var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteField("Id");
            csvWriter.WriteField("Name");
            csvWriter.WriteField("Surname");
            csvWriter.WriteField("Email");
            csvWriter.NextRecord();

            foreach (var person in persons)
            {
                csvWriter.WriteField(person.Id);
                csvWriter.WriteField(person.Name);
                csvWriter.WriteField(person.Surname);
                csvWriter.WriteField(person.Email);
                csvWriter.NextRecord();
            }

            writer.Flush();
            var result = Encoding.UTF8.GetString(mem.ToArray());
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
