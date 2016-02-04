using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace o1Solution.LifeSouthDonor.Lib.Helpers
{
    public class JsonHelper
    {
        /// <summary>
        /// Takes a string (typically from a website) containing JSON of type Dictionary<string, List<string>>, parses it and returns the dictionary
        /// </summary>
        /// <param name="textContainingJson">The full string containing JSON</param>
        /// <param name="jsonStarterText">Where the JSON starts</param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> ParseJsonDictionaryFromString(string textContainingJson, string jsonStarterText)
        {
            const string FOOTER_TEXT = "]};";
            const int SUFFIX_LENGTH = 2;

            var start = textContainingJson.IndexOf(jsonStarterText);
            var stop = textContainingJson.IndexOf(FOOTER_TEXT, start);
            var textLength = stop - start;

            var parseableText = textContainingJson.Substring(start, textLength + SUFFIX_LENGTH);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(parseableText);
        }

        public static string RemoveCarriageReturns(string jsonText)
        {
            return Regex.Replace(jsonText, @"\r|\n", string.Empty); ;
        }
    }
}
