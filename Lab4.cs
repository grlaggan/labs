namespace education_sharp;

static class Lab4
{
    public static void Task1()
    {
        Console.Write("Введите количество элементов: ");
        int lenghtList = Helper.TryParseStringToInt(Console.ReadLine(), false);
        List<double> list = Helper.ReadArray(lenghtList);

        PrintLenghtAndMultiplyingMaxAndMinElements(list);

        double Multiply(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }

        void PrintLenghtAndMultiplyingMaxAndMinElements(List<double> values)
        {
            double maxValue = values.Max();
            double minValue = values.Min();

            double multipliedValues = Multiply(maxValue, minValue);

            Console.WriteLine($"Длина коллекции: {values.Count}. Произведение максимального и минимального элементов: {multipliedValues}");
        }
    }

    public static void Task2()
    {
        var hashMap = new Dictionary<string, int>
        {
            {"Маша", 10000},
            {"Петя", 30000},
            {"Вася", 100000},
        };

        Console.Write("Введите имя: ");
        string? userName = Console.ReadLine();

        Console.Write("Введите сумму: ");
        int sum = Helper.TryParseStringToInt(Console.ReadLine(), false);

        if (string.IsNullOrEmpty(userName))
        {
            throw new InvalidDataException("Имя пользователя не может быть пустым.");
        }

        if (!hashMap.ContainsKey(userName))
        {
            hashMap.Add(userName, sum);
            Console.WriteLine($"Благодарим, что вы стали клиентом нашего банка! {userName}, Ваш баланс счета изменен! Текущий баланс {sum} рублей.");
        }
        else
        {
            hashMap[userName] = hashMap.GetValueOrDefault(userName) + sum;
            Console.WriteLine($"{userName}, Ваш баланс счета изменен! Текущий баланс {hashMap[userName]} рублей.");
        }

        Console.WriteLine($"Вы можете воспользоваться стандартным вкладом нашего банка! Вложив сумма остатка {hashMap[userName]} на 3 года под 17% годовых Вы получите прибыль {CountBenefit(hashMap[userName])}. Для активации вклада войдите в мобильное приложение!");

    }

    public static void Task3()
    {
        Console.Write("Введите предложение: ");
        string? v = Console.ReadLine() ?? throw new InvalidDataException("Предложение не может быть пустым!");

        var listWords = v.Split(" ");

        string maxWord = "";
        foreach (var word in listWords)
        {
            if (maxWord.Length < word.Length)
            {
                maxWord = word;
            }
        }

        Console.WriteLine(maxWord);
    }

    public static bool Task4()
    {
        bool isLowercase = false;
        bool isUppercase = false;
        bool isNumber = false;
        bool isSpecialChar = false;

        Console.Write("Введите пароль: ");
        string? password = Console.ReadLine() ?? throw new InvalidDataException("Пароль не может быть пустым!");

        foreach (char ch in password)
        {
            if (char.IsLower(ch))
            {
                isLowercase = true;
            }

            if (char.IsUpper(ch))
            {
                isUppercase = true;
            }

            if (char.IsNumber(ch))
            {
                isNumber = true;
            }

            if (char.IsPunctuation(ch) || char.IsSymbol(ch))
            {
                isSpecialChar = true;
            }
        }

        return password.Length >= 6 && password.Length <= 12 && isLowercase && isUppercase && isNumber && isSpecialChar;
    }

    private static double CountBenefit(int sum)
    {
        double newSum = sum;

        for (int i = 0; i < 3; i++)
        {
            newSum += newSum * 0.17;
        }

        return Math.Round(newSum - sum, 2);
    }
}