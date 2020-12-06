using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDownloads
{
    public class FileRecycler
    {
        private readonly IConfiguration _config;
        private readonly FileExpiration _expiration;

        public FileRecycler(IConfiguration config, FileExpiration expiration)
        {
            _config = config;
            _expiration = expiration;
        }

        public void Recycle()
        {
            var directory = _config.GetValue<string>("Directory");
            var files = Directory.GetFiles(directory);
            var expDate = _expiration.GetExpirationDate();

            foreach(var file in files)
            {
                var accessTime = File.GetLastAccessTime(file);

                if (accessTime.IsEarlierThan(expDate))
                {
                    file.FileRecycle();
                }
            }
        }
    }
}
