using Entitys;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        User Login(LoginUser UserR);
        void UpdateUser(int id, User value);
    }
}