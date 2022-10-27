using System;
using System.Data;
using System.IO;

namespace Libmas
{
    public class LibraryMas
    {
        /// <summary>
        /// Заполнять массив одномерный массив
        /// </summary>
        /// <param name="mas">Одномерный массив</param>
        /// <param name="minRandNum">Минимальное значение случайного числа</param>
        /// <param name="maxRandNum">Максимальное значение случайного числа</param>
        /// <returns>Заполненный одномерный массив</returns>
        public static void FillArray(ref int [] mas, int minRandNum, int maxRandNum)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(minRandNum, maxRandNum);
            }
        }

        /// <summary>
        /// Сохраняет одномерный массив
        /// </summary>
        /// <param name="mas">Одномернный массив</param>
        /// <param name="path">Путь до файла</param>
        public static void SaveArray(int[] mas, string path)
        {
            using(StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }


        /// <summary>
        /// Считывает данные с файла и заполняет одномернный массив
        /// </summary>
        /// <param name="mas">Очистка одномерного массива</param>
        /// <param name="path">Путь до файла</param>
        /// <returns>Заполенный массив с данными из файла</returns>
        public static void UploadArray(ref int[] mas, string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int.TryParse(reader.ReadLine(), out int lenght);

                mas = new int[lenght];

                for (int i = 0; i < mas.Length; i++)
                {
                    int.TryParse(reader.ReadLine(), out int value);
                    mas[i] = value;
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Очистка одномерного массива
        /// </summary>
        /// <param name="mas">Одномернный массив</param>
        /// <returns>Очищенный одномернный массив</returns>
        public static void ClearArray(ref int[] mas)
        {
            mas = null;
        }
    }
    //Класс для связывания массива с элементом DataGrid
    //для визуализации данных 
    public static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}