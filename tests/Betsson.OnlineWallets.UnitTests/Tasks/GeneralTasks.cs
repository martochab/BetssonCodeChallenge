using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betsson.OnlineWallets.UnitTests.Tasks
{
    public class GeneralTasks
    {
        internal static void VerifyInsertOnlineWalletEntry(Mock<IOnlineWalletRepository> repositoryMock, decimal amount, decimal balanceBefore)
        {
            repositoryMock.Verify(r =>
                    r.InsertOnlineWalletEntryAsync(
                        It.Is<OnlineWalletEntry>(e =>
                            e.Amount == amount &&
                            e.BalanceBefore == balanceBefore)),
                    Times.Once);
        }
    }
}
