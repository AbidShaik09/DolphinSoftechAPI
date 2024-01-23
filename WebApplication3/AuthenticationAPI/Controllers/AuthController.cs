using AuthenticationAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data_;
using WebApplication3.Model;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginPattern userdetails)
        {

            string username=userdetails.username;

            Report user = _db.reports.FirstOrDefault(reports => reports.username == username);
            if (user != null)
            {
                if (user.password == userdetails.password)
                {

                    TokenAuthenticator authenticator = new TokenAuthenticator();
                    string accessToken = authenticator.GenerateAuthToken(userdetails);
                    return (Ok(accessToken));
                }
                else
                {
                    return NotFound("Incorrect Username/Password");
                }
            }
            else
            {
                return NotFound("Incorrect Username/Password");
            }

        }
        [HttpGet]
        public IActionResult CheckToken(string accessToken)
        {

            TokenAuthenticator a = new TokenAuthenticator();
            string s = "";
            if (s.Equals("Invalid Token"))
            {
                return BadRequest("Access Denied, You are not authorized to perform this request");
            }
            if (a.Authenticate(accessToken))
            {
                return Ok("Valid Access Token");
            }
            else
            {
                return BadRequest("Access Denied, You are not authorized to perform this request");
            }
        }

    }
}