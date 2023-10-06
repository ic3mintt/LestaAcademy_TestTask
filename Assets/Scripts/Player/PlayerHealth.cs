using System;
using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: MonoBehaviour, IChangable
    {
        [SerializeField] private float _maxHealth;
        private float _health;
        public float Health 
        { 
            get => _health;
            set
            {
                _health = value; 
                OnHealthChanged?.Invoke(_health, _maxHealth);
            } 
        }
        public event Action<float, float> OnHealthChanged;
        
        private void Start()
        {
            _health = _maxHealth;
        }

        public void Change(Vector3 xDamage)
        {
            _health -= xDamage.x;
            OnHealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}