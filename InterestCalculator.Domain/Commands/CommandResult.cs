using InterestCalculator.Domain.Commands.Contracts;

namespace InterestCalculator.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CommandResult() { }

        public CommandResult(bool sucess, string message, object data = null)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}