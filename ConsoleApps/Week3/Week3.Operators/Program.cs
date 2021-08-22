using System;

namespace Week3.Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region arithmetic
            // +
            // -
            // *
            // /
            // %
            //int a = 10;
            //double x = 1000;
            //int y = 100;
            //var result = x + y;

            //byte x1 = 250;
            //byte x2 = 7;
            //var result = x1 + x2;
            #endregion

            #region relational
            // iki deyer arasinda boyuk , kicik ve beraber olmasini
            // munasibetini qarsilasdiran operatorlardir
            // geriye boool tipi qaytarir
            /*
             * <
             * >
             * <=
             * >=
             * ==
             */
            //int a = 10;
            //int b = 20;

            //bool result = a < b;


            #endregion

            #region logical
            /*
             * &&  ve
             * ||  ve ya
             * ^   ya da
             */
            //int x = 10;
            //int y = 20;

            // false ve false 
            //bool result = x > y && y < 5;
            //bool result = x < y || y < 5;

            //Console.WriteLine(true && false);
            //Console.WriteLine(false && false);
            //Console.WriteLine(true && true);
            //Console.WriteLine("----||-----");
            //Console.WriteLine(true || false);
            //Console.WriteLine(true || true);
            //Console.WriteLine(false || false);
            //Console.WriteLine("----^-----");
            //Console.WriteLine(false ^ false);
            //Console.WriteLine(true ^ true);
            //Console.WriteLine(true ^ false);

            #endregion

            #region string ifadeler-de + , += , == opretatorlarinin istifadesi

            //string a = "A";

            //int y = 123;
            //Console.WriteLine(a+y);

            //string a1 = "10";

            //int y1 = 123;
            //Console.WriteLine(a1 + y1);

            #endregion

            #region deyil ! != beraber deyilse

            //bool x3 = 5 != 6;
            //var x4 = 5 == 6;

            #endregion

            #region ternary
            /*
             * if else istifadesini tek setrde hell edir
             *
             */
            //bool isStudent = true;
            //var result = isStudent == true ? "true " : "false";
            //var result = isStudent  ? "true " : "false";
            // real
            //var result = isStudent ? "Telebedir" : "Telebe deyil";

            //int score = 25;
            //var result = score > 40 ? "A" : "F";
            //Console.WriteLine(result);

            //int score = 25;
            //var result = score > 40 ? "A" : (score <= 30 ?"B" : "C"): (score <= 30 ?"B" : "C");
            //Console.WriteLine(result);

            #endregion

            #region member access . operatoru

            #endregion

            #region typeof operatoru
            /*
             * typeOf tiplere aid melumatlari verir
             */
            //Type t = typeof(int);
            //Console.WriteLine(t.IsPrimitive);
            //Console.WriteLine(t.IsValueType);
            //Console.WriteLine(t.Name);
            //Console.WriteLine(t.IsClass);
            #endregion

            #region default operatoru
            /*
             * default  her hansisa tipe onceden teyin edilen deyeri default deyeri verir
             */
            //Console.WriteLine(default(int));
            //Console.WriteLine(default(byte));
            //Console.WriteLine(default(Program));
            //Console.WriteLine(default(bool));
            //int a;
            //int a1 = default;
            //int a2 = default(int);
            #endregion

            #region is operatoru
            /*
             * Boxing edilmis her hansisa bir tipin  oz tipini check etmek
             * ucun istifade edilir.
             *
             */
            //object x = false;
            //Console.WriteLine(x is bool);
            #endregion

            #region is null operatoru
            /*
             * her hansisa bir tipin null olub olmamasini yoxlayir
             * reference typelarda
             * bool tipinde deyer qaytarir
             */
            //string a = "aaaaaa";
            //Console.WriteLine(a is null);
            //string b = "";
            //Console.WriteLine(b is null);
            //string c=null;
            //Console.WriteLine(c is null);
            #endregion

            #region is not null operatoru
            /*
             *
             */
            //string a1 = "notnull";
            //Console.WriteLine(a1 is not null);
            #endregion

            #region as operatoru
            /*
             * () cast operatoruna alternativ olaraq istifade edilir
             * ferqi xeta mesaji vermeden null qaytarir.
             */
            //object x = 100;
            //int y = (int) x;

            //object obj = "123";
            //string s1 = obj as string;
            #endregion

            #region ? (Nullable) Operatoru
            /*
             * her hansisa tipin deyerinin null olmasini temin edir
             */

            //int? id = 0;
            #endregion

            #region ?? null coalescing operatoru
            /*
             * null olamagini yoxlayib deyer verir
             */
            //int? id = null;

            //Console.WriteLine(id ?? 1);
            //if (id is null)
            //{
            //    var x= id??4
            //}
            //DateTime? starTime =DateTime.Now;
            #endregion

            #region ??= null coalescing c# 8.0
            /*
             *
             */
            //Console.WriteLine(id ?? =4);
            #endregion

            Console.ReadLine();
        }
    }
}
