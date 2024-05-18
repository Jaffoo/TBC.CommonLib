namespace TBC.CommonLib.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var res = await Tools.PostAsync("http://154.201.76.32:3000/get_friend_list","", new Dictionary<string, string>() { { "Authorization", "Bearer 5266" } });
        }
    }
}
