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

            Assembly assembly = Assembly.LoadFile(reflectionLibPath);


            // GetTypes() dll-de olan butun tipleri list formasinda verir.
            Type[] types = assembly.GetTypes();
            // get ctors
            var ctorList = types.SelectMany(i => i.GetConstructors()).ToList();

            ctorList.ForEach(ctorInfo =>
            {
                Console.WriteLine(ctorInfo.DeclaringType?.Name +" "+ctorInfo.ToString());
            });
            // get props
            var propList = types.SelectMany(i => i.GetProperties()).ToList();

            propList.ForEach(propInfo =>
            {
                Console.WriteLine(propInfo.DeclaringType?.Name + " " + propInfo.ToString());
            });
            // get methods
            var methodList = types.SelectMany(i => i.GetMethods()).ToList();

            methodList.ForEach(methodInfo =>
            {
                Console.WriteLine(methodInfo.DeclaringType?.Name + " " + methodInfo.ToString());
            });

            Console.ReadLine();
        }
    }
}
