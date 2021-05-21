using InterestCalculator.Domain.Handlers;
using InterestCalculator.Domain.Services;
using InterestCalculator.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InterestCalculator.IoC.DependencyInjection.Domain
{
    class DomainInjector
    {
        internal static Task InjectDomain(IServiceCollection services)
        {
            services.AddScoped<IInterestRateService, InterestRateService>();
            services.AddScoped<InterestCalculatorHandler>();
            return Task.CompletedTask;
        }
    }
}