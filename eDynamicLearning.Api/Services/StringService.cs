using System.Text.RegularExpressions;

namespace eDynamicLearning.Api.Services
{
    public interface IStringService
    {
        string ReplaceString (string value, string find, string replace);
    }

    public class StringService : IStringService
    {
        public string ReplaceString(string input, string find, string replace)
        {
            return Regex.Replace(input, $@"\b{find}\b", replace);
        }
    }
}
