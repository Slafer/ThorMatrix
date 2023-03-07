using System;

namespace ThorMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            ThorMatrix a = new ThorMatrix((4, 4));
            foreach (var el in a)
            {
                Console.Write(el);
            }
            a[2, 2] = "hi! ";
            a[2, 3] = "-- ";
            a[2, 4] = "bye! ";
            var ans = a.Neighbours((2, 3));
            Console.Write(Environment.NewLine);
            foreach (var el in a)
            {
                Console.Write(el);
            }
            Console.Write(Environment.NewLine);
            foreach (var el in ans)
            {
                Console.Write(el);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(a);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(ans);
        }
    }
}
