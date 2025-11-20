using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Data.Repositories;
using Betsson.OnlineWallets.Exceptions;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Services;


namespace Betsson.OnlineWallets.UnitTests.Tests
{
    public class BaseTest
    {
        internal Mock<IOnlineWalletRepository> _repositoryMock;
        internal OnlineWalletService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IOnlineWalletRepository>();
            _service = new OnlineWalletService(_repositoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
