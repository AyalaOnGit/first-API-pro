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

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        UserService server= new UserService();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) 
        {
            User user = server.GetUserById(id);
            if(user!= null)
            {
                return Ok(user);
            }
            return NoContent();
        }
  
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User creatUser = server.AddUser(user);
            if(creatUser!=null)
                return CreatedAtAction(nameof(Get), new{id = user.UserId}, user);
            return BadRequest("not good password");
        }


        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] LoginUser userR)
        {
            User logUser = server.Login(userR);
            if (logUser != null)
            {
                return CreatedAtAction(nameof(Get), new { id = logUser.UserId }, logUser);
            }
            return NoContent();
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            bool res=server.UpdateUser(id,value);
            if (!res)
            {
                return BadRequest("not good update password");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            server.DeleteUser(id);
        }
    }
}
