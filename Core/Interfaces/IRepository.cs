using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseDBEntity
    {
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        T FindFirst(Func<T, bool> predicate);
        IEnumerable<T> FindAndSortAll(Func<T, bool> predicate, Func<T, object> sortBy, SortHow sortHow);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(int entityId);
        int Save();
    }
}
