using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhoneBook.Core.Context;
using PhoneBook.Entities;

namespace PhoneBook.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PhoneBookADODbContext _context;

        public UserRepository()
        {
            _context = new PhoneBookADODbContext();
        }
        #region Implementation of IUserRepository

        public int Login(User entity)
        {
            try
            {
                _context.Command =
                    new SqlCommand("select count(*) from [User] where Username=@Username and Password=@Password",
                        _context.Connection);
                _context.Command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = entity.Username;
                _context.Command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = entity.Password;
                _context.SetConnection();
                _context.ReturnValues = (int)_context.Command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _context.SetConnection();
            }

            return _context.ReturnValues;
        }

        #endregion
    }
}