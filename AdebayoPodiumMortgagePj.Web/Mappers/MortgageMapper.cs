using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Web.DTOs;

namespace AdebayoPodiumMortgagePj.Web.Mappers
{
    public static class MortgageMapper
    {
        public static Mortgage MortgageDtoToMortgage(MortgageDto mortgageDto)
        {
            return new Mortgage
            {
                Id = mortgageDto.Id,
                DepositAmount = mortgageDto.DepositAmount,
                PropertyValue = mortgageDto.PropertyValue,
                Customer = CustomerMapper.CustomerGetDtoToCustomer(mortgageDto.Customer)
            };
        }
    }
}
