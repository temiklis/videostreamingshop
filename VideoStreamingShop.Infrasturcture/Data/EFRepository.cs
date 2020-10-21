using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture.Data
{
    internal class EFRepository : IRepository
    {
        public Task<T> AddAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
