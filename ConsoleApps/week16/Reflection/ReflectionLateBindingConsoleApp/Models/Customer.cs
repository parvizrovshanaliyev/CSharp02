using System;

namespace ReflectionLateBindingConsoleApp.Models
{
    public class Customer
    {
        public string Info(string name, string surname)
        {
            return $"{name} {surname}";
        }
        
    }
}
