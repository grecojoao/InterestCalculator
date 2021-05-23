using InterestCalculator.Domain.Commands;
using InterestCalculator.Domain.Commands.Contracts;
using InterestCalculator.Domain.Handlers.Contracts;
using InterestCalculator.Domain.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Domain.Handlers
{
    public class InterestCalculatorHandler : IHandler<CalculateInterestCommand>
    {
        private readonly IInterestRateService _interestRateService;

        public InterestCalculatorHandler(IInterestRateService interestRateService) =>
            _interestRateService = interestRateService;

        public async Task<ICommandResult> Handle(CalculateInterestCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.IsInvalid)
                return new CommandResult(false, command.NotificationsMessage(), command.Notifications);
            var interestRate = await _interestRateService.GetAsync(cancellationToken);
            var amount = new InterestCalculator(interestRate)
                .Calculate((decimal)command.Value, (int)command.QuantityMonths);
            return new CommandResult(true, "Calculo realizado", amount);
        }
    }
}