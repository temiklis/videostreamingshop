using Ardalis.Specification;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture.Data
{
    public class MockDataRepository : IRepository
    {
        private readonly List<Entity> entities = new List<Entity>() {
            new Video()
            {
                Id = 1,
                Name = "Тесла",
                Description = @"История одного из самых влиятельных физиков-изобретателей ХХ века Николы Теслы.
                                Иммигрант из Сербии, переехав в Америку, вступает в неравное соперничество со своим великим работодателем Томасом Эдисоном.
                                Переживая неудачи, разочарования и гонения, Тесла упорно прокладывает свой особенный путь в науке.
                                Никола Тесла впервые сталкивается с электричеством еще в детстве, когда гладит кошку.",
                Price = 13.22m,
                AgeRate = AgeRating.PG  
            },
            new Video()
            {
                Name = "Элис",
                Description = @"После аварийной посадки космический пилот и его собака оказываются на неизведанной планете. 
                                Чтобы спасти себя и друга, герою приходится откинуть все привычные представления о гравитации, климате и времени. 
                                Независимый фантастический триллер режиссеров-дебютантов Джо Блэнда и Гранта Мартина, также исполнившего главную роль.",
                Price = 9.99m,
                AgeRate = AgeRating.PG13
            },
            new Video()
            {
                Name = "Форпост",
                Description = @"История неравного противостояния американских военных и боевиков движения Талибан, 
                                которые в несколько раз превосходили по численности силы США. Динамичная военная драма, основанная на реальных событиях.",
                Price = 9.99m,
                AgeRate = AgeRating.NC17
            }
        };

        public MockDataRepository()
        {
        }
        public Task<T> AddAsync<T>(T entity) where T : Entity
        {
            entities.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync<T>(T entity) where T : Entity
        {
            if (entities.Contains(entity))
                entities.Remove(entity);

            return Task.CompletedTask;
        }

        public Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            T entity = entities
                .Where(e => (e as Entity).Id == id)
                .SingleOrDefault() 
                as T;
            return Task.FromResult(entity);
        }

        public Task<List<T>> GetListAsync<T>() where T : Entity
        {
            return Task.FromResult(entities.Cast<T>().ToList());
        }

        public Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity
        {
            return Task.FromResult(entities
                .Take((int)spec.Take)
                .Skip((int)spec.Skip)
                .Cast<T>()
                .ToList()
                );
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            return Task.FromResult(default(T));
        }
    }
}
