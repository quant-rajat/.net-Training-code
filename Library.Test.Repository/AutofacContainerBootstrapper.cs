
//using Autofac;

//namespace Library.Test.Repository
//{
//    public class AutofacContainerBootstrapper : IDependencyResolverBootstrapper
//    {
//        private static readonly object _lock = new object();
//        private static IDependencyResolver _dependencyResolver;

//        public IContainer CreateContainer()
//        {
//            var builder = new ContainerBuilder();
//            builder.RegisterType<MyComponent>().As<IMyComponent>();

//            builder.RegisterModule(new TestsModule(typeof(AutofacContainerBootstrapper).Assembly));

//            return builder.Build();
//        }

//        public IDependencyResolver GetResolver()
//        {
//            lock (_lock)
//            {
//                if (_dependencyResolver == null)
//                    _dependencyResolver = new AutofacDependencyResolver(CreateContainer());
//                return _dependencyResolver;
//            }
//        }
//    }
//}