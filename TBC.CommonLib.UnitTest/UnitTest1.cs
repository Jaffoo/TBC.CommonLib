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
                Tools.CopyTo("E:\\��ʱ�ļ�\\123", "E:\\��ʱ�ļ�\\321", [".vs",".git",".github"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}