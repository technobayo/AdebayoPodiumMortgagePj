﻿using System;

namespace AdebayoPodiumMortgagePj.Web.DTOs
{
    public class CustomerGetDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
