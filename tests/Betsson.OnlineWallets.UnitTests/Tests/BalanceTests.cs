using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betsson.OnlineWallets.UnitTests.Tasks;

namespace Betsson.OnlineWallets.UnitTests.Tests
{
    public class BalanceTests : BaseTest
    {
        [Test]
        public async Task T001GetBalanceAsyncShouldReturnZeroWhenNoEntriesExist()
        {
            var result = await BalanceTasks.GetBalanceAsync(_repositoryMock, _service);

            Assert.That(result.Amount, Is.EqualTo(0));
        }

        [Test]
        public async Task T002GetBalanceAsyncShouldReturnBalanceComputedCorrectly()
        {
            var result = await BalanceTasks.GetBalanceWithEntriesAsync(_repositoryMock, _service, 50, 100);

            Assert.That(result.Amount, Is.EqualTo(150));
        }
    }
}
