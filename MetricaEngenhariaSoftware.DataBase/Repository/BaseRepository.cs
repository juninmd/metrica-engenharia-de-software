﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MetricaEngenhariaSoftware.DataBase.Interfaces;

namespace MetricaEngenhariaSoftware.DataBase.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MyContext _context;

        public BaseRepository(MyContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(item);
        }

        public void Add(T entidade)
        {
            _context.Set<T>().Add(entidade);
        }
    
        public void Update(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
