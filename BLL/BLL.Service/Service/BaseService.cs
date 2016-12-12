using BLL.Service.Interface;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;
using System.Linq.Expressions;
using DAL.Repository;
using BLL.Service.Factory;

namespace BLL.Service.Service
{
    public class BaseService<T, TKey> : IBaseService<T, TKey> where T : EntityBase<TKey>
    {
        protected IEntityRepository<T,TKey> Repository { get; set; }

        protected IUnitOfWork IUnitOfWork = ContextFactory.CurrentContext();

        public BaseService()
        {
            Repository = new EntityRepository<T, TKey>(IUnitOfWork);
        }

        public virtual T Find(TKey ID)
        {
            return Repository.Find(ID);
        }

        public virtual T Find(Expression<Func<T, bool>> where)
        {
            return Repository.Find(where);
        }

        public virtual IQueryable<T> FindList()
        {
            return Repository.FindList();
        }

        public virtual OperResult Add(T entity)
        {
            OperResult result = new OperResult();
            Repository.Add(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Message = "添加数据成功！";
                result.Data = entity;
            }
            else
            {
                result.Code = 0;
                result.Message = "添加数据失败！";
            }

            return result;
        }

        public virtual OperResult Update(T entity)
        {
            OperResult result = new OperResult();
            Repository.Update(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Message = "更新数据成功！";
                result.Data = entity;
            }
            else
            {
                result.Code = 0;
                result.Message = "更新数据失败！";
            }

            return result;
        }

        public virtual OperResult Delete(TKey id)
        {
            OperResult result = new OperResult();
            var _entity = Find(id);
            if (_entity == null)
            {
                result.Code = 10;
                result.Message = "ID为【" + id + "】的记录不存在！";
            }
            else
            {
                Repository.Delete(_entity);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Message = "删除数据成功！";
                }
                else
                {
                    result.Code = 0;
                    result.Message = "删除数据失败！";
                }
            }
            return result;
        }

        public virtual OperResult Delete(T entity)
        {
            OperResult result = new OperResult();
            Repository.Delete(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Message = "删除成功";
            }
            else
            {
                result.Code = 0;
                result.Message = "删除失败";
            }
            return result;
        }

        public virtual OperResult Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            OperResult result = new OperResult();
            Repository.Delete(where);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Message = "删除成功";
            }
            else
            {
                result.Code = 0;
                result.Message = "删除失败";
            }
            return result;
        }

        public virtual Paging<T> FindPageList(Paging<T> paging)
        {
            paging.Items = Repository.FindPageList(paging.PageSize, paging.PageIndex, out paging.TotalNumber).ToList();
            return paging;
        }


        public virtual Paging<T> FindPageList(Paging<T> paging, bool order)
        {
            paging.Items = Repository.FindPageList(paging.PageSize, paging.PageIndex, out paging.TotalNumber, order).ToList();
            return paging;
        }


        public virtual int Count()
        {
            return Repository.Count();
        }

        public virtual int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Repository.Count(predicate);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return Repository.FindList(where);
        }
    }
}
