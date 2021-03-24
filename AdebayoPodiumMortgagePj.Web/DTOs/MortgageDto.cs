namespace AdebayoPodiumMortgagePj.Web.DTOs
{
    public class MortgageDto
    {
        public int Id { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal PropertyValue { get; set; }
        public CustomerGetDto Customer { get; set; }
    }
}
