using System.Collections.Generic;
using WinForms.TodoApp.Entities.Concrete;

namespace WinForms.TodoApp.DataAccess.Abstract
{
    public interface IUserDal
    {
        UserEntity GetUser(string username, string password);
        List<UserEntity> GetAll();
        void Add(UserEntity data);
    }
}
