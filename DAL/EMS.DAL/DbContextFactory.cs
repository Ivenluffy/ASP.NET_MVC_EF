using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Model;

namespace EMS.DAL
{
    /// <summary>
    /// EF上下文工厂
    /// </summary>
    public partial class DbContextFactory
    {
        public static DbContext Create()
        {
            /// <summary>
            /// 已存在就直接获取EF上下文对象,不存在就创建,保证线程内是唯一。
            /// </summary>
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)
            {
                dbContext = new EMSEntities();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
