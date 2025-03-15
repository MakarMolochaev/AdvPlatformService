using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvPlatformService.Data;
using AdvPlatformsService.Abstract;
using AdvPlatformsService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvPlatformsService.Data
{
    public class PlatformsRepository : IPlatformsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PlatformsRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<PlatformCollectionModel?> Get(string url)
        {
            return await dbContext.Platforms.FirstOrDefaultAsync(el => el.Url == url);
        }

        public async Task SetPlatforms(List<PlatformCollectionModel> platforms)
        {
            var allEntities = await dbContext.Platforms.ToListAsync();
            dbContext.Platforms.RemoveRange(allEntities); 
            
            await dbContext.Platforms.AddRangeAsync(platforms);
            await dbContext.SaveChangesAsync();
        }
    }
}