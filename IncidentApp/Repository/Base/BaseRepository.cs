using IncidentApp.Models.Context;
using IncidentApp.Repository.Base.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IncidentApp.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IncidentContext context;
        private readonly DbSet<T> db;

        public BaseRepository(IncidentContext _context)
        {
            context = _context;
            db = _context.Set<T>();
        }

        public T Create(T entity)
        {
            db.Add(entity);

            context.SaveChanges();

            return entity;
        }

        public bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return db.Where(filter).Count() > 0;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            return db.Where(filter).AsEnumerable();
        }

        public T Read(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<T> Read()
        {
            return db.AsEnumerable();
        }

        public DbSet<T> TableInstance()
        {
            return db;
        }

        public T Update(T entity)
        {
            db.Update(entity);

            context.SaveChanges();

            return entity;
        }
    }
}
