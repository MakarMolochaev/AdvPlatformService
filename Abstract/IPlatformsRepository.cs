using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvPlatformService.Data;
using AdvPlatformsService.Models;

namespace AdvPlatformsService.Abstract
{
    public interface IPlatformsRepository
    {
        public Task<PlatformCollectionModel?> Get(string url);
        public Task SetPlatforms(List<PlatformCollectionModel> platforms);
    }
}