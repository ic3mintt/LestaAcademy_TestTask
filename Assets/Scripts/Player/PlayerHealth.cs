using System;
using DefaultNamespace;
using UnityEngine;

namespace Player
{
    //if game is going to be single player, then PlayerHealth could be scriptable object
    public class PlayerHealth: MonoBehaviour, IChangable
    {
        [SerializeField] private float _maxHealth;
        
        private float _health;

        public event Action OnDie;
        public event Action<float, float> OnHealthChanged;
        
        private void OnEnable()
        {
            _health = _maxHealth;
        }

        public void Change(Vector3 xDamage)
        {
            _health -= xDamage.x;
            OnHealthChanged?.Invoke(_health, _maxHealth);
            if(_health <= 0)
                OnDie?.Invoke();
        }
    }
}