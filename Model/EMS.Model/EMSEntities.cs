namespace EMS.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EMSEntities : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“EMSEntities”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“EMS.Model.EMSEntities”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“EMSEntities”
        //连接字符串。
        public EMSEntities()
            : base("name=EMSEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除以类名复数形式生成数据表的协议
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            //
            modelBuilder.Entity<Department>().HasMany(p => p.UserInfo).WithRequired(p => p.Department).HasForeignKey(p => p.DepartmentId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Department>().HasMany(p => p.Children).WithOptional(p => p.Parent).HasForeignKey(p => p.ParentId);
        }
        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public DbSet<Department> Department { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}