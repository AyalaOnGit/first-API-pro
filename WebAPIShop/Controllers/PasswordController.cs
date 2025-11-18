using Entitys;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servers;

namespace WebAPIShop.Controllers
{
    public class PasswordController : Controller
    {
        IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [Route("api/[controller]")]
        public ActionResult<Password> Post( [FromBody] Password password)
        {
            password = _passwordService.CheckPassword(password.ThePassword);
            return Ok(password);
        }
    }
}
