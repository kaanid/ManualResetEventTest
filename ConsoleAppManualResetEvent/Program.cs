using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppManualResetEvent
{
    class Program
    {
        static ManualResetEvent _mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Thread[] _threads = new Thread[3];
            for (int i = 0; i < _threads.Count(); i++)
            {
                _threads[i] = new Thread(ThreadRun);
                _threads[i].Start();
            }

            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("set");
            _mre.Set();

            Console.WriteLine("Reset");
            _mre.Reset();

            Console.WriteLine("end");
            Console.Read();
        }

        static void ThreadRun()
        {
            int _threadID = 0;
            while (true)
            {
                _mre.WaitOne();
                _threadID = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("current Tread is " + _threadID);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //_mre.WaitOne(500,false);
            }
        }
    }
}
