using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTest.Services {
    public interface IVerionsService {
        public void Set(int number, Action action);
        public Task SetAsync(int number, Func<Task> action);
    }
}
