using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
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

        public Player(string name, float health, int energy, float armor)
        {
            this.name = name;
            hp = health;
            maxHp = health;
            this.energy = energy;
            maxEnergy = energy;
            this.armor = armor;
        }

        public void UpdateHealth(float newHealth)
        {
            if (newHealth < 0)
            {
                newHealth = 0;
            }
            if (newHealth > maxHp)
            {
                newHealth = maxHp;
            }
            hp = newHealth;
        }
        public void UpdateEnergy(int newEnergy)
        {
            if (newEnergy < 0)
            {
                newEnergy = 0;
            }
            if (newEnergy > maxEnergy)
            {
                newEnergy = maxEnergy;
            }
            energy = newEnergy;
        }

        public void UpdateArmor(float newArmor)
        {
            if (newArmor < 0)
            {
                newArmor = 0;
            }
            armor = newArmor;
        }

        public void UpdateName(string newName)
        {
            name = newName;
        }

        public void LearnSkill(Stats newSkill)
        {
            skillStats = newSkill;
        }

        public string Attack(Player target)
        {
            if (skillStats == null)
            {
                return $"{name} has not learned any skill yet!";
            }

           

            float effectiveArmor = target.armor - skillStats.Penetration;
            if (effectiveArmor < 0)
            {
                effectiveArmor = 0;
            }
            if (effectiveArmor > 100)
            {
                effectiveArmor = 100;
            }

            if (energy < skillStats.Cost)
            {
                return $"{name} attempted to use {skillStats.Name}, but didn't have enough energy!";
            }
            energy -= skillStats.Cost;

            float damageDone = skillStats.Damage * ((100 - effectiveArmor) / 100);

            float newTargetHp = target.hp - damageDone;
            if (newTargetHp < 0)
            {
                newTargetHp = 0;
            }
            target.hp = newTargetHp;

            string result = $"{name} used skill {skillStats.Name}, {skillStats.Description}, against {target.name}, doing {damageDone:F2} damage!";

            if (skillStats.Heal != 0)
            {
                float newHp = hp + skillStats.Heal;
                if (newHp > maxHp)
                {
                    newHp = maxHp;
                }
                hp = newHp;
                result += $" {name} healed for {skillStats.Heal} health!";
            }

            if (target.hp <= 0)
            {
                result += $" {target.name} died.";
            }
            else
            {
                float targetHpPercent = (target.hp / target.maxHp) * 100;
                result += $" {target.name} is at {targetHpPercent:F2}% health.";
            }

            return result;
        }
    }
}

