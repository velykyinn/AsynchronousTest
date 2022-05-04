using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTest.Services {
    public interface IPerformanceService {
        public void Track(Action action);
        public Task TrackAsync(Func<Task> action);
    }
}
