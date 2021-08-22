using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.PartialClass
{
    public partial class Student
    {
        #region ctor

        public Student()
        {

        }
        #endregion
        #region props

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }


        #endregion

       
    }


}
