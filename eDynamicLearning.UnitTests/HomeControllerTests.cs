using eDynamicLearning.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Xunit;

namespace eDynamicLearning.UnitTests
{
    public class HomeControllerTests
    {

        [Fact]
        public void Index_ReturnsAOkObjectResult_WithArbitraryJsonInput()
        {
            //Arrange
            const string input = "{\"key1\": \"dog\", \"key2\": \"this is a test dog\", \"Test Nested Object\": {\"key3\": \"Another Test dog\", \"key4\": \"dog\", \"key5\": \"this is a cat\"}}";
            var expected = JToken.Parse("{\"key1\":\"cat\",\"key2\":\"this is a test dog\",\"Test Nested Object\":{\"key3\":\"Another Test dog\",\"key4\":\"cat\",\"key5\":\"this is a cat\"}}");
            var controller = new HomeController();

            //Act
            var actionResult = controller.Index(input);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okObjectResult);
            Assert.NotNull(okObjectResult.Value);
            var actual = JToken.Parse(okObjectResult.Value?.ToString());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Index_ReturnsAOkObjectResult_WithEmptyInput()
        {
            //Arrange
            const string input = "";
            const string expected = "Input cannot be an empty string";
            var controller = new HomeController();

            //Act
            var actionResult = controller.Index(input);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.NotNull(badRequestResult);
            Assert.NotNull(badRequestResult.Value);
            Assert.Equal(expected, badRequestResult.Value);
        }

    }
}