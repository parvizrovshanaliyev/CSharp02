using System.Linq;
using PhoneBook.Core.Context;
using PhoneBook.Entities;

namespace PhoneBook.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PhoneBookDbContext _context;

        public UserRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        //public UserRepository()
        //{
        //    _context = new PhoneBookDbContext();
        //}
        #region Implementation of IUserRepository

        public int Login(User entity)
        {
            return _context.Users.Count(i => i.Username == entity.Username && i.Password == entity.Password);
        }

        #endregion
    }
}