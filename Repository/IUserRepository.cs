using Entitys;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        void DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<User> Login(LoginUser loginUser);
<<<<<<< HEAD
        Task UpdateUser(int id, User updatedUser);
=======
        void UpdateUser(int id, User updatedUser);
>>>>>>> 2c52bab78f31f4cd7afa2026053ed949b4fdc19a
    }
}