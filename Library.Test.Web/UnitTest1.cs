using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Controllers;
using System.Web.Mvc;

namespace Library.Test.Web
{
    [TestClass]
    public class TestUsercontroller
    {
        UserController userController;
        public TestUsercontroller()
        {
            userController = new UserController();
        }
        public TestUsercontroller(UserController userController)
        {
            this.userController = userController;
        }
        [TestMethod]
        public void Pass_Test_Index()
        {
            var result = userController.GetResult(10) as JsonResult;
            Assert.AreEqual(10, result.Data);
        }
        [TestMethod]
        public void Fail_Test_Index()
        {
            var result = userController.GetResult(10) as JsonResult;
            Assert.AreEqual(11, result.Data);
        }
        //[TestMethod]
        //public async void Test_GetAllUsers()
        //{
        //    var result = await userController.GetAllUsers(1, 2);
        //    Assert.IsInstanceOfType(result, Object);
        //}

    }
}
