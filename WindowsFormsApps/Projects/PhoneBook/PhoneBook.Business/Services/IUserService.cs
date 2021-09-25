using PhoneBook.Entities;

namespace PhoneBook.Business.Services
{
    public interface IUserService
    {
        int Login(User entity);
    }
}