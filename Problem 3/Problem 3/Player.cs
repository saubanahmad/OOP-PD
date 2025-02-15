using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class Player
    {
        public float hp;
        public float maxHp;
        public int energy;
        public int maxEnergy;
        public float armor;
        public string name;
        public Stats skillStats;

        public Player(string name, float hp, float maxHp, int energy, int maxEnergy, float armor)
        {
            this.name = name;
            this.hp = hp;
            this.maxHp = maxHp;
            this.energy = energy;
            this.maxEnergy = maxEnergy;
            this.armor = armor;
        }

        public void UpdateHealth(float newHealth)
        {
            if (newHealth < 0)
                newHealth = 0;
            if (newHealth > maxHp)
                newHealth = maxHp;
            hp = newHealth;
        }

        public void UpdateEnergy(int newEnergy)
        {
            if (newEnergy < 0)
                newEnergy = 0;
            if (newEnergy > maxEnergy)
                newEnergy = maxEnergy;
            energy = newEnergy;
        }

        public void LearnSkill(Stats newSkill)
        {
            skillStats = newSkill;
        }

        public string Attack(Player target)
        {
            if (skillStats == null)
            {
                return name + " has not learned any skill!";
            }

            if (energy < skillStats.Cost)
            {
                return name + " attempted to use " + skillStats.Name + ", but didn't have enough energy!";
            }

            energy -= skillStats.Cost;

            float effectiveArmor = target.armor - skillStats.Penetration;
            if (effectiveArmor < 0)
                effectiveArmor = 0;
            if (effectiveArmor > 100)
                effectiveArmor = 100;

            float damageDealt = skillStats.Damage * ((100 - effectiveArmor) / 100);
            float targetNewHp = target.hp - damageDealt;
            if (targetNewHp < 0)
                targetNewHp = 0;
            target.hp = targetNewHp;

            string result = name + " used skill " + skillStats.Name + ", " + skillStats.Description +
                            ", against " + target.name + ", doing " + damageDealt.ToString("F2") + " damage!";

            if (skillStats.Heal != 0)
            {
                float healedHealth = hp + skillStats.Heal;
                if (healedHealth > maxHp)
                    healedHealth = maxHp;
                hp = healedHealth;
                result += " " + name + " healed for " + skillStats.Heal + " health!";
            }

            if (target.hp <= 0)
            {
                result += " " + target.name + " died.";
            }
            else
            {
                float targetHpPercent = (target.hp / target.maxHp) * 100;
                result += " " + target.name + " is at " + targetHpPercent.ToString("F2") + "% health.";
            }

            return result;
        }

        public string GetInfo()
        {
            string learnedSkill = (skillStats != null) ? skillStats.Name : "None";
            string info = "Name: " + name + "\n" +
                          "HP: " + hp + "/" + maxHp + "\n" +
                          "Energy: " + energy + "/" + maxEnergy + "\n" +
                          "Armor: " + armor + "\n" +
                          "Learned Skill: " + learnedSkill + "\n";
            return info;
        }
    }

}
