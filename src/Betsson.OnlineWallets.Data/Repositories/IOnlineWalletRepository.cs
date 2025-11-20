using Betsson.OnlineWallets.Data.Models;

namespace Betsson.OnlineWallets.Data.Repositories
{
    public interface IOnlineWalletRepository
    {
        Task<OnlineWalletEntry?> GetLastOnlineWalletEntryAsync();
        Task InsertOnlineWalletEntryAsync(OnlineWalletEntry onlineWalletEntry);
    }
}
