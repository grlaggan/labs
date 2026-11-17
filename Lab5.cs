namespace education_sharp;

class Cat
{
    public string Name { get; init; }
    public int Age { get; init; }
    public int Health { get; private set; }
    public int Mood { get; private set; }
    public string Color
    {
        get
        {
            if (Health <= 0)
            {
                return "White";
            }

            return "Green";
        }
    }

    public Cat(string name, int age)
    {
        Name = name;
        Age = age;
        Health = 100;
        Mood = 100;
    }

    public void Feed(int foodAmount)
    {
        Health += foodAmount;
        Mood += foodAmount / 2;
        if (Mood > 100)
            Mood = 100;

        CheckState();
    }

    public void Punish(int punishmentAmount)
    {
        Health -= punishmentAmount;
        if (Health < 0)
            Health = 0;
        Mood -= punishmentAmount * 2;

        CheckState();
    }

    public void Play(int moodCount)
    {
        Mood += moodCount;
        if (Mood > 100)
            Mood = 100;

        CheckState();
    }

    private void CheckState()
    {
        if (Mood > 50)
            Console.WriteLine($"{Name} мурлычет");
        if (Mood < 0)
            Console.WriteLine($"{Name} гадит в тапки");
    }
}