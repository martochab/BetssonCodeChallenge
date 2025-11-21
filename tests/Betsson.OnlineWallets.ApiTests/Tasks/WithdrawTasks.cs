using Betsson.OnlineWallets.ApiTests.Constants;
using Betsson.OnlineWallets.ApiTests.Helpers;
using Betsson.OnlineWallets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.ApiTests.Tasks
{
    internal class WithdrawTasks
    {
        public static async Task<HttpResponseMessage> PostWithdrawAsync(ApiClient client, WithdrawalRequest deposit)
        {
            var response = await client.PostRawAsync(EndPoints.UrlWithdraw, deposit);
            return response;
        }


        public static async Task<BalanceResponse> PostWithdrawGetBalanceAsync(ApiClient client, WithdrawalRequest deposit)
        {
            var response = await client.PostAsync<BalanceResponse>(EndPoints.UrlWithdraw, deposit);
            return response;
        }
    }
}
