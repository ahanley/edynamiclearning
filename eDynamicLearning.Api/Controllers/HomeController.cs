using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace eDynamicLearning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private const string FindWhat = "dog";
        private const string ReplaceWith = "cat";

        [HttpPost]
        public IActionResult Index([FromBody] string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) { throw new ArgumentOutOfRangeException(input, "Input cannot be an empty string"); }
                var json = JObject.Parse(input);

                var props = json.Descendants()
                    .OfType<JProperty>()
                    .Where(p => p.Value.ToString().Equals(FindWhat));

                foreach (var p in props)
                {
                    p.Value = p.Value.Value<string>()
                        .Replace(FindWhat, ReplaceWith);
                }

                return Ok(json.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}
