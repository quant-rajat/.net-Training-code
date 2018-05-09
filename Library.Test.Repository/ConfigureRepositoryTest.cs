using Autofac;
using Library.Contracts.Repository;
using Library.Repository;
using System.Linq;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Ioc.Autofac;
using Xunit.Sdk;


//[assembly: TestFramework("Your.Test.Project.ConfigureTestFramework", "AssemblyName")]
namespace Library.Test.Repository
{
    //public class ConfigureRepositoryTest : AutofacTestFramework
    //{
    //    public ConfigureRepositoryTest(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
    //    {
    //        var builder = new ContainerBuilder();
    //        //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
    //        //    .Where(t => t.Name.EndsWith(TestSuffixConvention));
    //        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UserRepository"));
    //        builder.Register(context => new UserRepository()).AsSelf().As<IUserRepository>().InstancePerLifetimeScope();
    //        builder.RegisterType<UserRepository>().As<IUserRepository>();
    //        // configure your container
    //        // e.g. builder.RegisterModule<TestOverrideModule>();

    //        Container = builder.Build();
    //    }
    //}
}
