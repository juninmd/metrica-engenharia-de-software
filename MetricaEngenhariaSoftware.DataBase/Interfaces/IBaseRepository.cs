using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.DataBase.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        void Delete(int id);
        void AddOrUpdate(T entidade);
        List<T> GetAll();

    }
}
