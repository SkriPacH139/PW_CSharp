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
    /// Логика взаимодействия для AddIncomePage.xaml
    /// </summary>
    public partial class AddIncomePage : Page
    {
        public AddIncomePage()
        {
            InitializeComponent();
        }

        // Placeholder-логика: Очистка текста при фокусировке
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Сумма дохода")
            {
                textBox.Text = "";  // Очистить текст
                textBox.Foreground = Brushes.Black; // Сделать текст черным
            }
        }

        // Placeholder-логика: Восстановление текста, если ничего не введено
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Сумма дохода";  // Восстановить placeholder
                textBox.Foreground = Brushes.Gray; // Сделать текст серым
            }
        }

        // Сохранение данных
        private void SaveIncome_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(IncomeTextBox.Text, out double amount) && amount > 0)
            {
                FinanceData.AddIncome(amount);
                MessageBox.Show("Доход добавлен!");
                NavigationService.GoBack(); // Возврат на главную страницу
            }
            else
            {
                MessageBox.Show("Введите корректную сумму дохода.");
            }
        }
    }
}
