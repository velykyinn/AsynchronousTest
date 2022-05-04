using System.Diagnostics;

namespace AsynchronousTest.Services {
    public class PerformanceService : IPerformanceService {
        public void Track(Action action) {
            var timer = new Stopwatch();
            timer.Start();

            action();

            timer.Stop();
            Console.WriteLine($"Coocking time: {timer.ElapsedMilliseconds / 1000}s");
        }

        public async Task TrackAsync(Func<Task> action) {
            var timer = new Stopwatch();
            timer.Start();

            await action();

            timer.Stop();
            Console.WriteLine($"Coocking time: {timer.ElapsedMilliseconds / 1000}s");
        }
    }
}
