using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : Entity;
        Task<List<T>> GetListAsync<T>() where T : Entity;
        Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity;
        Task<T> AddAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(T entity) where T : Entity;
    }
}
