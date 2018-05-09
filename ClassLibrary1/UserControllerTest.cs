using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Xunit;
using Moq;
using Library.Contracts.Services;
using Library.Controllers;

namespace ClassLibrary1
{
    public class UserControllerTest
    {
        UserController userController;
        public UserControllerTest( UserController userController)
        {
            this.userController = userController;
        }

        [Fact]
        
        public void TestIndexReturnsViewResult()
        {
            // var mockService = new Mock< IUserServices > ();
            //var controller = new UserController();
            var result = userController.GetResult();
            Assert.Equal("10", Convert.ToString(result));

        }


    }
}
