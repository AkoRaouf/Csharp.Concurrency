using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Csharp.Concurrency
{
    class Program
    {
        ///Here we want to run a new Task after completion of each task added to the list of tasks.
        ///the best practices should be followed.
        static void Main(string[] args)
        {
            var taskSource = new ReturnsTasks();
            Task<int> taskA = taskSource.DelayAndReturnAsync(2);
            Task<int> taskB = taskSource.DelayAndReturnAsync(3);
            Task<int> taskC = taskSource.DelayAndReturnAsync(1);
            List<Task<int>> taskList = new List<Task<int>>() { taskA, taskB, taskC };

            var taskQuery = from t in taskList select taskSource.AwaitAndProcessAsyinc(t);
            var secondTaskQuery = taskList.Select(x=> taskSource.AwaitAndProcessAsyinc(x));

            Task.WaitAll(taskQuery.ToArray());
            
            Console.Read();
        }
    }
}
