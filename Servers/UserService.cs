namespace Servers;

using Entitys;
using Repository;


public class UserService
{
    UserRepository repository=new UserRepository();
    PasswordService password = new PasswordService();
    public User GetUserById(int id)
    {
        return repository.GetUserById(id);
    }

    public User AddUser(User user)
    {
        Password passwordAfterCheck= password.CheckPassword(user.UserPassword);
        if (passwordAfterCheck.Level < 3)
            return null;
        return repository.AddUser(user);
    }
    public bool UpdateUser(int id, User value)//////בעייתי
    {
        Password passwordAfterCheck = password.CheckPassword(value.UserPassword);
        if (passwordAfterCheck.Level < 3) { 
            return false;
        }
        else { 
            repository.UpdateUser(id, value);
            return true;
        }
    }
    public User Login(LoginUser UserR)
    {
        return repository.Login(UserR);
    }
    public void DeleteUser(int id) {
        repository.DeleteUser(id);
    }
    
}
