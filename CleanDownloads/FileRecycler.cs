using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

/* 12/7/2020
 * The FileRecycler holds the logic
 * for deciding what files get to
 * live, and which files must die.
 * The Julius Caesar of the service.
 * 
 * Zach Robinson
 */

namespace CleanDownloads
{
    public class FileRecycler
    {
        private readonly IConfiguration _config;
        private readonly FileExpiration _expiration;
        private readonly ILogger<FileRecycler> _logger;

        public FileRecycler(IConfiguration config, FileExpiration expiration, ILogger<FileRecycler> logger)
        {
            _config = config;
            _expiration = expiration;
            _logger = logger;
        }

        public void Recycle()
        {
            var directory = _config.GetValue<string>("Directory");
            var files = Directory.GetFiles(directory);
            var expDate = _expiration.GetExpirationDate();
            _logger.LogInformation($"The current directory is {directory}");

            foreach(var file in files)
            {
                _logger.LogInformation($"The file name is {file}.");
                var accessTime = File.GetLastAccessTime(file);

                if (accessTime.IsEarlierThan(expDate))
                {
                    _logger.LogInformation($"{accessTime} is an earlier date than {expDate}, so {file} will be moved to the recycling bin.");
                    file.FileRecycle();
                }
            }
        }
    }
}
