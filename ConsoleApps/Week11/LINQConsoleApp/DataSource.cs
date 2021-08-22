using System;
using System.Collections.Generic;

namespace LINQConsoleApp
{
    public static class DataSource
    {
        private static readonly List<Customer> Customers;

        static DataSource()
        {
            Customers = new List<Customer>();
        }

        public static List<Customer> GetCustomers()
        {
            for (int i = 1; i <= 1000; i++)
            {
                Customer customer = new Customer
                {
                    Id = i,
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Country = FakeData.PlaceData.GetCountry(),
                    City = FakeData.PlaceData.GetCity(),
                    Region = FakeData.PlaceData.GetCountry(),
                    Phone = FakeData.PhoneNumberData.GetPhoneNumber(),
                    Birthdate = FakeData.DateTimeData.GetDatetime(new DateTime(1910,12,12), new DateTime(2020,12,12))
                };

                customer.Email = $"{customer.Name}.{customer.Surname}@{FakeData.NetworkData.GetDomain()}";
                Customers.Add(customer);
            }

            return Customers;
        }
    }
}
