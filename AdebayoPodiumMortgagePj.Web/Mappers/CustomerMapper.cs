using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Web.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace AdebayoPodiumMortgagePj.Web.Mappers
{
    public static class CustomerMapper
    {
        public static Customer CustomerCreateDtoToCustomer(CustomerCreateDto customerDto)
        {
            return new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                DateOfBirth = customerDto.DateOfBirth,
                Email = customerDto.Email
            };
        }

        public static CustomerGetDto CustomerToCustomerGetDto(Customer customer)
        {
            return new CustomerGetDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email
            };
        }

        public static Customer CustomerGetDtoToCustomer(CustomerGetDto customerGetDto)
        {
            return new Customer
            {
                Id = customerGetDto.Id,
                FirstName = customerGetDto.FirstName,
                LastName = customerGetDto.LastName,
                DateOfBirth = customerGetDto.DateOfBirth,
                Email = customerGetDto.Email
            };
        }

        public static IEnumerable<CustomerGetDto> CustomerListToCustomerGetDtoList(IEnumerable<Customer> customers)
        {
            return customers.Select(c => new CustomerGetDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Email = c.Email
            }).ToList();
        }
    }
}
