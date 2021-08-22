using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOWinForms
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }


        #region Overrides of Object

        public override string ToString()
        {
            return $"{this.Name} {this.Surname}";
        }

        #endregion

        public string GetInfo()
        {
            return
                $"Name:{this.Name} Surname:{this.Surname} Email:{this.Email} Company:{this.Company} Country:{this.Country}";
        }
    }
}
