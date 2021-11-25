using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_11_18
{
    public class Polynomial
    {
        /// <summary>
        /// Коэффициенты полинома
        /// </summary>
        public int[] Coefficients { get; }
        /// <summary>
        /// Глубина полинома
        /// </summary>
        public int Degree { get; }

        /// <param name="coefficients">
        /// Массив коэффициентов, где индекс элемента в массиве
        /// соответствует степени x при этом коээфициенте
        /// </param>
        public Polynomial(int[] coefficients)
        {
            if (coefficients.Length == 0)
                throw new Exception("Пустой массив коэффициентов");
            
            Coefficients = coefficients;
            Degree = coefficients.Length - 1;
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
            => p1.Degree == p2.Degree && p1.Coefficients.SequenceEqual(p2.Coefficients);

        public static bool operator !=(Polynomial p1, Polynomial p2)
            => !(p1 == p2);

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
            => p1.Multiply(p2);

        public Polynomial Multiply(Polynomial p)
        {
            var coefficients = new int[Degree + p.Degree + 1];
            coefficients[0] = Coefficients[0] * p.Coefficients[0];
            var row = 0;
            var col = 0;
            var direction = true;
            var i = 0;
            while (row < Degree || col < p.Degree)
            {
                i++;
                if (direction)
                    coefficients[i] = dirLeftBotton(ref row, ref col, p);
                else
                    coefficients[i] = ditRightTop(ref row, ref col, p);
                
                direction = !direction;
            }
            return new Polynomial(coefficients);
        }

        private int dirLeftBotton(ref int row, ref int col, Polynomial p)
        {
            if (col < p.Degree)
                col++;
            else
                row++;
            var k = 0;
            while(true)
            {
                k += Coefficients[row] * p.Coefficients[col];
                if (row < Degree && col > 0)
                {
                    row++;
                    col--;
                    continue;
                }
                return k;
            }
        }

        private int ditRightTop(ref int row, ref int col, Polynomial p)
        {
            if (row < Degree)
                row++;
            else
                col++;
            var k = 0;
            while (true)
            {
                k += Coefficients[row] * p.Coefficients[col];
                if (row > 0 && col < p.Degree)
                {
                    row--;
                    col++;
                    continue;
                }
                return k;
            }
        }

        public override string ToString()
        {
            return "[" + Coefficients.Select(c => c.ToString()).Aggregate((x1, x2) => x1 + ", " + x2) + "]";
        }

        public string ToFullString()
        {
            var pol = new StringBuilder();
            for(var i = 0; i < Coefficients.Length; i++)
            {
                var sign = " ";
                if (Coefficients[i] >= 0 && i != 0) sign = " + ";
                pol.Append(sign + Coefficients[i].ToString() + " * x^" + i.ToString());
            }
            return pol.ToString();
        }
    }
}
