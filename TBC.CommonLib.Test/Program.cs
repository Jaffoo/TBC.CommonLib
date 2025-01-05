using Newtonsoft.Json.Linq;

namespace TBC.CommonLib.Test
{
    internal class Program
    {
        static void Main()
        {
            var content = File.ReadAllText("C:\\Users\\gaffo\\Desktop\\test.json");
            var result = content.Fetch("data");
            var result1 = content.Fetch<JArray>("data");
        }
    }
}
