using System.Collections.Generic;

namespace OrderManagement.Persistence.Interfaces
{
    public interface IEntityRepository<T>
    {
        T CreateEntity(T entity);
        T GetEntityById(int id);
        List<T> GetEntities();
        T UpdateEntity(T entity);
        T DeleteEntity(int id);
    }
}
