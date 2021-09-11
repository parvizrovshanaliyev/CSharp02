using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToXML.Models;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             https://www.c-sharpcorner.com/UploadFile/de41d6/learning-linq-made-easy-linq-to-xml-tutorial-3/
             * LINQ to XML vasitesi ile collection-larimiz icerisindeki datalari
             * asanliqla xml file formasina getire bilerik, xml file-dan datalari oxuyub 
             * application icerisinde istifade ede bilerik.
             *
             * <?xml version="1.0" standalone="yes" encoding="utf-8"?>
               <DataBase>
                  <Persons>
                     <Person Id="1">
                       <Name>Layla</Name>
                       <Surname>Briggs</Surname>
                       <Email>Landon.Taylor@maplin.co</Email>
                       <Country>Indonesia</Country>
                       <City>Chicago</City>
                       <Phone>01426-752564</Phone>
                       <Birthdate>11/15/1989 18:49:32</Birthdate>
                     </Person>
                  </Persons>
               </DataBase>
             */
            // System.XML.LINQ

            var appRoot = AppRoot();

            //XDocument xDocument = new XDocument(
            //    new XDeclaration("1.0", "UTF-8", "yes"),
            //    new XElement("DataBase",
            //        new XElement("Persons",
            //            new XElement("Person", new XAttribute("Id", 1001),
            //                new XElement("Name", "qwqwq"),
            //                new XElement("Surname", "wqwq"),
            //                new XElement("Email", "wqqwqw")
            //                ))));


            //xDocument.Save(appRoot + "/Persons.xml");

            ////////////////////////////////
            #region write
            //List<Person> persons = new List<Person>();

            //for (int i = 1; i <= 100; i++)
            //{
            //    persons.Add(new Person
            //    {
            //        Id = i,
            //        Name = FakeData.NameData.GetFirstName(),
            //        Surname = FakeData.NameData.GetSurname(),
            //        Email = $"{FakeData.NameData.GetFirstName()}.{FakeData.NameData.GetSurname()}@{ FakeData.NetworkData.GetDomain()}"
            //    });
            //}

            //XDocument xDocument1 = new XDocument(
            //    new XDeclaration("1.0", "UTF-8", "yes"),
            //    new XElement("Persons", persons.Select(i =>
            //        new XElement("Person",
            //            new XElement("Id", i.Id),
            //            new XElement("Name", i.Name),
            //            new XElement("Surname", i.Surname),
            //            new XElement("Email", i.Email)))));


            //xDocument1.Save(appRoot + "/Persons1.xml");
            #endregion
            /////////////////////////////////////
            #region read

            //XDocument xDocument = XDocument.Load(appRoot + "/Persons1.xml");

            //var persons = xDocument.Descendants("Person")
            //    .Select(i => new Person
            //{
            //    Id = Convert.ToInt32(i.Element("Id")?.Value),
            //    Name = i.Element("Name")?.Value,
            //    Surname = i.Element("Surname")?.Value,
            //    Email = i.Element("Email")?.Value
            //})
            //    .ToList();

            #endregion
        }
        private static string AppRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher
                .Match(exePath ?? "C:\\Users\\User\\Documents\\GitHub\\C_Sharp\\CSharp-02\\XML\\LinqToXML").Value;
            return appRoot;
        }
    }
}
