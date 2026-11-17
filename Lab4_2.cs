namespace education_sharp;

static class Lab4_2
{
    private class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public static void Task1()
    {
        List<double> FindRoots(double a, double b, double c)
        {
            double D = Math.Pow(b, 2) - 4 * a * c;

            if (D < 0)
            {
                return [];
            }

            if (D == 0)
            {
                return [-b / (2 * a)];
            }

            return [(-b + Math.Sqrt(D)) / (2 * a), (-b - Math.Sqrt(D)) / (2 * a)];
        }

        for (int j = 0; j < 5; j++)
        {
            string letters = "abc";
            List<double> coofs = [];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Введите коэфициент {letters[i]}: ");
                double coof = Helper.TryParseStringToDouble(Console.ReadLine(), true);
                coofs.Add(coof);
            }

            var roots = FindRoots(coofs[0], coofs[1], coofs[2]);

            if (roots.Count == 0)
            {
                Console.WriteLine("Нет корней");
                continue;
            }

            foreach (var el in roots)
            {
                Console.WriteLine(el);
            }
        }
    }

    public static void Task2()
    {
        int Factorial(int value)
        {
            int answer = 1;
            for (int i = 1; i <= value; i++)
            {
                answer *= i;
            }

            return answer;
        }

        Console.Write("Через пробел введите 10 значений: ");
        string? numbers = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(numbers))
        {
            throw new InvalidDataException("Значения не могут быть пустыми!");
        }

        var values = numbers.Split(" ").Select(str => Convert.ToInt32(str)).ToList();

        if (values.Count != 10)
        {
            throw new InvalidDataException("Значений должно быть 10!");
        }

        foreach (int value in values)
        {
            Console.WriteLine($"Факториал числа {value} равен {Factorial(value)}");
        }
    }

    public static void Task3()
    {
        int FindSumDigitsOfNumber(int number)
        {
            int sum = 0;
            foreach (char chr in number.ToString())
            {
                int value = Convert.ToInt32(chr.ToString());
                sum += value;
            }

            return sum;
        }

        Console.Write("Через пробел введите 5 значений: ");
        string? numbers = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(numbers))
        {
            throw new InvalidDataException("Значения не могут быть пустыми!");
        }

        var values = numbers.Split(" ").Select(str => Convert.ToInt32(str)).ToList();

        if (values.Count != 5)
        {
            throw new InvalidDataException("Значений должно быть 5!");
        }

        foreach (int value in values)
        {
            Console.WriteLine($"Сумма цифр числа {value}: {FindSumDigitsOfNumber(value)}");
        }
    }

    public static void Task4()
    {
        double FindLenghtVector(Point first, Point second)
        {
            Point pointFromStart = new()
            {
                X = second.X - first.X,
                Y = second.Y - first.Y,
            };

            return Math.Sqrt(Math.Pow(pointFromStart.X, 2) + Math.Pow(pointFromStart.Y, 2));
        }

        string letters = "ABCD";
        List<Point> points = [];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Координаты для точки {letters[i]}");

            Console.Write("Введите координату X: ");
            int x = Helper.TryParseStringToInt(Console.ReadLine(), true);

            Console.Write("Введите координату Y: ");
            int y = Helper.TryParseStringToInt(Console.ReadLine(), true);

            points.Add(new Point { X = x, Y = y });
        }

        Console.WriteLine($"Длина отрезка AB: {FindLenghtVector(points[0], points[1])}");
        Console.WriteLine($"Длина отрезка AC: {FindLenghtVector(points[0], points[2])}");
        Console.WriteLine($"Длина отрезка AD: {FindLenghtVector(points[0], points[3])}");
    }

    public static void Task5()
    {
        double CountPerimeter(double ax, double ay, double bx, double by, double cx, double cy)
        {
            double ab = Math.Sqrt(Math.Pow(bx - ax, 2) + Math.Pow(by - ay, 2));
            double bc = Math.Sqrt(Math.Pow(cx - bx, 2) + Math.Pow(cy - by, 2));
            double ac = Math.Sqrt(Math.Pow(ax - cx, 2) + Math.Pow(ay - cy, 2));

            return ab + bc + ac;
        }

        string letters = "ABCD";
        List<Point> points = [];
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Введите координату x для точки {letters[i]}: ");
            int x = Helper.TryParseStringToInt(Console.ReadLine(), true);
            Console.Write($"Введите координату y для точки {letters[i]}: ");
            int y = Helper.TryParseStringToInt(Console.ReadLine(), true);
            points.Add(new Point
            {
                X = x,
                Y = y,
            });
        }

        Console.WriteLine($"Периметр треугольника ABC: {CountPerimeter(points[0].X, points[0].Y, points[1].X, points[1].Y, points[2].X, points[2].Y)}");
        Console.WriteLine($"Периметр треугольника ABD: {CountPerimeter(points[0].X, points[0].Y, points[1].X, points[1].Y, points[3].X, points[3].Y)}");
        Console.WriteLine($"Периметр треугольника ACD: {CountPerimeter(points[0].X, points[0].Y, points[2].X, points[2].Y, points[3].X, points[3].Y)}");
    }

    public static void Task6()
    {
        double FindNod(double a, double b)
        {
            double max = 0;
            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0 && b % i == 0 && i > max)
                {
                    max = i;
                }
            }

            return max;
        }

        string letters = "ABCD";
        List<int> ints = [];
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Введите {letters[i]}: ");
            int value = Helper.TryParseStringToInt(Console.ReadLine(), true);
            ints.Add(value);
        }

        Console.WriteLine($"НОД чисел A и B: {FindNod(ints[0], ints[1])}");
        Console.WriteLine($"НОД чисел A и C: {FindNod(ints[0], ints[2])}");
        Console.WriteLine($"НОД чисел A и D: {FindNod(ints[0], ints[3])}");
        Console.WriteLine($"НОД чисел A и D: {FindNod(ints[0], ints[3])}");
    }
    public static void Task7()
    {
        static void InvertArray(double[] values)
        {
            Array.Reverse(values);
        }

        Console.Write("Введите количество элементов массива A: ");
        int countA = Helper.TryParseStringToInt(Console.ReadLine(), false);
        double[] arrayA = Helper.ReadArray(countA).ToArray();

        Console.Write("Введите количество элементов массива B: ");
        int countB = Helper.TryParseStringToInt(Console.ReadLine(), false);
        double[] arrayB = Helper.ReadArray(countB).ToArray();

        Console.Write("Введите количество элементов массива C: ");
        int countC = Helper.TryParseStringToInt(Console.ReadLine(), false);
        double[] arrayC = Helper.ReadArray(countC).ToArray();

        InvertArray(arrayA);
        InvertArray(arrayB);
        InvertArray(arrayC);

        Console.WriteLine($"A: {string.Join(" ", arrayA)}");
        Console.WriteLine($"B: {string.Join(" ", arrayB)}");
        Console.WriteLine($"C: {string.Join(" ", arrayC)}");
    }

    public static void Task8()
    {
        static List<int> FindSubstringPositions(string subString, string source)
        {
            if (string.IsNullOrEmpty(subString))
            {
                throw new InvalidDataException("Подстрока не может быть пустой.");
            }

            List<int> positions = [];
            int position = source.IndexOf(subString, StringComparison.Ordinal);

            while (position >= 0)
            {
                positions.Add(position + 1);
                position = source.IndexOf(subString, position + 1, StringComparison.Ordinal);
            }

            return positions;
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Введите строку S ({i + 1}/5): ");
            string source = Console.ReadLine() ?? throw new InvalidDataException("Строка S не может быть пустой.");

            Console.Write("Введите подстроку subS: ");
            string subString = Console.ReadLine() ?? throw new InvalidDataException("Подстрока subS не может быть пустой.");

            List<int> positions = FindSubstringPositions(subString, source);
            Console.WriteLine(positions.Count == 0
                ? "Подстрока не найдена."
                : $"Позиция начала: {string.Join(", ", positions)}");
        }
    }

    public static void Task9()
    {
        static string ToBinaryString(int number)
        {
            if (number < 0)
            {
                throw new InvalidDataException("Число N должно быть неотрицательным.");
            }

            if (number == 0)
            {
                return "0";
            }

            string result = "";
            while (number > 0)
            {
                result = number % 2 + result;
                number /= 2;
            }

            return result;
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Введите N: ");
            int number = Helper.TryParseStringToInt(Console.ReadLine(), true);
            Console.WriteLine($"{number} в двоичной системе: {ToBinaryString(number)}");
        }
    }
}