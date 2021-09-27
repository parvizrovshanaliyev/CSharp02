using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using PhoneBook.Entities;

namespace PhoneBook.Core.Context
{
    public class PhoneBookDbContext
    {
       
        #region .::ctor::.
        public PhoneBookDbContext()
        {
            _approot = AppRoot();
            _path = Directory.GetParent(_approot)?.FullName + "/PhoneBook.Core/Context";
            _contacts ??= new List<Contact>();
            _users ??= new List<User>();
            EnsureOrCreateDatabase();
            DeserializeObject();
        }
        #endregion
        #region .::fields and properties::.
        private readonly string _path;
        private readonly string _approot;
        private const string usersJson = "/Users.json";
        private const string contactsJson = "/Contacts.json";


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
        #endregion

        private void EnsureOrCreateDatabase()
        {
            /*
             * cari path-de qovlugun olub olmamasini yoxlayiriq 
             */
            
            bool existDir=Directory.Exists(_path);

            if (!existDir)
            {
                Directory.CreateDirectory(_path);
            }

            var path = Directory.GetParent(_approot)?.FullName;
            string coreDLL = $@"{path}\PhoneBook.Core\bin\Debug\net5.0\PhoneBook.Core.dll";

            Assembly assembly = Assembly.LoadFile(coreDLL);

            Type type = assembly.GetType("PhoneBook.Core.Context.PhoneBookDbContext");

            if (type is not null)
            {
                // get props
                var propList = type.GetProperties().ToList();

                propList.ForEach(i =>
                {
                    var filePath = $"{_path}/{i.Name.ToString()}.json";
                    
                    if (!Exists(filePath))
                    {
                        CreateFile(filePath);
                        //SerializeObjToJson(_path + usersJson, users);
                    }
                });
            }

            // new version
            //DataSeeder();

            // old version
            // install nuget Newtonsoft.Json;
            //string userJson = JsonConvert.SerializeObject(users);
            //File.WriteAllText($"{_path}/users.json", userJson);

            //bool control = Exists($"{_path}/contacts.json");
            //if (!control) CreateFile($"{_path}/contacts.json");
        }

        /// <summary>
        /// Db yaradilarken default elave edilecek datalar insert edilir
        /// </summary>
        private void DataSeeder()
        {
            var user = new User
            {
                Username = "admin",
                Password = "admin123!"
            };

            var users = new List<User> { user };
            // new version
            SerializeObjToJson(_path + usersJson, users);
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
            if (Exists($"{_path}{usersJson}"))
            {
                string jsonData = File.ReadAllText(_path + usersJson);
                _users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }

            if (Exists($"{_path}{contactsJson}"))
            {
                string jsonData = File.ReadAllText(_path + contactsJson);
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
            }
        }

        public void SaveChanges()
        {
            if (Contacts.Any() && Contacts != null)
            {
                // new generic
                SerializeObjToJson(_path + contactsJson, _contacts);
                // old
                //string jsonData = JsonConvert.SerializeObject(_contacts);
                //File.WriteAllText(_path + "/contacts.json",jsonData);
            }
        }

        /// <summary>
        /// daxil edilen path-de T tipinde daxil edilen collection-nin json-a map edilmesi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="data"></param>
        private static void SerializeObjToJson<T>(string path, List<T> data)
        {
            // using System.Text.Json;
            string json = System.Text.Json.JsonSerializer.Serialize(data, typeof(List<T>), new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
                WriteIndented = true
            });

            AppendAllText(path, json);
        }

        /// <summary>
        /// daxil edilen path-deki jsona append 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        static void AppendAllText(string path, string data)
        {
            File.AppendAllText(path, data);
        }

        /// <summary>
        /// set as startup project hansidirsa onun base path-ni verir
        /// </summary>
        /// <returns></returns>
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
