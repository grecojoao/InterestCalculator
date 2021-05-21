using InterestCalculator.Domain.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Domain.Services
{
    public class InterestRateService : IInterestRateService
    {
        public Task<decimal> GetAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}