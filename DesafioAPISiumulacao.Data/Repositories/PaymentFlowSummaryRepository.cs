using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioAPISimulacao.Domain.Entities;
using DesafioAPISimulacao.Data;

namespace DesafioAPISiumulacao.Data.Repositories
{
    public class PaymentFlowSummaryRepository: RepositoryBase<PaymentFlowSummaryEntity>
    {
        public PaymentFlowSummaryRepository(IConfiguration configuration) : base(configuration) { 
        
        }
    }
}
