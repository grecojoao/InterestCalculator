namespace InterestCalculator.Domain.Commands.Contracts
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}