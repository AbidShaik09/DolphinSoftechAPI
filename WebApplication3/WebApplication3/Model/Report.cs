using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Report
    {
        [Key]
        public int sno { get; set; }
        
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string designation { get; set; }
        public string accountNumber {  get; set; }
        public string IFSC { get; set; }
        public int pincode {  get; set; }
    }
}
