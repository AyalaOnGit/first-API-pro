using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Servers;
using Entitys;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIShop.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) 
        {
            User user = _userService.GetUserById(id);
            if(user!= null)
            {
                return Ok(user);
            }
            return NotFound();
        }
  
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User createdUser = _userService.AddUser(user);
            if(createdUser!=null)
                return CreatedAtAction(nameof(Get), new{id = createdUser.UserId}, createdUser);
            return BadRequest("Password is not strong enough");
        }


        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginUser loginUser)
        {
            User user = _userService.Login(loginUser);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            bool isUpdateSuccessful = _userService.UpdateUser(id, user);
            if (!isUpdateSuccessful)
            {
                return BadRequest("Password is not strong enough");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
