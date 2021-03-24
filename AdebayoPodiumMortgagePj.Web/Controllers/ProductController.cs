using AdebayoPodiumMortgagePj.Service.IRepository;
using AdebayoPodiumMortgagePj.Web.DTOs;
using AdebayoPodiumMortgagePj.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AdebayoPodiumMortgagePj.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("/api/product")]
        public IActionResult GetAllProducts()
        {
            var products = _productManager.GetAllProducts();
            var productsDto = ProductMapper.ProductListToProductDtoList(products);
            return Ok(productsDto);
        }

        [HttpPost("/api/product")]
        public IActionResult CreateCustomerProduct([FromBody] MortgageDto mortgageDto)
        {
            var mortgage = MortgageMapper.MortgageDtoToMortgage(mortgageDto);
            var products = _productManager.GetCustomerProducts(mortgage);
            return Ok(products);
        }
    }
}
