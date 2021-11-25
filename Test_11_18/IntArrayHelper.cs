using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_11_18
{
    public static class IntArrayHelper
    {
        public static int[] Copy(int[] array)
            => Copy(array, 0, array.Length);

        public static int[] Copy(int[] array, int length)
            => Copy(array, 0, length);

        public static int[] Copy(int[] array, int startIndex, int length)
        {
            if (array is null)
                throw new ArgumentNullException();
            if (startIndex < 0 || startIndex + length > array.Length)
                throw new ArgumentOutOfRangeException();
            if (length < 0)
                throw new ArgumentException();
            var newArray = new int[length];
            var ind = 0;
            for (var i = startIndex; i < startIndex + length; i++)
            {
                newArray[ind++] = array[i];
            }
            return newArray;
        }

        public static string Print(this int[] array)
            => array != null && array.Length > 0 ?
                "[" + array.Select(item => item.ToString()).Aggregate((x, y) => x + ", " + y) + "]" : "[]";
    }
}
