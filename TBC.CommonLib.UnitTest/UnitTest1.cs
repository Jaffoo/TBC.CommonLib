namespace TBC.CommonLib.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                List<string> ssr = new();
                ssr.ListStrToStr();
                var idcard = "530128".ToLong();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}