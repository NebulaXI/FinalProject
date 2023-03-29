using CoreProject.Core.Services;
using SkiProject.Core.Contracts;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SkiProjectServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IResortService, ResortService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailSender,SendGridEmailSender>();


            return services;
        }
    }
}
