using System.Text.Json;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbShopContext _dbShopContext;
        public UserRepository(DbShopContext dbShopContext)
        {
            _dbShopContext = dbShopContext;
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public async Task<User> GetUserById(int id)
        {
            return await _dbShopContext.FindAsync<User>(id);
        }


        public async Task<User> AddUser(User user)
        {
            await _dbShopContext.Users.AddAsync(user);
            await _dbShopContext.SaveChangesAsync(); 
            return await _dbShopContext.Users.FindAsync(user.UserId);
        }


        public async Task<User> Login(LoginUser loginUser)
        {
            return await _dbShopContext.Users.FirstOrDefaultAsync(x => x.UserEmail == loginUser.LoginUserEmail && x.Password == loginUser.LoginUserPassword);    
        }


        public async Task UpdateUser(int id, User updatedUser)
        {
            _dbShopContext.Users.Update(updatedUser);
            await _dbShopContext.SaveChangesAsync();
        }


        public void DeleteUser(int id)
        {
        }
    }
}
