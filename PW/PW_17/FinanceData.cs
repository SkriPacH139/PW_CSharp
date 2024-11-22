using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_17
{
    internal class FinanceData
    {
        // Список для хранения доходов
        public static List<double> Incomes { get; private set; } = new List<double>();

        // Список для хранения расходов
        public static List<double> Expenses { get; private set; } = new List<double>();

        // Метод для добавления дохода
        public static void AddIncome(double amount)
        {
            Incomes.Add(amount);
        }

        // Метод для добавления расхода
        public static void AddExpense(double amount)
        {
            Expenses.Add(amount);
        }

        // Подсчет общего дохода
        public static double GetTotalIncome()
        {
            return Incomes.Sum();
        }

        // Подсчет общего расхода
        public static double GetTotalExpense()
        {
            return Expenses.Sum();
        }

        // Подсчет общего баланса
        public static double GetBalance()
        {
            return GetTotalIncome() - GetTotalExpense();
        }
    }
}
