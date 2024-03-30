using HW_Matrix.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace HW_Matrix
{
    internal class Matrix
    {
        private int row;
        public int Row { get => this.row; }

        private int column;
        public int Column { get => this.column; }

        //public int [][] Data { get; set; }

        protected int[][] Data;
        public Matrix(int row, int column)
        {
            this.row = row;
            this.column = column;
            Data = new int[Row][];
            for (int i = 0; i < Row; i++)
                Data[i] = new int[Column];
        }

        public void Print()
        {
            Console.WriteLine("--------MATRIX--------");
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data[i].Length; j++)
                {
                    Console.Write(" {0} ", Data[i][j]);
                }
                Console.WriteLine();
            }
        }

        public string Filling(string ConsoleString)
        {

            if (ConsoleString == null) return "Введенное количество цифр не соответствует размеру матрицы!";

            var myArray = ConsoleString.Split(' ');

            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data[i].Length; j++)
                {
                    int next;
                    if (int.TryParse(myArray[i * Data[i].Length + j], out next))
                        Data[i][j] = next;
                    else
                        return "Введенны символ, а не число!";
                }
            }
            return "";
        }

        public int GetCountNumbers(Numbers myNumbers)
        {
            int count = 0;
            for (int i = 0; i < Data.GetLength(0); i++)
                for (int j = 0; j < Data[i].Length; j++)
                {
                    if (myNumbers == 0 ? Data[i][j] > 0 : Data[i][j] < 0) count++;
                }
            return count;
        }

        public void BubbleSortRow(int myRow, SortType sortType) //sortType
        {
            int a;
            bool isChange = false;
            int temp = Data[myRow].Length;

            for (var i = 1; i < temp; i++)
            {
                for (var j = 0; j < temp - i; j++)
                {
                    if (sortType == 0 ? Data[myRow][j] > Data[myRow][j + 1] : Data[myRow][j] < Data[myRow][j + 1])
                    {
                        a = Data[myRow][j];
                        Data[myRow][j] = Data[myRow][j + 1];
                        Data[myRow][j + 1] = a;
                        isChange = true;
                    }
                }
                if (isChange == false) break;
            }
        }

        public void InersionRow(int myRow)
        {
            int a;
            int j = Data[myRow].Length % 2 == 0 ? Data[myRow].Length / 2 : (Data[myRow].Length / 2) + 1;
            int k = Data[myRow].Length - 1;
            for (int i = 0; i < j; i++)
            {
                a = Data[myRow][i];
                Data[myRow][i] = Data[myRow][k - i];
                Data[myRow][k - i] = a;

            }
        }
    }
}
