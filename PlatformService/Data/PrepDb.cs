using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> seeding data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "dot net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "sql server express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "kubernates", Publisher = "cloud native computing foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we already have data");

            }
        }
    }
}