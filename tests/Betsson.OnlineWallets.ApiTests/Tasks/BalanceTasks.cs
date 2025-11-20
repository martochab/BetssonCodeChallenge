using Betsson.OnlineWallets.ApiTests.Helpers;
using Betsson.OnlineWallets.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betsson.OnlineWallets.ApiTests.Constants;

namespace Betsson.OnlineWallets.ApiTests.Tasks
{
    internal class BalanceTasks
    {
        public static async Task<BalanceResponse> GetBalanceAsync(ApiClient client)
        {
            var balance = await client.GetAsync<BalanceResponse>(EndPoints.UrlBalance);
            return balance;
        }
    }
}
