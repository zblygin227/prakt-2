namespace Lib_5
{
    public class LibClass
    {
        /// <summary>
        /// Считает произведение чисел < 3
        /// </summary>
        /// <param name="arr">Одномерный массив</param>
        /// <returns>Прозведение чисел</returns>
        public static int PowOfNum(int[] arr)
        {
            int pow = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 3)
                {
                    pow *= arr[i];
                }
            }
            return pow;
        }
    }
}
