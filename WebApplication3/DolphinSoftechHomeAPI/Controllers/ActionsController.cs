using AuthenticationAPI;
using AuthenticationAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data_;
using WebApplication3.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DolphinSoftechHomeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {


        private readonly ApplicationDbContext _db;

        public ActionsController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        // GET: <ActionsController/GetEmployees>
        [HttpPost("GetEmployeees")]
        public IActionResult employees([FromBody] Client client)
        {
            string accessToken = client.accessToken;
            if (accessToken == null)
            {
                return BadRequest("Unauthorized");
            }
            bool hasAccess = checkToken(client);
            if (hasAccess)
            {
                var listData = _db.reports.ToList();
                foreach(var report in listData)
                {
                    var user = report;
                    user.Password = "*hidden*";
                    user.IFSC =  "********" ;
                    user.AccountNumber =  "*********" ;

                }
                return Ok(listData);

            }
            else
            {
                return BadRequest("Not Authorized");
            }
        }
        [HttpPost("user/")]
        public IActionResult GetDetails([FromBody] Client thisUser)
        {
            string username = thisUser.username;
            bool hasAccess = checkToken(thisUser);
            if(hasAccess) {
                Report user = _db.reports.FirstOrDefault(reports => reports.Username == username);

                if (user == null)
                {
                    return NotFound("Something is wrong, We could not find your data"); // 404 Not Found
                }
                user.Password = "*hidden*";
                user.IFSC = user.IFSC[0] + user.IFSC[1]+ "***"+ user.IFSC[user.IFSC.Length-1];
                user.AccountNumber = user.AccountNumber[0] + "*******" + user.AccountNumber[user.AccountNumber.Length - 1];

                return Ok(user); // 200 OK
            }
            else
            {
                return BadRequest("Login Expired/Invalid");
            }
            
        }
        private bool checkToken(Client accessToken)
        {

            TokenAuthenticator tokenAuthenticator = new TokenAuthenticator();
            var response = tokenAuthenticator.Authenticate(accessToken);

            return response;
        }
    }
}






/*
 using AuthenticationAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data_;
using WebApplication3.Model;

namespace DolphinSoftechHomeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ActionsController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult employees([FromBody] string accessToken)
        {
            if(accessToken == null)
            {
                return BadRequest("Unauthorized");
            }
            bool hasAccess = checkToken(accessToken);
            if(hasAccess)
            {
                var listData=_db.reports.ToList();
                return Ok(listData);

            }
            else
            {
                return BadRequest("Not Authorized");
            }
        }
        private bool checkToken(string accessToken)
        {

            TokenAuthenticator tokenAuthenticator = new TokenAuthenticator();
            var response=tokenAuthenticator.Authenticate(accessToken);
            
            return false;
        }
    }
}

 */