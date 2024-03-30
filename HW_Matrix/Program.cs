using HW_Matrix;
using HW_Matrix.Enum;
using System.Data.Common;
using System;

string inputString = "";
int Rows, Columns;
bool isCountRows = false;
bool isCountColumns = false;

while (true)
{
    Console.WriteLine("\n");
    Console.WriteLine("СОЗДАНИЕ МАТРИЦЫ \n");

    Console.WriteLine("Введите количество строк в матрице: ");
    inputString = Console.ReadLine();
    isCountRows = int.TryParse(inputString, out Rows);

    Console.WriteLine("Введите количество столбцов в матрице: ");
    inputString = Console.ReadLine();
    isCountColumns = int.TryParse(inputString, out Columns);


    // провекрка корректности размеров матрицы
    if (!isCountRows || !isCountColumns)
    {
        Console.WriteLine("Некорректный ввод размера матрицы! Попробуйте ещё раз.");
        Console.ReadLine();
        Console.Clear();
        continue;
    }
    else
    {
        Matrix myMatrix = new Matrix(Rows, Columns);
        Console.WriteLine($"Введите элементы матрицы (элементы являюся целые числа и вводятся в одну строку через пробел).\nВам необходимо ввести {Rows * Columns} элементов");
        if (myMatrix.Filling(Console.ReadLine()) == "")
        {
            myMatrix.Print();
            Console.WriteLine();

            Console.WriteLine("""
                    1. Найти количество положительных чисел в матрице.
                    2. Найти количество отрицательных чисел в матрице.
                    3. Сортировка по возрастанию элементов матрицы построчно.
                    4. Сортировка по убыванию элементов матрицы построчно.
                    5. Инверсия элементов матрицы построчно.
                    6. Выход.
                    """);
            while (true)
            {
                string input = Console.ReadLine();
                int numRow;
                Numbers myNumbers;
                SortType sortType;

                switch (input)
                {
                    case "1":
                        myNumbers = Numbers.Positive;
                        Console.WriteLine("Количество положительных элементов в матице равно {0}", myMatrix.GetCountNumbers(myNumbers));
                        break;
                    case "2":
                        myNumbers = Numbers.Negative;
                        Console.WriteLine("Количество отрицательных элементов в матице равно {0}", myMatrix.GetCountNumbers(myNumbers));
                        break;
                    case "3":
                        while (true)
                        {
                            Console.WriteLine("Введите номер строки для сортировки.");

                            if (int.TryParse(Console.ReadLine(), out numRow) && numRow <= myMatrix.Row)
                            {
                               sortType = SortType.Ascending;

                               myMatrix.BubbleSortRow(numRow, sortType);
                               myMatrix.Print();
                               break;
                            }
                            else
                               Console.WriteLine("введенный номер строки является числом или не соответствует размеру матрицы. Попробуйте еще раз.");
                        }
                        break;
                    case "4":
                        while (true)
                        {
                            Console.WriteLine("Введите номер строки для сортировки.");

                            if (int.TryParse(Console.ReadLine(), out numRow) && numRow <= myMatrix.Row)
                            {
                                sortType = SortType.Descending;
                                myMatrix.BubbleSortRow(numRow, sortType);
                                myMatrix.Print();
                                break;
                            }
                            else
                                Console.WriteLine("введенный номер строки является числом или не соответствует размеру матрицы. Попробуйте еще раз.");
                        }
                        break;
                    case "5":
                        while (true)
                        {
                            Console.WriteLine("Введите номер строки для инверсии.");
                        
                            if (int.TryParse(Console.ReadLine(), out numRow) && numRow <= myMatrix.Row)
                            {
                              myMatrix.InersionRow(numRow);
                              myMatrix.Print();
                              break;
                            }
                             else Console.WriteLine("введенный номер строки является числом или не соответствует размеру матрицы. Попробуйте еще раз.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Выход.");
                        return;
                    default:
                        Console.WriteLine("Выбор не корректен!");
                        break;
                }
            }
        }
        else
        {
             Console.WriteLine("Ошибка ввода! Попробуйте ещё раз.");
             Console.ReadLine();
             Console.Clear();
             continue;
        }
    }
}
