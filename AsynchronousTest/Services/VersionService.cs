using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTest.Services {
    public class VersionService : IVerionsService {
        public void Set(int number, Action action) {
            Console.WriteLine($"Version {number}");
            Console.WriteLine("----------------------------------------------");
            action();
            Console.WriteLine("----------------------------------------------");
        }

        public async Task SetAsync(int number, Func<Task> action) {
            Console.WriteLine($"Version {number}");
            Console.WriteLine("----------------------------------------------");
            await action();
            Console.WriteLine("----------------------------------------------");
        }
    }
}
