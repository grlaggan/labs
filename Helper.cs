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
            double parsedSide = TryParseStringToDouble(side, false);
            if (parsedSide == 0)
            {
                throw new InvalidDataException("side cannot equals zero");
            }
            values[i] = parsedSide;
        }

        return values;
    }

    public static List<double> ReadArray(int countElements)
    {
        List<double> values = [];

        for (int i = 0; i < countElements; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            values.Add(TryParseStringToDouble(Console.ReadLine(), true));
        }

        return values;
    }

    public static int TryParseStringToInt(string? value, bool isMinus)
    {
        if (value is null)
        {
            throw new InvalidDataException("value is null");
        }

        if (!int.TryParse(value, out var validatedValue))
        {
            throw new InvalidDataException("value is not an integer");
        }

        if (isMinus)
        {
            return validatedValue;
        }
        return validatedValue >= 0 ? validatedValue : throw new InvalidDataException("value must be greater than 0");
    }

    public static double TryParseStringToDouble(string? value, bool isMinus)
    {
        if (value is null)
        {
            throw new InvalidDataException("value is null");
        }

        if (!double.TryParse(value, out var validatedValue))
        {
            throw new InvalidDataException("value is not a double");
        }

        if (isMinus)
        {
            return validatedValue;
        }
        return validatedValue >= 0 ? validatedValue : throw new InvalidDataException("value must be greater than 0");
    }
}