namespace TBC.CommonLib.Test
{
    internal class Program
    {
        private static AutoResetEvent _resetEvent = new(false);
        static void Main()
        {
            _resetEvent.WaitOne();
        }
    }
}
