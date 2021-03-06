using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IBaseService<T, IdType>
    {
        ICollection<T> find(Expression<Func<T, bool>> filter = null);

        T findById(IdType Id);

        T Create(T entity);

        T Update(T entity);

        void UpdateStatusById(IdType id, bool status);

        void Delete(T entity);

        void DeleteById(IdType Id);

        void SoftDelete(IdType Id);

        bool Exist(IdType Id);
        bool Exist(Expression<Func<T,bool>> expression);

        int GetTotalRecordCount();
    }