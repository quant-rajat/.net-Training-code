
using Autofac;
using Library.Contracts.Repository;
using Library.Contracts.Services;
using Library.Models;
using Library.Repository;
using Library.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.Test.Services
{
    public class Test_UserService /*: IClassFixture<DbFixture>*/
    {
        Mock<IUserRepository> userRepository;
        Mock<IUserRepository> userRepository2;
IUserServices userServices;
        //public Test_UserService(DbFixture fixture)
        //{
        //    userRepository = fixture.Container.Resolve<UserRepository>();
        //}


        [Theory]
        [InlineData(1, 2)]
        async public void Test_GetAllUserAsync_Type(int pagenumber, int rowcount)
        {

            userRepository = new Mock<IUserRepository>();
            userRepository2 = new Mock<IUserRepository>();
            userServices = new UserService(userRepository.Object);
            var expected_GetTotalUser = new List<User>();
            var expected_GetTotalUserCount = new int();
            userRepository2.Setup(d => d.GetTotalUserCount()).Returns(Task.FromResult(expected_GetTotalUserCount));
            userRepository.Setup(d => d.GetAllUserAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(expected_GetTotalUser));
            var result = await userServices.GetAllUserAsync(pagenumber, rowcount);
            Assert.IsType<PagedResults<User>>(result);
            
        }

        [Theory]
        [InlineData("QVT17-1232")]
        [InlineData("QVT17-123")]
        public void Test_UserHistory_NotNull(string id)
        {
            userRepository = new Mock<IUserRepository>();
            userServices = new UserService(userRepository.Object);
            var list = new List<IssuedBook>();
            userRepository.Setup(d => d.UserHistory(It.IsAny<string>())).Returns(list);
            var result = userServices.UserHistory(id);
            Assert.NotNull(result);
        }


    }
}
