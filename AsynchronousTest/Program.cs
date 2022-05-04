global using AsynchronousTest.Models;
using AsynchronousTest.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICoockingService, CoockingService>()
    .AddSingleton<IPerformanceService, PerformanceService>()
    .AddSingleton<IVerionsService, VersionService>()
    .BuildServiceProvider();

var coockingService = serviceProvider.GetService<ICoockingService>();
var performanceService = serviceProvider.GetService<IPerformanceService>();
var versionService = serviceProvider.GetService<IVerionsService>();

versionService.Set(1, () => {
    performanceService.Track(() => {
        Coffee cup = coockingService.PourCoffee();
        Console.WriteLine("coffee is ready");

        Egg eggs = coockingService.FryEggs(2);
        Console.WriteLine("eggs are ready");

        Bacon bacon = coockingService.FryBacon(3);
        Console.WriteLine("bacon is ready");

        Toast toast = coockingService.ToastBread(2);
        coockingService.ApplyButter(toast);
        coockingService.ApplyJam(toast);
        Console.WriteLine("toast is ready");

        Juice oj = coockingService.PourOJ();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
    });
});

await versionService.SetAsync(2, async () => {
    await performanceService.TrackAsync(async () => {
        Coffee cup = coockingService.PourCoffee();
        Console.WriteLine("Coffee is ready");

        Task<Egg> eggsTask = coockingService.FryEggsAsync(2);
        Task<Bacon> baconTask = coockingService.FryBaconAsync(3);
        Task<Toast> toastTask = coockingService.ToastBreadAsync(2);

        Toast toast = await toastTask;
        coockingService.ApplyButter(toast);
        coockingService.ApplyJam(toast);
        Console.WriteLine("Toast is ready");
        Juice oj = coockingService.PourOJ();
        Console.WriteLine("Oj is ready");

        Egg eggs = await eggsTask;
        Console.WriteLine("Eggs are ready");
        Bacon bacon = await baconTask;
        Console.WriteLine("Bacon is ready");

        Console.WriteLine("Breakfast is ready!");
    });
});


await versionService.SetAsync(3, async () => {
    await performanceService.TrackAsync(async () => {
        Coffee cup = coockingService.PourCoffee();
        Console.WriteLine("coffee is ready");

        var eggsTask = coockingService.FryEggsAsync(2);
        var baconTask = coockingService.FryBaconAsync(3);
        var toastTask = coockingService.MakeToastWithButterAndJamAsync(2);

        var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
        while (breakfastTasks.Count > 0) {
            Task finishedTask = await Task.WhenAny(breakfastTasks);
            if (finishedTask == eggsTask) {
                Console.WriteLine("eggs are ready");
            }
            else if (finishedTask == baconTask) {
                Console.WriteLine("bacon is ready");
            }
            else if (finishedTask == toastTask) {
                Console.WriteLine("toast is ready");
            }
            breakfastTasks.Remove(finishedTask);
        }

        Juice oj = coockingService.PourOJ();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
    });
});