using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stellantis.Cotacao.Infra.Data.Mappers;
using DesafioAPISimulacao.Domain.Entities;
using DesafioAPISiumulacao.Data.Repositories;
using DesafioAPISimulacao.Data;

namespace DesafioAPISiumulacao.Data
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase<PaymentFlowSummaryEntity>, PaymentFlowSummaryRepository>();
            services.AddTransient<IRepositoryBase<ProposalEntity>, ProposalRepository>();
            return services;
        }

        public static IConfiguration AddInfrastructureMapper(this IConfiguration configuration)
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new PaymentFlowSummaryMap(configuration));
                config.AddMap(new ProposalMap(configuration));
                config.ForDommel();
            });

            return configuration;
        }
    }
}

