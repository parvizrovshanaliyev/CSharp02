using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Entities;

namespace PhoneBook.Core.Context
{
    public interface IPhoneBookDbContext
    {
        void SaveChanges();
    }
}
