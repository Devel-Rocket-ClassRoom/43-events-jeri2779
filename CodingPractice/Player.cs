using System;

class Player
    {
        public event Action<int> DamageTaken;
    
        public int Health { get; private set; } = 100;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            DamageTaken?.Invoke(Health);
        }
    }
