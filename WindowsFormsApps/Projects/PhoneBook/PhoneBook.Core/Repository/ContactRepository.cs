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

        private SqlDataReader GetAllDataReader()
        {
            _context.Command = new SqlCommand(
                "select * from Contact",
                _context.Connection);
            _context.SetConnection();
            return _context.Command.ExecuteReader();
        }

        private SqlDataReader GetByIdDataReader(Guid id)
        {
            _context.Command = new SqlCommand(
                "select * from Contact where Id=@Id",
                _context.Connection);
            _context.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            _context.SetConnection();
            return _context.Command.ExecuteReader();
        }
        public Contact GetById(Guid id)
        {
            var entity = new Contact();

            try
            {
                SqlDataReader reader = GetByIdDataReader(id);

                while (reader.Read())
                {
                    entity=new Contact
                    {
                        Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Number1 = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Number2 = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Number3 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Address = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Website = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),

                    };
                }
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

            return entity;
        }
        public List<Contact> GetAll()
        {
            List<Contact> entities = new List<Contact>();

            try
            {
                SqlDataReader reader = GetAllDataReader();

                while (reader.Read())
                {
                    entities.Add(new Contact
                    {
                        Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Number1 = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Number2 = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Number3 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Address = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Website = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Description = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),

                    });
                }
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

            return entities;
        }

        

        public int Add(Contact entity)
        {
            try
            {
                _context.Command = new SqlCommand(
                    "insert into Contact (Id ,Name,Surname,Number1,Number2,Number3,Address,Email,Website,Description) values (@Id ,@Name ,@Surname ,@Number1 ,@Number2 ,@Number3 ,@Address ,@Email ,@Website ,@Description )",
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
                _context.Command.Parameters.Add("@Website", SqlDbType.NVarChar).Value = entity.Website;
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
            try
            {
                _context.Command = new SqlCommand(
                    "update Contact set Name=@Name,Surname=@Surname,Number1=@Number1,Number2=@Number2,Number3=@Number3,Address=@Address,Email=@Email,Description=@Description where Id=@Id",
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
                _context.Command.Parameters.Add("@Website", SqlDbType.NVarChar).Value = entity.Website;
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

        public int Delete(Guid id)
        {
            try
            {
                _context.Command = new SqlCommand(
                    "delete Contact where Id=@Id",
                    _context.Connection);

                // insert into values hissesindeki deyerler assign edilir.
                _context.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;

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

        #endregion
    }
}
