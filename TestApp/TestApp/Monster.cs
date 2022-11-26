using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Monster : Mechanics
    {
        public Monster(int attack, int protection, int health, int damageMin, int damageMax)
        {
            Attack = attack;
            Protection = protection;
            HealthMax = health;
            Health = health;
            DamageMin = damageMin;
            DamageMax = damageMax;
        }
    }
}
