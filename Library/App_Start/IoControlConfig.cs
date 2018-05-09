using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Library.Services;
using Library.Contracts.Services;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Library.Repository;
using Library.Contracts.Repository;
using Library.Controllers;

namespace Library.App_Start
{
    public class IoControlConfig
    {
        public static void RegisterDependencies()
        {
           var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UserController>().As<UserController>();
            builder.RegisterType<UserService>().As<IUserServices>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<BookService>().As<IBookServices>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}