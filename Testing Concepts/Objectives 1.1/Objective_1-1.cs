using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Objective
{
    //
    // Written By: Antwoin Davis
    //
    // This program showcases threading. Creates a thread of threadMethod and runs for loop on the main thread.
    // This example shows how multiple threads can run at one time.  
    //

    class Program
    {
        static void Main(string[] args)
        {
            // Notice:  new Thread and new Thread(new ThreadStart to the compiler is the same thing.
            // However, on a more advanced topic, if you wanted to write a lamda expression, you should use the latter.
            // Example:
            //      
            //   Thread t = new Thread(new ThreadStart(() =>
            //            {
            //               for (int i = 0; i < 20; i++)
            //               {
            //                  Console.WriteLine("Do something...");
            //             }}));
            //  
           

            // Initialize thread ExecuteInBackground
            Thread tb = new Thread(ExecuteInBackground);

            // Initialize thread ThreadMethod
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            // tb is set to be a background thread.  This means that if the Main thread finishes before this thread ends the thread will be terminated without completing.
            tb.IsBackground = true;
            tb.Start();
           

             // Starts thread t as a foreground thread. A foreground thread will complete even if the console closes. 
            t.Start();
            

            // on the main thread,  this will be processd
            for (int i = 0; i< 20; i++)
            {
                Console.WriteLine("Main Thread| Thread {0}: {1}, Priority {2}",
                  Thread.CurrentThread.ManagedThreadId,
                  Thread.CurrentThread.ThreadState,
                  Thread.CurrentThread.Priority);
                Thread.Sleep(0);
            }

           

            // Wait till all tasks are completed before moving on. 
            // Join() forces the program to wait until thread that is attached to it finishes.  Else the program would exit the console before the threads finished.
            t.Join();
            tb.Join();
            
            //Suspends the current thread for the specified number of milliseconds.
            Thread.Sleep(5000);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Method| Thread {0}: {1}, Priority {2}",
                  Thread.CurrentThread.ManagedThreadId,
                  Thread.CurrentThread.ThreadState,
                  Thread.CurrentThread.Priority);

                //Suspends the current thread for the specified number of milliseconds.
                Thread.Sleep(0);
            }
        }
        private static void ExecuteInBackground()
        {
            DateTime start = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine("EIB Method| Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("EIB Thread| {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }

    }
}
