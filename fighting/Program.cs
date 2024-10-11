using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program {
    static void Main() {
        Console.WriteLine("name your character");
        string you = Console.ReadLine();
        
        Console.Clear();
        Console.WriteLine("name your opponent");
        string other = Console.ReadLine();

        EntityManager.AddCharacter(you, 150, 15);
        EntityManager.AddCharacter(other, 150, 15);

        List<Entity> characters = EntityManager.GetCharacters();

        while (characters[0].hp > 0 && characters[1].hp > 0)
        {
            Console.CursorVisible = false;
            Console.Clear();
            EntityManager.DisplayInfo();

            characters[0].Attack(characters[1]);

            characters[1].Attack(characters[0]); 

            Console.Write("\x1b[47m\x1b[30m");
            Console.Write("press enter to continue...");
            Console.WriteLine("\x1b[0m");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) {}
        }
        Console.Clear();
        if (characters[0].hp > characters[1].hp){
            Console.WriteLine($"{characters[0].name} won");
        }
        else if (characters[0].hp == characters[1].hp) 
        {
            Console.WriteLine("wat");
        }
        else {
            Console.WriteLine($"{characters[1].name} won");
        }
        Console.ReadLine();

    }
}

public class Entity {
    public string name;
    public int hp;
    public int dmg;

    public Entity(string name, int hp, int dmg) {
        this.name = name;
        this.hp = hp;
        this.dmg = dmg;
    }

    public void Attack(Entity opponent) {
        Random random = new Random();
        int damage = dmg + random.Next(-(int)(dmg * 0.15), (int)(dmg*0.15)+ 1);
        bool criticalHit = random.Next(1,21) == 1;

        if (criticalHit) {
            damage *= 2;
            Console.WriteLine($"{name} lands a critical hit");
        }

        opponent.hp = Math.Clamp((opponent.hp - damage), 0, opponent.hp);

        Console.WriteLine($"{name} attacks {opponent.name} hp for {damage}");
        Console.WriteLine($"{opponent.name} now has {opponent.hp} hp\n");
    }
}


public static class EntityManager {
    public static List<Entity> entities = new List<Entity>();
    public static void AddCharacter(string name, int hp, int dmg)
    {
        entities.Add(new Entity(name, hp, dmg));
    }


    public static void DisplayInfo()
    {
        foreach (var entity in entities)
        {
            Console.WriteLine($"{entity.name} has {entity.hp} hp\n");
        }
    }
    public static List<Entity> GetCharacters() {
        return entities;
    }
}
