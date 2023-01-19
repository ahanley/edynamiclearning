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
            try
            {
                if (string.IsNullOrEmpty(input)) { throw new ArgumentOutOfRangeException(input, "Input cannot be an empty string"); }
                const string find = "dog";
                const string replaceWith = "cat";
                var response = input == find ? _stringService.ReplaceString(input, find, replaceWith) : input;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
