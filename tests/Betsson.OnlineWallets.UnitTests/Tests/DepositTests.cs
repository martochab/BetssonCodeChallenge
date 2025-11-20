using Betsson.OnlineWallets.Data.Models;
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
    public class DepositTests : BaseTest
    {
        [Test]
        public async Task T003DepositFundsAsyncShouldIncreaseBalance()
        {
            var deposit = new Deposit { Amount = 50 };

            var result = await DepositTasks.DepositFundsAsync(_repositoryMock, _service, deposit);

            Assert.That(result.Amount, Is.EqualTo(150));

            GeneralTasks.VerifyInsertOnlineWalletEntry(_repositoryMock, 50, 100);
        }
    }
}
