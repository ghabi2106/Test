using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Test.FrontOffice.Helpers;
using Microsoft.EntityFrameworkCore;

[assembly: HostingStartup(typeof(AuthentificationHostingStartup))]
namespace Test.FrontOffice.Helpers
{
    public class AuthentificationHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestContext"))
                    );

            });
        }
    }
}