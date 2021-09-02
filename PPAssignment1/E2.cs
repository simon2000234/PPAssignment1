using System;
using System.Diagnostics;
using System.Threading;

namespace PPAssignment1
{
    public class E2
    {
        private readonly object TheLock = new object();
        private int x;
        private Mutex mut = new Mutex();


        public void RunE2()
        {
            Thread t1 = new Thread(() => Incrementx(1000000));
            Thread t2 = new Thread(() => Incrementx(1000000));


            Stopwatch sw = Stopwatch.StartNew();

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds / 1000f);
            Console.WriteLine(x);
        }



        private void Incrementx(int increment)
        {
            for (int i = 0; i < increment; i++)
            {
                WithMutex();
            }
        }


        private void Normal()
        {
            x++;
        }

        private void WithLock()
        {
            lock (TheLock)
            {
                x++;
            }

        }

        private void WithMutex()
        {
            mut.WaitOne();
            x++;
            mut.ReleaseMutex();

        }
    }
}