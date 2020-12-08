using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

/* 12/7/2020
 * Represents the service that performs
 * the work. The main loop is performed
 * in the ExecuteAsync method.
 * 
 * Zach Robinson
 */

namespace CleanDownloads
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly FileRecycler _recycler;
        private const int _weekDelay = 1000 * 60 * 60 * 24 * 7; // one week in milliseconds
        private const int _minuteDelay = 1000 * 60; // one minute in milliseconds

        public Worker(ILogger<Worker> logger, FileRecycler recycler)
        {
            _logger = logger;
            _recycler = recycler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _recycler.Recycle();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(_minuteDelay, stoppingToken);
            }
        }
    }
}
