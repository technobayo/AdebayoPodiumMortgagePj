namespace AdebayoPodiumMortgagePj.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string InterestRate { get; set; }
        public double BaseLoanToValue { get; set; }
        public string InterestType { get; set; }
        public Lender Lender { get; set; }
    }
}
