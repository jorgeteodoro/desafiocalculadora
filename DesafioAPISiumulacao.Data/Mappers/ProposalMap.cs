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
    class ProposalMap : DommelEntityMap<ProposalEntity>
    {
        public ProposalMap() { }
        internal ProposalMap(IConfiguration configuration)
        {

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            ToTable("Proposal");
            Map(t => t.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(t => t.LoanAmmount).ToColumn("LoanAmmount");
            Map(t => t.AnnualInterestRate).ToColumn("AnnualInterestRate");
            Map(t => t.NumberofMonths).ToColumn("NumberofMonths");
        }
    }
}
