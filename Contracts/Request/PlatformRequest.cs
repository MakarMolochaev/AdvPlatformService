using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvPlatformsService.Contracts
{
    public record PlatformRequest(List<string> Paths, string Name);
}