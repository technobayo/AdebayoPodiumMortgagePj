using AdebayoPodiumMortgagePj.Data.Models;
using AdebayoPodiumMortgagePj.Web.DTOs;

namespace AdebayoPodiumMortgagePj.Web.Mappers
{
    public static class LenderMapper
    {
        public static LenderDto LenderToLenderDto(Lender lender)
        {
            return new LenderDto
            {
                Id = lender.Id,
                Name = lender.Name
            };
        }
    }
}
