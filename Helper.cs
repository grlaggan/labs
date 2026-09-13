namespace education_sharp;

public static class Helper
{
    public static bool IsTriangle(double[] values)
    {
        return values[0] < values[1] + values[2] && values[1] < values[0] + values[2] && values[2] < values[1] + values[0];
    }

    public static double[] ReadSides()
    {
        double[] values = new double[3];
        
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Введите {i + 1} сторону треугольника: ");
            string? side = Console.ReadLine();
            double parsedSide = TryParseStringToDouble(side);
            values[i] = parsedSide;
        }

        return values;
    }

    public static int TryParseStringToInt(string? value)
    {
        if (value is null)
        {
            throw new InvalidDataException("n is null");
        }

        if (!int.TryParse(value, out var validatedValue))
        {
            throw new InvalidDataException("n is not an integer");
        }

        return validatedValue > 0 ? validatedValue : throw new InvalidDataException("n must be greater than 0");
    }
    
    public static double TryParseStringToDouble(string? value)
    {
        if (value is null)
        {
            throw new InvalidDataException("n is null");
        }

        if (!double.TryParse(value, out var validatedValue))
        {
            throw new InvalidDataException("n is not an integer");
        }

        return validatedValue > 0 ? validatedValue : throw new InvalidDataException("n must be greater than 0");
    }
}