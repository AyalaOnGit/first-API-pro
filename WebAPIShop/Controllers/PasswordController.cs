using Entitys;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servers;

namespace WebAPIShop.Controllers
{
    public class PasswordController : Controller
    {
        PasswordService service = new PasswordService();

        [Route("api/[controller]")]
        public ActionResult<Password> Post( [FromBody] Password password)
        {
            password = service.CheckPassword(password.ThePassword);
            return Ok(password);
        }
    }
}
