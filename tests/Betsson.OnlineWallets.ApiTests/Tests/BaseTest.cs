using Betsson.OnlineWallets.ApiTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Betsson.OnlineWallets.ApiTests.Tests
{
    public class BaseTest
    {
        protected ApiClient _client;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

            string baseUrl = config["ApiBaseUrl"];

            _client = new ApiClient(baseUrl);
        }
    }
}
