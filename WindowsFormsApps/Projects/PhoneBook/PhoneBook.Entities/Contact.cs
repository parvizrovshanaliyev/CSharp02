using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Entities
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        #endregion
    }
}
