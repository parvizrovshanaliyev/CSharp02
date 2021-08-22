using System;

namespace Week7.OOP.Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.Inheritance
            /*
             * Inheritance movzusu OOP-nin esas movlarindan biridir.
             * Umumilikde butun derslerimiz boyu oyrendiklerimiz ki, bunlar
             * value type ,reference type : class , object, collection ve sair mefhumlar
             * nezerde tutulur , isin ozeyinde her seyin real heyata gore modellendiyi
             * modellerimizinse real case-lerde her birinin bir obyekt oldugunu muzakire etmisik.
             *
             * Burdan bir mentiq ortaya qoyaraq her seyin ozeyinde eger ki obyekt dayanirsa demek ki
             * bir yolla bunlar arasinda elaqe var deye bilerik, yeni object-den gelen diger data tiplerinde
             * olan ToString(), GetHasCode(), GetType(),Equals() gormusduk bu methodlar ozlerinde
             * data tipleri ile object arasindaki elaqenin nisanidir deye bilerik.
             *
             * Evvelceden yaradilan her hansisa bir class icerisindeki ozelliklerini basqa bir classa
             * oture bilmekdedir, Inheritance mefhumunun ozeyi bundan ibaretdir.
             *
             * Buna misal olaraq real case-lerde ata ve ogul arasindaki gen uzerinden elaqeye nezer
             * yetire bilerik. Daha aciq danishsaq atanin genlerinin varisi ovladdir, oz atasinin
             * oxsar xususiyyetlerini goturmusdur. Elbetdeki misal-dan sual ortaya cixir axi ovlad
             * oz atasinin bire bir eynisi olmur bezi ozel xususiyyetlerini goturur ve ya simasindan
             * bir iki benzerlik goturur , bax ele inheritance movzusu programlasdirmada bize burada komek
             * olur meqsed iki eyni class yaratmaq deyilmeqsed evvel yaradilandan lazim olan xususiyyetleri
             * goturub uzerine basqa ozelliklerde elave ede bilmeyimizdir.
             *
             *
             * Umumi bir birine oxsar modellerimizde eyni xususiyyetleri bir ust modelde teyin etdiyimiz
             * zaman hem daha clean code yazmisiq oluruq hem ierarxiq struktur yaratmis oluruq proyektimizde
             * ki, dessign patternler ve sair kimi seyleri oyreneceyiniz zaman OOP movzularinin onemini
             * daha aydin sekilde basa duseceksiniz.
             *
             *
             * Class-lar sadece ve sadece class-lardan inheritance ala bilmekdedirler,
             * bu varisliy ozeliyyide demek olarki sadece class-lara aid ozellikdir,
             * istisna record-lardir, onlarda oz aralarinda varislik ozelliyinden
             * istifade ede bilirler.
             *
             * Inheritance mozularini arasdirarken miras veren class-in base class
             * varis olan classin ise derived class oldugu ile qarsila bilersiz yeni
             * bundan sonra bizde base class derived class deye izahlarimizda yer vereceyik bu movzulara
             *
             * Base classin ozelliklerinin diger derived class-da da olmasi ucun ilk once access modifier
             * movzularininda uzerinden kecmek lazimdir amma indiye qeder oyrendiyimiz public , private ile
             * baslayacaq olsaq deye bilerikki, public olan memberler hem classdan instance alinan
             * zaman istifade edile bilir hem de indi oyrendiyim inheritance movzusunda bir class digerinden
             * inheritance alibsa ve base classin memberleri-de public dirse derived classda da bu ozelikleri istifade
             * etmek mumkundur bunun tam eksi veziyyet ise private access modifier-da ozunu gostermekdedir.
             *
             * Bir class-in sadece bir base class-i ola biler, burdanda bu neticeye gele bilerik ki
             * bir class sadece bir class-dan varislik ala bilmekdedir, yeni onun inheritance aldigi base class-da
             * basqa bir classin derived class-i olsada bir class sadece bir class-dan miras ala ve miras vere bilir.
             *
             * Compiler seviyyesinde biz bir class-dan new deyib yeni instance almaga calisarken
             * compiler o class-in base class-i olub olmadigina baxir eger ki classin base classi varsa her hansisa
             * class-dan inheritance alibsa  ilk once  base classi yaradir heap bolgoye yerlesdirir ardinca
             * instance almaq istediyimiz obyekti yaradir.Ierarxik struktur dediyimiz mefhum burada ozunu
             * eyani olaraq gostermekdedir.
             *
             *
             * ********* base keyword
             * Derived class-da base class-in parametr alan ve ya almayan overload edilmis istenilen
             * ctor-nu base keywordu ile cagira bilerik.
             *
             * ********* base vs this
             * this : bir class-in ctorlari arasinda kecid ederken istifade edilir.
             * Hemcinin class icerisinde this. member operatoru ile class-a aid memberleri istifade ede bilirdik.
             * base : derived class-da base clasin her hansisa bir ctoruna kecid ederken istifade edilir.
             * hemcinin derived class icerisinde base. memeber operatoru ile base classin memberlerini istifade ede bilerik.
             * her ikiside yazilmasa bele compiler seviyyesinde basa dusulduyunden gorunmesede ora yerlesdirilir.
             *
             * ********* Object class
             * ** ToString(), GetHasCode(), GetType(),Equals()
             * C#-da butun class-lar Object class-dan inheritance almaqdadir.
             * Bir class yaradilan zaman Compiler seviyyesinde o class Object Class-dan inheritance
             * alacaqdir.Ona gorede yuxaridaki Object class-nin memberleri butun class-larda el catan olmaqdadir.
             *
             * Object uzerine gelib goto definition desez eyani olaraqda butun class-larin object-den inheritance aldigini
             * gore bilersiniz.
             *
             * Bir class dedik ki sadece bir class-dan inheritance ala bilmekdedir, amma indi
             * oyrendiyimize gore ise butun class-lar eslinde compiler seviyyesinde onject-den inheritance
             * almaqdadir, demeli bir class-in base class-i varsa o class objectden inheritance almir lakin
             * onun base class-i objectden inheritance aldigindan dolayi yolla oda objectden inheritance almis olur,
             * OOP-dei ierarxik struktur dediyimiz anlayis burada da ozunu biruze vermekdedir.
             * hamsi massonlarin isidi...
             *
             * ********* Name Hiding
             * Derived class-da olan her hansisa member base class da olan her hansisa bir
             * memberle eyni adli ola bilmekdedir. Ele buna gorede derived class-dan
             * instance alib memberlerini istifade etmek istedikde eyni adli memberin
             * base-den ve ya derived-dan geldiyini bilmirik, bu problem ve ya situasiya
             * name hiding adlanmaqdadir , ozet kecsek derived class-dan instance alan
             * zaman base-deki eyni adli memberi gore bilmeyeceyik, gosterilen member
             * derived class-in memberi olacaqdir. Bu veziyyetde complier terefinden her hansisa
             * bir xeta vermesede bize warning verir, bu warninge gore derived class-daki
             * memberin qarshisinda new keyword-den istifade etmeliyik evveller new keywordunden
             * istifade etmesek etmesek bize xata versede indi new keywordu olmadanda istifade ede bilerik.
             *
             * ********* sealed keyword
             *
             * class-larda sealed keywordunden istifade eden zaman hemin class-dan miras alinmayacagini
             * qeyd etmisik olur.
             *
             * ********* boxing / unboxing
             *
             * base class-la derived class-lari qarsilaya bilerik bu proses boxing adlanir.
             *
             *
             * ********* access modifier protected
             *
             * Normal istifadesi zamani ozunu private kimi aparmaqdadir bilavasite aid oldugu class-in
             * memberlerinden her hansisa protected olaraq isarelenibse o memberleri ancaq hemin class-dan inheritance
             * alan derived class-lar istifade ede biler.
             */

            #endregion
            // 1. object 2. employe 3. accountant
            Accountant accountant = new Accountant();
            //var accountantEmail = accountant.Email;
            //name hiding

            DerivedClass derived = new DerivedClass();
            var derivedClassMemberProp = derived.ClassMemberProp;
        }
    }

    #region examples

    #region 1 employe
    public class Employe // base class : Object
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Accountant : Employe // derived class
    {
        public Accountant()
        {
            var name = this.Name;
        }


    }

    public class A1 : Accountant
    {
        public A1()
        {
            var name = this.Name;
        }
    }

    public class Developer : Employe
    {

    }

    public class Manager : Employe
    {

    }


    #endregion

    #region 2 base class derived class munasibetlerinde obyektlerin yaradilma ardicilligi

    public class Mercedes
    {
        public Mercedes()
        {
            Console.WriteLine(nameof(Mercedes));
        }

    }

    public class Yeshka : Mercedes
    {
        public Yeshka()
        {
            Console.WriteLine(nameof(Yeshka));
        }

    }

    public class Ceshka : Yeshka
    {

        public Ceshka()
        {
            Console.WriteLine(nameof(Ceshka));

        }
    }

    public class DordGoz : Ceshka
    {
        public DordGoz()
        {
            Console.WriteLine(nameof(DordGoz));
        }
    }
    #endregion


    #region base keyword
    public class A
    {
        public A(int a)
        {
            Console.WriteLine(a);
        }

        public A()
        {

        }
    }

    public class B : A
    {
        public B()
        {

        }

        // yuxaridaki base class-in sadece paramet alan ctor-u olarsa eger derived class-da
        // xeta verecek cunki o ctor paramet aldigindan compiler basa duse bilmir ne etmelidir,
        // ve parametr derived class icerisinde de verilmelidir ki base class-da istifade edile bilsin.
        public B(int a) : base(a)
        {

        }
    }

    #endregion

    #region nameHiding

    public class BaseClass
    {
        public string ClassMemberProp { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        public new string ClassMemberProp { get; set; }
    }

    #endregion
    #endregion
}
