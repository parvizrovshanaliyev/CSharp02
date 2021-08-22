using System;

namespace Week5.Methods_Intro
{
    class Program // class
    {
        static void Main(string[] args) // Main method  : args : parametr
        {

            #region ref out in

            //double number1=1; //5

            //AssignValue(ref number1);

            #endregion

            #region params

            //int[] numbers2 = new [] {1, 2, 3};
            //Sum2(numbers2);

            //Sum2("Resad", 2, 3, 4, 5);

            #endregion

            #region examples methods 

            //Method1Public();

            //Sum(10, 20);

            //var total=Sum1(7, 6);
            //Console.WriteLine(Sum1(7, 6));
            #endregion

            #region example calculator
            //do
            //{
            //    Calculator.Menu();

            //    int operation = int.Parse(Console.ReadLine());

            //    Console.WriteLine("1. ededi daxil edin");
            //    decimal number1 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("2. ededi daxil edin");
            //    decimal number2 = Convert.ToInt32(Console.ReadLine());

            //    decimal result = 0;
            //    switch (operation)
            //    {
            //        case 1:
            //            result = Calculator.Sum(number1, number2);
            //            Calculator.Result(number1, number2, result, "+");
            //            break;
            //        case 2:
            //            result = Calculator.Subtract(number1, number2);
            //            Calculator.Result(number1, number2, result, "-");
            //            break;
            //        case 3:
            //            result = Calculator.Multiply(number1, number2);
            //            Calculator.Result(number1, number2, result, "*");
            //            break;
            //        case 4:
            //            result = Calculator.Divide(number1, number2);
            //            Calculator.Result(number1, number2, result, "/");
            //            break;
            //        default:
            //            Console.WriteLine("Emeliyyat duzgun daxil edilmeyib");
            //            break;
            //    }

            //    Print();

            //} while (Console.ReadLine()?.ToUpper() != "X");
            #endregion
        }

        //private static void Print()
        //{
        //    Console.Write("Davam etmek isteyirsinizmi? b/x (beli/xeyr):\t");
        //}

        #region methods
        /*
         * Real heyata nezer salsaq method-lari butun gorulen isler olaraq,
         * bir fel olaraq basa duse bilerik.
         * Programlashdirmada bir isi yerine getiren program hissesi method-dur
         * deye bilerik.
         * Methodlar bize kod tekrarin qarshisini almaqda heddin artiq komek edir .
         *
         * Method-lar class memberlerdir , yeni bir method class/struct icerisinde yaradilirlar,
         * access modifier___geri donus  deyeri__adi (){}
         *
         * access Modifier Inheritance hissselerinde daha etrafli oyreneceyik sade sekilde
         * yadda saxlayin private ve public
         *
         * Geriye donus deyeri : methodun her hansi bir tipde geriye (5, true,false) deyer
         * vermesidir ki, biz onu sonra yeniden ferqli emliyyatlar ucun istifade ede bilirik.
         *
         * 
         */

        #region geriye deyer donmeyen, parametr alamayan metod

        //public static void Method1Public()
        //{
        //    Console.WriteLine("geriye deyer donmeyen, parametr alamayan metod");
        //}

        //private static void Method1Private1()
        //{
        //    Console.WriteLine("geriye deyer donmeyen, parametr alamayan metod");
        //}

        //static void Method1Private2()
        //{
        //    Console.WriteLine("geriye deyer donmeyen, parametr alamayan metod");
        //}
        #endregion

        #region geriye deyer donmeyen, parametr alan method

        //public static void Sum(int a, int b)
        //{
        //    Console.WriteLine(a+b);
        //}
        #endregion

        #region geriye deyer donen , parametr almayan
        //public static int Sum()
        //{
        //    return 5 + 4;
        //}
        #endregion

        #region geriye deyer donen, parametr alan 
        //public static int Sum1(int a, int b)
        //{
        //    return (a + b);
        //}
        #endregion

        #region method-un parametrine default deyerin verilmesi
        /*
         * Qeyd: method-un her hansisa bir paramatrine default deyer verilerse ondan sonra gelen parametrlerde
         * bu tetbiq edilmelidir.
         */
        //public static int Sum2(int a, int b=0, int c= default, int d=40)
        //{
        //    return (a + b);
        //}


        #endregion

        #region ref, in  ve out keywordleri

        /*
         * Burada normal qaydada refden istifade edilmeseydi deyer kopyalanacaqdi ancaq
         * ref keywordu vasitesi ile deyer kopyalanmir  heapde yaradilir ve iki deyisende ona reference/muraciet
         * edir.
         *
         * https://www.pluralsight.com/guides/csharp-in-out-ref-parameters
         */

        /*
         * ref ve in baslangic deyeri almalidir,
         * out baslangic deyeri alamadan isleyir
         *
         * ref-istifadesi zamani evvelceden teyin edilen deyisenin parametr olaraq
         * method-a oturuldukden sonra method vasitesile yeni deyer alacagi
         * bildirilir (evvelceden deyeri oldugu ucun method-da yeni bir deyer
         *     alamaya biler).
         *
         * c# 7.2 in-istifadesi zamani evvelceden teyin edilen deyisenin parametr olaraq
         * method-a oturuldukden sonra method-da deyerinin deyismeyeceyi
         * bildirilir. Reference type-la isleyirikse yeni instance ala bilmerik.
         *
         * out-istifadesi method-a oturulen parametrin method icerisinde deyer
         * alacagini ve methoddan kenardada deyisen olaraq istifade edile bileceyini
         * bildirir(evvelceden deyer alma kimi mecburiyyeti olmadigindan method icerisinde mecbur
         *     deyer almalidir).
         *
         * Qeyd : Bu keyword-ler sadece sinxron isleyen metodlarda istifade edile biler,
         * async asenxron methodlarda istifade edilmir. Bu movzularla irelide tanis olacagiq.
         * hemcinin yield return, yield break iterasya isleri zamani da istifa edile bilmir.
         */
        //static void AssignValue(ref double value)
        //{
        //    value *= 5;
        //}

        #endregion

        #region params
        /*
         * deyisken sayda parametr almaq params key vasitesi ile
         *
         * params dan sonra yox parametrler ondan evvel teyin edilmelidir
         */
        //(1,2,3,4)
        //(numbers[])
        //static void Sum2(string a, params int[] numbers)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        sum += numbers[i];
        //    }

        //    Console.WriteLine(sum);
        //}
        #endregion
        #endregion

    }
}
