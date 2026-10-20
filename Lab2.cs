using System;
using System.Globalization;
using System.IO;

namespace education_sharp;

public static class Lab2
{
    private const int OneYearDeposit = 1;
    private const double OneYearDepositPercent = 0.07;
    private const int ThreeYearDeposit = 2;
    private const double ThreeYearDepositPercent = 0.08;
    private const int FiveYearDeposit = 3;
    private const double FiveYearDepositPercent = 0.1;
    private const int MaxSpeed = 90;

    public static void Task1()
    {
        Console.Write("На каком месте стоит Сережа? ");
        string? n = Console.ReadLine();
        int validatedN = Helper.TryParseStringToInt(n, false);
        Console.WriteLine(validatedN % 2 == 0 ? "Второй" : "Первый");
    }

    public static void Task2()
    {
        double[] sides = Helper.ReadSides();
        if (!Helper.IsTriangle(sides))
        {
            Console.WriteLine("sides is invalid");
            return;
        }

        sides.Sort();
        if (!IsRightAngledTriangle(sides))
        {
            Console.WriteLine("Не является прямоугольным");
            Console.WriteLine($"Угол C: {FindCAngle(sides):F2}");
            return;
        }

        Console.WriteLine("Является");
    }

    public static void Task3()
    {
        Console.Write("Номер Сергея в очереди: ");
        string? number = Console.ReadLine();
        int parsedInt = Helper.TryParseStringToInt(number, false);

        TimeSpan startTime = TimeSpan.ParseExact("9:00", @"h\:mm", CultureInfo.InvariantCulture);
        TimeSpan endTime = TimeSpan.ParseExact("17:00", @"h\:mm", CultureInfo.InvariantCulture);

        TimeSpan checkTime = startTime.Add(TimeSpan.FromMinutes(20 * ((parsedInt / 2) - 2)));
        if (checkTime <= endTime.Subtract(TimeSpan.FromMinutes(20)))
        {
            Console.WriteLine($"Очередь Сергея настанет в {checkTime}");
        }
        else
        {
            Console.WriteLine("Сергею лучше пойти домой");
        }

    }

    public static void Task4()
    {
        Console.Write("Выберите вид вклада ");
        string? number = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Введие сумму вклада ");
        string? deposit = Console.ReadLine();
        int parsedNumber = Helper.TryParseStringToInt(number, false);
        double parsedDeposit = Helper.TryParseStringToDouble(deposit, false);

        double countedDeposit = CountDeposit(parsedNumber, ref parsedDeposit);
        Console.WriteLine($"Вклад: {countedDeposit}");
    }

    public static void Task5()
    {
        Console.WriteLine("Введите скорость ");
        string? speed = Console.ReadLine();
        int parsedSpeed = Helper.TryParseStringToInt(speed, false);
        int substraction = parsedSpeed - MaxSpeed;

        switch (substraction)
        {
            case >= 20 when substraction < 40:
                Console.WriteLine("500 рублей штраф");
                break;
            case >= 40 when substraction < 60:
                Console.WriteLine("1500 рублей штраф");
                break;
            case >= 60 when substraction < 80:
                Console.WriteLine("2500 рублей штраф");
                break;
            case >= 80:
                Console.WriteLine("5000 или лишение прав на полгода");
                break;
            default:
                Console.WriteLine("Скорость автомобиля допустима на данном участке");
                return;
        }
    }

    private static bool IsRightAngledTriangle(double[] sortedSides)
    {
        return Math.Pow(sortedSides[2], 2) == Math.Pow(sortedSides[0], 2) + Math.Pow(sortedSides[1], 2);
    }

    private static double FindCAngle(double[] sides)
    {
        double cos = (sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) / (2 * sides[0] * sides[1]);
        return Math.Acos(cos) * 180.0 / Math.PI;
    }

    private static double CountDeposit(int typeDeposit, ref double deposit)
    {
        switch (typeDeposit)
        {
            case OneYearDeposit:
                return deposit + OneYearDepositPercent * deposit;
            case ThreeYearDeposit:
                for (int i = 0; i < 3; i++)
                {
                    deposit += ThreeYearDepositPercent * deposit;
                }

                return deposit;
            case FiveYearDeposit:
                for (int i = 0; i < 5; i++)
                {
                    deposit += FiveYearDepositPercent * deposit;
                }

                return deposit;
            default:
                throw new InvalidDataException("Type of deposit is invalid");
        }
    }
}