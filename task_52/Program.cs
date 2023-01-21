
//
// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов
//  в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
//

// Ввод чисел.Разделитель между числами или пробел(ы)
// Возвращает строку двух целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input two digits of integers. This is matrix dimentione M x N(as example: 4 5");
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
// Возвращает массив целых чисел, масив состоит из двух чисел, это кол-во строк
int[] GetConvertStrArrayToArrayInt(string[] wordsOfNumbers)
{
    int[] array = new int[3];
    array[0] = Convert.ToInt32(wordsOfNumbers[0]);
    array[1] = Convert.ToInt32(wordsOfNumbers[1]);

    return array;
}

// Сщздает и возвращает матрицу целых чисел, размером row на col
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

// Находим среднее арифмитическое в каждом столбце
// Возврат: массив среднее арифмитических цисел. Размер массива - col
double[] GetArrayОfАverages(int row, int col, int[,] matrix)
{
    double[] ArrayОfАverages = new double[col];

    for(int j = 0; j < col; ++j)
    {
        ArrayОfАverages[j] = 0.0;
        for(int i = 0; i < row; ++i)
        {
            ArrayОfАverages[j] = ArrayОfАverages[j] + matrix[i, j];
        }
        ArrayОfАverages[j] = ArrayОfАverages[j] / row;
    }

    return ArrayОfАverages;
}

// Печатаем результат. Массив вещественных чисел. Размер массива - col
void PrintRezult(double[] arrayОfАverages, int col)
{
    Console.WriteLine("Array of averages is: \n");
    for(int i = 0; i < col; ++i)
    {
        Console.Write("{0,8:N3}  ", arrayОfАverages[i]);
    }
    Console.WriteLine("\n");
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

    // Создать квадратную матрицу вещественных чисел и заполнить ее
    int[,] matrix = GetMatrixInt(row, col);

    // Печатаем матрицу
    PrintMatrix(row, col, matrix);

    // Получим массив среднеарифмитических чисел. Размер массива - col
    double[] arrayОfАverages = GetArrayОfАverages(row, col, matrix);

    // Печатаем результат (красиво), количество введенных чисел больше нуля
    PrintRezult(arrayОfАverages, col);
}

main();


