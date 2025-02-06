using Microsoft.Extensions.Configuration;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioAPISimulacao.Domain.Entities;


namespace Stellantis.Cotacao.Infra.Data.Mappers
{
    class PaymentFlowSummaryMap : DommelEntityMap<PaymentFlowSummaryEntity>
    {
        public PaymentFlowSummaryMap() { }
        internal PaymentFlowSummaryMap(IConfiguration configuration)
        {

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            //string schema = configuration.GetSection("Schema").Value.ToString();

            ToTable("PaymentFlowSummary");
            Map(t => t.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(t => t.IdProposal).ToColumn("IdProposal");
            Map(t => t.TotalPayment).ToColumn("totalPayment");
            Map(t => t.TotalInterest).ToColumn("totalInterest");
            Map(t => t.MonthlyPayment).ToColumn("monthlyPayment");

        }
    }
}
