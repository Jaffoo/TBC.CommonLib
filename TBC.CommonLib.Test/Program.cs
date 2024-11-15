namespace TBC.CommonLib.Test
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("请输入：");
            var input = Tools.ConsoleReadLine("输入为空，请重新输入：");
            Console.WriteLine("你输入的内容是:" + input);
            Tools.ConsoleExit();
        }
    }
}
