using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhoneBook.Core.Context;
using PhoneBook.Entities;

namespace PhoneBook.Core.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookADODbContext _context;
        public ContactRepository()
        {
            _context = new PhoneBookADODbContext();
        }
        #region Implementation of IContactRepository

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Contact entity)
        {
            try
            {
                _context.Command = new SqlCommand(
                    "insert into Contact (Id ,Name,Surname,Number1,Number2,Number3,Address,Email,Description) values (@Id ,@Name ,@Surname ,@Number1 ,@Number2 ,@Number3 ,@Address ,@Email ,@Description )",
                    _context.Connection);

                // insert into values hissesindeki deyerler assign edilir.
                _context.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = entity.Id;
                _context.Command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                _context.Command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = entity.Surname;
                _context.Command.Parameters.Add("@Number1", SqlDbType.NVarChar).Value = entity.Number1;
                _context.Command.Parameters.Add("@Number2", SqlDbType.NVarChar).Value = entity.Number2;
                _context.Command.Parameters.Add("@Number3", SqlDbType.NVarChar).Value = entity.Number3;
                _context.Command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = entity.Address;
                _context.Command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = entity.Email;
                _context.Command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;

                // connection acib baglayir,
                _context.SetConnection();

                // command-daki tsql code excute edilir.
                _context.ReturnValues = _context.Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                // connection acib baglayir,
                _context.SetConnection();
            }


            return _context.ReturnValues;
        }

        public int Update(Contact entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
