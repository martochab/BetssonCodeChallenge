using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Betsson.OnlineWallets.ApiTests.Constants;
using Betsson.OnlineWallets.ApiTests.Helpers;

namespace Betsson.OnlineWallets.ApiTests.Tasks
{
    internal class DepositTasks
    {
        public static async Task<HttpResponseMessage> PostDepositAsync(ApiClient client, DepositRequest deposit)
        {
            var response = await client.PostRawAsync(EndPoints.UrlDeposit, deposit);
            return response;
        }

        public static async Task<BalanceResponse> PostDepositGetBalanceAsync(ApiClient client, DepositRequest deposit)
        {
            var response = await client.PostAsync<BalanceResponse>(EndPoints.UrlDeposit,deposit);
            return response;
        }
    }
}
