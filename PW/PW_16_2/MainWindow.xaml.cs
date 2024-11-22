using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PW_16_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение текста и сдвига
            string input = InputTextBox.Text;
            if (int.TryParse(ShiftTextBox.Text, out int shift) && shift >= 0 && shift <= 25)
            {
                string encryptedText = Encrypt(input, shift);
                OutputTextBox.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение сдвига (0-25).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private string Encrypt(string text, int shift)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                // Проверяем, является ли символ буквой
                if (char.IsLetter(letter))
                {
                    // Определяем, является ли символ заглавным или строчным
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    // Шифруем букву с учетом сдвига
                    letter = (char)((((letter + shift) - offset) % 26) + offset);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}