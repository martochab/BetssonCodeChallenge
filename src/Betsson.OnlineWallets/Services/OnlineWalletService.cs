using Betsson.OnlineWallets.Data.Models;
using Betsson.OnlineWallets.Data.Repositories;
using Betsson.OnlineWallets.Exceptions;
using Betsson.OnlineWallets.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Betsson.OnlineWallets.UnitTests")]

namespace Betsson.OnlineWallets.Services
{
    internal class OnlineWalletService : IOnlineWalletService
    {
        private readonly IOnlineWalletRepository _onlineWalletRepository;

        public OnlineWalletService(IOnlineWalletRepository onlineWalletRepository)
        {
            _onlineWalletRepository = onlineWalletRepository;
        }

        public async Task<Balance> GetBalanceAsync()
        {
            OnlineWalletEntry? onlineWalletEntry = await _onlineWalletRepository.GetLastOnlineWalletEntryAsync();

            // Default BalanceBefore to 0 if there are no transactions
            decimal amount = onlineWalletEntry == default(OnlineWalletEntry) ? 0 : (onlineWalletEntry.BalanceBefore + onlineWalletEntry.Amount);

            Balance currentBalance = new Balance
            {
                Amount = amount
            };

            return currentBalance;
        }

        public async Task<Balance> DepositFundsAsync(Deposit deposit)
        {
            decimal depositAmount = deposit.Amount;

            Balance currentBalance = await GetBalanceAsync();
            decimal currentBalanceAmount = currentBalance.Amount;

            OnlineWalletEntry depositEntry = new OnlineWalletEntry()
            {
                Amount = depositAmount,
                BalanceBefore = currentBalanceAmount,
                EventTime = DateTimeOffset.UtcNow
            };

            await _onlineWalletRepository.InsertOnlineWalletEntryAsync(depositEntry);

            Balance newBalance = new Balance
            {
                Amount = currentBalanceAmount + depositAmount
            };

            return newBalance;
        }

        public async Task<Balance> WithdrawFundsAsync(Withdrawal withdrawal)
        {
            decimal withdrawalAmount = withdrawal.Amount;
            Balance currentBalance = await GetBalanceAsync();
            decimal currentBalanceAmount = currentBalance.Amount;

            if (withdrawalAmount > currentBalance.Amount)
            {
                throw new InsufficientBalanceException();
            }
            
            withdrawalAmount *= -1;
            
            OnlineWalletEntry withdrawalEntry = new OnlineWalletEntry()
            {
                Amount = withdrawalAmount,
                BalanceBefore = currentBalanceAmount,
                EventTime = DateTimeOffset.UtcNow
            };

            await _onlineWalletRepository.InsertOnlineWalletEntryAsync(withdrawalEntry);

            Balance newBalance = new Balance
            {
                Amount = currentBalanceAmount + withdrawalAmount
            };

            return newBalance;
        }
    }
}
