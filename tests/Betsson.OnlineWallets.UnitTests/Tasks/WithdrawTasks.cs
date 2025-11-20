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
    public class WithdrawTasks
    {
        internal static async Task<Balance> WithdrawFundsAsync(Mock<IOnlineWalletRepository> repositoryMock, OnlineWalletService service,Withdrawal withdrawal,decimal amount,decimal balanceBefore)
        {
            repositoryMock
                .Setup(r => r.GetLastOnlineWalletEntryAsync())
                .ReturnsAsync(new OnlineWalletEntry
                {
                    Amount = amount,
                    BalanceBefore = balanceBefore
                });
            var result = await service.WithdrawFundsAsync(withdrawal);

            return result;
        }
    }
}
