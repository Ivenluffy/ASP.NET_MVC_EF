using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.IBLL
{
    public partial interface IBaseService<T>where T:class,new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        bool Add(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        bool Update(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        bool Delete(T t);
        /// <summary>
        /// 查询获取
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
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
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, out int totalRecords, Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderByLambda, bool isAsc);
    }
}
