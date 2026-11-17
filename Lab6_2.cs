using System;
using System.Collections.Generic;
using System.IO;

namespace education_sharp;

public enum Element
{
    Nothing,
    Fire,
    Earth,
    Wood,
    Water,
    Metal
}

public abstract class AbstractWizard
{
    protected AbstractWizard(double damage, double health)
    {
        if (damage <= 0 || health <= 0)
        {
            throw new InvalidDataException("Урон и здоровье не могут быть по умолчанию <= 0!");
        }
        
        Damage = damage;
        Health = health;
    }

    protected double Damage { get; set; }
    protected double Health { get; set; }
    public double CurrentDamage => Damage;
    public double CurrentHealth => Health;
    public abstract Element GetElement();
    protected abstract string AttackMessage();
    public abstract void Train();

    public bool Attack(AbstractWizard enemy)
    {
        return enemy.GetDamage(Damage);
    }

    public string GetAttackMessage() => AttackMessage();

    private bool GetDamage(double damage)
    {
        Health -= damage;
        return Health <= 0;
    }
    public abstract bool UseUltimate(AbstractWizard enemy);
}

public class Wizard : AbstractWizard
{
    public Wizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Nothing;

    protected override string AttackMessage() => "ШАРОВАЯ МОЛНИЯ";

    public override void Train()
    {
        Damage *= 1.2;
        Health *= 1.2;
    }

    public override bool UseUltimate(AbstractWizard enemy)
    {
        return false;
    }
}

public sealed class FireWizard : AbstractWizard
{
    public FireWizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Fire;

    protected override string AttackMessage() => "ФАЕРБОЛ";

    public override void Train()
    {
        Damage *= Math.E;
    }

    public override bool UseUltimate(AbstractWizard enemy)
    {
        return enemy is MetalWizard;
    }
}

public sealed class EarthWizard : AbstractWizard
{
    public EarthWizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Earth;

    protected override string AttackMessage() => "КИРПИЧ";

    public override void Train()
    {
        Damage *= 1.33;
        Health *= 1.33;
    }

    public override bool UseUltimate(AbstractWizard enemy)
    {
        return enemy is WaterWizard;
    }
}

public sealed class MetalWizard : AbstractWizard
{
    public MetalWizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Metal;

    protected override string AttackMessage() => "НАКОВАЛЬНЯ";

    public override void Train()
    {
        Health *= Math.E;
    }

    public override bool UseUltimate(AbstractWizard enemy)
    {
        return enemy is WoodWizard;
    }
}

public sealed class WaterWizard : AbstractWizard
{
    public WaterWizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Water;

    protected override string AttackMessage() => "МОКРЫЙ ДОЖДЬ";

    public override void Train()
    {
        Damage *= 1.2;
        Health *= 1.2;
    }

    public override bool UseUltimate(AbstractWizard enemy)
    {
        return enemy is FireWizard;
    }
}

public sealed class WoodWizard : AbstractWizard
{
    public WoodWizard(double damage, double health) : base(damage, health)
    {
    }

    public override Element GetElement() => Element.Wood;

    protected override string AttackMessage() => "ПЕНЬКИ";

    public override void Train() { }
    public override bool UseUltimate(AbstractWizard enemy)
    {
        return enemy is EarthWizard;
    }
}

public class Arena
{
    public Arena(List<AbstractWizard> alliesWizards, List<AbstractWizard> enemyWizards)
    {
        if (alliesWizards.Count != 2 || enemyWizards.Count != 2)
        {
            throw new InvalidDataException("С каждой стороны должно быть по 2 мага!");
        }
        
        AllieseWizards = alliesWizards;
        EnemyWizards = enemyWizards;
    }

    public List<AbstractWizard> AllieseWizards { get; private set; }
    public List<AbstractWizard> EnemyWizards { get; private set; }

    public void Fight()
    {
        int lastWizardNumber = 4;
        bool isFirstAlliesStep = true;
        bool isFirstEnemyStep = true;

        while (AllieseWizards.Count > 0 && EnemyWizards.Count > 0)
        {
            if (isFirstAlliesStep)
            {
                var allieseWizard = AllieseWizards[0];
                var enemyWizard = EnemyWizards[Math.Min(0, EnemyWizards.Count - 1)];

                bool isKilled = allieseWizard.UseUltimate(enemyWizard);
                isFirstAlliesStep = false;
                PrintSpecialAbility(true, 1, allieseWizard, isKilled);
                if (isKilled)
                {
                    EnemyWizards.RemoveAt(0);
                }
                continue;
            }

            if (isFirstEnemyStep)
            {
                var enemyWizard = EnemyWizards[0];
                var allieseWizard = AllieseWizards[Math.Min(0, AllieseWizards.Count - 1)];

                bool isKilled = enemyWizard.UseUltimate(allieseWizard);
                isFirstEnemyStep = false;
                PrintSpecialAbility(false, 1, enemyWizard, isKilled);
                if (isKilled)
                {
                    AllieseWizards.RemoveAt(0);
                }
                continue;
            }

            int currentWizardNumber = lastWizardNumber % 4 + 1;

            if (currentWizardNumber <= 2)
            {
                int wizardIndex = Math.Min(currentWizardNumber - 1, AllieseWizards.Count - 1);
                int targetIndex = Math.Min(currentWizardNumber - 1, EnemyWizards.Count - 1);
                
                var allieseWizard = AllieseWizards[wizardIndex];
                var enemyWizard = EnemyWizards[targetIndex];
                
                bool isKilled = allieseWizard.Attack(enemyWizard);
                PrintAttack(true, currentWizardNumber, allieseWizard, enemyWizard, isKilled);
                if (isKilled)
                {
                    EnemyWizards.RemoveAt(targetIndex);
                }
            }
            else
            {
                int wizardIndex = Math.Min(currentWizardNumber - 3, EnemyWizards.Count - 1);
                int targetIndex = Math.Min(currentWizardNumber - 3, AllieseWizards.Count - 1);
                var enemyWizard = EnemyWizards[wizardIndex];
                var allieseWizard = AllieseWizards[targetIndex];

                bool isKilled = enemyWizard.Attack(allieseWizard);
                PrintAttack(false, currentWizardNumber, enemyWizard, allieseWizard, isKilled);
                if (isKilled)
                {
                    AllieseWizards.RemoveAt(targetIndex);
                }
            }

            lastWizardNumber = currentWizardNumber;
        }
    }

    private static void PrintSpecialAbility(
        bool isAllies,
        int wizardNumber,
        AbstractWizard wizard,
        bool isKilled)
    {
        string wizardName = GetWizardName(isAllies, wizardNumber, wizard);
        Console.WriteLine($"{wizardName} использует специальную способность!!!");
        if (isKilled)
        {
            Console.WriteLine("И эта способность уничтожает одного из вражеских магов!!!");
        }
        else
        {
            Console.WriteLine("И эта способность не наносит врагу никакого урона!!!");
        }
    }

    private static void PrintAttack(
        bool isAllies,
        int wizardNumber,
        AbstractWizard attacker,
        AbstractWizard target,
        bool isKilled)
    {
        string attackerName = GetWizardName(isAllies, wizardNumber, attacker);
        string targetName = GetWizardName(!isAllies, wizardNumber, target);

        if (isKilled)
        {
            Console.WriteLine(
                $"{attackerName} использует навык {attacker.GetAttackMessage()}!!! " +
                $"и наносит {attacker.CurrentDamage:0.##} урона по {targetName} " +
                "и убивает его!!!");
            return;
        }

        Console.WriteLine(
            $"{attackerName} использует навык {attacker.GetAttackMessage()}!!! " +
            $"и наносит {attacker.CurrentDamage:0.##} урона по {targetName} " +
            $"и оставляет ему {target.CurrentHealth:0.##} HP");
    }

    private static string GetWizardName(
        bool isAllies,
        int wizardNumber,
        AbstractWizard wizard)
    {
        string ordinal = wizardNumber % 2 == 1 ? "первый" : "второй";
        return isAllies
            ? $"Ваш {GetStringElement(wizard.GetElement())} {ordinal} маг"
            : $"Злой грязный {ordinal} маг";
    }

    private static string GetStringElement(Element element)
    {
        return element switch
        {
            Element.Nothing => "обычный",
            Element.Fire => "огненный",
            Element.Earth => "земляной",
            Element.Metal => "металлический",
            Element.Water => "водный",
            Element.Wood => "деревянный",
            _ => throw new InvalidDataException("Элемента не существует!")
        };
    }
}

public sealed class ArenaGame
{
    private const int WizardTypesCount = 6;
    private const int MinDamage = 10;
    private const int MaxDamage = 60;
    private const int MinHealth = 20;
    private const int MaxHealth = 80;

    private readonly Random _random;

    public ArenaGame(Random? random = null)
    {
        _random = random ?? Random.Shared;
    }

    public void Start()
    {
        List<AbstractWizard> enemies = CreateRandomWizards(2);
        Console.WriteLine("Ваши противники:");
        PrintWizards(enemies);

        List<AbstractWizard> allies = new();
        while (allies.Count < 2)
        {
            Console.WriteLine("Выберите мага:");
            PrintWizardTypes();

            int wizardType = ReadWizardType();
            allies.Add(CreateWizard(wizardType));
        }

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Тренировать мага");
            Console.WriteLine("2. Начать бой");

            int action = Helper.TryParseStringToInt(Console.ReadLine(), false);
            if (action == 2)
            {
                break;
            }

            if (action != 1)
            {
                Console.WriteLine("Введите 1 или 2.");
                continue;
            }

            Console.WriteLine("Выберите мага для тренировки:");
            PrintWizards(allies);
            int wizardNumber = Helper.TryParseStringToInt(Console.ReadLine(), false);
            if (wizardNumber < 1 || wizardNumber > allies.Count)
            {
                Console.WriteLine($"Введите число от 1 до {allies.Count}.");
                continue;
            }

            allies[wizardNumber - 1].Train();
            Console.WriteLine("Маг потренирован:");
            PrintWizards(allies);
        }

        Console.WriteLine();
        Console.WriteLine("Ваши бойцы:");
        PrintWizards(allies);
        Console.WriteLine("НАЧНЕТСЯ БОЙ!");
        Console.WriteLine();

        new Arena(allies, enemies).Fight();

        Console.WriteLine();
        Console.WriteLine(allies.Count > 0
            ? "И ВЫ ПОБЕДИЛИ!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
            : "ВЫ ПРОИГРАЛИ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    private List<AbstractWizard> CreateRandomWizards(int count)
    {
        var wizards = new List<AbstractWizard>(count);
        for (int i = 0; i < count; i++)
        {
            wizards.Add(CreateWizard(_random.Next(WizardTypesCount)));
        }

        return wizards;
    }

    private AbstractWizard CreateWizard(int wizardType)
    {
        double damage = _random.Next(MinDamage, MaxDamage + 1);
        double health = _random.Next(MinHealth, MaxHealth + 1);

        return wizardType switch
        {
            0 => new Wizard(damage, health),
            1 => new FireWizard(damage, health),
            2 => new EarthWizard(damage, health),
            3 => new MetalWizard(damage, health),
            4 => new WaterWizard(damage, health),
            5 => new WoodWizard(damage, health),
            _ => throw new InvalidDataException("Неизвестный тип мага.")
        };
    }

    private static void PrintWizardTypes()
    {
        Console.WriteLine("1. Обычный маг");
        Console.WriteLine("2. Огненный маг");
        Console.WriteLine("3. Земляной маг");
        Console.WriteLine("4. Металлический маг");
        Console.WriteLine("5. Водяной маг");
        Console.WriteLine("6. Деревянный маг");
    }

    private static int ReadWizardType()
    {
        while (true)
        {
            int wizardType = Helper.TryParseStringToInt(Console.ReadLine(), false);
            if (wizardType >= 1 && wizardType <= WizardTypesCount)
            {
                return wizardType - 1;
            }

            Console.WriteLine("Введите число от 1 до 6.");
        }
    }

    private static void PrintWizards(List<AbstractWizard> wizards)
    {
        foreach (AbstractWizard wizard in wizards)
        {
            Console.WriteLine(
                $"{GetElementName(wizard.GetElement())} маг: " +
                $"Урон {wizard.CurrentDamage:0.##}; " +
                $"Здоровье {wizard.CurrentHealth:0.##}");
        }
    }

    private static string GetElementName(Element element)
    {
        return element switch
        {
            Element.Nothing => "обычный",
            Element.Fire => "огненный",
            Element.Earth => "земляной",
            Element.Metal => "металлический",
            Element.Water => "водяной",
            Element.Wood => "деревянный",
            _ => throw new InvalidDataException("Элемента не существует.")
        };
    }
}