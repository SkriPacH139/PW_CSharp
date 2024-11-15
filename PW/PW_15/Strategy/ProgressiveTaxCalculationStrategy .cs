namespace PW_15.Strategy
{
    internal class ProgressiveTaxCalculationStrategy : TaxCalculationStrategy
    {
        public override decimal CalculateTax(decimal income) 
            => income <= 10000 ? income * 0.10m : income <= 30000 ? 1000 + (income - 10000) * 0.15m : 4000 + (income - 30000) * 0.20m;
    }
}
