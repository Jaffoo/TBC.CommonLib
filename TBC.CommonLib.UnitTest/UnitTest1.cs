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
                var idcard = "530128";
                var birthday = Tools.BirthdayFromIDCard(idcard);
                var sex = Tools.SexFromIDCard(idcard);
                var age = Tools.AgeFromIDCard(idcard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}