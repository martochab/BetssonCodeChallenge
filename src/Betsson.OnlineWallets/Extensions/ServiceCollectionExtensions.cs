using Betsson.OnlineWallets.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Betsson.OnlineWallets.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOnlineWalletService(this IServiceCollection services)
        {
            return services.AddTransient<IOnlineWalletService, OnlineWalletService>();
        }
    }
}
