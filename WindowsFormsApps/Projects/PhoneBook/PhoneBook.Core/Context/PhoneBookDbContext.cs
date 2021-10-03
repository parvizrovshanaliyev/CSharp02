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
using PhoneBook.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PhoneBook.Core.Context
{
    public class PhoneBookDbContext : IPhoneBookDbContext
    {
        #region .::ctor::.

        public PhoneBookDbContext()
        {
            _approot = AppRoot();
            _path = Directory.GetParent(_approot)?.FullName + "/PhoneBook.Core/Context";
            EnsureOrCreateDatabase();
            // eger db yaradildiqdan sonra hec bir data olmazsa new instance-lar yaradilir.
            _contacts ??= new List<Contact>();
            _users ??= new List<User>();
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

        /// <summary>
        /// Database evez edecek json file-larin create edilmesi,
        /// Default olaraq evvecelden daxil edilmeli olan datalarin insert edilmesi 
        /// </summary>
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
            var path = Directory.GetParent(_approot)?.FullName;
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

            // old version
            // install nuget Newtonsoft.Json;
            //string userJson = JsonConvert.SerializeObject(users);
            //File.WriteAllText($"{_path}/users.json", userJson);

            //bool control = Exists($"{_path}/contacts.json");
            //if (!control) CreateFile($"{_path}/contacts.json");
        }

        /// <summary>
        ///     Db yaradilarken default elave edilecek datalar insert edilir
        /// </summary>
        private void DataSeeder()
        {
            // Json data-nin Collectiona map edilmesi.
            DeserializeObject();

            if (_users == null)
            {
                var user = new User { Username = "admin", Password = "admin123!" };

                var users = new List<User> { user };
                // new version
                SerializeObjToJson(_path + usersJson, users);
            }
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

        /// <summary>
        ///     Json data-nin Collectiona map edilmesi.
        /// </summary>
        private void DeserializeObject()
        {
            if (Exists($"{_path}{usersJson}"))
            {
                var jsonData = File.ReadAllText(_path + usersJson);
                _users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }

            if (Exists($"{_path}{contactsJson}"))
            {
                var jsonData = File.ReadAllText(_path + contactsJson);
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
            }
        }

        /// <summary>
        /// Collection-larda olan deyiskliklerin yeniden json-a yazilmasi
        /// </summary>
        public void SaveChanges()
        {
            /*
            * Core dll icerisinde PhoneBookDbContext classinin entity-lere
            * uygun gelen collection type olan proplarina uygun json file yaradilir.
            * Bunlar Db-daki cedvellerimizi evez edecek.
            */
            var path = Directory.GetParent(_approot)?.FullName;
            var coreDLL = $@"{path}\PhoneBook.Core\bin\Debug\net5.0\PhoneBook.Core.dll";

            var assembly = Assembly.LoadFile(coreDLL);
            var type = assembly.GetType("PhoneBook.Core.Context.PhoneBookDbContext");

            if (type is not null)
            {
                // get props
                var propList = type.GetProperties().ToList();

                //Get propertyValues for properties that are enumerable (i.e. lists,arrays etc)
                //var collectionProperties = request.GetType()
                //    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                //    .Where(propertInfo => propertInfo.PropertyType.GetInterfaces().Any(x => x == typeof(IEnumerable)))
                //    .Select(p => p.GetValue(request, null))
                //    .Cast<IEnumerable<object>>().ToList();

                var x = propList
                    .Where(i => i.PropertyType.GetInterfaces()
                        .Any(x => x == typeof(IEnumerable)))
                    .Select(i => i.GetValue(null))
                    .Cast<IEnumerable<object>>().ToList();
                propList.ForEach(i =>
                {
                    var propInfo = i;
                });


            }


            if (Contacts.Any() && Contacts != null)
                // new generic
                SerializeObjToJson(_path + contactsJson, _contacts);

            
            // old
            //string jsonData = JsonConvert.SerializeObject(_contacts);
            //File.WriteAllText(_path + "/contacts.json",jsonData);
        }

        /// <summary>
        ///     daxil edilen path-de T tipinde daxil edilen collection-nin json-a map edilmesi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="data"></param>
        private static void SerializeObjToJson<T>(string path, List<T> data)
        {
            // using System.Text.Json;
            var json = JsonSerializer.Serialize(data, typeof(List<T>),
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges
                        .All),
                    WriteIndented = true
                });

            WriteAllText(path, json);
        }

        /// <summary>
        ///     daxil edilen path-deki jsona append
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        private static void WriteAllText(string path, string data)
        {
            File.WriteAllText(path, data);
        }

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

       
    }
}