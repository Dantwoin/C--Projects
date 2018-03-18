using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Objective
{
    // Written By: Antwoin Davis

    class SimpleThreadPool_Example
    {
        static void Main(string[] args)
        {
            // Create 10 threads that run in the background.

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadMethod, i);
            }

            // on the main thread,  this will be processd
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Main Thread Operating...");
                Thread.Sleep(5);
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        static void ThreadMethod(Object stateInfo)
        {
            int threadIndex = (int)stateInfo;
            Console.WriteLine("thread {0} started...", threadIndex);
        }
    }
}