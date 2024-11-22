using System.Collections.ObjectModel;
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

namespace PW_16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; }
        private bool isEditing = false;

        public MainWindow()
        {
            InitializeComponent();

            Notes = new ObservableCollection<Note>();
            NotesListBox.ItemsSource = Notes;

            // Добавляем текст подсказок при загрузке
            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            if (string.IsNullOrEmpty(TitleTextBox.Text))
                TitleTextBox.Text = TitleTextBox.Tag.ToString();

            if (string.IsNullOrEmpty(ContentTextBox.Text))
                ContentTextBox.Text = ContentTextBox.Tag.ToString();
        }

        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox.Text == TitleTextBox.Tag.ToString())
            {
                TitleTextBox.Text = string.Empty;
            }
        }

        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                TitleTextBox.Text = TitleTextBox.Tag.ToString();
            }
        }

        private void ContentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ContentTextBox.Text == ContentTextBox.Tag.ToString())
            {
                ContentTextBox.Text = string.Empty;
            }
        }

        private void ContentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContentTextBox.Text))
            {
                ContentTextBox.Text = ContentTextBox.Tag.ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing) // Если в режиме добавления
            {
                // Очищаем поля и активируем их для ввода
                TitleTextBox.Clear();
                ContentTextBox.Clear();
                TitleTextBox.IsEnabled = true;
                ContentTextBox.IsEnabled = true;
                TitleTextBox.Background = Brushes.White;
                ContentTextBox.Background = Brushes.White;

                // Меняем текст кнопки на "Сохранить"
                AddButton.Content = "Сохранить";
                isEditing = true;
            }
            else // Если в режиме сохранения
            {
                // Проверка на заполнение полей
                if (string.IsNullOrWhiteSpace(TitleTextBox.Text) || string.IsNullOrWhiteSpace(ContentTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите заголовок и содержание заметки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Создание новой заметки
                var newNote = new Note
                {
                    Title = TitleTextBox.Text,
                    Content = ContentTextBox.Text
                };

                // Добавление заметки в список
                Notes.Add(newNote);
                NotesListBox.Items.Refresh(); // Обновляем ListBox

                // Очищаем поля и сбрасываем состояние
                ClearInputFields();
                TitleTextBox.IsEnabled = false;
                ContentTextBox.IsEnabled = false;
                TitleTextBox.Background = Brushes.WhiteSmoke;
                ContentTextBox.Background = Brushes.WhiteSmoke;

                // Возвращаем текст кнопки "Добавить"
                AddButton.Content = "Добавить";
                isEditing = false;
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote && selectedNote != null)
            {
                // Переключаем режим редактирования
                isEditing = !isEditing;

                if (isEditing)
                {
                    // Если начинаем редактирование, заполняем поля из заметки
                    TitleTextBox.Text = selectedNote.Title;
                    ContentTextBox.Text = selectedNote.Content;

                    // Делаем поля доступными для редактирования и меняем цвет фона
                    TitleTextBox.IsEnabled = true;
                    ContentTextBox.IsEnabled = true;
                    TitleTextBox.Background = Brushes.WhiteSmoke;
                    ContentTextBox.Background = Brushes.WhiteSmoke;

                    // Меняем текст кнопки на "Сохранить"
                    (sender as Button).Content = "Сохранить";
                }
                else
                {
                    // Заканчиваем редактирование, обновляем заметку
                    selectedNote.Title = TitleTextBox.Text;
                    selectedNote.Content = ContentTextBox.Text;

                    // Закрываем редактирование, отключаем поля и возвращаем цвет
                    TitleTextBox.IsEnabled = false;
                    ContentTextBox.IsEnabled = false;
                    TitleTextBox.Background = Brushes.LightGray;
                    ContentTextBox.Background = Brushes.LightGray;

                    (sender as Button).Content = "Редактировать";

                    NotesListBox.Items.Refresh(); // Обновляем список заметок
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заметку для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote && selectedNote != null)
            {
                Notes.Remove(selectedNote);
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заметку для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                TitleTextBox.Text = selectedNote.Title;
                ContentTextBox.Text = selectedNote.Content;
            }
        }

        private void ClearInputFields()
        {
            TitleTextBox.Clear();
            ContentTextBox.Clear();
            NotesListBox.SelectedItem = null;
            SetPlaceholderText();  // Восстанавливаем подсказки
        }


    }
}