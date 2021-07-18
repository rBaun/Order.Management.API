﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IEntityRepository<T>
    {
        Task<T> CreateEntity(T entity);
        Task<T> GetEntityById(int id);
        Task<List<T>> GetEntities();
        Task<T> UpdateEntity(T entity);
        Task<T> DeleteEntity(int id);
    }
}
