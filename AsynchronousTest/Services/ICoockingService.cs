using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTest.Services {
    public interface ICoockingService {
        public Juice PourOJ();
        public void ApplyJam(Toast toast);
        public void ApplyButter(Toast toast);
        public Toast ToastBread(int slices);
        public Bacon FryBacon(int slices);
        public Egg FryEggs(int howMany);
        public Coffee PourCoffee();

        public Task<Toast> ToastBreadAsync(int slices);
        public Task<Bacon> FryBaconAsync(int slices);
        public Task<Egg> FryEggsAsync(int howMany);
        public Task<Toast> MakeToastWithButterAndJamAsync(int number);
    }
}
