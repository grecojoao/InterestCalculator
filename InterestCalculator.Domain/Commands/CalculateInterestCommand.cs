using InterestCalculator.Domain.Notifications.Entities;

namespace InterestCalculator.Domain.Commands
{
    public class CalculateInterestCommand : Command
    {
        public decimal? Value { get; set; }
        public int? QuantityMonths { get; set; }

        public CalculateInterestCommand() { }

        public CalculateInterestCommand(decimal? value, int? quantityMonths)
        {
            Value = value;
            QuantityMonths = quantityMonths;
        }

        public override void Validate()
        {
            if (Value == null)
                AddNotification(new Notification("Valor inicial", "O valor inicial deve ser informado"));
            if (QuantityMonths == null)
                AddNotification(new Notification("Meses", "A quantidade em meses deve ser informada"));
        }
    }
}