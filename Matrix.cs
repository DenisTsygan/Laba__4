using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    public class Matrix
    {
        private int rows;
        private int cols;
        private int[,] elementsMatrix;

        private Matrix(int rows, int cols)
        {
            if (rows > 0 && cols > 0)
            {
                this.rows = rows;
                this.cols = cols;
                this.elementsMatrix = new int[rows, cols];
            }
            else
            {
                this.rows = 0;
                this.cols = 0;
                this.elementsMatrix = new int[0, 0];
            }
        }
        public Matrix(int[,] elements)
        {
            this.rows = elements.GetLength(0);
            this.cols = elements.GetLength(1);
            this.elementsMatrix = elements;
        }
        ~Matrix()
        {
            Console.WriteLine("Matrix was deleted");
        }

        public bool isSimetricMatrix()
        {
            if (rows != cols)
            {
                return false;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (this.elementsMatrix[i, j] != this.elementsMatrix[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix is null || secondMatrix is null || firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
            {
                return null;
            }

            Matrix resultMatrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < firstMatrix.cols; j++)
                {
                    resultMatrix.elementsMatrix[i, j] = firstMatrix.elementsMatrix[i, j] + secondMatrix.elementsMatrix[i, j];
                }
            }

            return resultMatrix;
        }
        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix is null || secondMatrix is null || firstMatrix.rows != secondMatrix.rows || firstMatrix.cols != secondMatrix.cols)
            {
                return null;
            }

            Matrix resultMatrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < firstMatrix.cols; j++)
                {
                    resultMatrix.elementsMatrix[i, j] = firstMatrix.elementsMatrix[i, j] - secondMatrix.elementsMatrix[i, j];
                }
            }

            return resultMatrix;
        }
        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix is null || secondMatrix is null || firstMatrix.cols != secondMatrix.rows)
            {
                return null;
            }
            Matrix resultMatrix = new Matrix(firstMatrix.rows, secondMatrix.cols);

            for (int i = 0; i < firstMatrix.rows; i++)
            {
                for (int j = 0; j < secondMatrix.cols; j++)
                {
                    resultMatrix.elementsMatrix[i, j] = 0;
                    for (int k = 0; k < firstMatrix.cols; k++)
                    {
                        resultMatrix.elementsMatrix[i, j] += firstMatrix.elementsMatrix[i, k] * secondMatrix.elementsMatrix[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(int value, Matrix matrix)
        {
            Matrix result = new Matrix(matrix.rows, matrix.cols);
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    result.elementsMatrix[i, j] = matrix.elementsMatrix[i, j] * value;
                }
            }

            return result;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    res += $"{this.elementsMatrix[i, j]}  \t";
                }
                res += "\n";
            }

            return res;
        }

    }
}
