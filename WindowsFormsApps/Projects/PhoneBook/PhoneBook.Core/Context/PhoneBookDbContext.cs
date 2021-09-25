using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using PhoneBook.Entities;

namespace PhoneBook.Core.Context
{
    public class PhoneBookDbContext
    {
        private readonly string _path;
        public PhoneBookDbContext()
        {
            var appRoot = AppRoot();
            _path = appRoot + "/" + "Context";
            
            ExistDatabase();
            DeserializeObject();
            _contacts ??= new List<Contact>();
            _users ??= new List<User>();
        }
        private static List<Contact> _contacts;
        public List<Contact> Contacts
        {
            get => _contacts;
            set => _contacts = value;
        }

        private static List<User> _users;

        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        private void ExistDatabase()
        {
            /*
             * cari path-de qovlugun olub olmamasini yoxlayiriq 
             */
            
            bool existDir=Directory.Exists(_path);

            if (!existDir)
            {
                Directory.CreateDirectory(_path);
            }
            else
            {
                var user = new User
                {
                    Username = "admin",
                    Password = "admin123!"
                };

                var users = new List<User> { user };
                // install nuget Newtonsoft.Json;
                string userJson = JsonConvert.SerializeObject(users);
                File.WriteAllText($"{_path}/users.json", userJson);

                bool control = Exists($"{_path}/contacts.json");
                if (!control) CreateFile($"{_path}/contacts.json");
            }
        }
        static void CreateFile(string path)
        {
            FileStream fileStream = File.Create(path);
            fileStream.Close();
        }
        static bool Exists(string path)
        {
            return File.Exists(path);
        }
        private void DeserializeObject()
        {
            if (Exists($"{_path}/users.json"))
            {
                string jsonData = File.ReadAllText(_path + "/users.json");
                _users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }

            if (Exists($"{_path}/contacts.json"))
            {
                string jsonData = File.ReadAllText(_path + "/contacts.json");
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
            }

            
        }
        public void SaveChanges()
        {
            if (Contacts.Any() && Contacts != null)
            {
                string jsonData = JsonConvert.SerializeObject(_contacts);
                File.WriteAllText(_path + "contacts.json",jsonData);
            }
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
