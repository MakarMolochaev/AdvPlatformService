using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdvPlatformsService.Contracts;

namespace AdvPlatformsService.Helpers
{
    public static class PlatformValidation
    {
        public static bool IsCorrect(this PlatformRequest platform)
        {
            string pattern = @"^(/\w+)+$";
            Regex regex = new Regex(pattern);

            foreach(var path in platform.Paths)
            {
                if(!regex.IsMatch(path))
                    return false;
            }

            return true;
        }
    }
}