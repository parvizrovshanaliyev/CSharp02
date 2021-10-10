using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Entities;

namespace PhoneBook.Business.Services
{
    public interface IContactService
    {
        int Add(Contact entity);
        int Update(Contact entity);
        int Delete(Guid id);
        List<Contact> GetAll();
        int ExportXML();
        int ExportCSV();
        int ExportJSON();
    }
}
