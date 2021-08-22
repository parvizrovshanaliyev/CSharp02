using System;
using System.Linq.Expressions;

namespace Week3.DecisionMaking
{
    class Program
    {
        static void Main(string[] args)
        {
            #region if else else if

            #region examples

            #region week3,day1- 27.03.21
            /*
             * &&
             * ||
             *
             * daxil edilen 2 deyeri toplayib 50 ile muqayise et
             */

            //Console.Write("enter a number 1: ");
            ////string number1 = Console.ReadLine();
            ////decimal number_ = Convert.ToDecimal(number1);

            //decimal number1 = Convert.ToDecimal(Console.ReadLine());

            //Console.Write("enter a number 2: ");
            //decimal number2 = Convert.ToDecimal(Console.ReadLine());

            //decimal total = number1 + number2;

            //bool checkValue = total > 50;

            //bool checkValue = (number1 + number2) > 50;

            //if (checkValue)
            //{
            //    Console.WriteLine(" 50 boyukdur");
            //}
            //else
            //{
            //    Console.WriteLine("50-den kicikdir");
            //}

            //if ((number1 + number2) > 50)
            //{
            //    Console.WriteLine(" 50 boyukdur");
            //}
            //else
            //{
            //    Console.WriteLine("50-den kicikdir");
            //}

            //if ((number1 + number2) > 50)
            //{
            //    Console.WriteLine(" 50 boyukdur");
            //}
            //else if((number1 + number2) > 50 && (number1 + number2) >60)
            //{
            //    Console.WriteLine("50-den kicikdir");
            //}
            //else
            //{
            //    Console.WriteLine("hecbirini odemedi");
            //}

            /*
             * birden cox sertimiz uygn oldugu varaintlarda 
             */

            // 250
            //int a = Convert.ToInt32(Console.ReadLine());

            // xeta 
            //if (a > 100 && a <= 200)
            //{

            //}else if (a > 200 && a <= 300)// true
            //{
            //    Console.WriteLine("200 -300");
            //}else if (a > 200 && a <= 400)// true
            //{
            //    Console.WriteLine(" 200 -400 araligi");
            //}
            // duz varianti 
            //if (a > 100 && a <= 200)
            //{

            //}

            //if (a > 200 && a <= 300)
            //{
            //    Console.WriteLine("200 -300");
            //}

            //if (a > 200 && a <= 400)// true
            //{
            //    Console.WriteLine(" 200 -400 araligi");
            //}


            #endregion

            #region week3,day2- 28.03.21

            #region calculator
            /*
            * menu
            *
            * 1- Toplama
            * 2- Cixma
            * 3- Vurma
            * 4- Bolme
            *
            * qeyd: bolen 0 ola bilmez;
            */

            //Console.WriteLine("----Menu-----");
            //Console.WriteLine("1- Toplama:");
            //Console.WriteLine("2- Cixma:");
            //Console.WriteLine("3- Vurma:");
            //Console.WriteLine("4- Bolme:");
            //Console.WriteLine("----Menu-----");

            //Console.Write("Emeliyyat nomresini daxil edin: ");
            //int operation = Convert.ToInt32(Console.ReadLine());

            //if (operation == 1 ||
            //    operation == 2 ||
            //    operation == 3 ||
            //    operation == 4)
            //{
            //    Console.Write(" birinci reqemi daxil et :");
            //    decimal number1 = Convert.ToDecimal(Console.ReadLine());
            //    Console.Write(" ikinci reqemi daxil et :");
            //    decimal number2 = Convert.ToDecimal(Console.ReadLine());

            //    if (operation ==1)
            //    {
            //        Console.WriteLine("Netice : {0}",(number1+number2));
            //    }else if (operation == 2)
            //    {
            //        Console.WriteLine("Netice : {0}", (number1 - number2));

            //    }else if (operation == 3)
            //    {
            //        Console.WriteLine("Netice : {0}", (number1 * number2));

            //    }else if (operation == 4)
            //    {
            //        if(number2== 0)
            //            Console.WriteLine("qeyd: bolen 0 ola bilmez");
            //        else
            //            Console.WriteLine("Netice : {0}", (number1 / number2));
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("duzgun emeliyyat daxil edilmeyib");
            //}


            #endregion

            #endregion

            #endregion

            #region skopsuz istifade

            //if (a > 200 && a <= 300)
            //Console.WriteLine("200 -300");
            //Console.WriteLine("200 -300");


            #endregion

            #endregion

            #region switch case

            /*
             * beraberlik muqayisesi zamani daha cox istifade edilir.
             *
             * caselerdeki deyerler deyisenlerden alinmir
             *
             * caselerin sirasi onemli deyil
             */
            //if ()
            //{

            //}
            /*
             * istifadeciden gelen aylarin yoxlanilmasi
             *
            // */
            //string month = "Yanvar";

            //switch (month)
            //{
            //    case "Fevral":
            //        Console.WriteLine("Fevral");
            //        break;
            //    case "Yanvar":
            //        Console.WriteLine("Yanvar");
            //        break;
            //    default:
            //        Console.WriteLine("hec biri deyil");
            //        break;
               
            //}



            /*
            * switch casede  bir nece case elave etmek olur bu zaman ||
            * ve ya serti yerine yetirili bu ve ya o 
            */


            #region when istifadesi

            /*
             * normal switchde ancaq beraberlik yoxlaya bilirik
             * ferqli sertler ucun when istifade edilir.
             *
             */
            int total = 100;

            switch (total)
            {
                case 100 when ( total == 200):
                    Console.WriteLine("100");
                    break;
            }

            #endregion

            #region go to istifadesi

            /*
             * beraberlik yoxlanilir deye locigal emeliyyatlar ucun
             *
             * ferqli caselerde eyni emeliyyat(kod ) istifade olunursa
             * kod tekrari olmasin deye go to ile birini sece bilirik.
             *  caseler arasinda kecid
             * go to ile break silinir;
             */
            //string month = "Yanvar";
            //string month1 = "yanvar";

            //switch (month)
            //{
            //    case "Yanvar":
            //        Console.WriteLine("Yanvar");
            //        break;
            //    case "yanvar":
            //        goto case "Yanvar";

            //    default:
            //        Console.WriteLine("hec biri deyil");
            //        break;

            //}


            // multiple go to 
            //switch (month)
            //{
            //    case "Yanvar":
            //        Console.WriteLine("Yanvar");
            //        break;
            //    case "yanvar":
            //    case "Fevral":
            //        goto case "Yanvar";

            //    default:
            //        Console.WriteLine("hec biri deyil");
            //        break;

            //}
            #endregion

            #region switch expressions c# 8.0

            /*
             * Heftenin gunleri
             */
            //string message = "Monday";

            //string message = DateTime.Now.DayOfWeek switch
            //{
            //    DayOfWeek.Monday => "Bazar ertesi",
            //    DayOfWeek.Tuesday => "Cersenbe Axsami",
            //    DayOfWeek.Wednesday => "Cersenbe",
            //    DayOfWeek.Thursday => "Cume Axsami",
            //};


            // expressions


            #region when / expressions

            //int total = 100;

            //string result = total switch
            //{
            //    5 when 3 == 3 => "true",
            //    var xTotal when xTotal > 100 && xTotal % 2 == 0 => "false",
            //    var x => "default" // default
            //};


            #endregion

            #endregion

            #endregion

           
        }
    }
}
