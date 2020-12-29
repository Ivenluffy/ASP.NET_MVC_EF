using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using EMS.IDAL;
using EMS.DAL;

namespace EMS.DALContainer
{
    /// <summary>
    /// IOC容器
    /// </summary>
    public class Container
    {
        public static IContainer container = null;
        /// <summary>
        /// 获取IDAL中的实例化对象
        /// </summary>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            if (container == null)
            {
                Initialise();
            }
            return container.Resolve<T>();
        }
        /// <summary>
        /// 初始化，将所需要的访问接口依赖注入
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoDAL>().As<IUserInfoDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentDAL>().As<IDepartmentDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
