using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    internal class Stats
    {
        public string Name;
        public float Damage;
        public float Penetration;
        public int Heal;
        public int Cost;
        public string Description;

        public Stats(string name, float damage, float penetration, int heal, int cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
