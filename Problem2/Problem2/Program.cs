using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player bob = new Player("Bob", 100, 60, 20);

            Stats fireball = new Stats("fireball", 23, 1.2f, 5, 15, "a fiery magical attack");
            alice.LearnSkill(fireball);

            Console.WriteLine(alice.Attack(bob));

            Stats superbeam = new Stats("superbeam", 200, 50, 50, 75, "an overpowered attack, pls nerf");
            bob.LearnSkill(superbeam);

            Console.WriteLine(bob.Attack(alice));
        }
    }
}
