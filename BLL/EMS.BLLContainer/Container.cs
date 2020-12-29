using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using EMS.BLL;
using EMS.IBLL;

namespace EMS.BLLContainer
{
    public class Container
    {
        /// <summary>
        /// IOC容器
        /// </summary>
        public static IContainer container = null;
        /// <summary>
        /// 获取IBLL中的实例化对象
        /// </summary>
        /// <typeparam name=“T”></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("IOC实例化出错!" + ex.Message);
            }
        }
        /// <summary>
        /// 初始化，将所需要的访问接口依赖注入
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
