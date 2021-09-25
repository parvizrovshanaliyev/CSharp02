using PhoneBook.Entities;

namespace PhoneBook.Core.Repository
{
    public interface IUserRepository
    {
        int Login(User entity);
    }
}