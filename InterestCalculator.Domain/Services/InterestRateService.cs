using InterestCalculator.Domain.Services.Contracts;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Domain.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly EndpointAddress _endpointAddress;

        public InterestRateService(EndpointAddress endpointAddress) =>
            _endpointAddress = endpointAddress;

        public async Task<decimal> GetAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var httpClient = new HttpClient() { Timeout = TimeSpan.FromMilliseconds(800) };
                var response = await httpClient.GetAsync(_endpointAddress.Url, cancellationToken);
                var data = await response.Content.ReadAsStringAsync(cancellationToken);
                var interestRate = JsonSerializer.Deserialize<decimal>(data);
                return interestRate;
            }
            catch (HttpRequestException)
            {
                return 0m;
            }
            catch (TaskCanceledException)
            {
                return 0m;
            }
        }
    }
}