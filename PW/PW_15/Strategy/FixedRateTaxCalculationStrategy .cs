namespace PW_15.Strategy
{
    internal class FixedRateTaxCalculationStrategy : TaxCalculationStrategy
    {
        private readonly decimal _fixedRate;

        public FixedRateTaxCalculationStrategy(decimal fixedRate) => _fixedRate = fixedRate;

        public override decimal CalculateTax(decimal income) => income * _fixedRate; // фиксированная ставка
    }
}
