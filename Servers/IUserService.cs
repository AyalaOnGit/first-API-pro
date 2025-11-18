using Entitys;

namespace Servers
{
    public interface IUserService
    {
        User AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        User Login(LoginUser UserR);
        bool UpdateUser(int id, User value);
    }
}