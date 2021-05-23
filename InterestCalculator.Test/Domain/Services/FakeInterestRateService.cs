using InterestCalculator.Domain.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Test.Domain.Services
{
    class FakeInterestRateService : IInterestRateService
    {
        private readonly bool _yourServiceIsOnline;

        public FakeInterestRateService(bool yourServiceIsOnline = true) =>
            _yourServiceIsOnline = yourServiceIsOnline;

        public Task<decimal> GetAsync(CancellationToken cancellationToken)
        {
            if (_yourServiceIsOnline)
                return Task.FromResult(0.01m);
            return Task.FromResult(0m);
        }
    }
}