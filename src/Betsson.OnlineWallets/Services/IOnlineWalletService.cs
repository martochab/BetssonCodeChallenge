using Betsson.OnlineWallets.Models;

namespace Betsson.OnlineWallets.Services
{
    public interface IOnlineWalletService
    {
        Task<Balance> GetBalanceAsync();

        Task<Balance> DepositFundsAsync(Deposit deposit);

        Task<Balance> WithdrawFundsAsync(Withdrawal withdrawal);
    }
}
