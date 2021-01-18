using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Application.IServices;
using Test.Application.Services;
using Test.Domain.IRepositories;
using Test.Infra.Data.Repositories;

namespace Test.Application.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICityService, CityService>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
        }
    }
}
