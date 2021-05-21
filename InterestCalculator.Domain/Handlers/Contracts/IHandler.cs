using InterestCalculator.Domain.Commands.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command, CancellationToken cancellationToken);
    }
}