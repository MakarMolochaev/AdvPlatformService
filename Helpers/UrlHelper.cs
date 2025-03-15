using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdvPlatformsService.Contracts;

namespace AdvPlatformsService.Helpers
{
    public static class UrlHelper
    {
        public static List<string> SplitUrl(string url)
        {
            System.Console.WriteLine("URL: " + url);
            System.Console.WriteLine();
            List<string> urls = new List<string>();

            var s = url.Split('/');
            for(int i=s.Length-1;i>0;i--)
            {
                urls.Add(url);
                url = url.Substring(0, url.Length - s[i].Length - 1);
            }

            System.Console.WriteLine(string.Join(' ', urls));
            return urls;
        }

        public static bool IsUrlCorrect(string url)
        {
            string pattern = @"^(/\w+)+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(url);
        }

        public static List<string> GetNames(List<PlatformRequest> platforms, string url)
        {
            //url = url.Replace("%2F", "/");
            List<string> names = new List<string>();

            foreach(var p in platforms)
            {
                for(int i=0;i<p.Paths.Count;i++)
                {
                    if(p.Paths[i].Length <= url.Length
                    && url.StartsWith(p.Paths[i]))
                    {
                        names.Add(p.Name);
                        break;
                    }
                }
            }

            System.Console.WriteLine(string.Join(' ', names));
            return names;
        }
    }
}