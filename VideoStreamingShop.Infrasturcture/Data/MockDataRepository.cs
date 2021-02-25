using Ardalis.Specification;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly string fileExtension = "txt";
        private readonly string folder = "repositoryFolder";
        public MockDataRepository()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
        public async Task<T> AddAsync<T>(T entity) where T : Entity
        {
            entity.Id = AutoGenerate<T>();
            using (FileStream stream = new FileStream($@"{folder}\{entity.Id}.{typeof(T).ToString()}.{fileExtension}", FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(entity);
                    await writer.WriteLineAsync(json);
                }
            }

            return entity;
        }

        private int AutoGenerate<T>()
        {
            int id = 1;
            var path = $@"{folder}";
            var lastFilePath = Directory.EnumerateFiles(path, $"*.{typeof(T).ToString()}.{fileExtension}" ).LastOrDefault();
            if (lastFilePath != null)
            {
                id = int.Parse(lastFilePath.Replace(folder+"\\", string.Empty).Split('.').First());
                id += 1;
            }

            return id;
        }

        public Task DeleteAsync<T>(T entity) where T : Entity
        {
            var path = $@"{folder}\{entity.Id}.{typeof(T).ToString()}.{fileExtension}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }    
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            var path = $@"{folder}\{id}.{typeof(T).ToString()}.{fileExtension}";

            if (!File.Exists(path))
                return default(T);

            using(FileStream stream = new FileStream(path, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    var content = await reader.ReadToEndAsync();
                    var ent = JsonConvert.DeserializeObject<T>(content);
                    return ent;
                }
            }
        }

        public async Task<List<T>> GetListAsync<T>() where T : Entity
        {
            var results = new List<T>();
            var files = Directory.GetFiles($"{folder}", $"*.{typeof(T)}.{fileExtension}");
            foreach (var path in files)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    var content = await reader.ReadToEndAsync();
                    var entity = JsonConvert.DeserializeObject<T>(content);
                    results.Add(entity);
                }
            }

            return results;
        }

        public async Task<List<T>> GetListAsync<T>(ISpecification<T> spec) where T : Entity
        {
            var results = new List<T>();
            var files = Directory
                .EnumerateFiles($"{folder}", $"*.{typeof(T).ToString()}.{fileExtension}")
                .Take((int)spec.Take)
                .Skip((int)spec.Skip)
                .ToList();

            foreach (var path in files)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    var content = await reader.ReadToEndAsync();
                    var entity = JsonConvert.DeserializeObject<T>(content);
                    results.Add(entity);
                }
            }

            return results;
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            var path = $"{entity.Id}.{typeof(T).ToString()}.{fileExtension}";
            if (!File.Exists(path))
                return;

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(stream);
                var content = await streamReader.ReadToEndAsync();
                var ent = JsonConvert.DeserializeObject<T>(content);

                var id = ent.Id;
                ent = entity;
                ent.Id = id;

                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(ent);
                    await streamWriter.WriteAsync(json);
                }
            }
        }
    }
}
