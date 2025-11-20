using Betsson.OnlineWallets.Web.Models;
using FluentValidation;

namespace Betsson.OnlineWallets.Web.Validators
{
    public class DepositRequestValidator : AbstractValidator<DepositRequest> {
    
        public DepositRequestValidator()
        {
            RuleFor(depositRequest => depositRequest.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
