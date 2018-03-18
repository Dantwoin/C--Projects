using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_and_Await_Example
{
    // Written By: Antwoin Davis
    class Async_Await_Example
    {
        static void Main(string[] args)
        {            
            AsyncAwaitDemo demo = new AsyncAwaitDemo();
            
            demo.LongOperation();
            demo.FindFiles();

            // Two tasks are running in the background, while the main thread performs

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Working on the Main Thread...................");
            }

            Console.ReadLine();
        }
    }
    public class AsyncAwaitDemo
    {
        public async Task LongOperation()
        {
            // Task.Run starts a background thread
            // Await means this task must complete before the rest of this method is run
            await Task.Run(() =>
            {
                CountToFifty();
            });

            // This code will not run until the CountToFifty call has completed
            Console.WriteLine("Counting to 50 completed...");
        }

        private static async Task<string> CountToFifty()
        {
            int counter;

            for (counter = 0; counter < 51; counter++)
            {
                Console.WriteLine("BG thread: " + counter);
            }

            return "Counter = " + counter;
        }

        public async Task FindFiles()
        {
           
            await Task.Run(() =>
            {
                Console.WriteLine("Start Looking for Files...");
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine("Looking for files...");
                }
            });

            // Will wait until task is finished.
            Console.WriteLine("Stop looking for Files.");
        }
    }
}
