using AutoMapper;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Web.Models;

namespace Betsson.OnlineWallets.Web.Mappers
{
    public class OnlineWalletMappingProfile : Profile
    {
        public OnlineWalletMappingProfile()
        {
            CreateMap<Balance, BalanceResponse>();
            CreateMap<DepositRequest, Deposit>();
            CreateMap<WithdrawalRequest, Withdrawal>();
        }
    }
}
