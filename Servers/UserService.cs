namespace Servers;

using Entitys;
using Repository;


public class UserService : IUserService
{
    IUserRepository _userRepository;
    IPasswordService _passwordService;

    public UserService(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public User AddUser(User user)
    {
        Password passwordAfterCheck = _passwordService.CheckPassword(user.UserPassword);
        if (passwordAfterCheck.Level < 3)
            return null;
        return _userRepository.AddUser(user);
    }
    public bool UpdateUser(int id, User value)
    {
        Password passwordAfterCheck = _passwordService.CheckPassword(value.UserPassword);
        if (passwordAfterCheck.Level < 3)
        {
            return false;
        }
        else
        {
            _userRepository.UpdateUser(id, value);
            return true;
        }
    }
    public User Login(LoginUser UserR)
    {
        return _userRepository.Login(UserR);
    }
    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }

}
