using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //[HttpGet]
        //public ActionResult GetAllUsers() {
        //    UserManager userManager = new UserManager(new InMemoryUserDal());
        //    return Ok(userManager.GetAllUsers());
        //}

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            return Ok(userManager.GetAllUsers());
        }
    }
}
