using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Player : Mechanics
    {
        public int countHealing = 2;
        public Player(int attack, int protection, int health, int damageMin, int damageMax)
        {
            Attack = attack;
            Protection = protection;
            HealthMax = health;
            Health = health;
            DamageMin = damageMin;
            DamageMax = damageMax;
        }
        public void healing()
        {
            if (countHealing != 0 && Health < HealthMax)
            {
                Health += HealthMax / 2;
                countHealing--;
            }
        }
    }
}
