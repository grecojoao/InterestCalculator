using InterestCalculator.Domain.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Test.Domain.Services
{
    class FakeInterestRateService : IInterestRateService
    {
        public Task<decimal> GetAsync(CancellationToken cancellationToken) =>
            Task.FromResult(0.01m);
    }
}