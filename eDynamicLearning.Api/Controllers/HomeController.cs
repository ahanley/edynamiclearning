using eDynamicLearning.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace eDynamicLearning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringService _stringService;
        private const string FindWhat = "dog";
        private const string ReplaceWith = "cat";


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
                var response = input == FindWhat ? _stringService.ReplaceString(input, FindWhat, ReplaceWith) : input;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult JsonData([FromBody] string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) { throw new ArgumentOutOfRangeException(input, "Input cannot be an empty string"); }
                var response = input == FindWhat ? _stringService.ReplaceString(input, FindWhat, ReplaceWith) : input;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
