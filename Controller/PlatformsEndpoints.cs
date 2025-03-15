using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvPlatformsService.Abstract;
using AdvPlatformsService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AdvPlatformsService.Controller
{
    public static class PlatformsEndpoints
    {
        public static void MapPlatformsEndpoints(this WebApplication app)
        {
            var usersGroup = app.MapGroup("/platforms");

            usersGroup.MapPost("/", LoadPlatforms);
            usersGroup.MapGet("/{url}", GetPlatforms);
        }

        public static async Task<IResult> GetPlatforms([FromRoute] string url, IPlatformsService platformsService)
        {
            var result = await platformsService.GetPlatforms(url);
            if(!result.IsSuccess)
            {
                return Results.BadRequest(result.ErrorMessage);
            }
            else
            {
                return Results.Ok(result.Result);
            }
        }

        public static async Task<IResult> LoadPlatforms([FromBody] List<PlatformRequest> platforms, IPlatformsService platformsService)
        {
            var result = await platformsService.LoadPlatforms(platforms);
            
            if(!result.IsSuccess)
            {
                return Results.BadRequest(result.ErrorMessage);
            }
            else
            {
                return Results.Ok(result.Result);
            }
        }
    }
}