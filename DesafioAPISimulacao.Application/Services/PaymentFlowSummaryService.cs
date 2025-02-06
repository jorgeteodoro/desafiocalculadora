using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioAPISimulacao.Application.Services;
using DesafioAPISimulacao.Data;
using DesafioAPISimulacao.Domain.Entities;
using Microsoft.Extensions.Configuration;


namespace DesafioAPISimulacao.Application
{
    public class PaymentFlowSummaryService : ServiceBase<PaymentFlowSummaryEntity>
    {
        private readonly IConfiguration _configuration;

        public PaymentFlowSummaryService(IRepositoryBase<PaymentFlowSummaryEntity> repository, IConfiguration configuration) : base(repository)
        {
            _configuration = configuration;
        }
    }
}
