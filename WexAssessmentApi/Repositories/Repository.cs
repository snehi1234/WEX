using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WexAssessmentApi.Repositories
{
    /// <summary>
    /// Abstract repository class that implements basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">Type of entity implementing IIdentifiable</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        protected readonly ConcurrentDictionary<int, T> _store = new ConcurrentDictionary<int, T>();
        protected int _nextId = 1;
        private readonly object _lock = new object();

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>List of all entities</returns>
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_store.Values.AsEnumerable());
        }

        /// <summary>
        /// Gets an entity by ID.
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>The entity if found, otherwise null</returns>
        public Task<T> GetByIdAsync(int id)
        {
            _store.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Task</returns>
        public Task AddAsync(T entity)
        {
            lock (_lock)
            {
                entity.Id = _nextId++;
            }
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>Task</returns>
        public Task UpdateAsync(T entity)
        {
            _store.AddOrUpdate(entity.Id, entity, (key, oldValue) => entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deletes an entity by ID.
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Task</returns>
        public Task DeleteAsync(int id)
        {
            _store.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}


