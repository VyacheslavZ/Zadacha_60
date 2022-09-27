int[] FillArrayThree(int a, int b, int c)
{
    int[] result = new int[a * b * c];
    int[] index = new int[50];
    int v = 10;
    int i = 0;
    while (i < index.Length)
    {
        index[i] = v;
        v++;
        i++;
    }
    int j = 0; // для сортировки 
    int x = 0; // нижняя граница диапазона чисел для генератора псевдослучайных
    int z = 0;
    int m = 0;
    while (z < result.Length)
    {
        m = new Random().Next(x, index.Length);
        result[z] = index[m];
        int temp = index[m];
        index[m] = index[j];
        index[j] = temp;
        x++;
        z++;
        j++;
    }
    return result;
}
int[,,] RandomDoubleDigit(int[] arr, int a, int b, int c)
{
    int[,,] result = new int[a, b, c];
    int l = 0;
    int i = 0;
    int j = 0;
    for (int z = 0; z < c; z++)
    {
        while (i < a)
        {
            while (j < b)
            {
                result[i, j, z] = arr[l];
                l++;
                j++;
            }
            i++;
            j = 0;
        }
        i = 0;
        j = 0;
    }
    return result;
}
void PrintArray3(int[,,] arr)
{
    int i = 0;
    int j = 0;
    for (int z = 0; z < arr.GetLength(2); z++)
    {
        while (i < arr.GetLength(0))
        {
            while (j < arr.GetLength(1))
            {
                if (j < arr.GetLength(1) - 1) Console.Write($"{arr[i, j, z]}({i}, {j}, {z})  ");
                else if (j == arr.GetLength(1) - 1) Console.WriteLine($"{arr[i, j, z]}({i}, {j}, {z})  ");
                j++;
            }
            i++;
            j = 0;
        }
        i = 0;
        j = 0;
    }
}
try
{
    Console.WriteLine("Введите размер вашего трехмерного массива, чтобы произведение a*b*c не превышало 50-ти:");
    Console.WriteLine("Введите размер первого измерения а:");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите размер второго измерения b:");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите размер третьего измерения c:");
    int c = Convert.ToInt32(Console.ReadLine());
    if (a * b * c > 50) Console.WriteLine("Размер вашего трехмерного массива, превышает заданное условием произведение a*b*c");
    else
    {
        int[] res = FillArrayThree(a, b, c);
        int[,,] resu = RandomDoubleDigit(res, a, b, c);
        PrintArray3(resu);
    }
}
catch
{
    Console.WriteLine("Введите целые числа.");
}