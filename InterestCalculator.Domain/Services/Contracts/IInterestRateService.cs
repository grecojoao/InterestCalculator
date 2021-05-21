using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Domain.Services.Contracts
{
    public interface IInterestRateService
    {
        Task<decimal> GetAsync(CancellationToken cancellationToken);
    }
}