using System.Threading.Tasks;
using AdebayoPodiumMortgagePj.Service.IRepository;
using AdebayoPodiumMortgagePj.Web.DTOs;
using AdebayoPodiumMortgagePj.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AdebayoPodiumMortgagePj.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet("/api/customer")]
        public IActionResult GetCustomers()
        {
            var customers = _customerManager.GetAllCustomers();
            if (!customers.IsSuccess)
            {
                return BadRequest(customers);
            }
            return Ok(CustomerMapper.CustomerListToCustomerGetDtoList(customers.Data));
        }

        [HttpGet("/api/customer/{id}")]
        public IActionResult GetCustomer(string id)
        {
            var customer = _customerManager.GetCustomerWithId(id);
            if(!customer.IsSuccess)
            {
                return NotFound(customer);
            }
            return Ok(CustomerMapper.CustomerToCustomerGetDto(customer.Data));
        }

        [HttpPost("/api/customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            var customer = CustomerMapper.CustomerCreateDtoToCustomer(customerCreateDto);
            var result = await _customerManager.CreateCustomer(customer);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
