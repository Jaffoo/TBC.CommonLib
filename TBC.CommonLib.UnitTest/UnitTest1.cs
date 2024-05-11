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
                Tools.CopyTo("E:\\临时文件\\123", "E:\\临时文件\\321", [".vs",".git",".github"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}