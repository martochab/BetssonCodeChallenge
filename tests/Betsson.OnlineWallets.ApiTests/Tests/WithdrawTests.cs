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
    internal class WithdrawTests : BaseTest
    {
        [Test]
        public async Task T011WithdrawShouldReduceBalance()
        {
            var deposit=new DepositRequest { Amount = 100 };

            await DepositTasks.PostDepositGetBalanceAsync(_client, deposit);

            var before = await BalanceTasks.GetBalanceAsync(_client);

            var request = new WithdrawalRequest { Amount = 50 };

            var response = await WithdrawTasks.PostWithdrawGetBalanceAsync(_client, request);

            Assert.That(response.Amount, Is.EqualTo(before.Amount - 50));
        }

        [Test]
        public async Task T012WithdrawShouldReturn400WhenAmountIsNegative()
        {
            var request = new WithdrawalRequest { Amount = -20 };

            var response = await WithdrawTasks.PostWithdrawAsync(_client, request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task T013WithdrawShouldReturn400WhenInsufficientBalance()
        {
            var request= new WithdrawalRequest { Amount = 9999999999};

            var response = await WithdrawTasks.PostWithdrawAsync(_client, request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task T014WithdrawShouldReturn400WhenBodyIsEmpty()
        {
            WithdrawalRequest request = null;

            var response = await WithdrawTasks.PostWithdrawAsync(_client, request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
