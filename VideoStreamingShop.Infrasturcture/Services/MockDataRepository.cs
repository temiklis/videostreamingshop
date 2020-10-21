using Ardalis.Specification;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture.Services
{
    public class MockDataRepository : IRepository
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
            var moq = new Mock<List<T>>();
            moq.Setup(a => a.GetRange(0, 20)).Returns(new List<T>());
            return Task.FromResult(moq.Object);
        }

        public Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity
        {
            var moq = new Mock<List<T>>();
            moq.Setup(a => a.GetRange(0, 20)).Returns(new List<T>());
            return Task.FromResult(moq.Object);
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
