namespace TBC.CommonLib.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string timespan = "1717753663";
            var date = Tools.TimeStampToDate(timespan);
        }
    }
}
