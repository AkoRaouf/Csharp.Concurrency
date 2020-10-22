
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Csharp.Concurrency
{
    class ReturnsTasks
    {
        public async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }

        public async Task AwaitAndProcessAsyinc(Task<int> t)
        {
            int result = await t;
            Console.WriteLine($"The Task has been returned after {result} second");
        }
    }
}





