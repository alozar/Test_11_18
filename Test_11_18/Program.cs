using System;

namespace Test_11_18
{
    class Program
    {
        static void Main(string[] args)
        {
            PolynomialTest.Verify((p1, p2) => p1 * p2);
            IntHelperTest.Verify(IntArrayHelper.Copy);
        } 
    }
}
