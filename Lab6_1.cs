using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace education_sharp;
public class Lab6_1
{

}

abstract class Employee
{
    protected Employee(string name, DateTime dateOfEmployment, double salary)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsNumber))
        {
            throw new InvalidDataException("Невалидное имя");
        }

        if (DateTime.UtcNow < dateOfEmployment)
        {
            throw new InvalidDataException("Невалидное время");
        }

        if (salary < 0)
        {
            throw new InvalidDataException("Зарплата не может быть меньше 0");
        }
        
        Name = name;
        DateOfEmployment = dateOfEmployment;
        Salary = salary;
    }
    
    public string Name { get; set; }
    public DateTime DateOfEmployment { get; set; }
    public double Salary { get; set; }

    public string Say()
    {
        return Name;
    }

    public virtual double WorkTime()
    {
        return 0;
    }

    public abstract string WhatYouDo();
}

class Cashier : Employee
{
    private const string WhatDo = "Пополняю транспортные карты";

    public Cashier(string name, DateTime dateOfEmployment, double salary) : base(name, dateOfEmployment, salary)
    {
    }

    public override double WorkTime()
    {
        return (DateTime.UtcNow - DateOfEmployment).Days;
    }

    public override string WhatYouDo()
    {
        return WhatDo;
    }
}

class Operator : Employee
{
    private const string WhatDo = "Ищу посылку";

    public Operator(string name, DateTime dateOfEmployment, double salary) : base(name, dateOfEmployment, salary)
    {
    }

    public override double WorkTime()
    {
        var now = DateTime.UtcNow;
        return (now.Year - DateOfEmployment.Year) * 12 + now.Month - DateOfEmployment.Month;
    }

    public override string WhatYouDo()
    {
        return WhatDo;
    }
}

class Postman : Employee
{
    private const string WhatDo = "Разношу почту, не мешайте";

    public Postman(string name, DateTime dateOfEmployment, double salary) : base(name, dateOfEmployment, salary)
    {
    }

    public override double WorkTime()
    {
        DateTime now = DateTime.Today;                  

        int age = now.Year - DateOfEmployment.Year;

        // Если день рождения в этом году еще не наступал, уменьшаем возраст на 1
        if (DateOfEmployment.Date > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    public override string WhatYouDo()
    {
        return WhatDo;
    }
}

class PostOffice
{
    public List<Employee> Employees { get; private set; }

    public PostOffice(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            throw new InvalidDataException("Количество работников не может равнятся 0");
        }
        
        Employees = employees;
    }
    
    public void Pool()
    {
        Console.WriteLine("А вас как зовут?");
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee.Say());
        }

        Console.WriteLine("А что вы делаете?");
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee.WhatYouDo());
        }

        Console.WriteLine("И давно вы тут работаете?");
        foreach (var employee in Employees)
        {
            switch (employee)
            {
                case Cashier cashier:
                    Console.WriteLine($"{cashier.WorkTime()} дней");
                    break;
                case Operator operatorEmployee:
                    Console.WriteLine($"{operatorEmployee.WorkTime()} месяцев");
                    break;
                case Postman postman:
                    Console.WriteLine($"{postman.WorkTime()} лет");
                    break;
                default:
                    Console.WriteLine("Неизвестный тип работника");
                    break;
            }
        }

        Console.WriteLine("Сколько вы получаете?");
        foreach (var employee in Employees)
        {
            Console.WriteLine($"{employee.Salary} рублей");
        }
    }
    
    public void Stat()
    {
        List<double> cashierSalaries = Employees
            .Where(e => e.GetType() == typeof(Cashier))
            .Select(e => e.Salary).ToList();
        List<double> operatorSalaries = Employees
            .Where(e => e.GetType() == typeof(Operator))
            .Select(e => e.Salary).ToList();
        List<double> postmanSalaries = Employees
            .Where(e => e.GetType() == typeof(Postman))
            .Select(e => e.Salary).ToList();

        Console.WriteLine($"Средняя зарплата кассиров: {cashierSalaries.Average()}");
        Console.WriteLine($"Средняя зарплата операторов: {operatorSalaries.Average()}");
        Console.WriteLine($"Средняя зарплата почтальонов: {postmanSalaries.Average()}");
    }
}

