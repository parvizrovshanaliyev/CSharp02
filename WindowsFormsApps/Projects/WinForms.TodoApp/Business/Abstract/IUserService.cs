using WinForms.TodoApp.Entities.Concrete;

namespace WinForms.TodoApp.Business.Abstract
{
    public interface IUserService
    {
        UserEntity GetUser(string username, string password);
    }
}