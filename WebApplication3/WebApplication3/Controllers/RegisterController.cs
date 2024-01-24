using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.Serialization;
using WebApplication3.Data_;
using WebApplication3.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        // GET: api/<ReportsController>
       
        public RegisterController(ApplicationDbContext db)
        {
            _db =db;
        }


        // GET api/<ReportsController>/5
       


        // POST api/<ReportsController>
        [HttpPost]
        public  IActionResult Post([FromBody] Report entry)
        {
            //var createdEmployee = await _db.Add<Report>(entry);
            Report user = _db.reports.FirstOrDefault(e=>(e.Username==entry.Username));
            if(entry == null)
            {
                
                return NotFound();

            }
            else if (user != null)
            {
                string message = "Employee exists";
                return NotFound(message);


            }
            _db.reports.Add(entry);
            _db.SaveChanges();
            return Ok();

        }


        // DELETE api/<ReportsController>/5
        [HttpDelete("{username}")]
        public void Delete(string username)
        {
            Report noticePeriodUser=_db.reports.FirstOrDefault(reports=>(reports.Username==username));
            if(noticePeriodUser!=null)
            {
                _db.reports.Remove(noticePeriodUser);
                _db.SaveChanges();
            }
            
        }
    }
}
