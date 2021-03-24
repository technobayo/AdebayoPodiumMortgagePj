using System;
using System.ComponentModel.DataAnnotations;

namespace AdebayoPodiumMortgagePj.Data.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public string Email { get; set; }
    }
}
