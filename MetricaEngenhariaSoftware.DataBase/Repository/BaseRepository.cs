using System.Collections.Generic;
using MetricaEngenhariaSoftware.DataBase.Interfaces;

namespace MetricaEngenhariaSoftware.DataBase.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public T GetById()
        {
            throw new System.NotImplementedException();
        }

        public void Add(T entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
