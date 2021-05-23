using System;

namespace InterestCalculator.Domain
{
    class InterestCalculator
    {
        public decimal InterestRate { get; private set; }

        public InterestCalculator(decimal interestRate) =>
            InterestRate = interestRate;

        public decimal Calculate(decimal value, int quantityMonths) =>
            Truncate(value * Potentialize(1 + InterestRate, quantityMonths));

        private static decimal Potentialize(decimal interestRate, int quantityMonths) =>
            (decimal)Math.Pow((double)interestRate, quantityMonths);

        private static decimal Truncate(decimal value) =>
            Math.Truncate(100 * value) / 100;
    }
}