namespace TBC.CommonLib.Test
{
    internal class Program
    {
        static void Main()
        {
            string a = "{'a':'1','b':'2','c':{'c1':'3'},'d':'4','e':{'e1':'5'},'f':'6'}";
            Console.WriteLine(a.Fetch("a"));
            Console.WriteLine(a.Fetch("a", "b"));
            Console.WriteLine(a.Fetch("c:c1"));
            Console.WriteLine(a.Fetch("c:c1", "e:e1", "f"));
            Console.ReadKey();
        }
    }
}
