using DesafioAPISimulacao.Application.Services;
using DesafioAPISimulacao.Data;
using DesafioAPISimulacao.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Application
{
    public class ProposalService: ServiceBase<ProposalEntity>
    {
        private readonly IConfiguration _configuration;

        public ProposalService(IRepositoryBase<ProposalEntity> repository, IConfiguration configuration) : base(repository)
        {
            _configuration = configuration;
        }
    }
}
