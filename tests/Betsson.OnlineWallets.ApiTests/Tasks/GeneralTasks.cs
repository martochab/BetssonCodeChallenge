using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betsson.OnlineWallets.Web.Models;
using Betsson.OnlineWallets.ApiTests.Helpers;
using System.Text.Json;

namespace Betsson.OnlineWallets.ApiTests.Tasks
{
    internal class GeneralTasks
    {
        public static async Task<HttpResponseMessage> GetAsync(ApiClient client, string endpoint)
        {
            var response = await client.GetAsync<HttpResponseMessage>(endpoint);
            return response;
        }
    }
}
