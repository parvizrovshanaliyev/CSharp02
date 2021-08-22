using System;
using System.Collections;

namespace Week7.OOP.Static
{
    #region example 2
    /*
     * Customer class-i yaradin, yaradilan class-in icerisinde static bir
     * ArrayList yaradin.
     *
     * Yaradilan bu arrayList-i database olaraq istifade edeceyik
     *
     * Customer class-da yaradilacaq field ve property-ler.
     * Id
     * Name
     * Surname
     * Email
     * UserName
     * Password
     *
     * bu field-larin bezilerinde encapsulation filter yaradilacaq.
     *
     * 1.Username uygun deyer database icerisinde eger varsa fiel-de
     * bu deyer menimsedilmeyecek.
     *
     * 2. AddCustomer deye static bir method yaradilacaq,
     * parametr olaraq Customer tipi qebul edecek,
     * method icerisinde Customerin null olub olmamasini ve Customer icerisinde
     * olan username-in bos olmamasini yoxlayacagiq.
     *
     * 3. Yuxaridaki sertleri odeyirse yaradilacaq olan Customer
     * database elave edilmeden once email address-i yoxlanacaq
     * eger eyni deyere sahib email db-da varsa elave edile bilmeyecek
     */

    #endregion
    public class Customer
    {
        #region db

        public static ArrayList _database;

        #endregion

        #region ctors

        public Customer()
        {
            //_database = new ArrayList(); // her defe isleyecek 
        }

        static Customer()
        {
            _database = new ArrayList(); // birdefe yarancaq
        }
        #endregion

        #region fields and props
        private string _username;
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Username
        {
            get => _username;

            set
            {

                //bool check=CheckUsername(value)

                if (CheckUsername(value))
                {
                    Console.WriteLine("istifadeci adi artiq movcuddur");
                    _username = string.Empty;
                }
                else
                {
                    _username = value;
                }
            }
        }
        public string Password { get; set; }
        public string Email { get; set; }
        #endregion
        #region methods
        public void AddElement()
        {
            _database = new ArrayList();
        }

        private bool CheckUsername(string username)
        {

            bool control = false;

            foreach (var item in _database)
            {
                Customer tempCustomer = (Customer)item;
                if (tempCustomer != null && tempCustomer.Username == username)
                {
                    control = true;
                    break;
                }

                // pattern matching
                if (item is not Customer customer || customer.Username != username) continue;
                control = true;
                break;


            }

            return control;
        }
        private static bool CheckValue(string value)
        {

            bool control = false;

            foreach (var item in _database)
            {
                Customer tempCustomer = (Customer)item;

                if (tempCustomer != null && tempCustomer.Username == value)
                {
                    control = true;
                    break;
                }
            }

            return control;
        }
        private static bool CheckEmail(string email)
        {

            bool control = false;

            foreach (var item in _database)
            {
                Customer tempCustomer = (Customer)item;

                if (tempCustomer != null && tempCustomer.Username == email)
                {
                    control = true;
                    break;
                }
            }

            return control;
        }

        public static void AddCustomer(Customer customer)
        {
            if (customer != null
                &&!string.IsNullOrEmpty(customer.Username)
                && !string.IsNullOrEmpty(customer.Email) )
            {
                bool emailControl = CheckEmail(customer.Email);

                if (emailControl)
                {
                    Console.WriteLine("movcuddur");
                }
                else
                {
                    _database.Add(customer);
                }
            }
        }
        #endregion

    }
}