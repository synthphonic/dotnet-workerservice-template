using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coravel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerServiceTemplate.Jobs;

namespace WorkerServiceTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.UseScheduler(scheduler =>
            {
                var jobSchedule = scheduler.Schedule<TestJob>();
                jobSchedule
                    .EverySeconds(2)
                    .PreventOverlapping("TestJob");
            });

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // comment out if using coravel
                    //services.AddHostedService<Worker>();

                    services.AddScheduler();
                    services.AddTransient<TestJob>();
                });
    }
}
