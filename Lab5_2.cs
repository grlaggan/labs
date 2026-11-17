namespace education_sharp;

class Cockroach
{
    public string Name { get; init; }
    public string Color { get; init; }
    public int MaxSpeed { get; private set; }
    public int Stamina { get; private set; }

    private int TrainCount = 0;

    public Cockroach(string name, string color, int maxSpeed, int stamina)
    {
        Name = name;
        Color = color;
        MaxSpeed = maxSpeed;
        Stamina = stamina;
    }

    public int Move()
    {
        var random = new Random();
        int v = random.Next(0, MaxSpeed + 1);
        Console.WriteLine($"Таракан двигается со скоростью: {v}");
        return v;
    }

    public bool Train()
    {
        if (TrainCount >= 3)
        {
            Console.WriteLine($"Таракан {Name} больше не может тренироваться");
            return false;
        }

        var random = new Random();

        int speedOrStamina = random.Next(0, 2);
        switch (speedOrStamina)
        {
            case 0:
                MaxSpeed += Convert.ToInt32(MaxSpeed * 0.2);
                Console.WriteLine($"Таракан {Name} увеличил скорость до {MaxSpeed}");
                break;
            case 1:
                Stamina += Convert.ToInt32(Stamina * 0.2);
                Console.WriteLine($"Таракан {Name} увеличил выносливость до {Stamina}");
                break;
        }
        TrainCount++;
        bool willDie = random.Next(0, 4) == 0;
        return willDie;
    }
}

class Totalizer
{
    public int Count { get; private set; } = 1000;

    public void Start(int bet, int cockroachIndex, List<Cockroach> cockroaches)
    {
        if (bet > Count)
        {
            Console.WriteLine("Недостаточно средств для ставки");
            return;
        }

        Count -= bet;
        var raceResults = cockroaches
            .Select(cockroach => new
            {
                Cockroach = cockroach,
                Score = cockroach.Move() + cockroach.Stamina
            })
            .OrderByDescending(result => result.Score)
            .ToList();

        int winnerIndex = cockroaches.IndexOf(raceResults[0].Cockroach);
        Console.WriteLine($"Победил таракан: {cockroaches[winnerIndex].Name}");
        Console.WriteLine($"Результат победителя: {raceResults[0].Score} очков (скорость + выносливость)");

        if (winnerIndex == cockroachIndex)
        {
            int winnings = bet * cockroaches.Count;
            Count += winnings;
            Console.WriteLine($"Вы выиграли {winnings}");
        }
        else
        {
            Console.WriteLine("Вы проиграли");
        }
    }
}

static class Lab5_2
{
    private static string MENU = "Меню:\n1. Добавить таракана\n2. Удалить таракана\n3. Показать всех тараканов\n4. Тренировать таракана\n5. Сделать ставку и запустить игру\n6. Посмотреть состояние счета\n7. Выйти из программы";

    public static void Start()
    {
        var totalizer = new Totalizer();

        var list = new List<Cockroach> { };
        while (true)
        {
            Console.WriteLine(MENU);
            int input = Helper.TryParseStringToInt(Console.ReadLine(), false);

            switch (input)
            {
                case 1:
                    Console.WriteLine("Введите имя, цвет, максимальную скорость и выносливость таракана через Enter");
                    string name = Console.ReadLine() ?? throw new InvalidDataException("Имя не может быть пустым");
                    string color = Console.ReadLine() ?? throw new InvalidDataException("Цвет не может быть пустым");
                    int maxSpeed = Helper.TryParseStringToInt(Console.ReadLine(), false);
                    int stamina = Helper.TryParseStringToInt(Console.ReadLine(), false);
                    var cockroach = new Cockroach(name, color, maxSpeed, stamina);
                    list.Add(cockroach);
                    Console.WriteLine($"Таракан {name} добавлен");
                    break;
                case 2:
                    foreach (var c in list)
                    {
                        Console.WriteLine($"Имя: {c.Name}");
                    }
                    Console.WriteLine("Введите имя таракана, которого хотите удалить");
                    string nameToDelete = Console.ReadLine() ?? throw new InvalidDataException("Имя не может быть пустым");
                    list = list.Where(c => c.Name != nameToDelete).ToList();
                    Console.WriteLine($"Таракан {nameToDelete} удален");
                    break;
                case 3:
                    foreach (var c in list)
                    {
                        Console.WriteLine($"Имя: {c.Name}, Цвет: {c.Color}, Максимальная скорость: {c.MaxSpeed}, Выносливость: {c.Stamina}");
                    }
                    break;
                case 4:
                    foreach (var c in list)
                    {
                        Console.WriteLine($"Имя: {c.Name}");
                    }
                    Console.WriteLine("Введите имя таракана, которого хотите тренировать");
                    string nameToTrain = Console.ReadLine() ?? throw new InvalidDataException("Имя не может быть пустым");
                    var cockroachToTrain = list.FirstOrDefault(c => c.Name == nameToTrain);
                    if (cockroachToTrain == null) throw new InvalidDataException($"Таракан с именем {nameToTrain} не найден");
                    bool willDie = cockroachToTrain.Train();
                    if (willDie)
                    {
                        list.Remove(cockroachToTrain);
                        Console.WriteLine($"Таракан {nameToTrain} умер во время тренировки");
                        break;
                    }
                   
                    break;
                case 5:
                    Console.Write("Введите ставку: ");
                    int bet = Helper.TryParseStringToInt(Console.ReadLine(), false);
                    Console.Write("Введите имя таракана, на которого хотите сделать ставку: ");
                    string nameToBet = Console.ReadLine() ?? throw new InvalidDataException("Имя не может быть пустым");
                    var cockroachToBet = list.FirstOrDefault(c => c.Name == nameToBet) ?? throw new InvalidDataException($"Таракан с именем {nameToBet} не найден");
                    totalizer.Start(bet, list.IndexOf(cockroachToBet), list);
                    break;
                case 6:
                    Console.WriteLine($"Состояние счета: {totalizer.Count}");
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}