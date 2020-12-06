using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanDownloads
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly FileRecycler _recycler;
        private const int _weekDelay = 1000 * 60 * 60 * 24 * 7; // one week in milliseconds

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
                await Task.Delay(_weekDelay, stoppingToken);
            }
        }
    }
}
