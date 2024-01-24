using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication3.Model
{
    public class Report
    {
        [Key]
        public int sno { get; set; }

        [Required]
        [NotNull]
        public string Email { get; set; }


        [ProtectedPersonalData]
        [Required]
        [NotNull]
        public string Gender {  get; set; }



        [Required]
        [NotNull]
        public DateOnly BirthDay { get; set; }

        [Required]
        [NotNull]
        public string Username { get; set; }
        [Required]
        [NotNull]
        [PasswordPropertyText]
        [ProtectedPersonalData]
        public string Password { get; set; }
        [Required]
        [NotNull]
        public long PhoneNumber { get; set; }



        //Company-Related
        [Required]
        [NotNull]

        public string EID {  get; set; }
        [Required]
        [NotNull]
        public string Designation { get; set; }
        [MaxLength(600)]
        public string Bio { get; set; }

        [NotNull]
        public DateOnly JoinDate { get; set; }



        //Residence data 
        [Required]
        [NotNull]
        public string Country { get; set; }
        [Required]
        [NotNull]
        public string State { get; set; }

        [Required]
        [NotNull]
        public string City { get; set; }


        [Required]
        [NotNull]
        public int Pincode { get; set; }

        //Bank Account Data
        [Required]
        [NotNull]

        [ProtectedPersonalData]
        public string AccountNumber {  get; set; }
        [Required]
        [NotNull]
        [ProtectedPersonalData]
        public string IFSC { get; set; }
        
        
        
        
        
    }
}
