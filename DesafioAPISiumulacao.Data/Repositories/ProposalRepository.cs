using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioAPISimulacao.Domain.Entities;
using DesafioAPISiumulacao.Data;
using DesafioAPISimulacao.Data;

namespace DesafioAPISiumulacao.Data.Repositories
{
    public class ProposalRepository : RepositoryBase<ProposalEntity>
    {
        public ProposalRepository(IConfiguration configuration) : base(configuration) { 
        
        }
    }
}
