using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MetricaEngenhariaSoftware.DataBase.Interfaces;

namespace MetricaEngenhariaSoftware.DataBase.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        private readonly MyContext _context;
        internal DbSet<T> DbSet;


        public BaseRepository(MyContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void AddOrUpdate(T entidade)
        {
            _context.Set<T>().AddOrUpdate(entidade);
            _context.SaveChanges();
        }


        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
