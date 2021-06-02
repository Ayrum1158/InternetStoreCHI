using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ISRepository<T> : IRepository<T> where T : BaseDBEntity
    {
        private readonly ISContext dbcontext;
        private DbSet<T> fieldOfWork;

        public ISRepository(ISContext dbcontext)
        {
            this.dbcontext = dbcontext;

            fieldOfWork = dbcontext.Set<T>();
        }

        public void Add(T entity)
        {
            fieldOfWork.Add(entity);
        }

        public void Remove(int entityId)
        {
            T entity = (T)new BaseDBEntity(entityId);
            fieldOfWork.Attach(entity);
            fieldOfWork.Remove(entity);
        }

        public IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return fieldOfWork.Where(predicate);
        }

        public IEnumerable<T> FindAndSortAll(Func<T, bool> predicate, Func<T, object> sortBy, SortHow sortHow)
        {
            switch(sortHow)
            {
                case SortHow.Ascending:
                    return fieldOfWork.Where(predicate).OrderBy(sortBy);
                case SortHow.Descending:
                    return fieldOfWork.Where(predicate).OrderByDescending(sortBy);
                default:// SortHow.None
                    return fieldOfWork.Where(predicate);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return fieldOfWork;
        }

        public void Update(T entity)
        {
            fieldOfWork.Update(entity);
        }

        public int Save()
        {
            return dbcontext.SaveChanges();
        }

        public T FindFirst(Func<T, bool> predicate)
        {
            return fieldOfWork.Where(predicate).FirstOrDefault();
        }
    }
}
