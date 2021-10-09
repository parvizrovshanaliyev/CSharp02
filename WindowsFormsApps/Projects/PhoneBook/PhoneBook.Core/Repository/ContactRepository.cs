using System;
using System.Linq;
using PhoneBook.Core.Context;
using PhoneBook.Entities;

namespace PhoneBook.Core.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookDbContext _context;
        public ContactRepository()
        {
            _context = new PhoneBookDbContext();
        }
        #region Implementation of IContactRepository

        public int Add(Contact entity)
        {
            int result;
            try
            {
                _context.Contacts.Add(entity);
                _context.SaveChanges(_context.Contacts.First().GetEntityName(), _context.Contacts);

                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
                throw;
            }


            return result;
        }

        #endregion
    }
}
