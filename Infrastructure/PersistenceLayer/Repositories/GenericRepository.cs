using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    internal class GenericRepositoryy<TEntity, TKey> (StoreDbContext _dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public  async Task AddAsync(TEntity entity)
            =>await _dbContext.Set<TEntity>().AddAsync(entity);
        

        public async Task<IEnumerable<TEntity>> GetALLAsync()
          => await _dbContext.Set<TEntity>().ToListAsync();

       

       

        public void Remove(TEntity entity)
          => _dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)
          => _dbContext.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specifications)
        {
            //var baseQuery = _dbContext.Set<TEntity>();
            //if (specifications.Criteria is not null)
            //{
            //    var criteria = specifications.Criteria;
            //    baseQuery = baseQuery.Where(criteria);
            //}
            return  await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).ToListAsync();

        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specifications)
        {
            //var baseQuery = _dbContext.Set<TEntity>();
            //if (specifications.Criteria is not null)
            //{
            //    var criteria = specifications.Criteria;
            //    baseQuery = baseQuery.Where(criteria);
            //}
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();

        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
          => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).CountAsync(); throw new NotImplementedException();
        }
    }
}
