using System;

namespace ReflectionLib.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        public Customer(int userCode):this()
        {
            UserCode = userCode;
        }
        public Customer(int userCode, string name, string surname, string email) : this()
        {
            UserCode = userCode;
            Name = name;
            Surname = surname;
            Email = email;
        }

       
        public Guid Id { get; private set; }= Guid.NewGuid();
        public int UserCode { get;private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public void Print()
        {
            Console.WriteLine($"{this.Id} ,{this.UserCode}, {this.Name}, {this.Surname}, {this.Email}");
        }

        public void SetUserCode(int userCode)
        {
            this.UserCode = userCode;
        }
    }
}
