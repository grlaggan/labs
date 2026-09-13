using System;
using System.IO;
using System.Linq;

namespace education_sharp;

public class Lab
{
    public static void Task1()
    {
        Console.Write("Как вас зовут? ");
        string? name = Console.ReadLine();
        
        Console.Write("Какой язык программирования вы изучали ранее? ");
        string? programmingLang = Console.ReadLine();

        if (name is null || programmingLang is null)
        {
            throw new InvalidDataException("values is invalid");
        }
        
        Console.WriteLine($"Я {name}, я уже знаю {programmingLang}");
    }
    
    public static int Task2()
    {
        Console.Write("X: ");
        string? x = Console.ReadLine();
        
        Console.Write("Y: ");
        string? y = Console.ReadLine();
        
        if (!double.TryParse(x, out var convertedX) || !double.TryParse(y, out var convertedY))
        {
            throw new InvalidDataException("values is invalid");
        }

        if (!IsValidTask3(convertedY))
        {
            throw new InvalidDataException("y is invalid");
        }
        
        return Convert.ToInt32(System.Math.Atan2(convertedX, convertedY) * (180 / System.Math.PI));                                                          
    }

    public static void Task3()
    {
        try
        {
            int road = 163;

            Console.Write("Введите скорость: ");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("введите время: ");
            int time = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Через {time} часов он остановится на отметке {Convert.ToDouble(time * speed) / road:F2}");
            Console.WriteLine($"Полных кругов: {speed * time / road}");
        }
        catch (FormatException)
        {
            throw new InvalidDataException("values is invalid");
        }
    }

    public static int Task4()
    {
        try
        {
            int[] values = new int[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Введите {i}-е число: ");    
                values[i] = Convert.ToInt32(Console.ReadLine());
            }
        
            var random = new Random();
            return random.Next(values.Min(), values.Max() + 1);
        }
        catch (FormatException)
        {
            throw new InvalidDataException("values is invalid");
        }
    }

    public static double Task5()
    {
        int[] values = new int[4];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Введите {i + 1} значение: ");
            values[i] = Convert.ToInt32(Console.ReadLine());
        }

        if (!IsValidTask5(values))
        {
            throw new InvalidDataException("values is invalid");
        }
        
        return (Convert.ToDouble(values[0]) / values[2]) * (Convert.ToDouble(values[1]) / values[3]) - (Convert.ToDouble(values[0]) * values[1] - values[2]) / (Convert.ToDouble(values[2]) * values[3]) + System.Math.Sqrt(values[3]); 
    }

    public static double Task6()
    {
        double[] values = Helper.ReadSides();

        if (!Helper.IsTriangle(values))
        {
            throw new InvalidDataException("sides is invalid");
        }
        
        var p = values.Sum() / 2.0;

        return System.Math.Sqrt(p * (p - values[0]) * (p - values[1]) * (p - values[2]));
    }

    private static bool IsValidTask5(int[] values)
    {
        return values[2] != 0 && values[3] > 0;
    }

    private static bool IsValidTask3(double y)
    {
        return y != 0;
    }
}