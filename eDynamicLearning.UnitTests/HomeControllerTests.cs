using eDynamicLearning.Api.Controllers;
using eDynamicLearning.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace eDynamicLearning.UnitTests
{
    public class HomeControllerTests
    {
        private readonly IStringService _stringService;

        public HomeControllerTests()
        {
           _stringService = new StringService();
        }

        [Fact]
        public void HomeController_Index_TestWithExactString()
        {
            //Arrange
            const string input = "dog";
            const string expected = "cat";
            var controller = new HomeController(_stringService);

            //Act
            var actionResult = controller.Index(input);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okObjectResult);
            Assert.Equal(expected, okObjectResult.Value);
        }


        [Fact]
        public void HomeController_Index_TestWithContainsString()
        {
            //Arrange
            const string input = "This is a test with a string that contains dog";
            const string expected = "This is a test with a string that contains dog";
            var controller = new HomeController(_stringService);

            //Act
            var actionResult = controller.Index(input);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okObjectResult);
            Assert.Equal(expected, okObjectResult.Value);
        }

    }
}