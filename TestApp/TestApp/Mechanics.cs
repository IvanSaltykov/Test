using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Mechanics
    {
        private int _attack;
        private int _protection;
        private int _healthMax;
        private int _health;
        private int _damageMin;
        private int _damageMax;
        public int Attack
        {
            get { return _attack; }
            set
            {
                if (value <= 20 && value >= 1)
                    _attack = value;
                if (value < 1)
                    _attack = 1;
                if (value > 20)
                    _attack = 20;
            }
        }
        protected int Protection
        {
            set
            {
                if (value <= 20 && value >= 1)
                    _protection = value;
                if (value < 1)
                    _protection = 1;
                if (value > 20)
                    _protection = 20;
            }
        }
        protected int HealthMax
        {
            get { return _healthMax; }
            set
            {
                if (value <= 0)
                    _healthMax = 100;
                else
                    _healthMax = value;
            }

        }
        public int Health
        {
            get { return _health; }
            set
            {
                if (value > 0 && value <= _healthMax)
                    _health = value;
                if (value <= 0)
                    _health = 0;
                if (value > _healthMax)
                    _health = _healthMax;
            }
        }
        protected int DamageMin 
        { 
            get { return _damageMin; }  
            set
            {
                if (value <= 0)
                    if (value >= _damageMax)
                        _damageMin = _damageMax - 2;
                    else
                        _damageMin = value;
            }
        }
        protected int DamageMax
        {
            get { return _damageMax; }
            set
            {
                if (value <= _damageMin)
                    _damageMax = _damageMin + 2;
                else
                    _damageMax = value;
            }
        }
        private int modifier(int attacking)
        {
            return attacking - _protection + 1;
        }
        private bool checkSuccessAttack(int attacking)
        {
            int attack = modifier(attacking);
            int index = 1;
            Random random = new Random();
            do
            {
                int randomNumber = random.Next(1, 6);
                if (randomNumber == 5 || randomNumber == 6)
                    return true;
                index++;
            } while (index <= attack);
            return false;
        }
        public void takingDamage(int attackOpponent, int damage)
        {
            Random random = new Random();
            if (checkSuccessAttack(attackOpponent))
                _health -= damage;
        }
        public int attackDamage()
        {
            Random random = new Random();
            return random.Next(_damageMin, _damageMax);
        }
    }
}
