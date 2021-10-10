using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Linq;
using CsvHelper;
using Newtonsoft.Json;
using PhoneBook.Business.Enums;
using PhoneBook.Core.Repository;
using PhoneBook.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PhoneBook.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private static string _exportPath;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _exportPath = @"C:\Users\Asus\Documents\GitHub\CSharp02\WindowsFormsApps\Projects\PhoneBook\PhoneBook.Core\Context\export";
        }

        #region Implementation of IContactService

        #region add , update , delete

        public int Add(Contact entity)
        {
            int result = 0;

            if (ContactValidations(entity))
            {
                result = _contactRepository.Add(entity);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }
        public int Update(Contact request)
        {
            int result = 0;

            if (UpdateContactValidations(request))
            {
                result = _contactRepository.Update(request);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }
        public int Delete(Guid id)
        {
            int result = 0;

            if (DeleteContactValidations(id))
            {
                result = _contactRepository.Delete(id);
            }
            else
            {
                result = (int)ResultCodeEnums.ModelStateNoValid;
            }

            return result;
        }

        #region validations

        private bool ContactValidations(Contact entity)
        {
            return !string.IsNullOrEmpty(entity.Name)
                   && !string.IsNullOrEmpty(entity.Surname)
                   && !string.IsNullOrEmpty(entity.Number1);
        }
        private bool UpdateContactValidations(Contact entity)
        {
            return entity.Id != Guid.Empty
                   && !string.IsNullOrEmpty(entity.Name)
                   && !string.IsNullOrEmpty(entity.Surname)
                   && !string.IsNullOrEmpty(entity.Number1);
        }
        private bool DeleteContactValidations(Guid id)
        {
            return id != Guid.Empty;
        }

        #endregion

        #endregion

        #region queries
        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
        #endregion

        #region export & import

        public int ExportXML()
        {
            int result = 0;
            try
            {
                var entities = _contactRepository.GetAll();
                XDocument document = new XDocument(
                    new XDeclaration("1.0.0.1", "UTF-8", "yes"),
                    new XElement("Contacts", entities.Select(i =>
                        new XElement("Contact",
                            new XElement("Id", i.Id),
                            new XElement("Name", i.Name),
                            new XElement("Surname", i.Surname),
                            new XElement("Address", i.Address),
                            new XElement("Description", i.Description),
                            new XElement("Email", i.Email),
                            new XElement("Website", i.Website),
                            new XElement("Number1", i.Number1),
                            new XElement("Number2", i.Number2),
                            new XElement("Number3", i.Number3)))));

                document.Save(_exportPath+"Contacts.xml");
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return result;
        }

        public int ExportCSV()
        {
            int result = 0;
            try
            {
                var entities = _contactRepository.GetAll();
                
                using (var writer = new StreamWriter(_exportPath + "Contacts.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Contact>();
                    csv.NextRecord();
                    foreach (var record in entities)
                    {
                        csv.WriteRecord(record);
                        csv.NextRecord();
                    }
                }

                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return result;
        }

        public int ExportJSON()
        {
            int result = 0;
            try
            {
                var entities = _contactRepository.GetAll();

                SerializeObjToJson("Contacts.json", entities);

                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return result;
        }
        private static void SerializeObjToJson<T>(string fileName, List<T> data)
        {
            // using System.Text.Json;
            var json = JsonSerializer.Serialize(data, typeof(List<T>),
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges
                        .All),
                    WriteIndented = true
                });

            File.WriteAllText(_exportPath + fileName, json);
        }
        #endregion
        #endregion
    }
}
