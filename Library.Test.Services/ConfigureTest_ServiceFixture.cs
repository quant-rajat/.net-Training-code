using Autofac;
using Library.Contracts.Repository;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test.Services
{
    public class DbFixture
    {
        public IContainer Container { get; private set; }

        public DbFixture()
        {
            var builder = new ContainerBuilder();
            //var option = new DbContextOptionsBuilder<UserContext>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFProject;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            //UserContext context = new UserContext(option);
            //builder.RegisterInstance(context).As<UserContext>();

            builder.RegisterType<UserRepository>().AsSelf().As<IUserRepository>();

            builder.RegisterAssemblyTypes(typeof(DbFixture).GetTypeInfo().Assembly);

            Container = builder.Build();
        }
    }
}
