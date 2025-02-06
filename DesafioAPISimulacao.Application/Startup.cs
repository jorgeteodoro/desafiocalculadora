using DesafioAPISimulacao.Application.Interfaces;
using DesafioAPISimulacao.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Application
{
    public static class Startup
    {
      
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {

            //implementar as DIs da service collections
            services.AddTransient<IServiceBase<ProposalEntity>, ProposalService>();
            services.AddTransient<IServiceBase<PaymentFlowSummaryEntity>, PaymentFlowSummaryService>();
            return services;
        }
    }
}
