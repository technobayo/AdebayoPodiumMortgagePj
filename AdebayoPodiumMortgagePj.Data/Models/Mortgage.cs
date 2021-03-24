namespace AdebayoPodiumMortgagePj.Data.Models
{
    public class Mortgage
    {
        public int Id { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal PropertyValue { get; set; }
        public Customer Customer { get; set; }
    }
}
