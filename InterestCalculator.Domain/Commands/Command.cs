using InterestCalculator.Domain.Commands.Contracts;
using InterestCalculator.Domain.Notifications;

namespace InterestCalculator.Domain.Commands
{
    public abstract class Command : Notifiable, ICommand
    {
        public abstract void Validate();
    }
}