using Autofac;
using Library.Contracts.Repository;
using Library.Repository;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Abstractions;
using Xunit.Ioc.Autofac;
using Xunit.Sdk;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Library.Test.Repository")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Library.Test.Repository")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("4fa53ed6-78d4-49ba-a2b6-726afabeb1aa")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TestFramework("Library.Test.Repository.ConfigureTestFramework", "Library.Test.Repository")]

namespace Library.Test.Repository
{
    public class ConfigureRepositoryTest : AutofacTestFramework
    {
        public ConfigureRepositoryTest(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith(TestSuffixConvention));
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UserRepository"));
            builder.Register(context => new UserRepository()).AsSelf().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            // configure your container
            // e.g. builder.RegisterModule<TestOverrideModule>();

            Container = builder.Build();
        }
    }
}


//namespace Your.Test.Project
//{
//    public class ConfigureTestFramework : AutofacTestFramework
//    {
//        private const string TestSuffixConvention = "Tests";

//        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
//            : base(diagnosticMessageSink)
//        {
//            var builder = new ContainerBuilder();
//            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
//            //    .Where(t => t.Name.EndsWith(TestSuffixConvention));
//            builder.RegisterType<UserRepository>().As<IUserRepository>();

//            builder.Register(context => new TestOutputHelper())
//                .AsSelf()
//                .As<ITestOutputHelper>()
//                .InstancePerLifetimeScope();

//            // configure your container
//            // e.g. builder.RegisterModule<TestOverrideModule>();

//            Container = builder.Build();
//        }
//    }
//}