namespace Services;

using Entities;
using Repository;


public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public UserService(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<User> AddUser(User user)
    {
        Password passwordAfterCheck = _passwordService.CheckPassword(user.Password);
        if (passwordAfterCheck.Level < 3)
            return null;
        return await _userRepository.AddUser(user);
    }
    public async Task<bool> UpdateUser(int id, User user)
    {
        Password passwordAfterCheck = _passwordService.CheckPassword(user.Password);
        if (passwordAfterCheck.Level < 3)
        {
            return false;
        }
        else
        {
            await _userRepository.UpdateUser(id, user);
            return true;
        }
    }
    public async Task<User> Login(LoginUser loginUser)
    {
        return await _userRepository.Login(loginUser);
    }
    public async Task<bool> DeleteUser(int id)
    {
        return await _userRepository.DeleteUser(id);
    }

}
