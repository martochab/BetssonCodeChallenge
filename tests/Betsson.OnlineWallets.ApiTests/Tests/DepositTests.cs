using Betsson.OnlineWallets.ApiTests.Tasks;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.ApiTests.Tests
{
    internal class DepositTests : BaseTest
    {
        [Test]
        public async Task T008DepositShouldIncreaseBalance()
        {
            var initial = await BalanceTasks.GetBalanceAsync(_client);

            var deposit = new DepositRequest { Amount = 100 };

            var response =await DepositTasks.PostDepositGetBalanceAsync(_client, deposit);

            Assert.That(response.Amount, Is.EqualTo(initial.Amount + 100));
        }

        [Test]
        public async Task T009DepositShouldReturn400WhenAmountIsNegative()
        {
            var deposit = new DepositRequest { Amount = -50 };

            var response = await DepositTasks.PostDepositAsync(_client, deposit);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task T010DepositShouldReturn400WhenBodyIsEmpty()
        {
            DepositRequest deposit = null;

            var response = await DepositTasks.PostDepositAsync(_client,deposit);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
