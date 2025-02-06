using DesafioAPISimulacao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Data
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task<int> Insert(TEntity entity, bool normalizeString);
        SqlTransaction GetTransaction();
    }
}
