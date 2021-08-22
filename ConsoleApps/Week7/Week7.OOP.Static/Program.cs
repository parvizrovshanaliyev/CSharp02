using System;
using static System.Console;
namespace Week7.OOP.Static
{

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            ReadLine();
            #region OOP.Static
            /*
             *
             *                 * Object Oriented Programming
             *                 * -Static
             *                 *
             *                 *           =============RAM================
             *                 *           =             =                =
             *                 *           =  Stack      =   Heap         =
             *                 *           =             =                =
             *                 *           =  Value Type = Reference Type =
             *                 *           =             =                 =
             *                 *           =             =                =
             *                 *           =             =                =
             *                 *           ================================
             *                 *           =           STATIC             =
             *                 *           ================================
             *
             * Static member elements
             *
             * static memeber-ler bir class-in global seviyyede olan member-leridir desek
             * yanilmariq , yeni bu memberleri istifade etmek ucun her hansisa bir obyekt
             * yaratmagimiza ehtiyyac yoxdur.
             * Her defe class-dan yeni instance alinan zaman her static ucun ram-da ayri ayri yer
             * ayrilmaz.
             *
             * c# kitabkanasinda olan Math class-i static-dir ve instance alinmadan riyazi
             * emeliyyatlar aparmaq ucun istifade ede bilirik.
             *
             *
             * static keyword-nu access modifier-den once ve ya sonra teyin etmeyimiz bir
             * ferq yaratmir lakin umumi olaraq access modifier onde gelir.
             *
             * Bir static method icerisinde basqa bir static olan method cagirila biler lakin normal
             * methodlar cagirila bilmez. Cunki normal methodlara reach eden zaman bize classdan bir
             * instance almagimiz mutleqdir.
             *
             * *static field
             * Static deyisenler umumilikde bir class-da global seviyyede istifade ucun nezerde tutulmusdur.
             * meselen : bir class-da birden cox method eyni ozelliyi istifade etdikde.
             *
             * Static deyisen teyin olan zaman tipine gore default deyer almaqdadir.
             * Static fied-lere ancaq static bir method icerisinde reach ede bilerik.
             *
             * *Static ctor
             * Standart bildiyimiz methodlar kimi ctor-da static ola bilmekdedir.
             * Static ctor bir class-daki static deyisenler ile elaqeli emeliyyatlar
             * aparmaq ucun istifade edilir.
             *
             * Static ctor-da normal ctor kimi istifade edilir, onunde sadece static
             * keywordunden istifade edilir
             * Access modifier olmur
             * Parametr qebul etmir
             *
             * Bir class-da normal ve static olan ctor-lar varsa ilk instance alinan zaman
             * static ctor ise dusur.
             *
             * ** Static class
             *
             * C# 2.0 ile birlikde c#-a static class mefhumu gelmisdir.
             * icinde sadece static member , method saxlayan class-lari static olaraq yarada bilerik.
             * Bir class icerisinde butun memberler staticdirse meslehetdirki class-in ozunude
             * static class olraq teyin edek ancaq mecbur deyilik.
             *
             * Bir class static olaraq teyin edildiyi andan o class-dan instance alina bilmez.
             * Static class-lar icinde static olmayan memeberler saxlamaz.
             * Static class-lar iheritance vasitesile ile basqa bir classa oturule bilmez.
             *
             * *** Static using directives
             *
             * C# 6.0 ile birlikte gelen kod yazmagimiz dahada asanlasdiran bir ozellikdir.
             * Bu ozellik vasitesi ile using keywordunden istifade ederek namespace hissesinde static olan
             * obyektlere bir basa reach ede bilerik.
             *
             * using System;
             *
             * using static System.Console;
             *
             * bu ozellik her neqeder asanliq yaratsada oxunaqliligi itirir.
             *
             *
             * ************* const ve readonly
             *
             * Deyerinin deyismeyeceyi bilinen elementlerimiz sabit/deyismez olaraq bildirilir.
             * Sabit deyisenler c#-da const keywordu vasitesi ile bildirilmekdedir.
             * Sabit d. deyerleri compile vaxti bilinmelidir ve eger deyeri deyismeye cehd etsek
             * compile xetasi vermekdedirler.
             * Sabit ifadeler reference tipinde deyildir, cunki reference tiplerde deyerler
             * RUN time vaxti bilinir ancaq String tipi bu veziyyetde istisnadir.
             *
             *
             *
             * public const double PI=3,14;
             *
             *
             * public const string name = "Parviz";
             *
             * **** readonly
             * rererans tiplerde sabit ifadeler ucun readonly keyword-den istifade edilir.
             * Readonly const-un sadece referans tipler ucun olan versiyasidir,
             * Aralarindaki ferq deyerin RunTime(readonlyden sohbet gedir) verilmesidir.
             *
             *
             *
             *  * https://www.tutorialsteacher.com/csharp/csharp-static
             * https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff650316(v=pandp.10)
             * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-static
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
             *
             * //static ctor
             * https://www.tutorialsteacher.com/codeeditor?cid=cs-Nt4G23
             */
            // Math class
            //Console.WriteLine(Math.Min(1, 2));

            // static field
            //public static int Total;
            #endregion

            //var personManager = Test.personManager;

            MyClass myClass;

            var number = MyClass.number;

            //myClass = new MyClass
            //{
            //    name = "Parviz"
            //}; 

            //PersonManager personManager = new PersonManager();
            //PersonManager personManager = new PersonManager();

            Customer customer = new Customer();
            //customer.AddElement();
            Customer customer1 = new Customer();

            Customer.AddCustomer(customer1);
            //customer.AddElement();
        }
    }

   

    #region examples
    // 1.
    public class PersonManager
    {
        public static int TotalPerson;
        public int personType;

        public PersonManager()
        {
            Console.WriteLine("ctor");
        }

        static PersonManager()
        {
            Console.WriteLine("static ctor");
        }

        public static void AddPersonDetail()
        {

            //personType++;

            //An object reference is required for the non-static field, method, or property 'PersonManager.personType'

            // statik olmayan field bizden classa aid obyekt isteyir.

        }

        public static int Sum(int a, int b)
        {

            return a + b;

        }

    }
    public class Test
    {
       public static readonly PersonManager personManager = new PersonManager
       {
           //personType = 
       };

    }
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
    #endregion


    public class Employee
    {
        public Employee()
        {
            Console.WriteLine("standart ctor her instance alinanda ise dusecek");
        }

        static Employee()
        {
            DomainAddress2 = "pragmatech.az";
            Console.WriteLine("sadece bir defe ilk instance alinan zaman ise dusecek");
        }
        public static string DomainAddress = "pragmatech.az";
        public static string DomainAddress2;

        private string _email;


        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }

        public string Email
        {
            get { return _email; }
            set { _email = $"{value.ToLower()}@{DomainAddress}"; }
        }

    }
    public class MyClass
    {
        public MyClass()
        {

        }

        public const double PI = 3.14;
        public const string name = "c#-2";




        public static int number = 10;
        //public string name;

        public void Sum()
        {

        }

        public static void Sum1()
        {
            //Sum();
        }
    }

    public static class MyClassStatic
    {

        static MyClassStatic()
        {

        }
        public static int number;

        public static void Sum()
        {

        }
    }

    public class EmailHelper
    {

        public static void Send(string toEmail, string subject, string body)
        {
            Console.WriteLine("mail gonderildi");
        }
    }

    public static class EmailHelper2
    {
        static EmailHelper2()
        {

        }

        public static void Send(string toEmail, string subject, string body)
        {
            Console.WriteLine("mail gonderildi");
        }
    }
}
