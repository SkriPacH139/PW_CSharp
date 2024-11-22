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

namespace PW_19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[,] cells = new TextBox[9, 9];
        private int[,] solution = new int[9, 9];
        private int[,] puzzle = new int[9, 9];

        public MainWindow()
        {
            InitializeComponent();
        }

        // Создание сетки
        private void CreateSudokuGrid()
        {
            SudokuGrid.Children.Clear();
            SudokuGrid.RowDefinitions.Clear();
            SudokuGrid.ColumnDefinitions.Clear();

            // Создаем строки и столбцы для сетки 9x9
            for (int i = 0; i < 9; i++)
            {
                SudokuGrid.RowDefinitions.Add(new RowDefinition());
                SudokuGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Создаем TextBox для каждой ячейки
                    TextBox cell = new TextBox
                    {
                        Text = puzzle[row, col] == 0 ? "" : puzzle[row, col].ToString(),
                        Margin = new Thickness(0), // Убираем стандартный отступ
                        TextAlignment = TextAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 18,
                        IsReadOnly = puzzle[row, col] != 0
                    };

                    // Оборачиваем TextBox в Border
                    Border cellBorder = new Border
                    {
                        BorderThickness = new Thickness(
                            col % 3 == 0 ? 2 : 0.5, // Левая граница
                            row % 3 == 0 ? 2 : 0.5, // Верхняя граница
                            col == 8 ? 2 : 0.5,     // Правая граница
                            row == 8 ? 2 : 0.5      // Нижняя граница
                        ),
                        BorderBrush = col % 3 == 0 || row % 3 == 0 || col == 8 || row == 8
                            ? Brushes.Black // Черный для жирных линий
                            : Brushes.Black, // Светло-серый для остальных линий
                        Child = cell // Вставляем TextBox внутрь
                    };

                    Grid.SetRow(cellBorder, row);
                    Grid.SetColumn(cellBorder, col);
                    cells[row, col] = cell; // Сохраняем TextBox для дальнейшей логики
                    SudokuGrid.Children.Add(cellBorder); // Добавляем Border в сетку
                }
            }
        }

        // Проверка решения
        private void CheckSudoku(object sender, RoutedEventArgs e)
        {
            bool isCorrect = true;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (int.TryParse(cells[row, col].Text, out int value))
                    {
                        if (value != solution[row, col])
                        {
                            cells[row, col].Background = Brushes.Red;
                            isCorrect = false;
                        }
                        else
                        {
                            cells[row, col].Background = Brushes.LightGreen;
                        }
                    }
                    else
                    {
                        cells[row, col].Background = Brushes.Red;
                        isCorrect = false;
                    }
                }
            }

            if (isCorrect)
            {
                MessageBox.Show("Поздравляем! Судоку решено правильно!");
            }
            else
            {
                MessageBox.Show("Есть ошибки. Попробуйте еще раз.");
            }
        }

        // Сгенерировать случайную головоломку
        private void GenerateSudoku()
        {
            // Базовая валидная сетка для судоку
            solution = new int[9, 9]
            {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9}
            };

            // Перемешиваем строки и столбцы в рамках правил
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int boxRow = rand.Next(0, 3) * 3;
                int boxCol = rand.Next(0, 3) * 3;
                int row1 = boxRow + rand.Next(0, 3);
                int row2 = boxRow + rand.Next(0, 3);
                int col1 = boxCol + rand.Next(0, 3);
                int col2 = boxCol + rand.Next(0, 3);

                SwapRows(solution, row1, row2);
                SwapCols(solution, col1, col2);
            }

            // Создаем головоломку, убирая случайные числа
            puzzle = (int[,])solution.Clone();
            for (int i = 0; i < 40; i++) // Убираем 40 клеток
            {
                int row = rand.Next(0, 9);
                int col = rand.Next(0, 9);
                puzzle[row, col] = 0;
            }
        }

        // Перемена строк
        private void SwapRows(int[,] grid, int row1, int row2)
        {
            for (int col = 0; col < 9; col++)
            {
                int temp = grid[row1, col];
                grid[row1, col] = grid[row2, col];
                grid[row2, col] = temp;
            }
        }

        // Перемена столбцов
        private void SwapCols(int[,] grid, int col1, int col2)
        {
            for (int row = 0; row < 9; row++)
            {
                int temp = grid[row, col1];
                grid[row, col1] = grid[row, col2];
                grid[row, col2] = temp;
            }
        }

        // Начать новую игру
        private void StartGame(object sender, RoutedEventArgs e)
        {
            GenerateSudoku();
            CreateSudokuGrid();
        }

        // Выход из игры
        private void ExitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

