using InterestCalculator.IoC.DependencyInjection.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InterestCalculator.IoC.DependencyInjection
{
    public static class DependencyInjector
    {
        public static Task InjectDependencies(IServiceCollection services)
        {
            DomainInjector.InjectDomain(services);
            return Task.CompletedTask;
        }
    }
}