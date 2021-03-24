using System.Collections.Generic;
using System.Linq;
using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Web.DTOs;

namespace AdebayoPodiumMortgagePj.Web.Mappers
{
    public static class ProductMapper
    {
        public static IEnumerable<ProductDto> ProductListToProductDtoList(IEnumerable<Product> products)
        {
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                InterestRate = p.InterestRate,
                BaseLoanToValue = p.BaseLoanToValue,
                InterestType = p.InterestType,
                Lender = LenderMapper.LenderToLenderDto(p.Lender)
            }).ToList();
        }
    }
}
