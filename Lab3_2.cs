namespace education_sharp;

public static class Lab3_2
{
    public static void Task1()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);
        int indexLastNegativeElement = -1;
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i] < 0)
            {
                indexLastNegativeElement = i;
            }
        }

        Console.WriteLine(indexLastNegativeElement == -1
            ? "Отрицательных элементов нет"
            : $"Номер последнего отрицательного элемента массива: {indexLastNegativeElement + 1}");
    }

    public static void Task2()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);
        Dictionary<double, int> valueCounts = [];

        foreach (double value in values)
        {
            valueCounts[value] = valueCounts.GetValueOrDefault(value) + 1;
        }

        int pairCount = valueCounts.Values.Sum(count => count * (count - 1) / 2);
        Console.WriteLine($"Количество пар одинаковых элементов: {pairCount}");
    }

    public static void Task3()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);
        Dictionary<double, int> valueCounts = [];

        foreach (double value in values)
        {
            valueCounts[value] = valueCounts.GetValueOrDefault(value) + 1;
        }

        foreach (double value in values.Where(value => valueCounts[value] == 1))
        {
            Console.WriteLine($"Элемент {value} встречается один раз");
        }
    }

    public static void Task4()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);

        double temp = 0;
        for (int i = 0; i < values.Count; i += 2)
        {
            if (i + 1 < values.Count)
            {
                temp = values[i];
                values[i] = values[i + 1];
                values[i + 1] = temp;
            }
        }

        Console.WriteLine("Массив после перестановки соседних элементов:");
        foreach (var item in values)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public static void Task5()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);

        values.Reverse();
        int count = 0;
        foreach (var item in values)
        {
            if (item % 2 == 0)
            {
                Console.Write($"{item} ");
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("Нет четных элементов в массиве");
        }
        else
        {
            Console.WriteLine($"\nКоличество четных элементов: {count}");
        }
    }

    public static void Task6()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);

        int count = 0;
        bool isIncreasing = false;
        for (int i = 1; i < values.Count; i++)
        {
            if (values[i] > values[i - 1])
            {
                if (!isIncreasing)
                {
                    count++;
                    isIncreasing = true;
                }
            }
            else
            {
                isIncreasing = false;
            }
        }

        Console.WriteLine($"Количество участков, где элементы массива возрастают: {count}");
    }

    public static void Task7()
    {
        Console.Write("Введите количество элементов: ");
        int countElements = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> values = Helper.ReadArray(countElements);

        Console.Write("Введите K: ");
        int k = Helper.TryParseStringToInt(Console.ReadLine(), false);

        Console.Write("Введите L: ");
        int l = Helper.TryParseStringToInt(Console.ReadLine(), false);

        if (k < 1 || l > values.Count || k > l)
        {
            throw new InvalidDataException("K и L должны быть в пределах от 1 до N, и K должно быть меньше L");
        }

        double sum = 0;
        int count = 0;
        for (int i = k - 1; i < l; i++)
        {
            Console.Write($"{values[i]} ");
            sum += values[i];
            count++;
        }
        Console.WriteLine($"\nСумма элементов в диапазоне [K, L]: {sum}");
        Console.WriteLine($"Количество элементов в диапазоне [K, L]: {count}");
    }

    public static void Task8()
    {
        Console.Write("Введите M: ");
        int m = Helper.TryParseStringToInt(Console.ReadLine(), false);

        Console.Write("Введите N: ");
        int n = Helper.TryParseStringToInt(Console.ReadLine(), false);

        int[,] matrix = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var random = new Random();
                matrix[i, j] = random.Next(0, 21);
            }
        }

        HashSet<int> rowsWithFour = [];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j]} ");
                if (matrix[i, j] == 4)
                {
                    rowsWithFour.Add(i);
                }
            }
            Console.WriteLine();
        }

        if (rowsWithFour.Count == 0)
        {
            Console.WriteLine("Число 4 не встречается в массиве");
        }
        else
        {
            foreach (int row in rowsWithFour)
            {
                Console.WriteLine($"Число 4 встречается в строке под номером {row + 1}");
            }
        }
    }

    public static void Task9()
    {
        Console.Write("Введите M: ");
        int m = Helper.TryParseStringToInt(Console.ReadLine(), false);

        Console.Write("Введите N: ");
        int n = Helper.TryParseStringToInt(Console.ReadLine(), false);

        int[,] matrix = new int[m, n];
        int[,] newMatrix = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var random = new Random();
                matrix[i, j] = random.Next(-20, 21);
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                newMatrix[i, j] = matrix[i, j] % 2 == 0 ? matrix[i, j] : 0;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Новая матрица:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{newMatrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
