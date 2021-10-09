using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneBook.Entities;
using static Newtonsoft.Json.JsonConvert;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PhoneBook.Core.Context
{
    public class PhoneBookDbContext
    {
        #region .::ctor::.

        public PhoneBookDbContext()
        {
            Approot = AppRoot();
            _path = Directory.GetParent(Approot)?.FullName + "/PhoneBook.Core/Context/";
            EnsureOrCreateDatabaseV2();
            #region old version

            //EnsureOrCreateDatabase();
            // eger db yaradildiqdan sonra hec bir data olmazsa new instance-lar yaradilir.
            // old version
            //_contacts ??= new List<Contact>();
            //_users ??= new List<User>();

            #endregion
        }

        #endregion

        #region .::fields and properties::.

        private static string _path;
        public static string Approot { get; private set; }

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


        #region EnsureOrCreateDatabaseV2
        public static List<T> Deserialize<T>(string SerializedJSONString)
        {
            var stuff = DeserializeObject<List<T>>(SerializedJSONString);
            return stuff;
        }
        /// <summary>
        /// Database evez edecek json file-larin create edilmesi,
        /// Default olaraq evvecelden daxil edilmeli olan datalarin insert edilmesi 
        /// </summary>
        private void EnsureOrCreateDatabaseV2()
        {
            /*
             * cari path-de qovlugun olub olmamasini yoxlayiriq 
             */

            var existDir = Directory.Exists(_path);

            if (!existDir) Directory.CreateDirectory(_path);

            // this : PhoneBookDbContext
            var propertyInfos = GetGenericListProperties(this).ToList();

            if (propertyInfos.Any())
            {
                foreach (var info in propertyInfos)
                {
                    var propertyType = info.PropertyType.GetGenericArguments()[0];
                    
                    // prop adina uygun json fileName
                    var filePath = $"{_path}{propertyType.Name}.json";
                    if (!Exists(filePath)) CreateFile(filePath);

                    var jsonData = ReadAllText(filePath);

                    Type listType = typeof(List<>).MakeGenericType(new Type[] { propertyType });
                    
                    var result = JsonConvert.DeserializeObject(jsonData, listType);

                    if (result != null)
                    {
                        info.SetValue(this, result, null);
                    }
                    else
                    {
                        Type type = typeof(List<>);
                        Type makeGenericType = type.MakeGenericType(propertyType);
                        object obj = Activator.CreateInstance(makeGenericType);
                        info.SetValue(this, obj, null);
                    }
                }

                DataSeederV2();
            }
        }

       

        #region old version

        private void EnsureOrCreateDatabase()
        {
            /*
             * cari path-de qovlugun olub olmamasini yoxlayiriq 
             */

            var existDir = Directory.Exists(_path);

            if (!existDir) Directory.CreateDirectory(_path);
            /*
             * Core dll icerisinde PhoneBookDbContext classinin entity-lere
             * uygun gelen collection type olan proplarina uygun json file yaradilir.
             * Bunlar Db-daki cedvellerimizi evez edecek.
             */
            var path = Directory.GetParent(Approot)?.FullName;
            var coreDLL = $@"{path}\PhoneBook.Core\bin\Debug\net5.0\PhoneBook.Core.dll";

            var assembly = Assembly.LoadFile(coreDLL);
            var type = assembly.GetType("PhoneBook.Core.Context.PhoneBookDbContext");

            if (type is not null)
            {
                // get props
                var propList = type.GetProperties().ToList();

                propList.ForEach(i =>
                {
                    // prop adina uygun json fileName
                    var filePath = $"{_path}/{i.Name.ToString()}.json";

                    if (!Exists(filePath)) CreateFile(filePath);
                });
            }

            // new version
            DataSeeder();
        }

        #endregion

        #endregion


        #region GetGenericListProperties

        private IEnumerable<PropertyInfo> GetGenericListProperties(object model)
        {
            return (model.GetType().GetProperties().Where(t => t.PropertyType.ToString().Contains("List"))).Where(u => u.PropertyType.IsPublic && u.PropertyType.IsGenericType);
        }

        #endregion

        #region DataSeeder

        /// <summary>
        ///     Db yaradilarken default elave edilecek datalar insert edilir
        /// </summary>
        private void DataSeederV2()
        {
            if (_users.Any()) return;
            var user = new User { Username = "admin", Password = "admin123!" };
            _users.Add(user);
            var fileName = user.GetType().Name + ".json";
            SerializeObjToJson(fileName, _users);
        }

        #region old version

        private void DataSeeder()
        {
            // Json data-nin Collectiona map edilmesi.
            // DeserializeObject();

            if (_users == null)
            {
                var user = new User { Username = "admin", Password = "admin123!" };

                var users = new List<User> { user };
                var fileName = user.GetType().Name;

                SerializeObjToJson(usersJson, users);
            }
        }

        #endregion

        #endregion

        #region File helper methods
        /// <summary>
        ///     daxil edilen path-deki jsona append
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        private static void WriteAllText(string fileName, string data)
        {
            File.WriteAllText(_path + fileName, data);
        }
        private static string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        private static void CreateFile(string path)
        {
            var fileStream = File.Create(path);
            fileStream.Close();
        }
        private static bool Exists(string path)
        {
            return File.Exists(path);
        }

        #endregion

        #region DeserializeObject old version

        /// <summary>
        ///     Json data-nin Collectiona map edilmesi.
        /// </summary>
        private void DeserializeObject()
        {
            if (Exists($"{_path}{usersJson}"))
            {
                var jsonData = File.ReadAllText(_path + usersJson);
                _users = DeserializeObject<List<User>>(jsonData);
            }

            if (Exists($"{_path}{contactsJson}"))
            {
                var jsonData = File.ReadAllText(_path + contactsJson);
                _contacts = DeserializeObject<List<Contact>>(jsonData);
            }
        }

        #endregion

        #region SaveChanges

        /// <summary>
        /// Collection-larda olan deyiskliklerin yeniden json-a yazilmasi
        /// </summary>
        public void SaveChanges<T>(List<T> data)
        {
            if (!data.Any()) return;
            var fileName = data.GetType().GetGenericArguments()[0].Name+".json";
            SerializeObjToJson(fileName, data);
        }

        #endregion

        #region SerializeObjToJson

        /// <summary>
        ///     daxil edilen path-de T tipinde daxil edilen collection-nin json-a map edilmesi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
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

            WriteAllText(fileName, json);
        }

        #endregion

        #region AppRoot

        /// <summary>
        ///     set as startup project hansidirsa onun base path-ni verir
        /// </summary>
        /// <returns></returns>
        private static string AppRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath ?? string.Empty).Value;
            return appRoot;
        }

        #endregion

    }
}