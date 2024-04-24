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
                var idcard = Tools.PhoneHide("18787145600");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}