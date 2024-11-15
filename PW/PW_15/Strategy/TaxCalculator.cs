using System;

namespace PW_15.Strategy
{
    internal class TaxCalculator
    {
        private TaxCalculationStrategy _taxCalculationStrategy;

        public void SetTaxCalculationStrategy(TaxCalculationStrategy taxCalculationStrategy) => _taxCalculationStrategy = taxCalculationStrategy;

        public decimal CalculateTax(decimal income)
        {
            if (_taxCalculationStrategy == null)
            {
                throw new InvalidOperationException("Стратегия налогообложения не определена.");
            }

            return _taxCalculationStrategy.CalculateTax(income);
        }
    }
}
