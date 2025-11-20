using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Exceptions;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.UnitTests.Tasks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.UnitTests.Tests
{
    public class WithdrawTests : BaseTest
    {
        [Test]
        public async Task T004WithdrawFundsAsyncShouldThrowWhenInsufficientBalance()
        {
            var withdrawal = new Withdrawal { Amount = 200 };

            Assert.ThrowsAsync<InsufficientBalanceException>(async () =>
            await WithdrawTasks.WithdrawFundsAsync(_repositoryMock, _service, withdrawal, 100, 0));
        }

        [Test]
        public async Task T005WithdrawFundsAsyncShouldReduceBalance()
        {
            var withdrawal = new Withdrawal { Amount = 50 };

            var result = await WithdrawTasks.WithdrawFundsAsync(_repositoryMock, _service, withdrawal, 200, 0);

            Assert.That(result.Amount, Is.EqualTo(150));

            GeneralTasks.VerifyInsertOnlineWalletEntry(_repositoryMock, -50, 200);
        }
    }
}
