using AuthenticationAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data_;
using WebApplication3.Model;

namespace AuthenticationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class Client
    {
        public string username {  get; set; }
        public string accessToken {  get; set; }
    }
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpPost("Login/")]
        public IActionResult Login([FromBody] LoginPattern userdetails)
        {

            string username=userdetails.username;

            Report user = _db.reports.FirstOrDefault(reports => reports.Username == username);
            if (user != null)
            {
                if (user.Password == userdetails.password)
                {

                    TokenAuthenticator authenticator = new TokenAuthenticator();
                    Client response = authenticator.GenerateAuthToken(userdetails);
                    return (Ok(response));
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
        [HttpPost("/CheckTokenValidity")]
        public IActionResult CheckToken([FromBody] Client client)
        {
            string accessToken=client.accessToken;
            TokenAuthenticator a = new TokenAuthenticator();
            string s = "";
            if (s.Equals("Invalid Token"))
            {
                return BadRequest("Access Denied, You are not authorized to perform this request");
            }
            if (a.Authenticate(client))
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