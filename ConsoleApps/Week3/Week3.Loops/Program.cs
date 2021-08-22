using System;

namespace Week3.Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            #region loops
            /*
             * yazilan kodun tekrar edilmesi ucun istifade edilir
             * uygun sertlere gore emeliyyatlarimiz tekrarlanir.
             *
             * for , while , do while
             *
             * her biri bir birini evez ede biler.
             * lakin uygun konsepte gore sece bilerik.
             *
             * ard-arda emeliyyatlarda daha cox for
             * sonsuz dongu lazimdirsa while
             * her hansia bir serte uygun konseptde do while
             */


            #region for

            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //Console.WriteLine("hello world");
            //int i = 0;

            //Console.WriteLine(i++); 
            //Console.WriteLine(++i);
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}


            #region 1-10 qeder ededleri sirala

            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region 1 ile 40 arasinda cut ededlerin cemi

            //var total = 0;

            //for (int i = 1; i <= 40; i++)
            //{

            //    if (i % 2 == 0)
            //        total += i;
            //    //total = total +i;
            //}

            //Console.WriteLine(total);
            #endregion

            #region girilen deyerin faktorialini tapin
            /*
             * 5!
             */
            //int number = 5;

            //int factorial = 1;

            // 1*1*2*3*4*5
            //for (int i = 1; i <= number; i++)
            //{
            //    factorial *= i;
            //}
            // 1*2*3*4*5
            //for (int i = 2; i <= number; i++)
            //{
            //    factorial *= i;
            //}

            // 2ci variant Kamran
            //int factorial = 5;
            //for (int i = factorial - 1; i >= 1; i--)
            //{
            //    factorial *= i;
            //}
            //Console.WriteLine(factorial);

            //Console.WriteLine(factorial);
            #endregion

            #endregion

            #region while
            /*
             * for loopuna nezeren daha sadedir
             * sert true olduqca kecerlidir
             */

            #region while ve for qarsilastirma
            //for (int i = 0 , j=0; i < UPPER; i++)
            //{


            //}
            //int i = 0;
            //while (i<=10)
            //{

            //    Console.WriteLine(i);
            //    //result += i++;
            //    i++;

            //}

            //while (false)
            //{
            //    Console.WriteLine("while");
            //}

            //do
            //{
            //    Console.WriteLine("do while");
            //} while (false);
            #region consoledan daxil edilen ededden geriye dogru loop

            #endregion

            #region 0 ile 100 arasindaki tek ededlerin cemi


            #endregion

            #region faktorial

            #endregion

            #region while aid numune

            /*
             * O anki tarixin saniye deyeri 5 kvadratidirsa
             * tarixi ekranda gosterin
             */

            //while (true)
            //{
            //    if (DateTime.Now.Second % 5 ==0)
            //    {
            //        Console.WriteLine(DateTime.Now);
            //    }
            //}
            #endregion
            #endregion

            #endregion

            #region do while

            /*
             * while : sert dogru olduqca loop gedir
             * do while : sert dogru olduqca loop gedir
             *
             * ferq: while evvelce serte baxir sonra loop gedir,
             * \
             * do while : once kodu icra edir sonra serte baxir,
             * dogrudusa loopa girir
             * sert dogru olmasa bele birdefe kod icra edilir gedir.
             *
             *
             */

            //while (false)
            //{
            //    Console.WriteLine("while");
            //}

            //do
            //{
            //    Console.WriteLine("do while");
            //} while (false);
            #endregion

            #region skopsuz loop

            //for (int i = 0; i < 10; i++)
            //    Console.WriteLine(i);


            #endregion

            #region sonsuz dongu

            #region for
            /*
             * int deyeri kecerse sonsuz dongu olmayacaq
             */
            //for (int i = 0; true; i++)
            //{

            //}

            // sonsuz
            //for (;;)
            //{

            //}

            // sonsuz donguden cxmaq istedikde
            //bool loop = true;

            //for (;loop;)
            //{
            //    if (true)
            //    {
            //        loop = !loop;
            //    }
            //}

            #endregion

            #region while

            //bool status = false;
            //while (!status)
            //{
            //    if (true)
            //        status = !status;
            //}
            #endregion

            #endregion

            #region nested loop - ic ice looplar

            //for (int i = 0; i < UPPER; i++)
            //{
            //    for (int j = 0; j < ; j++)
            //    {

            //    }

            //    while (expression)
            //    {

            //    }
            //}

            #endregion

            #region foreach loopdurmu ?
            /*
             * Foreach loop deyil sadece iteration emeliyyatini
             * yerine yetirir
             */


            #endregion

            #endregion
        }
    }
}
