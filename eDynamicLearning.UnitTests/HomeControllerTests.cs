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
        public void Index_ReturnsAOkObjectResult_WithAExactInput()
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
        public void Json_ReturnsAOkObjectResult_WithAExactInput()
        {
            //Arrange
            const string input = "dog";
            const string expected = "cat";
            var controller = new HomeController(_stringService);

            //Act
            var actionResult = controller.JsonData(input);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okObjectResult);
            Assert.Equal(expected, okObjectResult.Value);
        }


        [Fact]
        public void Index_ReturnsAOkObjectResult_WithAContainsInput()
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

        [Fact]
        public void Index_ReturnsABadRequestObjectResult_WithANullInput()
        {
            //Arrange
            string input = null;
            const string expected = "Input cannot be an empty string";
            var controller = new HomeController(_stringService);

            //Act
            var actionResult = controller.Index(input);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(badRequestResult);
            Assert.Equal(expected, badRequestResult.Value);
        }

    }
}