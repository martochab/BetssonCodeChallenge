using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Data.Repositories;
using Betsson.OnlineWallets.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.UnitTests.Tasks
{
    public class BalanceTasks
    {
        internal static async Task<Models.Balance> GetBalanceAsync(Mock<IOnlineWalletRepository> repositoryMock, OnlineWalletService service)
        {
            repositoryMock
            .Setup(r => r.GetLastOnlineWalletEntryAsync())
            .ReturnsAsync((OnlineWalletEntry?)null);

            var result = await service.GetBalanceAsync();

            return result;
        }

        internal static async Task<Models.Balance> GetBalanceWithEntriesAsync(Mock<IOnlineWalletRepository> repositoryMock, OnlineWalletService service, decimal lastEntryAmount, decimal lastEntryBalanceBefore)
        {
            repositoryMock
            .Setup(r => r.GetLastOnlineWalletEntryAsync())
            .ReturnsAsync(new OnlineWalletEntry
            {
                Amount = lastEntryAmount,
                BalanceBefore = lastEntryBalanceBefore
            });

            var result = await service.GetBalanceAsync();

            return result;
        }
    }
}
