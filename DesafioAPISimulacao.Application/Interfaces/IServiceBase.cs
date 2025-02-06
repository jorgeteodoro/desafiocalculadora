using DesafioAPISimulacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Application.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        Task<int> Insert(TEntity entity, bool normalizeString = false);
    }
}
