using System;

namespace Week5.Methods_Intro
{
    public static class Calculator
    {


        /*
         * Menu
         *
         * Emeliyyatlar
         *
         * Result 
         */

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1.Toplama");
            Console.WriteLine("2.Cixma");
            Console.WriteLine("3.Vurma");
            Console.WriteLine("4.Bolme");
            Console.Write("Emeliiyat nomresini daxil edin:\t");
        }
        public static decimal Sum(decimal a, decimal b)
        {
            return a + b;
        }

        public static decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public static decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public static decimal Divide(decimal a, decimal b)
        {
            return a / b;
        }


        public static void Result(decimal number1, decimal number2, decimal result, string operation)
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("___________________ Netice_______________________");
            Console.WriteLine("{0} {1} {2} = {3}", number1, operation, number2, result);
        }
    }
}
