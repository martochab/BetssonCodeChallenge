using Betsson.OnlineWallets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Betsson.OnlineWallets.Data.IntegrationTests")]

namespace Betsson.OnlineWallets.Data.Repositories
{
    internal class OnlineWalletRepository : IOnlineWalletRepository
    {
        private readonly OnlineWalletContext _onlineWalletContext;

        public OnlineWalletRepository(OnlineWalletContext onlineWalletContext)
        {
            _onlineWalletContext = onlineWalletContext;
        }
                
        public async Task<OnlineWalletEntry?> GetLastOnlineWalletEntryAsync()
        {
            return await _onlineWalletContext
                .Transactions
                .OrderByDescending(onlineWalletEntry => onlineWalletEntry.EventTime)
                .FirstOrDefaultAsync();
        }

        public Task InsertOnlineWalletEntryAsync(OnlineWalletEntry onlineWalletEntry)
        {
            _onlineWalletContext.Transactions.Add(onlineWalletEntry);
            _onlineWalletContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
