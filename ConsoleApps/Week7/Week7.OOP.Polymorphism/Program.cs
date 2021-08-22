using System;

namespace Week7.OOP.Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.Polymorphism
            /*
             * OOP.Polymorphism
             *
             * Umumilikde OOP-de Encapsulation ve Inheritance-dan sonra Polymorphism
             * gelmekdedir.Polymorphism : "many shaped" yeni cox formali demekdir ki bu
             * anlayis eslinde bir ozelliyi ozunu bir nece formada gostere bilmesine deyilir.
             *
             * Polymorphism-in tam olaraq ne oldugunu helelik bilmesekde ctor-larin davranis
             * sekillerine nezer yetire bilerik.
             * 1. class daxilinde hec bir ctor teyin edilmese bele default ctor var demisdik,
             * lakin biz parametr qebul etmeyen ctor yaradan zaman default ctor-u ezmish
             * yeni override etmis olurduq.
             * 2. class daxilinde bir ve daha artiq ctor ola bilerdi parametr alan , almayan , ferqli
             * saylarda ve yerleri deyisik sekilde olan ctorlar buna ise method overloading demisdik.
             *
             * Yuxarida sadaladigimiz veziyyetlerde Polymorphism temel anlayislarini eslinde gormus
             * olduq Ctor ozunu bir nece davranis sekline uygun cox formali apara bildi.
             *
             *
             * Bir class daxilinde teyin olunan memberler hemin class-dan instance alinarken istifade
             * edile bilir, burdan bu neticeye gele bilerik ki bu proses compile vaxtinda teyin edilir.
             *
             * Lakin virtual structures bu runTime -da bilinmekdedir.
             *
             * Her hansisa bir derived class base-den inheritance alarken bir basa
             * base class-in memberlerini istifade ede bilirdi, bezi situasiyalarda bize
             * lazim olurki base-de olan memberi derived-da da teyin edek bu zaman basedeki memberinmi
             * yoxsa derived-deki memberinmi istifade edileceyi Runtime zamani bilinir,
             * virtual memberler bu ise yarayir.
             *
             * ****** virtual keyword
             *
             * Virtual memberler : method ve ya property ola bilerler.
             *
             * public virtual string Name {get;set;}
             * public virtual void Sum(){
             *
             * }
             * ******* override keyword
             * virtual keyword-u ile isarelenmis her hansisa member derived class-da deyisdirilmek
             * istenirse override edilmelidir.
             * Base-de virtual olan memberlerin override edilmesi mecburi deyil.
             *
             * ******* Object virtual methods
             *
             * ******* Virtual : Static
             * Static memberler virtual ola bilmez.
             *
             * *****************************************
             *
             * C# Method Overloading
             * Method Overloading : zamani eyni method-un ferqli davranislara sahib olmasi temin edilir.
             *  Overload edilecek methodlar eyni adli olmalidir.
             *  Overload edilecek methodlarda parametrler digerine gore ferqli olmalidir.
             *
             *
             *
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism
             */


            #endregion
        }
    }

    #region examples

    #region virtual members / override // runtime
    public class Car
    {
        public virtual string Name { get; set; }

        public virtual void Drive()
        {
            Console.WriteLine("xodda masini nabrana sur");
        }
    }

    public class BMW : Car
    {
        #region Overrides of Car
        /*
         * override edilmis olan method Runtime zamani derived classdaki method
         * istifade edileceyini bildirmekdedir.
         */
        public override void Drive()
        {
            Console.WriteLine("nabrana getmirem");
        }

        #endregion
    }

    #region examples 2

    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    public partial class Rectangle : Circle
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }

    #endregion


    #endregion

    #region method overloading // compile time

    partial class Rectangle
    {
        public static void PrintArea(int x, int y)
        {
            Console.WriteLine(x * y);
        }

        public static void PrintArea(int x)
        {
            Console.WriteLine(x * x);
        }

        public static void PrintArea(int x, double y)
        {
            Console.WriteLine(x * y);
        }
        public static void PrintArea(double y,int x)
        {
            Console.WriteLine(x * y);
        }
        public static void PrintArea(double x)
        {
            Console.WriteLine(x * x);
        }
    }

    #endregion
    #endregion
}
