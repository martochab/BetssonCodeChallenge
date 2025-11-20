using FluentValidation;
using Betsson.OnlineWallets.Web.Models;

namespace Betsson.OnlineWallets.Web.Validators
{
    public class WithdrawalRequestValidator : AbstractValidator<WithdrawalRequest> {
    
        public WithdrawalRequestValidator()
        {
            RuleFor(withdrawalRequest => withdrawalRequest.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
