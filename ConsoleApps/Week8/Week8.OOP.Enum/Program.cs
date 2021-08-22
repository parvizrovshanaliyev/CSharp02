using System;
using Week8.PartialClass;

namespace Week8.OOP.Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.Enum
            /*
             * OOP aspektinden baxarken umumilikde yazilan kodlarin setirbesetir uygun ieararxik
             * struktura sahib olgunu gore bilerik , bes bu bize ne qazandirir? daha sade emelliyyatlari
             * eslinde daha sade kod bloklari ile hell ede bilerikmi ? eslinde ede bilerik amma bunun bize
             * avantajdan cox dezavantaj olaraq geri doneceyinide unutmamaliyiq, sebeb yazilan kodlar her zaman
             * inkisaf etdirilmelidir ve bu da ozunde monolit tipli proyektlerin artiq sirketlerde qebul gormus
             * daha cox boyumeye elverisli n layer proyektlere cevrilmesi ile musahide edilir, bu zaman yazilan kodlarin
             * mueyyen prinsiplere esaslanmasi, onceden teyin edilen qaydalarin olmasi butum komonda ucun development
             * prosesini daha suretli ve duzgun qaydada ireliletmeye imkan verir.
             * Meselen evvelceden teyin edilen xeta mesajlarini fikirlesin eger ki bunlar onceden teyin edilmezse
             * proyekt uzerinde isleyen her developer ferqli desti xette malik oldugundan xeta mesajlarini, hetta ugurlu
             * yerine yetirilen emeliyyatlarin neticelerini ferqli yaza biler demekdir. Bunun olmamasi ucun zehmetlide olsa
             * bu problem yaradacaq hisseler evvelceden teyin edilmekdedir. Enum-larinda bu meselede onemli avantajlari vardir.
             *
             *
             * Enumerations kod icerisinde number deyerler ile qarsilastirma aparilan zaman , gelen deyere uygun
             * emeliyyatlari yonlendiren , daha oxunaqli kod yazilmasini temin eden struktura malikdirler.
             *
             * Enum elementlerine baslagic deyer verilmezse 0-dan baslayaraq diger elementleride nomreleyir ve
             * elementin deyeri buna uygun oxuna bilir.
             *
             * Enum-larin default deyer tipi INT-dir, inheritance ile ferqli tiplerlede islemek mumkundur.
             * byte,sbyte, short,ushort, int, uint,long, ulong
             *
             * Deyisenlerin adlandirma qaydasinda oldugu kimi enum icerisindeki elementlerin adlandirmasinda
             * da hemcinin baslangicde reqem ve ya bosluq istifade edile bilmez.
             *
             * https://www.w3schools.com/cs/cs_enums.asp
             * https://www.tutorialsteacher.com/csharp/csharp-enum
             * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
             */
            #endregion

            #region without enum

            User user = new User
            {
                Id = 1,
                Username = "Username",
                Type = 1
            };
            User user2 = new User
            {
                Id = 2,
                Username = "Username2",
                Type = 2
            };

            if (user.Type == 1)
            {
                Console.WriteLine("admin");
            }else if (user.Type == 2)
            {
                Console.WriteLine("s User");
            }

            if (user2.Type == 1)
            {

            }
            else if (user2.Type == 2)
            {

            }
            #endregion

            #region with enum

            UserWithEnum user3 = new UserWithEnum
            {
                Id = 1,
                Username = "U",
                Type = UserType.Admin
            };
            UserWithEnum user4 = new UserWithEnum
            {
                Id = 1,
                Username = "U",
                Type =(UserType) 1
            };


            if (user3.Type == UserType.Admin)
            {
                Console.WriteLine("admin");
            }
            else if (user3.Type == UserType.User)
            {
                Console.WriteLine("s User");
            }
            #endregion

            #region Converts int to enum values

            Days day = (Days)System.Enum.ToObject(typeof(Days), 3);
            #endregion

            #region Convert a string to an enum

            string wednesday = "Wednesday";

            Days day3 = (Days) System.Enum.Parse(typeof(Days), wednesday);

            if (day3 == Days.Wednesday)
            {
                Console.WriteLine(day3.ToString());
            }
            #endregion

            #region foreach

            foreach (var item in System.Enum.GetNames(typeof(Days)))
            {
                Console.WriteLine(item.ToString());
            }

            #endregion

            #region switch

            switch (day3)
            {
                case Days.Friday:
                    Console.WriteLine(Days.Friday);
                    break;
                case Days.Monday:
                    break;
            }
            #endregion
            #region examples

            #region 1.

            Customer customer = new Customer
            {
                Id = 1,
                Name = "Customer1",
                Surname = "Customer1",
                Email = "Customer1@gmail.com",
            };
            var result = customer.Add(customer);

            if (result == CRUDResult.Success)
            {
                const string addMessage = "insert ugurla yerine yetirildi";

                Console.WriteLine(CRUDMessages.addM);
            }
            else if(result == CRUDResult.Fail)
            {
                Console.WriteLine(CRUDMessages.failMessage);
            }

            #endregion


            #endregion
        }
    }

    #region without enum

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte Type { get; set; } // type = 1 admin , =2 standart user 
    }
    
    #endregion

    #region with enum

    public class UserWithEnum
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserType Type { get; set; } 
    }

    // Usertype
    // name   type byte 
    //   Admin  1
    //   user   2
    #endregion

    #region examples

    #region 1.

    public class Customer
    {
        #region ctor

        public Customer()
        {

        }
        #endregion
        #region props

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int CustomerNo { get; set; }
        public DateTime BirthDate { get; set; }

        #endregion

        #region methods

        
        public CRUDResult Add(Customer customer)
        {
            //
            Console.WriteLine("database insert olunur");

            return CRUDResult.Success;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int Update(Customer customer)
        {
            var result = 1; //_database.add(customer);
            // db daki obyektiizi redakte edirik
            Console.WriteLine("database redakte olunur");

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int: result</returns>
        public int Delete(int id)
        {
            var result = 1;
            //
            Console.WriteLine("db daki obyekt silinir");
            return result;
        }
        #endregion
    }

    #endregion

    #endregion
}
