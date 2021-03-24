using System;
using System.ComponentModel.DataAnnotations;

namespace AdebayoPodiumMortgagePj.Web.DTOs
{
    public class CustomerCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
