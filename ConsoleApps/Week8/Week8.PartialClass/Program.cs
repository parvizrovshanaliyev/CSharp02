using System;

namespace Week8.PartialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Partial class

            /*
             * Partial class anlayisi C# 2.0 ile birlikde gelmisdir.
             * Bu ozellik heddinden artiq kod setirlerinden ibaret class-i hisselere ayirmaga
             * yarayir, yeni class-in memberlerini ferqli partial class-larda saxlaya bilerik.
             */

            #endregion

            #region without partial

            Customer customer = new Customer
            {
                Id = 1,
                Name = "Customer1",
                Surname = "Customer1",
                Email = "Customer1@gmail.com",
            };
            var result=customer.Add(customer);
            if (result > 0)
            {
                Console.WriteLine("add ugurla yerine yetirildi");
            }
            else
            {
                Console.WriteLine("xeta bas verdi");
            }
            #endregion

            #region with partial

            Student student = new Student
            {
                Id = 1,
                Name = "Student",
                Surname = "Student",
                Email = "Student@gmail.com",
            };
            
            #endregion
        }
    }

    #region standart class

    public class Customer
    {
        #region ctor

        public Customer()
        {
            
        }
        #endregion
        #region props

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int CustomerNo { get; set; }
        public DateTime BirthDate { get; set; }

        #endregion

        #region methods

        public int Add(Customer customer)
        {
            //
            Console.WriteLine("database insert olunur");

            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int Update(Customer customer)
        {
            var result = 1; //_database.add(customer);
            // db daki obyektiizi redakte edirik
            Console.WriteLine("database redakte olunur");

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int: result</returns>
        public int Delete(int id)
        {
            var result = 1;
            //
            Console.WriteLine("db daki obyekt silinir");
            return result;
        }
        #endregion
    }
    #endregion
}
