//
// Задача 50. Напишите программу, которая на вход принимает позиции
// элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет
//

// Ввод чисел.Разделитель между числами или пробел(ы)
// Возвращает строку двух целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input three digits of integers. This is matrix dimentione M x N and Digit for seaching (as example: 4 5 17");
    Console.Write("\n --- The number separator is a space!");

    Console.Write("\nInput digits, please: ");

    string? strArray = Console.ReadLine();
    if( String.IsNullOrEmpty(strArray) == true)
        strArray = "";

    // Из строки, которая может иметь значение NULL, делаем строку без NULL. Чтобы не использовать string?
    string str = string.Concat("", strArray);
    return str;
}

// Получает на входе строку чисел из консоли ввода.
// Если разделителем чисел была запятая ",", то удаляем ее.
// Возвращает строку целых чисел, где разделитель между числами - пробел
string GetNormilizeStrOfIntegers(string strArray)
{
    return strArray.Replace(",", "");
}

// Конвертирует строку целых чисел в массив строк целых чисел
// Возвращает массив слов, где каждый элемент массива целое число в виде строки.
string[] GetStrArrayOfNumvers(string strDigits)
{
    return strDigits.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
}

// Конвертирует массив строк целых чисел в массив целых чисел
// Пример: string "3 4 17" => int[3 4 17]
// Возвращает массив целых чисел, масив состоит из двух чисел, это кол-во строк и стоьбцов матрицы
int[] GetConvertStrArrayToArrayInt(string[] wordsOfNumbers)
{
    int[] array = new int[3];
    array[0] = Convert.ToInt32(wordsOfNumbers[0]);
    array[1] = Convert.ToInt32(wordsOfNumbers[1]);
    array[2] = Convert.ToInt32(wordsOfNumbers[2]);

    return array;
}

// Создает и возвращает матрицу целых чисел, размером row на col
// Возвращает матрицу целых чисел
int[,] GetMatrixInt(int row, int col)
{
    int[,] matrix = new int[row, col];

    var rand = new Random();

    for(int i = 0; i < row; ++i)
    {
        for(int j = 0; j < col; ++j)
        {
            matrix[i, j] = rand.Next(20);
        }
    }

    return matrix;
}

// Печатаем матрицу целых чисел
void PrintMatrix(int row, int col, int[,] matrix)
{
    Console.WriteLine($"\nYou create matrix. Size matrix is: {row} x {col}");
    for(int i = 0; i < row; ++i)
    {
        Console.WriteLine();
        for(int j = 0; j < col; ++j)
        {
            Console.Write("{0,4:N0}  ", matrix[i, j]);

        }
    }
    Console.WriteLine("\n");
}

// Ищем целое число digitForSearch в матрице matrix размером row на col
// Возврат: целое число, если 0, то ничего не найдено, если больше нуля, то значение это
// количество найденных чисел в матрице
int GetCountDigits(int row, int col, int[,] matrix, int digitForSearch)
{
    int foundedDigits = 0;

    for(int i = 0; i < row; ++i)
    {
        for(int j = 0; j < col; ++j)
        {
            if(matrix[i, j] == digitForSearch)
            {
                foundedDigits = foundedDigits + 1;
            }
        }
    }

    return foundedDigits;
}

// Печатаем результат. Если countOfFoundedDigit = 0, то число digitForSearch не найдено
// Если countOfFoundedDigit > 0, то число digitForSearch найдено countOfFoundedDigit раз
void PrintRezult(int digitForSearch, int countOfFoundedDigit)
{
    if(countOfFoundedDigit <= 0)
    {
        Console.WriteLine($"Sorry, digit: {digitForSearch} not found!!!");
    }
    else
    {
        Console.WriteLine($"Digit: {digitForSearch}, founded {countOfFoundedDigit} times.\n");
    }
}

void main()
{
    Console.WriteLine(" ------- Task-50 -------");

    // Получить строку ввода целых чисел. Это строка вида: "N M P" задает размер матрицы и число, которое мы ищем в матрице
    // Пример : " 5 4 17", матрица размером 5 на 4 и мы ищем число 17 в матрице
    string strDigits = InputIntegerDigitsAsString();
    Console.WriteLine($"\n You input digits: {strDigits}");

    // Если были введены целые числа с разделителем запятая "," то заменяем запятую на пробел " "
    strDigits = GetNormilizeStrOfIntegers(strDigits);

    // Получим массив строк, где строка - целое число в виде строки
    string[] wordsOfNumbers = GetStrArrayOfNumvers(strDigits);

    // Конвертируем массив строк в массив целых числех
    int[] arrayOfDigits = GetConvertStrArrayToArrayInt(wordsOfNumbers);

    int row = arrayOfDigits[0];
    int col = arrayOfDigits[1];
    int digitForSearch = arrayOfDigits[2];

    // Создать квадратную матрицу вещественных чисел и заполнить ее
    int[,] matrix = GetMatrixInt(row, col);

    // Печатаем матрицу
    PrintMatrix(row, col, matrix);

    // Получим количество чисел больше нуля из массива целых чисел
    int countOfFoundedDigit = GetCountDigits(row, col, matrix, digitForSearch);

    // Печатаем результат (красиво), количество введенных чисел больше нуля
    PrintRezult(digitForSearch, countOfFoundedDigit);
}

main();



