using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvPlatformsService.Models
{
    public class PlatformCollectionModel
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public List<string> PlatformNames { get; set; } = new List<string>();

        public PlatformCollectionModel(string url, List<string> platformNames)
        {
            Url = url;
            PlatformNames = platformNames;
        }
    }
}