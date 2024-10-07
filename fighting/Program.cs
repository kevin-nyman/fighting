using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program {
    static void Main() {
        Random random = new();
        Entity entity_1 = new Entity("john", 150, 50);
        Entity entity_2 = new Entity("pork", 100, 100);
        entity_1.Attack(entity_2);
        Console.ReadLine();

    }
}

class Entity {
    string name;
    int hp;
    int dmg;

    public Entity(string name, int hp, int dmg) {
        this.name = name;
        this.hp = hp;
        this.dmg = dmg;
    }

    public void Attack(Entity opponent) {
        Console.WriteLine($"{name} attacks {opponent.name} with {opponent.hp} hp for {dmg}");
        opponent.hp -= dmg;
        Console.WriteLine($"{opponent.name} now has {opponent.hp} hp");
    }
}

public static class Terminal {
    public static int index = 0;
    public static bool updater = false;
    public static int rows = Console.WindowHeight;
    public static int cols = Console.WindowWidth;

    public static void Menu() {

    }

}