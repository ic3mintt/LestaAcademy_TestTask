using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: MonoBehaviour
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
                Debug.Log($"Health = {_health}");
            } 
        }
        public event Action<float, float> OnHealthChanged;
        
        private void Start()
        {
            _health = _maxHealth;
        }
    }
}