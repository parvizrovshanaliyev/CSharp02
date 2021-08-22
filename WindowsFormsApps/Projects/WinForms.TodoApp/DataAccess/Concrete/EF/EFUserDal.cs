using System;
using System.Collections.Generic;
using WinForms.TodoApp.DataAccess.Abstract;
using WinForms.TodoApp.Entities.Concrete;

namespace WinForms.TodoApp.DataAccess.Concrete
{
    public class EFUserDal : IUserDal
    {
        #region Implementation of IUserDal

        public UserEntity GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(UserEntity data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
