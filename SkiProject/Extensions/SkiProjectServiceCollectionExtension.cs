using CoreProject.Core.Services;
using SkiProject.Core.Contracts;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Models;
using SkiProject.Core.Contracts;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HouseRentingServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICardService, CardService>();

            return services;
        }
    }
}
