using AdvPlatformService.Data;
using AdvPlatformsService.Abstract;
using AdvPlatformsService.Contracts;
using AdvPlatformsService.Data;
using AdvPlatformsService.Models;
using AdvPlatformsService.Helpers;

namespace AdvPlatformsService.Service
{
    public class PlatformsService : IPlatformsService
    {
        public IPlatformsRepository platformsRepository;

        public PlatformsService(IPlatformsRepository _platformsRepository)
        {
            platformsRepository = _platformsRepository;
        }

        public async Task<ServiceResult<List<string>>> GetPlatforms(string url)
        {
            url = url.Replace("%2F", "/");
            if(! UrlHelper.IsUrlCorrect(url))
            {
                return new ServiceResult<List<string>>(IsSuccess: false, ErrorMessage: $"Url {url} is not in correct format.");
            }

            var platformCollection = await platformsRepository.Get(url);

            if (platformCollection == null)
            {
                return new ServiceResult<List<string>>(IsSuccess: true, Result: new List<string>());
            }
            else
            {
                return new ServiceResult<List<string>>(IsSuccess: true, Result: platformCollection.PlatformNames);
            }
        }

        public async Task<ServiceResult<string>> LoadPlatforms(List<PlatformRequest> platforms)
        {
            var platformCollections = new List<PlatformCollectionModel>();

            HashSet<string> urls = new HashSet<string>();
            foreach (var p in platforms)
            {
                if (!p.IsCorrect())
                {
                    return new ServiceResult<string>(IsSuccess: false, ErrorMessage: $"Wrong Url format in {p.Name} platform.");
                }

                foreach (var path in p.Paths)
                {
                    var splitted = UrlHelper.SplitUrl(path);
                    foreach (var s in splitted)
                        urls.Add(s);
                }
            }

            foreach (var url in urls)
            {
                platformCollections.Add(new PlatformCollectionModel(url, UrlHelper.GetNames(platforms, url)));
            }

            await platformsRepository.SetPlatforms(platformCollections);

            return new ServiceResult<string>(IsSuccess: true, Result: "Platforms are loaded.");
        }
    }
}