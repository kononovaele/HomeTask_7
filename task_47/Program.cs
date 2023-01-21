//
// Задача 47: Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4
// 0.5  7       -2      -0.2
// 1    -3.3    8       -9.9
// 8    7.8     -7.1     9
//

// Ввод чисел.Разделитель между числами или пробел(ы)
// Возвращает строку двух целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input two digits of integers. This is matrix dimentione M x N (as example: 4 5 ");
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
// Пример: string "3 4" => int[3 4]
// Возвращает массив целых чисел, масив состоит из двух чисел, это кол-во строк и стоьбцов матрицы
int[] GetConvertStrArrayToArrayInt(string[] wordsOfNumbers)
{
    int[] array = new int[2];
    array[0] = Convert.ToInt32(wordsOfNumbers[0]);
    array[1] = Convert.ToInt32(wordsOfNumbers[1]);

    return array;
}

// Конвертирует массив строк целых чисел в массив целых чисел
// Пример: string "11 -2 77 90 101 -44" => int[11 -2 77 90 101 -44]
// Возвращает массив целых чисел
double[,] GetMatrixDouble(int row, int col)
{
    double[,] matrix = new double[row, col];

    var rand = new Random();

    for(int i = 0; i < row; ++i)
    {
        for(int j = 0; j < col; ++j)
        {
            matrix[i, j] = rand.NextDouble();
        }
    }

    return matrix;
}

void PrintMatrix(int row, int col, double[,] matrix)
{
    Console.WriteLine($"\nYou craete matrix. Size matriz is: {row} x {col}");
    for(int i = 0; i < row; ++i)
    {
        Console.WriteLine();
        for(int j = 0; j < col; ++j)
        {
            Console.Write("{0,8:N3}  ", matrix[i, j]);
        }
    }
    Console.WriteLine("\n");
}

void PrintRezult(double sum)
{
    Console.WriteLine($"\n Count of digits bigger than zero is: {sum}");
}

void main()
{
    Console.WriteLine(" ------- Task-41 -------");

    // Получить строку ввода целых чисел. Это строка вида: "N M" задает размер матрицы
    // Пример : " 5 4" 
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
    // Создать квадратную матрицу вещественных чисел и заполнить ее
    double[,] matrix = GetMatrixDouble(row, col);

    // Печатаем матрицу
    PrintMatrix(row, col, matrix);

    // Получим количество чисел больше нуля из массива целых чисел
    //int countDigitsBiggerZero = GetCountDigitsBiggerZero(row, col, matrix);
    //double sum = 0.0;

    // Печатаем результат (красиво), количество введенных чисел больше нуля
    //PrintRezult(sum);
}

main();




