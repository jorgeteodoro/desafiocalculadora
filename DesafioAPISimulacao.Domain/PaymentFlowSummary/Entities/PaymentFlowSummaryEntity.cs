using DesafioAPISimulacao.Domain;


namespace DesafioAPISimulacao.Domain.Entities
{
    public class PaymentFlowSummaryEntity: BaseEntity
    {
        public double MonthlyPayment { get; set; }
        public double TotalInterest { get; set; }
        public double TotalPayment { get; set; }
        public int IdProposal { get; set; }

       
    }
}