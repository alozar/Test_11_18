using System;

namespace Test_11_18
{
    public static class PolynomialTest
    {
        private static int num = 1;

        private static void testExecute(Polynomial p1, Polynomial p2, Polynomial trueResult, Func<Polynomial, Polynomial, Polynomial> testFunc)
        {
            var testNum = "Test " + num++;
            Console.WriteLine("{0}:\n{1}\n{2}",testNum, p1, p2);
            var testResult = testFunc(p1, p2);
            if (trueResult == testResult)
                Console.WriteLine("Успешно:{0}\n", trueResult);
            else
                throw new Exception(testNum);
        }

        public static void Verify(Func<Polynomial, Polynomial, Polynomial> func)
        {
            num = 1;
            try
            {
                var p1 = new Polynomial(new int[] { -1, 1 });
                var p2 = new Polynomial(new int[] { 2, 1 });
                var trueResult = new Polynomial(new int[] { -2, 1, 1 });
                testExecute(p1, p2, trueResult, func);


                p1 = new Polynomial(new int[] { 7, 3, 1 });
                p2 = new Polynomial(new int[] { -8, 7, 2, 1 });
                trueResult = new Polynomial(new int[] { -56, 25, 27, 20, 5, 1 });
                testExecute(p1, p2, trueResult, func);

                p1 = new Polynomial(new int[] { 7, 3, 1 });
                p2 = new Polynomial(new int[] { -1 });
                trueResult = new Polynomial(new int[] { -7, -3, -1 });
                testExecute(p1, p2, trueResult, func);

                p1 = new Polynomial(new int[] { 2 });
                p2 = new Polynomial(new int[] { 5 });
                trueResult = new Polynomial(new int[] { 10 });
                testExecute(p1, p2, trueResult, func);

                p1 = new Polynomial(new int[] { 5 });
                p2 = new Polynomial(new int[] { 2, 3, 0, -1 });
                trueResult = new Polynomial(new int[] { 10, 15, 0, -5 });
                testExecute(p1, p2, trueResult, func);

                p1 = new Polynomial(new int[] { 3, 0, 1, 1 });
                p2 = new Polynomial(new int[] { 0, 2 });
                trueResult = new Polynomial(new int[] { 0, 6, 0, 2, 2 });
                testExecute(p1, p2, trueResult, func);

                p1 = new Polynomial(new int[] { -1, 0, 0, 0, 1, -5, 6, 7, 9, 11, -5, 0, 3 });
                p2 = new Polynomial(new int[] { 1, 1, 0, -6, 2, -4, 3, 0, 0, 2, -4, -2, 1, 1, 5, 3, 1, 0, 5 });
                trueResult = new Polynomial(new int[] { -1, -1, 0, 6, -1, 0, -2, 7, 48, -32, 3, -82, -56, 41, -46, 62, -9, -38, -18, -81, 30, 84, 71, 53, 50, 34, 55, 64, -22, 0, 15 });
                testExecute(p1, p2, trueResult, func);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " провален");
            }
        }
    }
}
