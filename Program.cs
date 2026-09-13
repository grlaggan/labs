using System;

namespace education_sharp;

public static class Program
{
    public interface ISome
    {
        void Hi()
        {
            Console.WriteLine("Hi");
        }
    }

    class Some : ISome
    {
        public void Hi()
        {
            Console.WriteLine("Hello");
        }
    }
    
    public static void Main(string[] args)
    {
        // Lab.Task1();
        // Console.WriteLine();
        //
        // Console.WriteLine($"Задание 2: {Lab.Task2()}");
        // Console.WriteLine();
        //
        // Lab.Task3();
        // Console.WriteLine();
        //
        // Console.WriteLine($"Задание 4: {Lab.Task4()}");
        // Console.WriteLine();
        //
        // Console.WriteLine($"Задание 5: {Lab.Task5()}");
        // Console.WriteLine();
        //
        // Console.WriteLine($"Задание 6: {Lab.Task6()}");

        try
        {
            ExecuteLab2();
        }
        catch
        {
            return;
        }
    }
    
    private static void ExecuteLab2()
    {
        Lab2.Task1();
        Lab2.Task2();
        Lab2.Task3();
        Lab2.Task4();
        Lab2.Task5();
    }
}