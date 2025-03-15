using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvPlatformsService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvPlatformService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PlatformCollectionModel> Platforms { get; set; } = null!;
    }
}