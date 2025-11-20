using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Data.Repositories;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.UnitTests.Tasks
{
    public class DepositTasks
    {
        internal static async Task<Balance> DepositFundsAsync(Mock<IOnlineWalletRepository> repositoryMock, OnlineWalletService service,Deposit deposit)
        {
            repositoryMock
                .Setup(r => r.GetLastOnlineWalletEntryAsync())
                .ReturnsAsync(new OnlineWalletEntry
                {
                    Amount = 100,
                    BalanceBefore = 0
                });

            var result = await service.DepositFundsAsync(deposit);

            return result;
        }

        internal static void VerifyInsertOnlineWalletEntry(Mock<IOnlineWalletRepository> repositoryMock, decimal amount, decimal balanceBefore)
        {
            repositoryMock.Verify(r =>
                    r.InsertOnlineWalletEntryAsync(
                        It.Is<OnlineWalletEntry>(e =>
                            e.Amount == amount &&
                            e.BalanceBefore == balanceBefore)),
                    Times.Once);
        }
    }
}
