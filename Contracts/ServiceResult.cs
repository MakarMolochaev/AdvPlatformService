using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvPlatformsService.Contracts
{
    public record ServiceResult<T>(bool IsSuccess, T? Result = default, string ErrorMessage = "");
}