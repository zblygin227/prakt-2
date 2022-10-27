using Lib_5;
using Libmas;
using Microsoft.Win32;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] arr;
        public MainWindow()
        {
            InitializeComponent();
            MasLenghtText.Focus();
        }

        private void SaveArr_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Текстовые файлы | *.txt";
            sfg.FilterIndex = 1;
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if (sfg.ShowDialog() == true)
            {
                LibraryMas.SaveArray(arr, sfg.FileName);
            }
        }

        private void UplArr_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pfg = new OpenFileDialog();
            pfg.Filter = "Текстовые файлы | *.txt";
            pfg.FilterIndex = 1;
            if (pfg.ShowDialog() == true)
            {
                LibraryMas.UploadArray(ref arr, pfg.FileName);
                MasNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Зблыгин Даниил\nВвести n целых чисел.\nНайти произведение чисел < 3.\nРезультат вывести на экран.");
        }

        private void ResBut_Click(object sender, RoutedEventArgs e)
        {
            if (arr != null || MasNums.ItemsSource != null)
            {
                ResBox.Text = $"{LibClass.PowOfNum(arr)}";
            }
            else
            {
                MessageBox.Show("Размер массива не может быть пустым");
            }
        }

        private void FillArrBut_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MasLenghtText.Text, out int len))
            {
                arr = new int[len];
                LibraryMas.FillArray(ref arr, 1, 10);
                MasNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void ClearArr_Click(object sender, RoutedEventArgs e)
        {
            MasLenghtText.Clear();
            MasLenghtText.Focus();
            ResBox.Clear();
            LibraryMas.ClearArray(ref arr);
            MasNums.ItemsSource = null;
        }
    }
}
