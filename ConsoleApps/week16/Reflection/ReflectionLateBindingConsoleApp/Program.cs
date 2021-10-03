using System;
using System.Reflection;
using ReflectionLateBindingConsoleApp.Models;

namespace ReflectionLateBindingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {   // GetExecutingAssembly() cari appi assembly olaraq verir.
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetType("ReflectionLateBindingConsoleApp.Models.Customer");

            if (type is not null)
            {
                object obj = Activator.CreateInstance(type);
                
                //Customer customer = new Customer();
                //var customerInfo=customer.Info("", "");
                
                MethodInfo methodInfo = type.GetMethod("Info");

                object[] objParams =
                {
                    "Arif",
                    "Vagif"
                };

                var value = methodInfo?.Invoke(obj, objParams);

                Console.WriteLine(value);
            }

            Console.ReadLine();

        }


       
    }

    public interface IABC
    {


    }

    public class A : IABC
    {

    }


    public class B : IABC
    {

    }

    
}
