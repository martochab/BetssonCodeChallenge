using Betsson.OnlineWallets.ApiTests.Constants;
using Betsson.OnlineWallets.ApiTests.Tasks;
using Betsson.OnlineWallets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.ApiTests.Tests
{
    internal class BalanceTests : BaseTest
    {
        [Test]
        public async Task T006GetBalanceShouldReturn200()
        {
            var response = await GeneralTasks.GetAsync(_client, EndPoints.UrlBalance);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public async Task T007GetBalanceShouldReturnCorrectSchema()
        {
            var response = await BalanceTasks.GetBalanceAsync(_client);

            Assert.That(response.Amount, Is.TypeOf<decimal>());
        }
    }
}
