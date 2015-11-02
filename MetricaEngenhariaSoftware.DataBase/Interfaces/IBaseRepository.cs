using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.DataBase.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById();
        void Add(T entidade);
        void Update(T entidade);
        List<T> GetAll();

    }
}
