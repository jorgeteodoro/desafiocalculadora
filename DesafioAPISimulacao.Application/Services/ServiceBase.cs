using DesafioAPISimulacao.Application.Interfaces;
using DesafioAPISimulacao.Data;
using DesafioAPISimulacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Application.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository) {
            _repository = repository
               ?? throw new ArgumentNullException(nameof(repository));
        }
        
        public async Task<int> Insert(TEntity entity, bool normalizeString = false)
        {
            return await _repository.Insert(entity, normalizeString);
        }

    }
}
