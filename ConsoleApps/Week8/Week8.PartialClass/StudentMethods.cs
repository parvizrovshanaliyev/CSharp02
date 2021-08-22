using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.PartialClass
{
    public partial class Student
    {
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
}
