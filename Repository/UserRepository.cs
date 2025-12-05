using System.Text.Json;
using Entitys;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        db_shopContext _ShopContext;
        public UserRepository(db_shopContext ShopContext)
        {
            _ShopContext = ShopContext;
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public async Task<User> GetUserById(int id)
        {
            return await _ShopContext.FindAsync<User>(id);
        }


        public async Task<User> AddUser(User user)
        {
            await _ShopContext.Users.AddAsync(user);
            await _ShopContext.SaveChangesAsync(); 
            return await _ShopContext.Users.FindAsync(user.UserId);
        }



        public async Task<User> Login(LoginUser loginUser)
        {
            return await _ShopContext.Users.FirstOrDefaultAsync(x => x.UserEmail == loginUser.LoginUserEmail && x.Password == loginUser.LoginUserPassword);    
        }


<<<<<<< HEAD
        public async Task UpdateUser(int id, User updatedUser)
=======
        public async void UpdateUser(int id, User updatedUser)
>>>>>>> 2c52bab78f31f4cd7afa2026053ed949b4fdc19a
        {
            _ShopContext.Users.Update(updatedUser);
            await _ShopContext.SaveChangesAsync();
        }


        public void DeleteUser(int id)
        {
        }
    }
}
