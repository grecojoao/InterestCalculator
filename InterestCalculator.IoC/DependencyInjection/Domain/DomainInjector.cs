using InterestCalculator.Domain.Handlers;
using InterestCalculator.Domain.Services;
using InterestCalculator.Domain.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InterestCalculator.IoC.DependencyInjection.Domain
{
    class DomainInjector
    {
        internal static Task InjectDomain(IServiceCollection services, IConfiguration configuration)
        {
            EndpointAddress EndpointAddress(IServiceProvider a)
                => new(configuration.GetSection("InterestRatesURL").Value);
            services.AddScoped(EndpointAddress);
            services.AddScoped<IInterestRateService, InterestRateService>();
            services.AddScoped<InterestCalculatorHandler>();
            return Task.CompletedTask;
        }
    }
}