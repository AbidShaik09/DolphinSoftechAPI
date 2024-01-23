using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Model
{
    public class LoginPattern
    {
        [Key]
        public int uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
