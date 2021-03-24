namespace AdebayoPodiumMortgagePj.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string InterestRate { get; set; }
        public double BaseLoanToValue { get; set; }
        public string InterestType { get; set; }
        public LenderDto Lender { get; set; }
    }
}
