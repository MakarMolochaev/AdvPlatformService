using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvPlatformService.Data;
using AdvPlatformsService.Contracts;
using AdvPlatformsService.Data;
using AdvPlatformsService.Models;

namespace AdvPlatformsService.Abstract
{
    public interface IPlatformsService
    {
        public Task<ServiceResult<List<string>>> GetPlatforms(string url);
        public Task<ServiceResult<string>> LoadPlatforms(List<PlatformRequest> platforms);
    }
}