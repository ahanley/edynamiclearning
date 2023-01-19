using eDynamicLearning.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace eDynamicLearning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringService _stringService;
        public HomeController(IStringService stringService)
        {
            _stringService = stringService;
        }

        [HttpGet]
        public IActionResult Index(string input)
        {
            var find = "dog";
            var replaceWith = "cat";
            var response = (input == find) ? _stringService.ReplaceString(input, find, replaceWith) : input;
            return Ok(response);
        }
    }
}
