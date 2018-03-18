using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//  Written by: Antwoin Davis
//  Description: This is code practice uses task factories to create threads and then use ContinueWith to preform tasks an additional task on completion. WaitAll and WaitAny are exhibted.
//  
//
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task.Factory.StartNew is the alternative to new Task and then start task.
            // EXAMPLE:
            //    var t1 = new Task (()=>DoWork(1,3000);      ==   var t1 = Task.Factory.StartNew(() => DoWork(1,3000)
            //    t1.Start();
            //   
            // Remark:  Task.Factory.StartNew starts the task immediately. While t1.Start can be started when desired.

            var t1 = Task.Factory.StartNew(() => DoWork(1, 3000)).ContinueWith((prevTask) => DoSomeMoreWork(1, 2000));
            var t2 = Task.Factory.StartNew(() => DoWork(2, 1500)).ContinueWith((prevTask) => DoSomeMoreWork(2, 4000));
            var t3 = Task.Factory.StartNew(() => DoWork(3, 1000)).ContinueWith((prevTask) => DoSomeMoreWork(3, 3000));

            var taskList = new List<Task> { t1, t2, t3 };

            Task.WaitAll(taskList.ToArray());
            // Remark: WaitALL takes in the array of taskList and then waits until all tasks in the array are completed until processing onward. 
            Console.WriteLine("Wait All Check.");

            //Task.WaitAny(taskList.ToArray());
            //// Remark: WaitAny takes in the array of taskList and then waits until one task completes for contuning the main thread. 
            //// You should also notice, that waitAny will wait until the task compltes Dowork and DoSomeMoreWork before excuting to the next s 
            //Console.WriteLine("Wait Any Check.");

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
        static void DoWork(int id, int sleepTime)
        {
            Console.WriteLine("Task{0} has started.", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task{0} has ended.",id );

        }
        static void DoSomeMoreWork(int id, int sleepTime)
        {
            Console.WriteLine("Task{0} has started some more work.", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task{0} has ended some more work.", id);

        }
    }
}
