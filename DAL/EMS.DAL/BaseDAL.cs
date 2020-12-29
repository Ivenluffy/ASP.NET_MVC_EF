using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public partial class BaseDAL<T>where T:class,new()
    {
        private DbContext dbContext = DbContextFactory.Create();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        public void Update(T t)
        {
            dbContext.Set<T>().AddOrUpdate(t);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }
        /// <summary>
        /// 查询获取
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }
        /// <summary>
        /// 分页查询获取
        /// </summary>
        /// <typeparam name="type">指定类型</typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalRecords">总共记录数</param>
        /// <param name="whereLambda">查询条件表达式树</param>
        /// <param name="orderByLambda">排序项表达式树</param>
        /// <param name="isAsc">是否升序排序</param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, out int totalRecords, Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderByLambda, bool isAsc)
        {
            IQueryable<T> results = dbContext.Set<T>().Where(whereLambda);
            totalRecords = results.Count();
            return isAsc ? results.OrderBy(orderByLambda).Skip((pageIndex-1)*pageSize) : results.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize);
        }
        /// <summary>
        /// 是否更改。
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges()>0;
        }
    }
}
