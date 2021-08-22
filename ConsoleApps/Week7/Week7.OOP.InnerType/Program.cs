using System;

namespace Week7.OOP.InnerType
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP.InnerType

            /*
             * OOP-de tez-tez istifade edilen inner type olaraq adlandirdigimiz mefhumu
             * ic-ice obyektlerin istifadesidir.
             *
             */

            #endregion

            Customer customer = new Customer
            {
                Name = "Flankes",
                Surname = "Flankesov",
                Email = "Flankesov@gmail.com",
                CustomerAddresses = new []
                {
                    new CustomerAddress
                    {
                        AddressType = "Isyeri",
                    },
                    new CustomerAddress
                    {
                        AddressType = "Isyeri",
                    }
                } 
            };

            // xeta verecek
            customer.CustomerAddresses[0] = new CustomerAddress
            {
                AddressType = "ev"
            };
        }
    }

    public class Customer
    {


        #region ctors

        public Customer()
        {
            CustomerAddresses = new CustomerAddress[5];
            CustomerOrders = new CustomerOrder[5];
            CustomerContacts = new CustomerContact[5];
        }

        #endregion

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }


        //public string AddressType { get; set; } // is yeri ve ya ev
        //public string Country { get; set; } 
        //public string City { get; set; } 
        //public string Address { get; set; } 

        public CustomerAddress[] CustomerAddresses;
        public CustomerContact[] CustomerContacts;
        public CustomerOrder[] CustomerOrders;

    }


    public class CustomerAddress
    {
        public string AddressType { get; set; } // is yeri ve ya ev
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }


    public class CustomerContact
    {
        public string Number { get; set; } 
        public string Code { get; set; }
    }

    public class CustomerOrder
    {
        public string Number { get; set; }
    }
}
