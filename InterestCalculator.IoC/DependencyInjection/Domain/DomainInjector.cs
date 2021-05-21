using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace InterestCalculator.IoC.DependencyInjection.Domain
{
    class DomainInjector
    {
        internal static Task InjectDomain(IServiceCollection services)
        {
            return Task.CompletedTask;
        }
    }
}