namespace DesafioAPISimulacao.Domain.Entities
{
    
    public class ProposalEntity : BaseEntity
    {
        public double LoanAmmount { get; set; }
        public double AnnualInterestRate { get; set; }
        public int NumberofMonths { get; set; }
    }
}
