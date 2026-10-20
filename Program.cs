using System;
using System.Security.Cryptography;
using System.Text;

namespace education_sharp;

public static class Program
{

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
            ExecuteLab4();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
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

    private static void ExecuteLab3()
    {
        Lab3.Task1();
        Lab3.Task2();
        Lab3.Task3();
        Lab3.Task4();
        Lab3.Task5();
        Lab3.Task6();
    }

    private static void ExecuteLab3_2()
    {
        Lab3_2.Task1();
        Lab3_2.Task2();
        Lab3_2.Task3();
        Lab3_2.Task4();
        Lab3_2.Task5();
        Lab3_2.Task6();
        Lab3_2.Task7();
        Lab3_2.Task8();
        Lab3_2.Task9();
    }

    private static void ExecuteLab4()
    {
        Lab4.Task1();
        Lab4.Task2();
        Lab4.Task3();
        Console.WriteLine(Lab4.Task4());
    }
}