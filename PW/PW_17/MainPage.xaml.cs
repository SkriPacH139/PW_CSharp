using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PW_17
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded; // Подписка на событие Loaded
        }

        // Метод, который вызывается при загрузке страницы
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDisplay(); // Обновляем интерфейс
        }

        // Обновление данных на странице
        private void UpdateDisplay()
        {
            IncomeText.Text = $"Общий доход: {FinanceData.GetTotalIncome():C}";
            ExpenseText.Text = $"Общий расход: {FinanceData.GetTotalExpense():C}";
            BalanceText.Text = $"Баланс: {FinanceData.GetBalance():C}";
        }

        // Переход на страницу добавления дохода
        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddIncomePage());
        }

        // Переход на страницу добавления расхода
        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExpensePage());
        }
    }
}
