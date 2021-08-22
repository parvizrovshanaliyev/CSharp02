using System;
using System.Net.Cache;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region int  byte double float decimal

            //int intMinVal, a, b;
            ////int intMinVal = int.MinValue;
            //intMinVal = int.MinValue;
            //Console.WriteLine("min val :{0}",intMinVal);

            //int intMaxVal = int.MaxValue;
            //Console.WriteLine(intMaxVal);



            //int x1 = 10;

            //string user_name_surname = "Parviz";

            //char choise = 'A';


            //// tuple
            //(int a, int b) c= (5, 10);
            //Console.WriteLine(c.a);
            //Console.WriteLine(c.b);

            //// c# 7.o literals
            //ulong num1= 18_446_744_073_709_551_615;

            #endregion

            #region string

            //string groupName = "CSharp-02";
            //string courseName = "Pragmatech";
            //string email = "kanan@pragmatech.az";

            //Console.WriteLine(groupName.ToLower());
            //Console.WriteLine(groupName.ToUpper());
            //Console.WriteLine(groupName.Substring(0,6));



            #endregion

            #region object




            #region boxing
            //int number1 = 100;
            //object number2 = number1;
            #endregion

            #region unBoxing

            //string name = "Zaur";
            //object _name = "Zaur";

            //object age = 28;

            //int _age = (int) age;




            #endregion

            #endregion

            #region var , dynamic

            //var name = "Kamran";

            //object _name = "Kamran";
            ////_name.
            //    name.

            //dynamic age = 20;

            #endregion

            #region typeConversion

            #region parse

            //string a = "123";

            //int b = int.Parse(a);

            //Console.WriteLine("b-nin deyeri :{0}",b*5);

            ////string c = "IsDeleted";
            //string c = "true";

            //bool f = bool.Parse(c);
            //Console.WriteLine("b-nin deyeri :{0}", f );
            #endregion
            #region convert

            //string a = "500";

            //int b = Convert.ToInt32(a);

            //Console.WriteLine("b-nin deyeri {0}{1}",b,a);
            //string p = "3,14";
            //double v = Convert.ToDouble(p);

            //#endregion

            //#region impilict

            //short b1 = 500;
            //int b2 = b1;


            #endregion
            #region explicit

            //int l = 5000;
            //byte l1 = (byte) l;


            #endregion

            //checked
            //{
            //    int l = 5000;
            //    byte l1 = (byte)l;
            //}
            //int l = 5000;
            //byte l1 = (byte)l;
            //unchecked
            //{
            //    int l = 5000;
            //    byte l1 = (byte)l;
            //}
            //string h = "true";
            bool u = true;
            int k = Convert.ToInt32(u);
            char p = 'a';

            #endregion
        }


    }
}
