using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceSchedule.Application.Services;
using ServiceSchedule.Application.Services.Interfaces;
using ServiceSchedule.Infra.Data.Context;
using ServiceSchedule.Infra.Data.Repositories;

namespace ServiceSchedule.Infra.IoC
{
    public static class NativeInjector
    {
        public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            
            #endregion
        }
    }
}