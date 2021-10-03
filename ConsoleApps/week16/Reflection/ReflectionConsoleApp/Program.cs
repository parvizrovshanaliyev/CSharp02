using System;
using System.Linq;
using System.Reflection;

namespace ReflectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //"C:\\Users\\User\\Documents\\GitHub\\C_Sharp\\CSharp-02\\CSharp\\Reflection\\ReflectionLib\\bin\\Debug\\net5.0\\ReflectionLib.dll"

            string reflectionLibPath =
                @"C:\Users\Asus\Documents\GitHub\CSharp02\ConsoleApps\week16\Reflection\ReflectionLib\bin\Debug\net5.0\ReflectionLib.dll";

            /*
             * burada oxumaq ve ya istifade etmek istediyimiz dll-in path-ne gore runtime zamaninda dll icerisinde
             * olan tipler haqqinda melumat elde ede ve istifade ede bilerik .
             *
             * LoadFile
             */


            // GetTypes() dll-de olan butun tipleri list formasinda verir.

            // get ctors

            
            // get props
           
            // get methods
            

            Console.ReadLine();
        }
    }
}
