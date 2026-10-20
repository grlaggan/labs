namespace education_sharp;

public static class Lab3
{
    public static void Task1()
    {
        int count = 0;
        var random = new Random();
        int v = random.Next(1, 11);
        while (true)
        {
            Console.Write("Введите значение ");
            string? value = Console.ReadLine();
            try
            {
                int parsedValue = Helper.TryParseStringToInt(value, false);
                count++;
                if (parsedValue == v)
                {
                    Console.WriteLine("Вы угадали!");
                    break;
                }

                if (parsedValue > v)
                {
                    Console.WriteLine("Введеное значение больше загаданного");
                    continue;
                }
                Console.WriteLine("Введеное значение меньше загаданного");
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine($"Ошибка: {e.Message} Попробуйте еще раз");
                continue;
            }
        }
    }

    public static void Task2()
    {
        Console.WriteLine("Введите n");
        string? n = Console.ReadLine();
        int validatedN = Helper.TryParseStringToInt(n, false);
        if (validatedN <= 10)
        {
            throw new InvalidDataException("N должен быть больше 10");
        }

        int sumValues = 0;
        int sumSquared = 0;
        for (int i = 0; i <= validatedN; i++)
        {
            sumValues += i;
            sumSquared += (int)Math.Pow(i, 2);
            if (sumSquared > 500)
            {
                Console.WriteLine("Сумма квадратов больше 500");
                break;
            }
        }

        Console.WriteLine($"Сумма значений: {sumValues}");
        Console.WriteLine($"Сумма квадратов: {sumSquared}");
    }

    public static void Task3()
    {
        Console.WriteLine("Введите количество человек");
        string? count = Console.ReadLine();
        int parsedCount = Helper.TryParseStringToInt(count, false);
        List<int> values = [];
        for (int i = 0; i < parsedCount; i++)
        {
            Console.WriteLine("Введите количество подтяиваний");
            string? amount = Console.ReadLine();
            int parsedAmont = Helper.TryParseStringToInt(amount, false);

            values.Add(parsedAmont);
        }

        int threes = values.Count(v => v >= 12 && v < 14);
        int fours = values.Count(v => v >= 14 && v < 16);
        int fives = values.Count(v => v >= 16);
        int maxCount = values.Max();
        int minCount = values.Min();

        Console.WriteLine($"Количество троек: {threes}\nКоличество четверок: {fours}\nКоличество пятерок: {fives}");
        Console.WriteLine($"Максимальное количество: {maxCount}\nМинимальное количество: {minCount}");
    }

    public static void Task4()
    {
        List<double> values = [];
        string letters = "ABCD";
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Введите {letters[i]} ");
            values.Add(Helper.TryParseStringToDouble(Console.ReadLine(), true));
        }

        Func<double, double> y = x =>
        {
            return values[0] * Math.Sqrt(values[1] * x + values[3]) - values[2] * x;
        };

        List<double> ys = [];
        for (double i = 1; i < 10; i++)
        {
            ys.Add(y(i));
        }

        double sum = ys.Sum();
        double average = ys.Average();
        if (!double.IsNaN(sum) && !double.IsNaN(average))
        {
            Console.WriteLine($"Сумма значений: {sum}");
            Console.WriteLine($"Среднее значение: {average}");
            return;
        }
        Console.WriteLine("Сумма или среднее значение не может быть вычислено");
    }

    public static void Task5()
    {
        Console.Write("Введите количество чисел: ");
        int count = Helper.TryParseStringToInt(Console.ReadLine(), false);

        List<int> ints = [];
        int maxValue = 0;
        int indexMaxValue = 0;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите {i + 1} значение: ");
            ints.Add(Helper.TryParseStringToInt(Console.ReadLine(), true));
            if (ints[i] >= maxValue)
            {
                maxValue = ints[i];
                indexMaxValue = i;
            }
        }
        Console.WriteLine($"Максимальное значение: {maxValue}, индекс: {indexMaxValue}");
    }

    public static void Task6()
    {
        Console.Write("Введите радиус окружностей R: ");
        double radius = Helper.TryParseStringToDouble(Console.ReadLine(), false);
        int intersectingCount = 0;
        double maximumDistanceSquared = 4 * radius * radius;

        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine($"Введите координаты центра {i + 1}-й окружности:");
            Console.Write("x: ");
            double x = Helper.TryParseStringToDouble(Console.ReadLine(), true);
            Console.Write("y: ");
            double y = Helper.TryParseStringToDouble(Console.ReadLine(), true);

            if (x * x + y * y <= maximumDistanceSquared)
            {
                intersectingCount++;
            }
        }

        Console.WriteLine($"Количество пересекающихся окружностей: {intersectingCount}");
    }
}
