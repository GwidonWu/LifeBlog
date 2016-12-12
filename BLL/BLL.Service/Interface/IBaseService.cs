using BLL.Contract;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Service.Interface
{
    /// <summary>
    /// 单模型管理类接口
    /// </summary>
    public interface IBaseService<T,TKey> where T : EntityBase<TKey>
    {
        T Find(TKey ID);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> FindList();
        IQueryable<T> FindList(Expression<Func<T, bool>> where);
        OperResult Add(T entity);
        OperResult Update(T entity);
        OperResult Delete(TKey id);
        OperResult Delete(T entity);
        OperResult Delete(Expression<Func<T, bool>> where);
        Paging<T> FindPageList(Paging<T> paging);
        Paging<T> FindPageList(Paging<T> paging, bool order);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
    }
}
