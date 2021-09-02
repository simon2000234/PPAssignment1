using System;
using System.Diagnostics;
using System.Threading;

namespace PPAssignment1
{
    class Program
    {
        private static int x;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Incrementx(1000000));
            Thread t2 = new Thread(() => Incrementx(1000000));


            Stopwatch sw = Stopwatch.StartNew();

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(x);

        }


        public static void Incrementx(int increment)
        {
            for (int i = 0; i < increment; i++)
            {
                x++;
            }
        }
    }
}
