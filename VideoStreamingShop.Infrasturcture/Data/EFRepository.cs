using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace VideoStreamingShop.Infrasturcture.Data
{
    internal class EFRepository : IRepository
    {
        private readonly VideoShopDbContext _shopDbContext;
        public EFRepository(VideoShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<T> AddAsync<T>(T entity) where T : Entity
        {
            var result = await _shopDbContext.AddAsync(entity);
            await _shopDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : Entity
        {
            _shopDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            try
            {
                await _shopDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("error {0}", e);
            }

        }

        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            var entity = await _shopDbContext.FindAsync<T>(id);
            if (entity != null)
                return entity;

            return default(T);
        }

        public async Task<List<T>> GetListAsync<T>() where T : Entity
        {
            var entities = await _shopDbContext.Set<T>().AsQueryable().ToListAsync();
            return entities;
        }

        public async Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity
        {
           var query = new SpecificationEvaluator<T>().GetQuery(_shopDbContext.Set<T>().AsQueryable(), spec);
           return await query.ToListAsync();
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
