using System;
using Library.Contracts.Repository;
using Library.Repository;
using Xunit;
using Xunit.Ioc;
using System.Threading.Tasks;
using Xunit.Ioc.Autofac;
using Autofac;
using Library.Models;
using System.Collections.Generic;
using Moq;
using System.Web.Helpers;
using System.Collections;

namespace Library.Test.Repository
{
    [UseAutofacTestFramework]
    //[RunWith(typeof(IocTestClassCommand))]
    //[DependencyResolverBootstrapper(typeof(AutofacContainerBootstrapper))]
    public class Test_UserRepository:IClassFixture<DbFixture>
    {
        IUserRepository userRepository ;

        //public Test_UserRepository()
        //{
        //}


        public Test_UserRepository(DbFixture fixture)
        {
            userRepository = fixture.Container.Resolve<IUserRepository>();
        }

        [Fact]
       async  public void Test_GetTotalUserCount()
        {
            //  IUserRepository userRepository = new UserRepository();

            //var mockDependency1 = new Mock<IUserRepository>();
            //mockDependency1.Setup<Task>(s => s.GetTotalUserCount()).Returns(Object);
            var result = await  userRepository.GetTotalUserCount();
            
            Assert.Equal(5, result);
        }


    }
}
