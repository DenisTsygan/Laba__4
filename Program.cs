using System;

namespace Laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] elementsMatrixA = { { 2, 3, 4 }, { 1, -2, 0 }, { 0, 1, 2 } };
            Matrix matrixA = new(elementsMatrixA);
            int[,] elementsMatrixB = { { 2, 0, -2 }, { 1, 1, 0 }, { 1, -1, 1 } };
            Matrix matrixB = new(elementsMatrixB);
            Console.WriteLine("Matrix A:");
            Console.WriteLine(matrixA);
            Console.WriteLine("Matrix B:");
            Console.WriteLine(matrixB);
            Matrix matrixX = 2 * matrixA * (matrixA + matrixB) - 3 * matrixA;

            Console.WriteLine("X=2A*(A+B)-3A");
            if (matrixX is not null)
            {
                Console.WriteLine("Matrix X:");
                Console.WriteLine(matrixX);

                Console.WriteLine($"Matrix X simetric ={matrixX.isSimetricMatrix()}");
            }
            else
            {
                Console.WriteLine("Matrix X was not created");
            }
            /*
            Console.WriteLine("Test on simetric another matrix:");
            Console.WriteLine("");
            int[,] elementsMatrixS = { { 1, 0, -3 }, { 0, 1, 0 }, { -3, 0, 1 } };
            Matrix matrixS = new(elementsMatrixS);
            Console.WriteLine("Matrix S:");
            Console.WriteLine(matrixS);
            Console.WriteLine($"Matrix S simetric ={matrixS.isSimetricMatrix()}");
            */
        }
    }
}
