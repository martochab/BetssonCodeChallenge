using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Betsson.OnlineWallets.Models;
using Betsson.OnlineWallets.Services;
using Betsson.OnlineWallets.Web.Models;

namespace Betsson.OnlineWallets.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OnlineWalletController : ControllerBase
    {
        private readonly ILogger<OnlineWalletController> _logger;
        private readonly IMapper _mapper;
        private readonly IOnlineWalletService _onlineWalletService;

        public OnlineWalletController(ILogger<OnlineWalletController> logger, IMapper mapper, IOnlineWalletService onlineWalletService)
        {
            _logger = logger;
            _mapper = mapper;
            _onlineWalletService = onlineWalletService;
        }

        [HttpGet]
        public async Task<ActionResult<BalanceResponse>> Balance()
        {
            Balance balance = await _onlineWalletService.GetBalanceAsync();

            BalanceResponse balanceResponse = _mapper.Map<BalanceResponse>(balance);
            
            return Ok(balanceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<BalanceResponse>> Deposit(DepositRequest depositRequest)
        {
            Deposit deposit = _mapper.Map<Deposit>(depositRequest);

            Balance balance =  await _onlineWalletService.DepositFundsAsync(deposit);

            BalanceResponse balanceResponse = _mapper.Map<BalanceResponse>(balance);

            return Ok(balanceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<BalanceResponse>> Withdraw(WithdrawalRequest withdrawalRequest)
        {
            Withdrawal withdrawal = _mapper.Map<Withdrawal>(withdrawalRequest); 

            Balance balance = await _onlineWalletService.WithdrawFundsAsync(withdrawal);

            BalanceResponse balanceResponse = _mapper.Map<BalanceResponse>(balance);

            return Ok(balanceResponse);
        }
    }
}
