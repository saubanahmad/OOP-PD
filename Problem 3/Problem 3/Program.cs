using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class Program
    {
        static List<Player> players = new List<Player>();
        static List<Stats> skills = new List<Stats>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== Magical Duel Menu =====");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. Display Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        AddSkill();
                        break;
                    case "3":
                        DisplayPlayersInfo();
                        break;
                    case "4":
                        LearnSkill();
                        break;
                    case "5":
                        PerformAttack();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddPlayer()
        {
            Console.WriteLine("Add Player:");
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter current health: ");
            float health = float.Parse(Console.ReadLine());

            Console.Write("Enter maximum health: ");
            float maxHealth = float.Parse(Console.ReadLine());

            Console.Write("Enter current energy: ");
            int energy = int.Parse(Console.ReadLine());

            Console.Write("Enter maximum energy: ");
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.Write("Enter armor value: ");
            float armor = float.Parse(Console.ReadLine());

            Player newPlayer = new Player(name, health, maxHealth, energy, maxEnergy, armor);
            players.Add(newPlayer);
            Console.WriteLine("Player added successfully!");
        }

        static void AddSkill()
        {
            Console.WriteLine("Add Skill Statistics:");
            Console.Write("Enter skill name: ");
            string name = Console.ReadLine();

            Console.Write("Enter damage: ");
            float damage = float.Parse(Console.ReadLine());

            Console.Write("Enter penetration: ");
            float penetration = float.Parse(Console.ReadLine());

            Console.Write("Enter heal value: ");
            int heal = int.Parse(Console.ReadLine());

            Console.Write("Enter cost: ");
            int cost = int.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Stats newSkill = new Stats(name, damage, penetration, heal, cost, description);
            skills.Add(newSkill);
            Console.WriteLine("Skill added successfully!");
        }

        static void DisplayPlayersInfo()
        {
            Console.WriteLine("Player Information:");
            if (players.Count == 0)
            {
                Console.WriteLine("No players have been added yet.");
            }
            else
            {
                foreach (Player p in players)
                {
                    Console.WriteLine(p.GetInfo());
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void LearnSkill()
        {
            Console.Write("Enter the player's name: ");
            string playerName = Console.ReadLine();
            Player player = players.Find(p => p.name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (player == null)
            {
                Console.WriteLine("Player not found.");
                return;
            }

            Console.Write("Enter the skill name: ");
            string skillName = Console.ReadLine();
            Stats skill = skills.Find(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
            if (skill == null)
            {
                Console.WriteLine("Skill not found.");
                return;
            }

            player.LearnSkill(skill);
            Console.WriteLine(player.name + " has learned the skill " + skill.Name + ".");
        }

        static void PerformAttack()
        {
            if (players.Count < 2)
            {
                Console.WriteLine("At least two players are required for an attack.");
                return;
            }

            Console.WriteLine("Select the attacker:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + players[i].name);
            }
            Console.Write("Enter the number for the attacker: ");
            int attackerIndex = int.Parse(Console.ReadLine()) - 1;
            if (attackerIndex < 0 || attackerIndex >= players.Count)
            {
                Console.WriteLine("Invalid attacker selection.");
                return;
            }
            Player attacker = players[attackerIndex];

            Console.WriteLine("Select the target:");
            for (int i = 0; i < players.Count; i++)
            {
                if (i == attackerIndex)
                    continue;
                Console.WriteLine((i + 1) + ". " + players[i].name);
            }
            Console.Write("Enter the number for the target: ");
            int targetIndex = int.Parse(Console.ReadLine()) - 1;
            if (targetIndex < 0 || targetIndex >= players.Count || targetIndex == attackerIndex)
            {
                Console.WriteLine("Invalid target selection.");
                return;
            }
            Player target = players[targetIndex];

            string result = attacker.Attack(target);
            Console.WriteLine(result);
        }
    }
}