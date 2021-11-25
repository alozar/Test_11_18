using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_11_18
{
    public class IntHelperTest
    {
        private static int num = 1;
        private static string funcText;

        private static void printArray(int[] array, int[] result)
            => Console.WriteLine("Test " + num++ + ":\n"
                + array.Print() + "\n" + funcText + "\n" + result.Print() + "\n");

        public static void Verify(Func<int[], int, int, int[]> func)
        {
            num = 1;
            try
            {
                funcText = "func(array, 0, 10)";
                var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var result = func(array, 0, 10);
                printArray(array, result);

                funcText = "func(array, 3, 5)";
                array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                result = func(array, 3, 5);
                printArray(array, result);

                funcText = "func(array, 0, 1)";
                array = new int[] { 2 };
                result = func(array, 0, 1);
                printArray(array, result);

                funcText = "func(array, 1, 0)";
                array = new int[] { 2 };
                result = func(array, 1, 0);
                printArray(array, result);

                funcText = "func(array, 0, 0)";
                array = new int[] { 2 };
                result = func(array, 0, 0);
                printArray(array, result);

                funcText = "func(array, 0, 0)";
                array = new int[] { };
                result = func(array, 0, 0);
                printArray(array, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Тест " + num + " провален\n" + funcText);
            }
        }
    }
}
