using System;
using System.IO;
using System.Linq;

namespace education_sharp;

enum Color
{
    Red = 0,
    Green,
    Blue
}

enum Direction
{
    Forward = 0,
    Backward,
    Left,
    Right
}

class Car
{
    private Color _color = Color.Red;
    private double _averageSpeedPerHour = 80;
    private Direction _direction = Direction.Forward;

    public void ChangeDirection(Direction newDirection)
    {
        _direction = newDirection;
    }

    public void Navigator()
    {
        string strDirection = _direction switch
        {
            Direction.Forward => "Прямо",
            Direction.Backward => "Назад",
            Direction.Left => "Налево",
            Direction.Right => "Направо",
            _ => throw new InvalidDataException("Такого направления нет!")
        };
        Console.WriteLine($"Сейчас мы едем {strDirection} со средней скоростью {_averageSpeedPerHour}");
    }

    public void ChangeColor(Color newColor)
    {
        _color = newColor;
    }

    public void UpgradeCar(double newSpeed)
    {
        _averageSpeedPerHour = newSpeed;
    }

    public string GetColor()
    {
        return _color switch
        {
            Color.Red => "Красный",
            Color.Green => "Зеленый",
            Color.Blue => "Синий",
            _ => throw new InvalidDataException("Такого цвета нет!")
        };
    }

    public double ReturnDistance(double time)
    {
        return time * _averageSpeedPerHour;
    }

    public static bool IsValidVin(string vin)
    {
        if (vin.Any(ch => char.IsPunctuation(ch) || char.IsSymbol(ch)))
        {
            return false;
        }

        return vin.Length == 17;
    }

    public static double CalculateFuelConsumption(double distanceKm, double fuelLiters)
    {
        double fuelLiterPerKm = fuelLiters / distanceKm;
        return 100 * fuelLiterPerKm;
    }

    public static string GetEngineClass(double engineVolume)
    {
        return engineVolume switch
        {
            < 1.4 => "Малолитражный",
            >= 1.4 and < 2.0 => "Средний",
            >= 2.0 => "Большой",
            _ => throw new ArgumentException("Некорректный объем двигателя")
        };
    }
}