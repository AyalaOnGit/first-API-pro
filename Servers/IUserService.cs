using Entitys;

namespace Servers
{
    public interface IUserService
    {
        User AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        bool UpdateUser(int id, User user);
    }
}