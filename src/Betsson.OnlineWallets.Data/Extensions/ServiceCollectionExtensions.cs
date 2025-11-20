using Betsson.OnlineWallets.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Betsson.OnlineWallets.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOnlineWalletRepository(this IServiceCollection services)
        {
            services.AddDbContext<OnlineWalletContext>(context => context.UseInMemoryDatabase("Wallet"));
            services.AddScoped<IOnlineWalletRepository, OnlineWalletRepository>();
            return services;
        }
    }
}
