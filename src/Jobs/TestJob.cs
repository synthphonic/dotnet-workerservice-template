using System;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace WorkerServiceTemplate.Jobs
{
    public class TestJob : IInvocable
    {
        private readonly ILogger<TestJob> _logger;

        public TestJob(ILogger<TestJob> logger)
        {
            _logger = logger;
        }

        public async Task Invoke()
        {
            var jobId = Guid.NewGuid();
            _logger.LogInformation($"Starting job Id {jobId}");

            await Task.Delay(3000);

            _logger.LogInformation($"Job with Id {jobId} completed");
        }
    }
}